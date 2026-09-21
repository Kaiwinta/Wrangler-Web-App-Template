# upload_images.ps1
$base = ".\PROJECTNAME\wwwroot\content\stories"
$images = Get-ChildItem -Recurse -Filter "image.png" -Path $base

$total = $images.Count
$current = 0

foreach ($img in $images) {
    $current++
    
    # Construit la clé R2 : ex. League_Lore/Anivia/image.png
    $relativePath = $img.FullName.Substring((Resolve-Path $base).Path.Length + 1)
    $key = $relativePath.Replace("\", "/")
    
    Write-Host "[$current/$total] Uploading $key..."
    npx wrangler r2 object put "lore-images/$key" --file=$img --remote
}

Write-Host "Done! $total images uploaded."