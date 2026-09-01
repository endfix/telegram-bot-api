# Benchmarks

The project measures the local cost of the library without making requests to Telegram.

Run all benchmarks from the repository root:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release
```

Run one group:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *SerializationBenchmarks*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *Rich*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *TransportBenchmarks*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *MultipartBenchmarks*
```

The multipart group compares scalar fields, top-level file sources, media groups
at Telegram's practical 10-item size, and deeply nested poll/rich media. Its fake
HTTP handler does not read the request body, so the results isolate multipart object
construction, JSON preparation, nested-file traversal, and local file opening rather
than network transfer.

Run the long local stress test:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress-parallel 10
```

The stress test reports elapsed and CPU time, retained managed memory after a full GC,
Working Set, and GC collection counts across 1,000,000 complete local client calls. It
is intended to reveal throughput or long-running memory-retention problems. It does not
measure total managed allocations: use `Benchmarks / transport` and its BenchmarkDotNet
`Allocated` result for allocations per operation.

The same scenarios are available as Visual Studio launch profiles:

- `Benchmarks / all` runs the interactive BenchmarkDotNet selector;
- `Benchmarks / serialization` runs JSON benchmarks;
- `Benchmarks / transport` runs local transport benchmarks;
- `Benchmarks / multipart` compares flat and nested multipart request preparation;
- `Benchmarks / stress` runs the 1,000,000-call stress test;
- `Benchmarks / stress parallel` runs the same test with 10 bounded workers;
- `Benchmarks / quick` runs a short serialization smoke test.

The benchmark project targets .NET 9. Results are written to `results` in this project directory and should be compared on the same machine and runtime configuration.
