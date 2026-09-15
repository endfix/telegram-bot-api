# Current performance results

Captured on September 15, 2026. This report compares current commit
`a229efd5e953f6c60b1584ed5aa8c691db0bb757` with previous reference commit
`5f58e9ac490ba0270ddc1ec1304f1b6ef10118f3`.

## Summary

**No release-blocking regression was found.** The complete BenchmarkDotNet run
finished all 82 scenarios. Managed allocations remained unchanged in nearly
every row. Differences of −3 to +9 bytes per operation in file-stream
benchmarks are measurement noise.

Serialization is stable or slightly faster overall. Two complete client
pipeline scenarios produced directional slowdowns, but focused repeats reduced
their magnitude substantially. They should be monitored in future snapshots,
but the current evidence does not establish a user-visible regression.

Six independent million-call stress processes found no accumulating retained
memory. Every run reported exactly `5184.0 B/op`, and retained managed memory
after a full GC decreased in all six runs.

## Reproducibility

| Property | Value |
| --- | --- |
| Commit | `a229efd5e953f6c60b1584ed5aa8c691db0bb757` |
| Version description | `v0.5.0-16-ga229efd` |
| Working tree | Clean before the run |
| Full-run window | `05:49–06:11`, `Europe/Moscow` |
| OS | Windows 10 `10.0.19045.6466` |
| CPU | Intel Xeon E5-2690 v3, 12 physical / 24 logical cores |
| SDK / runtime | .NET SDK `9.0.318`, runtime `9.0.20` |
| JIT / GC | X64 RyuJIT x86-64-v3, concurrent Workstation GC |
| Library asset | Native `net8.0` |
| JSON runtime | Platform-provided `System.Text.Json` 9 |
| BenchmarkDotNet | `0.15.8`, DefaultJob, separate process |
| Power plan | High performance |
| Result | 82/82 scenarios, 22 minutes 15 seconds |

All numeric data behind this report is available in
[`benchmark-data.json`](benchmark-data.json): the canonical run, row-by-row
comparison with the baseline, focused repeat, and six stress runs. JSON numbers
use invariant culture; BenchmarkDotNet timings are normalized to nanoseconds.

Full-run command:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj `
  -c Release --no-restore --no-build -- --filter "*" --join
```

Every comparison below matches rows by benchmark type, method, and parameters.
`Ratio` values are not interpreted across different benchmark classes.

## Comparison with `5f58e9a`

The previous and current canonical snapshots used the same machine, runtime
`9.0.20`, native `net8.0` asset, and BenchmarkDotNet harness. This is a much
cleaner comparison than the September 7 and September 15 snapshots, which used
different JSON runtimes.

### Serialization

| Scenario | `5f58e9a` | `a229efd` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `SerializeParameters` | 535.0 ns | 537.8 ns | +0.5% | unchanged |
| `DeserializeParameters` | 677.5 ns | 688.6 ns | +1.6% | unchanged |
| `SerializeMessage` | 2,986.3 ns | 3,111.3 ns | +4.2% | unchanged |
| `DeserializeMessage` | 1,187.7 ns | 1,309.6 ns | +10.3% | unchanged |
| `SerializeRichText` | 561.8 ns | 565.5 ns | +0.7% | unchanged |
| `DeserializeRichText` | 3,093.5 ns | 3,113.5 ns | +0.6% | unchanged |
| `SerializeRichMessage` | 5,143.9 ns | 4,930.7 ns | −4.1% | unchanged |
| `DeserializeRichMessage` | 20,229.4 ns | 19,760.2 ns | −2.3% | unchanged |
| `RichMessage Serialize(1)` | 1,362.2 ns | 1,319.6 ns | −3.1% | unchanged |
| `RichMessage Serialize(5)` | 4,235.6 ns | 4,110.0 ns | −3.0% | unchanged |
| `RichMessage Serialize(10)` | 7,692.4 ns | 7,142.1 ns | −7.2% | unchanged |
| `RichMessage Serialize(50)` | 35,352.3 ns | 33,411.3 ns | −5.5% | unchanged |

`DeserializeMessage` was repeated separately and produced `1.204 μs`, only
`+1.4%` above the previous snapshot. The full-run `+10.3%` result did not
reproduce and is classified as noise from the long joined run.

### Complete local client pipeline

| Scenario | `5f58e9a` | Full run | Focused repeat | Conclusion |
| --- | ---: | ---: | ---: | --- |
| `Multipart.SendMessage` | 3.873 μs | 4.626 μs (+19.4%) | 4.071 μs (+5.1%) | directional; original magnitude did not reproduce |
| `Transport.RequestAndDeserialize` | 5.752 μs | 6.633 μs (+15.3%) | 6.217 μs (+8.1%) | directional; monitor |
| `Transport.RequestWithoutParametersAndDeserialize` | 3.305 μs | 3.278 μs (−0.8%) | not repeated | stable |

Allocations in all three rows exactly match the previous snapshot. The focused
repeat does not justify calling the remaining two changes improvements, but it
shows that the result is sensitive to benchmark order and the state of a long
run. This is an observation rather than a proven library-code regression.

### Multipart and file sources

The 10-part path-backed scenarios create ten independent `FileStream`
instances, but every stream opens the same generated path. `MediaGroup10` uses
the same arrangement. These rows therefore measure multipart pipeline and
stream multiplicity with a warm filesystem cache, not ten distinct physical
files or cold-file I/O. This is a methodological boundary, not a measurement
error.

The principal path-backed scenarios are stable:

| Scenario | Change |
| --- | ---: |
| `SendPhotoByLocalFile` | +1.1% |
| `SendMediaGroupByLocalFile10` | +3.3% |
| `SendPollWithNestedLocalFiles` | +2.6% |
| `SendRichMessageWithNestedLocalFiles` | +2.2% |
| `WriteSingleFile`, 256 B | +1.7% |
| `WriteSingleFile`, 1 MiB | +0.9% |
| `OpenLocalFile` | approximately +2.3% |

This does not confirm the previously observed 4–7% `WriteSingleFile` slowdown.
The new snapshot is closer to the previous result.

Some memory-backed rows differed by 8–17% in the complete run, but the focused
repeat returned `WritePreloadedMemoryStreams` to its previous range:

| Payload / parts | `5f58e9a` | Full run | Focused repeat |
| --- | ---: | ---: | ---: |
| 256 B / 1 | 1.611 μs | 1.790 μs | 1.469 μs |
| 64 KiB / 1 | 1.526 μs | 1.784 μs | 1.516 μs |
| 1 MiB / 1 | 1.528 μs | 1.529 μs | 1.519 μs |
| 256 B / 10 | 9.864 μs | 8.907 μs | 9.273 μs |
| 64 KiB / 10 | 9.500 μs | 9.354 μs | 9.390 μs |
| 1 MiB / 10 | 9.351 μs | 9.434 μs | 9.402 μs |

In the focused repeat, the two 256 B combinations improved by `8.8%` and
`6.0%`; the other four differed by no more than `±1.2%`. Allocations did not
change, so the complete-run outliers are not a performance regression.

#### What the multipart diagnostics measure

- `OpenLocalFile` measures only opening a path-backed file.
- `Prepare*` constructs the request, but the fake handler does not consume its body.
- `Write*` additionally copies the multipart body to `Stream.Null`.
- `FromMemory` starts with an array created in `GlobalSetup`.

The approximately `×47` ratio between `PrepareSingleMemoryFile` and
`PrepareSingleFile` therefore describes only the difference between preparing
a request from an already loaded memory source and opening a path-backed
source. It does **not** mean that a real Telegram upload will be 47 times
faster. Neither the cost of loading the file into memory nor the network is
included in this ratio.

`Stream.Null` also does not model network backpressure: `MemoryStream` can copy
its complete buffer in one operation, while a real network must still transmit
every byte.

The practical guidance remains straightforward:

- use `FromMemory` when the payload is already in memory or will be sent repeatedly;
- do not preload a one-off file merely to reproduce a benchmark result;
- use a path or stream factory for large files and controlled reopening during retries.

## Million-call stress

Each result was produced in a separate process after warming up the same
concurrency shape that it measured.

| Profile | Run | Elapsed | Throughput | Allocated/op | Retained delta | Working-set delta | GC 0/1/2 |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| Sequential | 1 | 7.844 s | 127,478 op/s | 5,184.0 B | −8.3 KB | +14.9 MB | 330/0/0 |
| Sequential | 2 | 7.325 s | 136,519 op/s | 5,184.0 B | −8.3 KB | +14.6 MB | 330/0/0 |
| Sequential | 3 | 7.555 s | 132,363 op/s | 5,184.0 B | −16.3 KB | +14.8 MB | 330/0/0 |
| Parallel 10 | 1 | 2.423 s | 412,683 op/s | 5,184.0 B | −15.5 KB | +7.6 MB | 348/0/0 |
| Parallel 10 | 2 | 2.532 s | 395,021 op/s | 5,184.0 B | −15.5 KB | +6.0 MB | 348/0/0 |
| Parallel 10 | 3 | 2.400 s | 416,741 op/s | 5,184.0 B | −15.5 KB | +6.6 MB | 348/0/0 |

Aggregates across the three independent processes:

| Profile | Mean elapsed | Min–max | Sample StdDev | CV | Mean throughput |
| --- | ---: | ---: | ---: | ---: | ---: |
| Sequential | 7.575 s | 7.325–7.844 s | 0.260 s | 3.4% | 132,120 op/s |
| Parallel 10 | 2.451 s | 2.400–2.532 s | 0.070 s | 2.9% | 408,148 op/s |

With `n=3`, StdDev and CV describe only the spread of these runs; they are not
precise estimates of the underlying distribution. Sequential runs themselves
vary by approximately 3.4%, so small differences in parallel throughput within
a few percent are ordinary variability on this machine.

These results confirm that the earlier `+204.4 KB retained` result was an
artifact of the old stress harness. After concurrency-aware warm-up and
measurement in independent processes, retained delta does not grow; it is
negative in all six runs. Allocations per operation are deterministic, with no
Gen1 or Gen2 collections.

Working Set is not a managed-memory leak metric. Its fixed 6–15 MB increase
includes JIT code, runtime structures, thread stacks, and reserved process
pages.

The smaller working-set delta in the parallel profile does not mean parallel
execution uses less memory. Measurement begins **after** warming up the same
concurrency shape. Sequential processes entered the measured interval at
`44.3–44.6 MB` and ended at `59.1–59.3 MB`. Parallel processes had already
created worker tasks, ThreadPool threads, and associated runtime caches; they
entered at `56.6–57.4 MB` and ended at `63.5–64.1 MB`. A substantial part of the
parallel footprint is therefore intentionally paid before the baseline.

All six runs used concurrent Workstation GC, so Server GC does not explain the
difference. The shorter wall-clock duration of the parallel profile should not
be treated as an established cause either: the runner records endpoint Working
Set, not the process high-water mark over time.

## Controlled `System.Text.Json` check

Comparing the September 7 and September 15 snapshots was not like-for-like. The
older .NET 9 benchmark host consumed the `netstandard2.0` asset with packaged
`System.Text.Json 10.0.11`; the newer host selected the native `net8.0` asset
and platform-provided STJ 9.

A separate in-process diagnostic used the same runtime `9.0.20` and source code
to measure rich-message serialization:

| Configuration | 1 block | 5 blocks | 10 blocks | 50 blocks |
| --- | ---: | ---: | ---: | ---: |
| `netstandard + STJ 10.0.11` | 1.125 μs | 3.388 μs | 6.312 μs | 30.473 μs |
| native `net8 + STJ 9` | 1.390 μs | 4.316 μs | 7.642 μs | 35.752 μs |
| `netstandard + platform STJ 9` | 1.557 μs | 4.663 μs | 8.563 μs | 40.787 μs |

Conclusions:

- STJ 10.0.11 specifically reproduces the older, faster numbers;
- with the same STJ 9, the native `net8` asset is 7–12% faster than the
  `netstandard` asset, so the native asset is not the cause of the slowdown;
- the difference belongs to the serializer write-path implementation for these
  object graphs and is not a regression in the library source;
- restoring STJ 10 as a required dependency would unnecessarily increase the
  dependency footprint and create conflicts with platform-provided versions.

This diagnostic ran in-process, so its absolute values must not be mixed with
the canonical DefaultJob report. It identifies the cause; it is not a new
public baseline.

## What these results do not prove

- They do not measure Telegram, network, TLS, rate limits, or data-center latency.
- `Stream.Null` does not model real data transmission.
- They do not compare different machines, GC modes, or runtime patches.
- A small timing delta without a focused repeat is not a proven regression.
- Stable `Allocated/op` cannot exclude every native-resource issue, but together
  with ownership tests and stress results it substantially reduces the risk.

## Review conclusion

Current commit `a229efd` is acceptable from a performance perspective:

1. Functional and ownership changes did not increase managed allocations.
2. Rich-message serialization did not regress against the previous
   like-for-like snapshot.
3. Path-backed multipart scenarios are stable.
4. The revised stress harness shows no retained-memory growth.
5. Two small directional client-pipeline signals should be monitored in the
   next snapshot, but they are not release blockers.

The canonical run, normalized comparison, focused repeat, and individual stress
runs are available in [`benchmark-data.json`](benchmark-data.json). Raw
BenchmarkDotNet exports and complete console logs are temporary run artifacts
and are not stored in the repository.
