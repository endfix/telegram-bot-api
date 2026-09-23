# Current performance results

Captured on September 24, 2026. This report compares current commit
`cfaa5ce15fde576063faf98ff4f3a7747eb6cf72` (`v1.0.0-5-gcfaa5ce`) with the
previous reference `a229efd5e953f6c60b1584ed5aa8c691db0bb757` from
September 15.

## Summary

The local no-file client path is substantially cheaper after sending
parameterized requests as `application/json` instead of always using
multipart. `sendMessage` preparation dropped from `4.63 μs / 3232 B` to
`2.42 μs / 2104 B`. The complete `RequestAndDeserialize` pipeline dropped
from `6.63 μs / 5264 B` to `4.41 μs / 4136 B`. File-id media groups fell
from `27.9 μs / 18200 B` to `10.0 μs / 3704 B`.

Serialization is stable. Nested local-file multipart remains filesystem-bound:
in-memory nested poll preparation is about `21 μs`, while the same scenario
with `File.OpenRead` is about `440 μs`.

Six independent million-call stress processes allocated exactly `4064.0 B/op`
and retained less managed memory after a full GC in every run.

## Reproducibility

| Property | Value |
| --- | --- |
| Commit | `cfaa5ce15fde576063faf98ff4f3a7747eb6cf72` |
| Version description | `v1.0.0-5-gcfaa5ce` |
| Working tree | Clean before the run |
| Full-run window | `02:19–02:45`, `Europe/Moscow` |
| OS | Windows 10 `10.0.19045.6466` |
| CPU | Intel Xeon E5-2690 v3, 12 physical / 24 logical cores |
| SDK / runtime | .NET SDK `9.0.318`, runtime `9.0.20` |
| JIT / GC | X64 RyuJIT x86-64-v3, concurrent Workstation GC |
| Library asset | Native `net8.0` |
| JSON runtime | Platform-provided `System.Text.Json` 9 |
| BenchmarkDotNet | `0.15.8`, DefaultJob, separate process |
| Power plan | High performance |
| Result | 82/82 scenarios, 25 minutes 52 seconds |

All numeric data behind this report is available in
[`benchmark-data.json`](benchmark-data.json). JSON numbers use invariant
culture; BenchmarkDotNet timings are normalized to nanoseconds.

Full-run command:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj `
  -c Release --no-launch-profile -- --filter * --join
```

Every comparison below matches rows by benchmark type, method, and parameters.

## Comparison with `a229efd`

The previous and current canonical snapshots used the same machine, runtime
`9.0.20`, native `net8.0` asset, and BenchmarkDotNet harness.

### Serialization

| Scenario | `a229efd` | `cfaa5ce` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `SerializeParameters` | 537.8 ns | 523.8 ns | −2.6% | unchanged |
| `DeserializeParameters` | 688.6 ns | 665.8 ns | −3.3% | unchanged |
| `SerializeMessage` | 3,111.3 ns | 3,072.7 ns | −1.2% | unchanged |
| `DeserializeMessage` | 1,309.6 ns | 1,199.0 ns | −8.4% | unchanged |
| `SerializeRichText` | 565.5 ns | 550.5 ns | −2.7% | unchanged |
| `DeserializeRichText` | 3,113.5 ns | 3,127.2 ns | +0.4% | unchanged |
| `SerializeRichMessage` | 4,930.7 ns | 5,227.3 ns | +6.0% | unchanged |
| `DeserializeRichMessage` | 19,760.2 ns | 19,808.6 ns | +0.2% | unchanged |
| `RichMessage Serialize(1)` | 1,319.6 ns | 1,411.9 ns | +7.0% | unchanged |
| `RichMessage Serialize(5)` | 4,110.0 ns | 4,002.7 ns | −2.6% | unchanged |
| `RichMessage Serialize(10)` | 7,142.1 ns | 7,641.6 ns | +7.0% | unchanged |
| `RichMessage Serialize(50)` | 33,411.3 ns | 34,868.6 ns | +4.4% | unchanged |

Serialization allocations match the previous snapshot. Timing moves of a few
percent on rich-message rows are consistent with DefaultJob noise on this
machine.

### Complete local client pipeline

| Scenario | `a229efd` | `cfaa5ce` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `Multipart.SendMessage` | 4.626 μs / 3232 B | 2.424 μs / 2104 B | −47.6% / −1128 B | JSON body |
| `Transport.RequestAndDeserialize` | 6.633 μs / 5264 B | 4.413 μs / 4136 B | −33.5% / −1128 B | JSON body |
| `Transport.RequestWithoutParametersAndDeserialize` | 3.278 μs / 3680 B | 3.173 μs / 3680 B | −3.2% | unchanged |
| `SendPhotoByFileId` | 3.955 μs / 3240 B | 3.534 μs / 2144 B | −10.6% / −1096 B | JSON body |
| `SendMediaGroupByFileId10` | 27.94 μs / 18200 B | 10.04 μs / 3704 B | −64.1% / −14496 B | JSON body |

The GET control path (`RequestWithoutParametersAndDeserialize`) did not change
allocations. The no-file POST rows all lost about 1.1 KB because they no longer
build `MultipartFormDataContent`.

### Multipart and file sources

| Scenario | `a229efd` | `cfaa5ce` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `SendPhotoByLocalFile` | 219.3 μs / 3768 B | 213.4 μs / 3816 B | −2.7% / +48 B | noise |
| `SendMediaGroupByLocalFile10` | 2047 μs / 28249 B | 1986 μs / 28353 B | −3.0% / +104 B | noise |
| `SendPollWithNestedLocalFiles` | 451.9 μs / 11520 B | 451.3 μs / 11624 B | −0.1% / +104 B | noise |
| `SendRichMessageWithNestedLocalFiles` | 446.9 μs / 11656 B | 454.1 μs / 11784 B | +1.6% / +128 B | noise |

The 10-part path-backed scenarios still open ten streams over the same
generated file. They measure multipart and stream multiplicity with a warm
filesystem cache, not ten distinct physical files.

Nested poll with two 64 KB files: in-memory preparation is `21.1 μs / 11008 B`;
the path-backed prepare is `440.2 μs / 11632 B`. The extra ~420 μs is
`File.OpenRead`, not reflection.

`WriteSingleFile` at 256 B is `396.2 μs` versus `OpenLocalFile` `189.2 μs`.
Path-backed uploads remain filesystem-dominated.

## Stress: 1,000,000 local `sendMessage` calls

Three sequential and three parallel (`maxParallel = 10`) processes. Every run
used concurrent Workstation GC.

| Profile | Elapsed | Allocated/op | Retained delta | Gen1 / Gen2 |
| --- | ---: | ---: | ---: | --- |
| Sequential 1 | 5.56 s | 4064.0 B | −8.3 KB | 0 / 0 |
| Sequential 2 | 5.47 s | 4064.0 B | −8.3 KB | 0 / 0 |
| Sequential 3 | 5.43 s | 4064.0 B | −8.3 KB | 0 / 0 |
| Parallel 1 | 2.07 s | 4064.0 B | −15.5 KB | 0 / 0 |
| Parallel 2 | 2.09 s | 4064.0 B | −15.5 KB | 0 / 0 |
| Parallel 3 | 2.01 s | 4064.0 B | −15.5 KB | 0 / 0 |

The previous snapshot allocated `5184.0 B/op`. The new figure matches
BenchmarkDotNet `RequestAndDeserialize` minus per-op noise: JSON `sendMessage`
no longer builds multipart. Retained managed memory after a full GC still
decreases. Sequential wall time fell from about `7.5 s` to about `5.5 s`.

Working Set still grows (sequential `44 → 60 MB`, parallel `58 → 64 MB`)
because the process starts from a smaller footprint and then pays for JIT,
ThreadPool, and runtime caches. That is the same pattern as September 15.

## What these results do not prove

- They do not measure Telegram, network, TLS, rate limits, or data-center latency.
- `Stream.Null` does not model real data transmission.
- They do not compare different machines, GC modes, or runtime patches.
- A small timing delta without a focused repeat is not a proven regression.

## Review conclusion

Current commit `cfaa5ce` is the performance snapshot for the 1.0 line:

1. No-file parameterized requests are JSON; that is a real local CPU and
   allocation win, not DefaultJob noise.
2. Serialization allocations are unchanged; timings are within usual scatter.
3. Path-backed multipart is stable and still dominated by opening files.
4. Stress shows no retained-memory growth and a lower per-operation allocation.

The canonical run, row-by-row comparison with `a229efd`, and six stress runs
are available in [`benchmark-data.json`](benchmark-data.json). Raw
BenchmarkDotNet exports and complete console logs are temporary run artifacts
and are not stored in the repository.
