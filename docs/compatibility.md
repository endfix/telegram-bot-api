# Runtime compatibility

The [README](../README.md) shows a short version of this table. This page is the
complete compatibility reference.

The package targets `net8.0` and `netstandard2.0`. NuGet selects the native
`net8.0` asset for .NET 8 and later applications. Older runtimes use the
compatible `netstandard2.0` fallback; this is a library target, not a requirement
to install a particular .NET SDK in the consuming application.

| Consumer target | Status | Guidance |
| --- | --- | --- |
| `.NET 10`, `.NET 9`, `.NET 8` | Supported via `net8.0` | Recommended targets for new applications. |
| `.NET 7`, `.NET 6` | Compatible via `netstandard2.0` | CI executes the packaged fallback on .NET 6. These runtimes are end of support and should be used only where an application is intentionally pinned to them. |
| `.NET 5`, `.NET Core 3.1` | NuGet asset compatibility only | These runtimes are not exercised or supported. Treat them as migration targets. |
| `.NET Core 2.0` through `2.2` | Compatible in principle | NuGet compatibility is possible through `netstandard2.0`, but this is not a current CI target. |
| `.NET Framework 4.7.2` through `4.8.1` | Compatible | Practical choice for maintained classic Windows applications. |
| `.NET Framework 4.6.2` through `4.7.1` | Package-dependent | May resolve the package graph, but is not a recommended baseline for new builds. |
| `.NET Framework 4.6.1` | Not a recommended baseline | Although .NET Standard compatibility tables list it, Microsoft documents compatibility issues for consuming higher .NET Standard libraries from this framework version. |

The compatibility column describes framework and NuGet asset compatibility;
it is not a claim that every listed runtime is actively tested by this
repository. The test and example projects exercise the `net8.0` asset, while
CI compiles and package-validates both library targets.

NuGet does not need a dedicated `net6.0` or `net7.0` asset to resolve this
package: applications targeting those frameworks select `netstandard2.0`.
CI executes that packaged fallback on .NET 6 as a compatibility canary; this
does not extend the support lifetime of the consuming runtime.

## Dependency footprint

.NET 8 and later consumers select the `net8.0` asset and use the
runtime-provided `System.Text.Json`. The `netstandard2.0` fallback references
`System.Text.Json 8.0.6` and its compatibility dependencies for older .NET
and .NET Framework consumers. NuGet resolves that graph automatically; an
application normally should not pin its transitive packages manually.

The package does not claim trimming or Native AOT compatibility and has no
platform-specific runtime identifier or operating-system requirement. The
consuming runtime must still support the selected .NET target and dependency
graph.
