param(
  [switch]$remote
)

$base = ".\PROJECTNAME\wwwroot\content\stories"
$datas = Get-ChildItem -Recurse -Filter "data.json" -Path $base

$total = $datas.Count
$current = 0
$batchSize = 10
$SQLINSERT = "INSERT INTO Story (slug, name, additional_information, image_url, image_r2_url, external_url, story) VALUES "
$rows = @()
$tmpFile = [System.IO.Path]::GetTempFileName() + ".sql"

foreach ($data in $datas) {
    $current++
    
    $relativePath = $data.FullName.Substring((Resolve-Path $base).Path.Length + 1)
    $slug = $relativePath.Replace("\", "/").Replace("/data.json", "")

    Write-Host "[$current/$total] Processing $relativePath..."

    $jsonContent = Get-Content -Raw -Path $data.FullName | ConvertFrom-Json
    $additional_information = '{"Region": "' + $jsonContent.Region + '"}'

    $slug         = $slug                     -replace "'", "''"
    $name         = $jsonContent.Name         -replace "'", "''"
    $add_info     = $additional_information   -replace "'", "''"
    $image_url    = $jsonContent.ImageUrl     -replace "'", "''"
    $image_r2_url = $jsonContent.r2_url       -replace "'", "''"
    $external_url = $jsonContent.ChampionUrl  -replace "'", "''"
    $story        = $jsonContent.Lore         -replace "'", "''"

    $rows += "('$slug', '$name', '$add_info', '$image_url', '$image_r2_url', '$external_url', '$story')"

    if ($current % $batchSize -eq 0 -or $current -eq $total) {
        $SQL = $SQLINSERT + ($rows -join ",") + ";"

        # Write to temp file instead of passing as argument
        Set-Content -Path $tmpFile -Value $SQL -Encoding UTF8

        if ($remote) {
            wrangler d1 execute lore-db --file "$tmpFile" --remote -y
        } else {
            wrangler d1 execute lore-db --file "$tmpFile" --local -y
        }

        $rows = @()
    }
}

# Cleanup
Remove-Item -Path $tmpFile -ErrorAction SilentlyContinue

Write-Host "Done! $total json files updated."