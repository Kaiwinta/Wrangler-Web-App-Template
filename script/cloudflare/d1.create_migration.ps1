param(
  [string]$migration_name
)

if ([string]::IsNullOrWhiteSpace($migration_name)) {
  Write-Host "Usage: .\db.2create_migration.ps1 <migration_name>"
  exit 1
}

wrangler d1 migrations create lore-db $migration_name
