param(
  [string]$file_path,
  [switch]$remote
)

if ([string]::IsNullOrWhiteSpace($file_path)) {
  Write-Host "Usage: .\d1.launch_sql.ps1 <file_path>"
  exit 1
}

if ($remote) {
  wrangler d1 execute --file $file_path lore-db --remote
} else {
  wrangler d1 execute --file $file_path lore-db
}