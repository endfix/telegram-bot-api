#!/usr/bin/env bash
set -euo pipefail

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
timestamp="$(date -u +%Y%m%dT%H%M%SZ)"
report_dir="${repo_root}/artifacts/arm-stress/${timestamp}"
mkdir -p "${report_dir}"

skip_build=0
skip_tests=0
binary=""

while [[ $# -gt 0 ]]; do
  case "$1" in
    --skip-build)
      skip_build=1
      shift
      ;;
    --skip-tests)
      skip_tests=1
      shift
      ;;
    --binary)
      binary="${2:-}"
      if [[ -z "${binary}" ]]; then
        echo "usage: $0 [--skip-build] [--skip-tests] [--binary <path>]" >&2
        exit 1
      fi
      shift 2
      ;;
    -h|--help)
      echo "usage: $0 [--skip-build] [--skip-tests] [--binary <path>]"
      exit 0
      ;;
    *)
      echo "unknown argument: $1" >&2
      exit 1
      ;;
  esac
done

if [[ -n "${binary}" ]]; then
  skip_build=1
  skip_tests=1
fi

exec > >(tee "${report_dir}/run.log") 2>&1

log_host() {
  echo "===== host $(date -u +%H:%M:%SZ) ====="
  echo "Host: $(uname -a)"
  if [[ -r /proc/device-tree/model ]]; then
    echo "Model: $(tr -d '\0' </proc/device-tree/model)"
  fi
  if [[ -r /sys/devices/system/cpu/cpu0/cpufreq/scaling_governor ]]; then
    echo "Governor: $(cat /sys/devices/system/cpu/cpu0/cpufreq/scaling_governor)"
  fi
  echo "Memory:"
  free -h
  awk '/MemTotal|MemAvailable|SwapTotal|SwapFree/ { print }' /proc/meminfo
}

log_thermal() {
  echo "===== thermal $(date -u +%H:%M:%SZ) ====="
  if command -v vcgencmd >/dev/null 2>&1; then
    echo "Temp: $(vcgencmd measure_temp)"
    echo "Freq: $(vcgencmd measure_clock arm)"
    throttled="$(vcgencmd get_throttled)"
    echo "Throttled: ${throttled}"
    if [[ "${throttled}" != *"=0x0" ]]; then
      echo "WARNING: get_throttled is not 0x0; ARM timings may be limited by power or temperature."
    fi
  else
    echo "vcgencmd is not available."
  fi
}

run_stress() {
  local workers="$1"
  echo
  echo "===== stress-parallel ${workers} $(date -u +%H:%M:%SZ) ====="
  log_thermal
  if [[ -n "${binary}" ]]; then
    if [[ "${workers}" == "1" ]]; then
      "${binary}" --stress
    else
      "${binary}" --stress-parallel "${workers}"
    fi
  elif [[ "${workers}" == "1" ]]; then
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
  log_thermal
}

echo "ARM stress run: ${timestamp}"
log_host
echo
if command -v dotnet >/dev/null 2>&1; then
  dotnet --info
else
  echo "dotnet SDK is not on PATH (expected when using --binary)."
fi

cd "${repo_root}"

if [[ "${skip_build}" -eq 0 ]]; then
  echo "===== restore/build $(date -u +%H:%M:%SZ) ====="
  dotnet restore Telegram.BotAPI.sln
  dotnet build Telegram.BotAPI.sln --configuration Release --no-restore
  dotnet build Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj --configuration Release --no-restore
fi

if [[ "${skip_tests}" -eq 0 ]]; then
  echo "===== tests $(date -u +%H:%M:%SZ) ====="
  dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj \
    --configuration Release \
    --no-build \
    --filter "Category!=Integration"
fi

for workers in 1 2 4 10; do
  run_stress "${workers}"
done

echo
echo "Report: ${report_dir}/run.log"
