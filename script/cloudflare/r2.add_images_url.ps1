# upload_images.ps1
$base = ".\PROJECTNAME\wwwroot\content\stories"
$datas = Get-ChildItem -Recurse -Filter "data.json" -Path $base

$total = $datas.Count
$current = 0
$publicR2Path = "https://pub-af7e786a29084fefaa6d23620283d158.r2.dev/"

foreach ($data in $datas) {
    $current++
    
    # Construit la clé R2 : ex. League_Lore/Anivia/data.json
    $relativePath = $data.FullName.Substring((Resolve-Path $base).Path.Length + 1)
    $imageKey = $relativePath.Replace("data.json", "image.png").Replace("\", "/")

    $publicUrl = "$publicR2Path$imageKey"

    write-Host "[$current/$total] Processing $imageKey..."
    # Adding an "r2_url" property to the JSON content
    $jsonContent = Get-Content -Raw -Path $data.FullName | ConvertFrom-Json
    $jsonContent | Add-Member -NotePropertyName r2_url -NotePropertyValue $publicUrl -Force
    $updatedJson = $jsonContent | ConvertTo-Json -Depth 10
    # Save the updated JSON back to the file
    $updatedJson | Set-Content -Path $data.FullName
}

Write-Host "Done! $total json files updated."