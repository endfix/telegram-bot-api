#!/usr/bin/env bash
set -euo pipefail

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
timestamp="$(date -u +%Y%m%dT%H%M%SZ)"
report_dir="${repo_root}/artifacts/arm-stress/${timestamp}"
mkdir -p "${report_dir}"

exec > >(tee "${report_dir}/run.log") 2>&1

echo "ARM stress run: ${timestamp}"
echo "Host: $(uname -a)"
echo
dotnet --info

cd "${repo_root}"

dotnet restore Telegram.BotAPI.sln
dotnet build Telegram.BotAPI.sln --configuration Release --no-restore
dotnet build Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj --configuration Release --no-restore

dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj \
  --configuration Release \
  --no-build \
  --filter "Category!=Integration"

for workers in 1 2 4 10; do
  echo
  echo "===== stress-parallel ${workers} ====="
  if [[ "${workers}" == "1" ]]; then
    dotnet run \
      --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj \
      --configuration Release \
      --no-build \
      -- --stress
  else
    dotnet run \
      --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj \
      --configuration Release \
      --no-build \
      -- --stress-parallel "${workers}"
  fi
done

echo
echo "Report: ${report_dir}/run.log"
