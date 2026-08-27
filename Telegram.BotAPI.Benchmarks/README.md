# Benchmarks

The project measures the local cost of the library without making requests to Telegram.

Run all benchmarks from the repository root:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release
```

Run one group:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *SerializationBenchmarks*
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter *TransportBenchmarks*
```

Run the long local stress test:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress
```

The same scenarios are available as Visual Studio launch profiles:

- `Benchmarks / all` runs the interactive BenchmarkDotNet selector;
- `Benchmarks / serialization` runs JSON benchmarks;
- `Benchmarks / transport` runs local transport benchmarks;
- `Benchmarks / stress` runs the 1,000,000-call stress test;
- `Benchmarks / quick` runs a short serialization smoke test.

The benchmark project targets .NET 9 to match the current AuctionArena runtime. Results are written to `results` in this project directory and should be compared on the same machine and runtime configuration.
