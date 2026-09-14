# Package consumer smoke tests

This project consumes the locally packed `Endfix.Telegram.BotAPI` package rather
than a project reference. It verifies both NuGet asset-selection paths:

- `net8.0` on the host, using the runtime-provided `System.Text.Json 8`;
- `netstandard2.0` in the official .NET 6 runtime container, using the package's
  `System.Text.Json 10` dependency graph.

Each run checks the loaded library target framework, the loaded
`System.Text.Json` major version, polymorphic model deserialization, multipart
request construction, and ownership of a caller-supplied `HttpClient`. Requests
are handled in memory; no Telegram credentials or Telegram network access are
used.

From the repository root:

```bash
dotnet pack Telegram.BotAPI/Telegram.BotAPI.csproj --configuration Release --output artifacts -p:PackageVersion=0.0.0-ci
dotnet restore eng/PackageSmoke/Telegram.BotAPI.PackageSmoke.csproj --source artifacts --source https://api.nuget.org/v3/index.json
dotnet run --project eng/PackageSmoke/Telegram.BotAPI.PackageSmoke.csproj --configuration Release --framework net8.0 --no-restore -- net8.0
dotnet build eng/PackageSmoke/Telegram.BotAPI.PackageSmoke.csproj --configuration Release --framework net6.0 --no-restore
docker build --tag telegram-bot-api-package-smoke:net6 eng/PackageSmoke
docker run --rm telegram-bot-api-package-smoke:net6
```

The .NET 6 build intentionally leaves end-of-support and package-support
warnings visible. Passing the smoke run proves the tested fallback scenario; it
does not override the support policy declared by .NET or the dependency owners.
