# Benchmark snapshot

Captured on September 15, 2026 from library commit
`5f58e9ac490ba0270ddc1ec1304f1b6ef10118f3`. The library source matched that
commit; only benchmark reporting and documentation changes were pending while
this run was recorded.

| Property | Value |
| --- | --- |
| Library version | `v0.5.0-10-g5f58e9a` |
| Commit count | 206 total; 10 since `v0.5.0` |
| Commit date | `2026-09-15T02:58:30+03:00` |
| Benchmark window | `2026-09-15T03:13:54+03:00` to `2026-09-15T03:37:38+03:00` |
| OS | Microsoft Windows 10 Pro `10.0.19045` |
| Architecture | X64 process / X64 OS |
| CPU | Intel Xeon E5-2690 v3 at 2.60 GHz, 12 physical / 24 logical cores |
| Memory | 15.9 GiB |
| .NET | SDK `9.0.318`; runtime `9.0.20`; X64 RyuJIT x86-64-v3 |
| BenchmarkDotNet | `0.15.8`, DefaultJob, high-performance power plan |
| Configuration | Release; 82 benchmarks; 23 minutes 44 seconds |

The [full BenchmarkDotNet report](report.md) and
[machine-readable measurements](results.csv) are retained with this snapshot.
These benchmarks use local transports and do not measure Telegram or network
throughput. Ratios spanning different benchmark types in the joined report are
not meaningful because each type defines its own baseline.

## Comparison with September 7

All 82 scenarios completed successfully. Multipart and transport timings were
stable or generally faster, and their managed allocations were stable or
slightly lower. The largest allocation reductions were 240 bytes for media
groups and 48 bytes for nested uploads.

Rich-message serialization was 15% to 25% slower with unchanged allocations.
This is not a like-for-like library regression: the earlier benchmark predated
the native `net8.0` package asset, so its .NET 9 host selected the
`netstandard2.0` asset with `System.Text.Json` 10.0.11. This snapshot selects the
native `net8.0` asset and uses the .NET 9 platform serializer. A focused repeat
of all eight rich-message complexity cases confirmed the timing difference;
deserialization remained stable or faster.

The two snapshots also use different runtime patches (`9.0.19` and `9.0.20`).
Absolute timings should therefore be treated as directional and compared on
the same asset and runtime configuration when investigating small changes.

## Stress profiles

Each profile executes 1,000,000 complete calls against the local test transport.

| Max parallel | Elapsed | Average | Throughput | CPU time | Retained delta | Working set delta | GC Gen0/1/2 |
| ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| 1 | 7.840 s | 7.84 us/op | 127,544 req/s | 8.625 s | +19.3 KB | +16.7 MB | 332/2/2 |
| 10 | 2.382 s | 2.38 us/op | 419,897 req/s | 20.750 s | +204.4 KB | +19.3 MB | 350/2/2 |

The parallel profile was repeated because its retained delta was higher than
the previous snapshot. The repeat produced the same 204.4 KB delta with the
same collection counts, which is a small fixed retained cost rather than growth
proportional to the one million operations.
