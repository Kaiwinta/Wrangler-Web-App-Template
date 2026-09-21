param(
  [switch]$remote
)

if ($remote) {
  wrangler d1 migrations apply lore-db --remote
} else {
  wrangler d1 migrations apply lore-db --local
}