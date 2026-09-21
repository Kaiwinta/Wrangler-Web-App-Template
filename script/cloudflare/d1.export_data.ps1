param(
  [switch]$remote
)

$timestamp = Get-Date -Format "MM_dd_yyyy_HH_mm_ss"

if ($remote) {
  New-Item -ItemType Directory -Force -Path sql/backup/remote | Out-Null
  wrangler d1 export lore-db --output=sql/backup/remote/backup_$timestamp.sql --remote
} else {
  New-Item -ItemType Directory -Force -Path sql/backup/local | Out-Null
  wrangler d1 export lore-db --output=sql/backup/local/backup_$timestamp.sql --local
}