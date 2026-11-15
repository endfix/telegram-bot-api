# Development

This guide is for repository contributors. Installing and using the package is
covered in the [README](../README.md).

## SDK requirements

Repository builds are pinned to .NET SDK `9.0.317` through `global.json`. The
complete solution also runs `net8.0` tests and examples, so install the .NET 8
SDK or runtime alongside SDK 9 when working locally. CI installs both SDK
versions explicitly.

## Tests

Run the solution tests. Live integration tests are skipped when their secrets
are not configured:

```bash
dotnet test Telegram.BotAPI.sln
```

Run local tests without contacting Telegram:

```bash
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "Category!=Integration"
```

Telegram integration tests can send real messages and are intended for a
dedicated test bot and chat. The [test project guide](../Telegram.BotAPI.Tests/README.md)
covers the live topology, BotFather settings, administrator rights, secrets, and
rollback behavior.

## Package smoke tests

CI installs the locally packed NuGet package into two small consumer
applications: one executes the native `net8.0` asset on .NET 8, and the other
executes the `netstandard2.0` fallback in a .NET 6 Docker container. These smoke
tests use an in-memory HTTP handler and require neither a bot token nor network
access to Telegram. See the [package smoke guide](../eng/PackageSmoke/README.md)
for the exact checks and local commands.

## README validation

`README.md` ships inside the package, so CI runs
[`scripts/check-readme.ps1`](../scripts/check-readme.ps1). It rejects raw HTML
and repository-relative links, because nuget.org escapes the former and cannot
resolve the latter.

## Benchmarks

The [benchmark project](../Telegram.BotAPI.Benchmarks/README.md) contains
serialization, rich-message and local transport benchmarks, plus sequential and
bounded-parallel stress profiles:

```bash
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --filter * --join
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress-parallel 10
```

The current reference snapshot was recorded on November 12, 2026 at commit
`c61abe2` on .NET 9.0.23, Windows 10 x64, and an Intel Xeon E5-2690 v3. The
benchmarks use local transports and exclude Telegram and network latency.

| Scenario | Mean | Allocated |
| --- | ---: | ---: |
| Serialize parameters | 535.7 ns | 264 B |
| Request and deserialize | 3.378 us | 3,760 B |
| Send scalar message | 1.807 us | 1,704 B |

The complete environment, all 84 measurements, historical `2.0.0` comparisons,
and million-call stress profiles are in the
[latest benchmark report](../Telegram.BotAPI.Benchmarks/RESULTS.md), with
normalized measurements in
[`benchmark-data.json`](../Telegram.BotAPI.Benchmarks/benchmark-data.json).

## API documentation source

Descriptions of Telegram objects, fields and method parameters are aligned with
the [official Bot API documentation](https://core.telegram.org/bots/api). The
current repository snapshot targets Bot API `10.4` (published November 9, 2026).
Telegram may clarify or extend descriptions without changing a .NET type, so
the source version and date should be reviewed when updating XML documentation.
Library-specific behavior, such as stream ownership, retryability and polling
semantics, is documented locally and is not copied from Telegram's object
descriptions.

## Releases

Push the intended release commit to `main` and wait for CI to pass before
creating a `vX.Y.Z` tag. Pushing the tag starts the publish workflow, which
independently restores, builds, tests, packs with the version derived from the
tag, publishes the package to NuGet, and creates the corresponding GitHub
Release from that version's [CHANGELOG](../CHANGELOG.md) section.
