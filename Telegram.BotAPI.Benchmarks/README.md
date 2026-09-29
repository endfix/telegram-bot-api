# Benchmarks

The project measures the local cost of the library without making requests to Telegram.

Run all benchmarks from the repository root:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter * --join
```

BenchmarkDotNet writes its raw Markdown, CSV, and HTML artifacts to the ignored
`results` directory. When a run is accepted as the new reference, its findings
are summarized in `RESULTS.md` and its normalized measurements replace
`benchmark-data.json`.

Run one group:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *SerializationBenchmarks*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *Rich*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *TransportBenchmarks*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *MultipartBenchmarks*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *MultipartDiagnostic*
```

The multipart group compares a no-file `sendMessage` (JSON body), top-level file
sources, media groups at Telegram's practical 10-item size, and deeply nested
poll/rich media. Its fake HTTP handler does not read the request body, so the
results isolate request construction, nested-file traversal, and local file
opening rather than network transfer.

The multipart diagnostic group separates local-file opening, direct multipart
writing from `FileStream` and preloaded `MemoryStream` sources, client-side
request preparation without consuming the body, and complete multipart writes
to `Stream.Null`. The complete client pipeline compares local paths with
`InputFileSource.FromMemory`. It covers 1 part, 10 parts, two nested files, and
payload sizes of 256 B, 64 KB, and 1 MB. The 10-part path-backed scenarios open
ten independent streams over the same generated file. They measure multipart
and stream multiplicity with a warm filesystem cache, not ten distinct files or
cold-file I/O. The memory-stream case starts from an already loaded byte array,
so it measures stream and multipart overhead rather than loading the payload
into memory.

Run the long local stress test:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress-parallel 10
```

The stress test warms up the same concurrency shape that it measures, then reports
elapsed and CPU time, total managed allocations, retained managed memory after a full
GC, Working Set, GC mode, and collection counts across 1,000,000 complete local client
calls. It is intended to reveal throughput or long-running memory-retention problems.
Use `Benchmarks / transport` and its BenchmarkDotNet `Allocated` result when precise
per-operation allocation statistics and distributions are required.

For comparisons, run each stress profile in at least three separate processes. A single
stress timing is directional rather than benchmark-grade, and sequential and parallel
results must use the same library asset, runtime patch, machine, and GC configuration.

The same scenarios are available as Visual Studio launch profiles:

- `Benchmarks / all` runs the interactive BenchmarkDotNet selector;
- `Benchmarks / serialization` runs JSON benchmarks;
- `Benchmarks / transport` runs local transport benchmarks;
- `Benchmarks / multipart` compares flat and nested multipart request preparation;
- `Benchmarks / multipart diagnostics` separates filesystem, preparation, and body-write costs;
- `Benchmarks / stress` runs the 1,000,000-call stress test;
- `Benchmarks / stress parallel` runs the same test with 10 bounded workers;
- `Benchmarks / quick` runs a short serialization smoke test.

The benchmark project targets .NET 9. Temporary results are written to `results`
in this project directory and should be compared on the same machine and runtime
configuration. The curated report identifies the tested commit and environment;
it is a reference point rather than a cross-machine performance guarantee.

## Latest results

The repository keeps one curated [human-readable report](RESULTS.md) and one
[normalized data file](benchmark-data.json). They are replaced when a new
canonical snapshot is accepted; previous versions remain available through Git
history and release tags. Raw BenchmarkDotNet exports and stress logs are build
artifacts rather than repository snapshots.

The `Generate benchmark snapshot` GitHub Actions workflow can be started
manually. It runs the complete joined benchmark set and optionally the
sequential and 10-worker stress profiles in three independent processes each.
The downloadable artifact contains:

- `README.md` with the library version, commit description and counts, run
  dates, test-machine configuration, and the full BenchmarkDotNet table;
- `results.csv` for machine-readable comparisons;
- stress output logs when stress profiles are enabled.

Use `windows-latest` for an independently reproducible snapshot whose exact
runner hardware is recorded. Use a stable `self-hosted` runner when comparing
results over time, because GitHub-hosted hardware may change between runs.

## ARM stress run

These results compare runtime behavior, retained memory and GC activity on a
Linux ARM device. They must not be mixed into the x64 canonical table in
`RESULTS.md` and must not be presented as Telegram throughput: the stress
transport is local and contains no network or API rate-limit effects.

On a device with 2 GB RAM, publish a self-contained `linux-arm64` build on a
desktop and copy it to the board instead of restoring and compiling on the
device. A minimal Armbian image may also need `libicu` (`libicu78` on Ubuntu
26.04) before the host process starts.

```powershell
dotnet publish Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj `
  -c Release -r linux-arm64 --self-contained -o .\artifacts\pi-stress
```

```bash
./Telegram.BotAPI.Benchmarks --stress
./Telegram.BotAPI.Benchmarks --stress-parallel 4
```

On a board with enough RAM to build, the repository script from the project
root records host, governor, memory/swap and thermal bits (`vcgencmd` on a Pi,
sysfs `cpu-thermal` and `cpufreq` otherwise), builds the solution, runs the
non-integration tests, and executes the one-million-call stress test with 1, 2,
4 and 10 workers. `get_throttled` other than `0x0` means the Pi run was power-
or temperature-limited. Output is stored under
`artifacts/arm-stress/<timestamp>/run.log`.

```bash
bash scripts/run-arm-stress.sh
bash scripts/run-arm-stress.sh --skip-build --skip-tests
bash scripts/run-arm-stress.sh --binary ~/telegram-stress/Telegram.BotAPI.Benchmarks
```

### Snapshot: Raspberry Pi 4 Model B, 24 September 2026

| Property | Value |
| --- | --- |
| Board | Raspberry Pi 4 Model B Rev 1.1 |
| CPU | 4 × ARM Cortex-A72, 600–1500 MHz, 128 KiB L1d + 192 KiB L1i + 1 MiB L2 |
| RAM | 1.8 GiB usable (2 GB SKU), 1.8 GiB swap unused |
| Storage | microSD `/dev/mmcblk0p2`, 15 GB ext4 |
| OS | Debian GNU/Linux 13 (trixie), kernel `6.18.50+rpt-rpi-v8` aarch64 |
| Runtime | TFM `net9.0`, self-contained runtime **9.0.20**, Arm64 RyuJIT armv8.0-a |
| GC | concurrent Workstation |
| Cooling | No heatsink on the SoC; a 5 V fan above the board only |
| Governor | `ondemand` |
| Thermal | 41–51 °C during the worker sweep, `vcgencmd get_throttled=0x0`, ARM clock ~1500 MHz |
| Harness | BenchmarkDotNet 0.15.8 host banner; stress runner `--stress` |

One million local `sendMessage` calls:

| Profile | Elapsed | Average | Allocated/op | Retained | Gen1 / Gen2 |
| --- | ---: | ---: | ---: | ---: | --- |
| Sequential | 29.68 s | 29.68 µs/op | 4064.0 B | +0.9 KB | 2 / 0 |
| Parallel 4 | 12.67 s | 12.67 µs/op | 4064.0 B | +0.2 KB | 1 / 0 |
| Parallel 10 | 13.38 s | 13.38 µs/op | 4064.1 B | +18.0 KB | 1 / 0 |

Allocated bytes per operation match the x64 workstation snapshot (`4064.0 B`),
which used the same runtime patch `9.0.20`. The project TFM is `net9.0`;
`9.0.x` patches can still change JIT and GC, so later ARM runs should record
the exact runtime version. Wall time is slower, as expected on Cortex-A72.
Ten workers on four cores is intentional oversubscription: Parallel 10 is
5.6% slower than Parallel 4, with the same allocated bytes per operation and
about 18 KB more retained memory. That is CPU oversubscription, not a
scalability win. Retained managed memory after a full GC stays near zero;
there is no Gen2 collection.

### Snapshot: Invin KM6 (Amlogic S905W), 29 September 2026

| Property | Value |
| --- | --- |
| Board | Invin KM6, device-tree `Amlogic Meson GXL (S905W) P281 Development Board` (`amlogic,p281` / `amlogic,s905w`) |
| CPU | 4 × ARM Cortex-A53, 100–1200 MHz, 128 KiB L1d + 128 KiB L1i + 512 KiB L2 |
| RAM | 1.8 GiB usable, 896 MiB zram swap unused |
| Storage | microSD `/dev/mmcblk1p2` (USDU1, 14.9 GB) is Armbian root; onboard eMMC `/dev/mmcblk2` (M8G1GC, 7.3 GB) still holds factory Android and stayed unmounted |
| OS | Armbian OS 26.11.0 resolute (Ubuntu 26.04), kernel `6.12.107-ophub` aarch64 |
| Runtime | TFM `net9.0`, self-contained runtime **9.0.20**, Arm64 RyuJIT armv8.0-a |
| GC | concurrent Workstation |
| Cooling | Passive heatsink on the SoC; no fan |
| Governor | `schedutil` |
| Thermal | `cpu-thermal` 48–55 °C during the worker sweep, ARM clock 1000 MHz throughout (max 1200 MHz) |
| Harness | BenchmarkDotNet 0.15.8 host banner; stress runner `--stress` |

One million local `sendMessage` calls:

| Profile | Elapsed | Average | Allocated/op | Retained | Gen1 / Gen2 |
| --- | ---: | ---: | ---: | ---: | --- |
| Sequential | 62.40 s | 62.40 µs/op | 4064.0 B | -3.0 KB | 6 / 0 |
| Parallel 4 | 31.94 s | 31.94 µs/op | 4064.0 B | -9.8 KB | 3 / 0 |
| Parallel 10 | 40.59 s | 40.59 µs/op | 4064.1 B | +27.6 KB | 4 / 0 |

Allocated bytes per operation match the Pi and x64 snapshots (`4064.0 B`) on
runtime patch `9.0.20`. Wall time is slower than the Cortex-A72 Pi, as
expected on Cortex-A53 at 1000 MHz. Ten workers on four cores is again
oversubscription: Parallel 10 is 27% slower than Parallel 4, with the same
allocated bytes per operation and +27.6 KB retained memory. There is no Gen2
collection. The measured path is in-process local HTTP; after warm-up the
working set stayed in RAM and zram swap stayed unused, so the SD-card root is
the boot and install surface. These numbers stay in this ARM section; they
are not mixed into `RESULTS.md`.
