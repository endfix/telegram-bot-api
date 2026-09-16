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

For a repeatable local-runtime check on a Linux ARM device, run the repository
script from the project root:

```bash
bash scripts/run-arm-stress.sh
```

The script records the host and .NET runtime information, builds the solution,
runs the non-integration tests, and executes the one-million-call stress test
with 1, 2, 4 and 10 workers. The complete output is stored under
`artifacts/arm-stress/<timestamp>/run.log`.

These results compare runtime behavior, retained memory and GC activity on the
ARM device. They must not be presented as Telegram throughput: the stress
transport is local and deliberately contains no network or API rate-limit
effects.
