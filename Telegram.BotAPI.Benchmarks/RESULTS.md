# Current performance results

Captured on November 12, 2026 for commit
`c61abe273607c401d24796bebd1228f698c9b7f3` (`v2.0.0-7-gc61abe2`), the first
snapshot after the `2.0.0` release. The previous canonical snapshot is
`bb633f586ae4d5bda59502a0e6b32ab95bef5291` (`v2.0.0-0-gbb633f5`) from
November 10; the 1.x baseline is
`cfaa5ce15fde576063faf98ff4f3a7747eb6cf72` (`v1.0.0-5-gcfaa5ce`) from
September 24.

## Summary

The only library change since `2.0.0` is a lazy per-client cache of request
`Uri` instances in `BotApiClient`. The request algorithm, the JSON pipeline, and
the entity model are untouched: no-file parameterized requests are still sent as
`application/json`, and multipart is still used only when a request carries a
file source.

- 51 of the 84 scenarios allocate `328–424 B` less per operation. That is the
  interpolated relative path and the parsed `Uri` that used to be rebuilt on
  every request; the exact size follows the token and method-name lengths.
- 26 scenarios are byte-identical to `2.0.0`: serialization, rich-message
  complexity, `OpenLocalFile`, and the preloaded-memory stream writes. Five
  file-stream rows moved by `−2…+15 B` because they embed a generated temporary
  path whose length varies between runs.
- `Transport.RequestAndDeserialize` falls from `5,147.4 ns / 4,160 B` to
  `3,378.1 ns / 3,760 B` (`−34.4%`, `−400 B`), and
  `RequestWithoutParametersAndDeserialize` from `3,292.1 ns / 3,704 B` to
  `2,520.4 ns / 3,344 B` (`−23.4%`, `−360 B`).
- Six independent million-call stress processes allocate `3688.0 B/op` instead
  of `4088.0 B/op` (`−9.8%`) and complete in `4.61–4.66 s` sequential and
  `1.84–1.88 s` at ten workers, versus `5.42–5.55 s` and `2.10–2.13 s`.
- The 26 allocation-identical rows provide the drift control for this run: their
  timings moved by a median of `−3.0%` (`−9.0…+5.6%`), far below the
  `−23…−34%` seen on the transport rows.

## Reproducibility

| Property | Value |
| --- | --- |
| Commit | `c61abe273607c401d24796bebd1228f698c9b7f3` |
| Version description | `v2.0.0-7-gc61abe2` |
| Working tree | Clean before the run |
| Full-run window | `01:59–02:25`, `Europe/Moscow` |
| OS | Windows 10 `10.0.19045.6466` |
| CPU | Intel Xeon E5-2690 v3, 12 physical / 24 logical cores |
| SDK / runtime | .NET SDK `9.0.321`, runtime `9.0.23` |
| JIT / GC | X64 RyuJIT x86-64-v3, concurrent Workstation GC |
| Library asset | Native `net8.0` |
| JSON runtime | Platform-provided `System.Text.Json` 9 |
| BenchmarkDotNet | `0.15.8`, DefaultJob, separate process |
| Power plan | High performance |
| Result | 84/84 scenarios, 25 minutes 3 seconds |

The `2.0.0` snapshot used SDK `9.0.320` and runtime `9.0.22`; this run used
runtime `9.0.23`. The 26 allocation-identical rows are the control for that
patch change: their timings moved by a median of `−3.0%`, so no serialization
change is claimed from this run.

All numeric data behind this report is available in
[`benchmark-data.json`](benchmark-data.json). JSON numbers use invariant
culture; BenchmarkDotNet timings are normalized to nanoseconds.

Full-run command:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj `
  -c Release -- --filter * --join
```

Every comparison below matches rows by benchmark type, method, and parameters.

## Changes since `2.0.0`

`bb633f5` and `c61abe2` were measured on the same host two days apart, so the
allocation comparison is exact and the timing comparison is directionally
useful. The 26 rows that do not build a request are unchanged and act as the
drift control for time: their median delta is `−3.0%` with a `−9.0…+5.6%`
range.

| Scenario | `2.0.0` | Now | Time | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `Transport.RequestAndDeserialize` | 5,147.4 ns / 4,160 B | 3,378.1 ns / 3,760 B | −34.4% | −400 B |
| `Transport.RequestWithoutParametersAndDeserialize` | 3,292.1 ns / 3,704 B | 2,520.4 ns / 3,344 B | −23.4% | −360 B |
| `Multipart.SendMessage` | 2,648.1 ns / 2,104 B | 1,807.4 ns / 1,704 B | −31.7% | −400 B |
| `SendPhotoByFileId` | 3,624.0 ns / 2,144 B | 2,740.4 ns / 1,760 B | −24.4% | −384 B |
| `SendMediaGroupByFileId10` | 10,225.4 ns / 3,704 B | 9,181.9 ns / 3,288 B | −10.2% | −416 B |
| `SendMediaGroupByLocalFile10` | 2,324.8 μs / 28,353 B | 2,309.0 μs / 27,937 B | −0.7% | −416 B |
| `SerializeMessage` | 3,229.0 ns / 600 B | 2,939.8 ns / 600 B | −9.0% | unchanged |
| `DeserializeMessage` | 1,179.4 ns / 1,736 B | 1,141.4 ns / 1,736 B | −3.2% | unchanged |

The allocation saving is one relative string plus one `Uri` per request, so it
sits in a narrow band: `−424 B` for the longest method name in the set,
`−328…−400 B` for the rest. Rows that only serialize or deserialize do not
build a request and do not move. The five `WriteFileStreams` rows differ by
`−2…+15 B` because their multipart body embeds a generated temporary path whose
length changes between runs; that is unrelated to the client.

Timing tells the same story. Rows whose time is dominated by request
construction improved by 10–34%, including `PrepareScalar` (`−27.8…−30.5%`) and
`WriteScalar` (`−28.2…−38.3%`), which are multipart diagnostics that still build
a request URI. Path-backed uploads moved only `−0.7…−6.7%` because
`File.OpenRead` dominates them: `2,309.0 μs` for the 10-part local-file media
group against `219.2 μs` for opening one file. Serialization rows stayed inside
the drift range (`−9.0…+5.6%`).

## Historical: A/B control `cfaa5ce` versus `bb633f5` (the `2.0.0` release)

The protocols below established the `2.0.0` allocation story and are kept as
the release record. They are not measurements of the current snapshot.

Protocol: both trees were built with the same SDK and runtime, each round ran
17 benchmarks (serialization, transport, multipart) from its own repository
root, and the rounds were ordered `old`, `new`, `old`, `new`. The working
directory matters: BenchmarkDotNet resolves the `ProjectReference` of its
generated child project from the current directory, so running the old tree
from the new repository silently benchmarks the new library. Every round was
validated by allocation signature: the new rounds report `4160 / 3704 /
1736 / 328 B`, the old rounds report `4136 / 3680 / 1712 / 320 B`.

| Scenario | Old round 1 | New round 1 | Change | Old round 2 | New round 2 | Change |
| --- | ---: | ---: | ---: | ---: | ---: | ---: |
| `Transport.RequestAndDeserialize` | 4,802.7 ns | 5,308.7 ns | +10.5% | 4,610.4 ns | 5,066.2 ns | +9.9% |
| `Transport.RequestWithoutParametersAndDeserialize` | 3,424.6 ns | 3,718.4 ns | +8.6% | 3,262.5 ns | 3,486.6 ns | +6.9% |
| `DeserializeParameters` | 686.0 ns | 742.0 ns | +8.2% | 680.6 ns | 741.9 ns | +9.0% |
| `DeserializeMessage` | 1,234.5 ns | 1,265.2 ns | +2.5% | 1,218.3 ns | 1,280.6 ns | +5.1% |
| `SerializeParameters` | 543.4 ns | 708.1 ns | +30.3% | 528.5 ns | 560.7 ns | +6.1% |
| `SerializeMessage` | 2,989.8 ns | 3,045.0 ns | +1.8% | 2,868.3 ns | 3,586.1 ns | +25.0% |
| `Multipart.SendMessage` | 2,644.2 ns | 2,527.3 ns | −4.4% | 2,686.6 ns | 2,484.9 ns | −7.5% |
| `SendPhotoByFileId` | 3,574.2 ns | 4,050.0 ns | +13.3% | 3,856.3 ns | 4,068.5 ns | +5.5% |

The row set is inconsistent: `SendMessage` is faster in both rounds while the
transport rows are slower in both, and the serialization rows swing by 1.8%
to 30.3% between rounds. That is larger than any plausible effect of adding
three properties to `Message`.

To separate signal from machine state, the transport pair was repeated twice
more.

**Focused run, 8 rounds, transport only.** Rounds were ordered
`old, new, new, old, old, new, new, old` to break any period-two machine
effect (about one minute per round):

| Build | `RequestAndDeserialize` | `RequestWithoutParametersAndDeserialize` |
| --- | ---: | ---: |
| Old (`cfaa5ce`) | 5.249, 4.594, 4.618, 4.978 μs | 3.479, 3.362, 3.280, 3.342 μs |
| New (`bb633f5`) | 4.637, 4.470, 4.414, 4.463 μs | 3.365, 3.345, 3.342, 3.253 μs |

Median `RequestAndDeserialize` is now `4.467 μs` for the new build versus
`4.798 μs` for the old one (−6.9%); the best samples are `4.414` versus
`4.594 μs` (−3.9%). `RequestWithoutParametersAndDeserialize` differs by
−0.3% by median and −0.8% by best sample. The sign of the transport delta is
opposite to the first A/B, and the spread inside one build (5–14%) is larger
than the delta.

**Isolated probe, alternating every two seconds.** Two console probes were
compiled against the two DLLs and executed alternately, ten pairs, each
measuring the best of nine 20,000-operation batches through the same
in-memory `HttpMessageHandler`:

| Metric | Old | New | Change |
| --- | ---: | ---: | ---: |
| `RequestAndDeserialize`, median of minima | 4,416 ns | 4,305 ns | −2.5% |
| `RequestWithoutParametersAndDeserialize`, median of minima | 3,297 ns | 3,366 ns | +2.1% |
| `RequestAndDeserialize`, overall minimum | 4,153 ns | 4,183 ns | +0.7% |
| `RequestWithoutParametersAndDeserialize`, overall minimum | 3,226 ns | 3,205 ns | −0.7% |

Allocation deltas are exact and reproduce in every protocol; timing deltas do
not reproduce and are within the scatter of this in-memory benchmark.

## Historical: allocation changes in `2.0.0`

These types and allocations belong to the `2.0.0` release and have not changed
since.

Measured directly against the two built DLLs with
`GC.GetAllocatedBytesForCurrentThread` (100,000 object-creation iterations,
20,000 deserialization iterations, after warm-up and a full GC):

| Measurement | `cfaa5ce` | `bb633f5` | Change | Cause |
| --- | ---: | ---: | ---: | --- |
| `new Message()` | 944 B | 968 B | +24 B | three new reference properties |
| `DeserializeMessage` | 1,712 B | 1,736 B | +24 B | same `Message` growth |
| `DeserializeParameters` | 320 B | 328 B | +8 B | `ChatId` is now `ChatIdSource?` |
| `RequestAndDeserialize` | 4,136 B | 4,160 B | +24 B | `Message` growth |
| `RequestWithoutParametersAndDeserialize` | 3,680 B | 3,704 B | +24 B | `Message` growth |

The other 77 canonical rows have byte-identical allocations. The three new
`Message` properties are `Widget?`, `PaidMessagesWaived?` and
`TonWalletTransfer?`; each reference occupies 8 B on x64.
`ChatIdSource` contains one `object` field, so `ChatIdSource?` is a 16-byte
`Nullable<ChatIdSource>` instead of the previous 8-byte struct.

## Realistic message shape

The canonical serialization rows use a 131-character message with one chat and
no media, so they measure the type floor rather than a real update. The set also
contains a photo post as Telegram actually delivers it: media group, author,
chat, four photo sizes, caption text and three caption entities (bold, URL,
mention with a nested user).

| Scenario | Mean | Allocated | Gen0 / 1000 ops |
| --- | ---: | ---: | ---: |
| `SerializeMessage` (synthetic) | 2.94 µs | 600 B | 0.038 |
| `DeserializeMessage` (synthetic) | 1.14 µs | 1,736 B | 0.111 |
| `SerializePhotoMessage` | 8.68 µs | 2,720 B | 0.168 |
| `DeserializePhotoMessage` | 8.34 µs | 4,080 B | 0.259 |

A realistic photo post costs `2.35×` the allocation and `7.3×` the time of the
synthetic message. The extra `2,344 B` are the objects the JSON describes, not
serializer overhead: four `PhotoSize` instances, three `MessageEntity`
instances, two `User` instances, the caption and file-id strings, and the
`List<T>` backing arrays. All of them are small and short-lived, so the cost
stays in generation 0: `0.2594` collections per 1,000 operations is one Gen0
collection per roughly 3,850 messages, with no Gen1 or Gen2 activity.

Both scenarios were added to the benchmark set after the `2.0.0` snapshot and
these rows are now part of the canonical run.

## Lazy request URI cache

Every request used to build its own `Uri`:

```csharp
new Uri(_baseAddress, $"./bot{_token}/{request.MethodName}")
```

A lambda probe on the same host measured that shape at 144 B for the relative
string plus about 496 B for the `Uri`, and another 280 B once the path is
materialized, which `HttpClient` does. In other words, URI construction was
roughly 900 B of the local pipeline, not the 100-200 B that the first estimate
assumed.

`BotApiClient` now keeps one `ConcurrentDictionary<string, Uri>` per instance
and resolves the URI lazily on first use of each method name. The absolute URI
embeds the token, so the table cannot be shared between clients; it is also
lazy, because eagerly prebuilding all 193 method URIs costs 133,496 B and
147.5 µs per client and would only pay back after about 145 requests.

Canonical run on November 12, 2026, same host:

| Scenario | `2.0.0` | Now | Change |
| --- | ---: | ---: | ---: |
| `RequestAndDeserialize` | 5,147.4 ns / 4,160 B / Gen0 0.2441 | 3,378.1 ns / 3,760 B / Gen0 0.2365 | −34.4% time, −400 B |
| `RequestWithoutParametersAndDeserialize` | 3,292.1 ns / 3,704 B / Gen0 0.2289 | 2,520.4 ns / 3,344 B / Gen0 0.2098 | −23.4% time, −360 B |

An earlier focused run on the same day measured `−17.6%` and `−19.0%` for the
same pair; the canonical run is faster because the machine was quieter and the
run used the joined configuration. The allocation delta is the reliable part.

The saving is smaller than the probe cost because the benchmark token and
method names are short, so the discarded strings were shorter than in the
probe. The cached entry stays at zero allocation on every subsequent call, and
the memory cost is one dictionary entry plus one `Uri` (about 600 B) per
distinct method name that a client actually uses. The stress runs below show
the same `400 B` drop per million-call operation (`4088.0 → 3688.0 B/op`).

## Historical: absolute snapshot versus `cfaa5ce` (the `2.0.0` release)

These numbers record the `2.0.0` comparison with the September `1.x` baseline.
The deltas mix the release changes with machine drift and are not evidence about
the current snapshot.

### Serialization

| Scenario | `cfaa5ce` | `bb633f5` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `SerializeParameters` | 523.8 ns | 582.6 ns | +11.2% | unchanged |
| `DeserializeParameters` | 665.8 ns | 686.3 ns | +3.1% | +8 B |
| `SerializeMessage` | 3,072.7 ns | 3,229.0 ns | +5.1% | unchanged |
| `DeserializeMessage` | 1,199.0 ns | 1,179.4 ns | −1.6% | +24 B |
| `SerializeRichText` | 550.5 ns | 566.9 ns | +3.0% | unchanged |
| `DeserializeRichText` | 3,127.2 ns | 3,036.1 ns | −2.9% | unchanged |
| `SerializeRichMessage` | 5,227.3 ns | 5,195.4 ns | −0.6% | unchanged |
| `DeserializeRichMessage` | 19,808.6 ns | 20,582.6 ns | +3.9% | unchanged |
| `RichMessage Serialize(1)` | 1,411.9 ns | 1,304.2 ns | −7.6% | unchanged |
| `RichMessage Serialize(5)` | 4,002.7 ns | 3,895.8 ns | −2.7% | unchanged |
| `RichMessage Serialize(10)` | 7,641.6 ns | 7,231.2 ns | −5.4% | unchanged |
| `RichMessage Serialize(50)` | 34,868.6 ns | 34,235.6 ns | −1.8% | unchanged |

### Complete local client pipeline

| Scenario | `cfaa5ce` | `bb633f5` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `Multipart.SendMessage` | 2.424 μs / 2104 B | 2.648 μs / 2104 B | +9.3% | unchanged |
| `Transport.RequestAndDeserialize` | 4.413 μs / 4136 B | 5.147 μs / 4160 B | +16.6% | +24 B |
| `Transport.RequestWithoutParametersAndDeserialize` | 3.173 μs / 3680 B | 3.292 μs / 3704 B | +3.8% | +24 B |
| `SendPhotoByFileId` | 3.534 μs / 2144 B | 3.624 μs / 2144 B | +2.5% | unchanged |
| `SendMediaGroupByFileId10` | 10.04 μs / 3704 B | 10.23 μs / 3704 B | +1.9% | unchanged |

The no-file POST rows still build a JSON body instead of multipart, so their
allocations remain about 1.1 KB below the 1.x pre-JSON snapshot.

### Multipart and file sources

| Scenario | `cfaa5ce` | `bb633f5` | Change | Allocated |
| --- | ---: | ---: | ---: | ---: |
| `SendPhotoByLocalFile` | 213.4 μs / 3816 B | 257.4 μs / 3816 B | +20.6% | unchanged |
| `SendMediaGroupByLocalFile10` | 1,986 μs / 28353 B | 2,325 μs / 28353 B | +17.1% | unchanged |
| `SendPollWithNestedLocalFiles` | 451.3 μs / 11624 B | 500.1 μs / 11624 B | +10.8% | unchanged |
| `SendRichMessageWithNestedLocalFiles` | 454.1 μs / 11784 B | 507.5 μs / 11784 B | +11.8% | unchanged |

The 10-part path-backed scenarios still open ten streams over the same
generated file. They measure multipart and stream multiplicity with a warm
filesystem cache, not ten distinct physical files.

Nested poll with two 64 KB files: in-memory preparation is `21.1 μs / 11008 B`;
the path-backed prepare is `520.7 μs / 11632 B`. The extra time is
`File.OpenRead`, which is exactly the diagnostic row that drifted by about a
fifth on this machine.

`WriteScalar` at 64 KiB is `2.98 μs` versus `OpenLocalFile` `225.3 μs`.
Path-backed uploads remain filesystem-dominated.

## Stress: 1,000,000 local `sendMessage` calls

Three sequential and three parallel (`maxParallel = 10`) processes, run directly
after the full BenchmarkDotNet set. Every run used concurrent Workstation GC.

| Profile | Elapsed | Allocated/op | Retained delta | Gen0 | Gen1 / Gen2 |
| --- | ---: | ---: | ---: | ---: | --- |
| Sequential 1 | 4.61 s | 3688.0 B | −8.3 KB | 235 | 0 / 0 |
| Sequential 2 | 4.66 s | 3688.0 B | −8.3 KB | 235 | 0 / 0 |
| Sequential 3 | 4.62 s | 3688.0 B | −8.3 KB | 235 | 0 / 0 |
| Parallel 1 | 1.84 s | 3688.0 B | −15.5 KB | 261 | 0 / 0 |
| Parallel 2 | 1.86 s | 3688.0 B | −15.5 KB | 261 | 0 / 0 |
| Parallel 3 | 1.88 s | 3688.0 B | −15.5 KB | 261 | 0 / 0 |

The `−400 B/op` against the `2.0.0` snapshot is the cached request URI: a
million calls now allocate `3,517.2 MB` instead of `3,898.6 MB`. Wall time
dropped from `5.42–5.55 s` to `4.61–4.66 s` sequential and from `2.10–2.13 s` to
`1.84–1.88 s` at ten workers. Sequential Gen0 collections fall from `260` to
`235`; the parallel profile stays at `261`, so the remaining allocation volume
still drives the same number of collections.

Retained managed memory after a full GC still decreases in every run, and there
are no Gen1 or Gen2 collections in a million calls.

Working Set still grows (sequential `44 → 60 MB`, parallel `57 → 63 MB`)
because the process starts from a small footprint and then pays for JIT,
ThreadPool, and runtime caches. That is the same pattern as the previous
snapshots.

## What these results do not prove

- They do not measure Telegram, network, TLS, rate limits, or data-center latency.
- `Stream.Null` does not model real data transmission.
- They do not compare different machines, GC modes, or runtime patches.
- A small timing delta without a focused repeat is not a proven regression.
- The historical `2.0.0` A/B transport rows are smaller than the run-to-run
  scatter of this in-memory benchmark, so no timing direction should be quoted
  from them.

## Review conclusion

Commit `c61abe2` is the current performance snapshot for the 2.0 line:

1. The only change since `2.0.0` is the lazy request `Uri` cache; the request
   algorithm and the JSON pipeline are untouched.
2. Allocations drop by exactly one relative string plus one `Uri` on every row
   that constructs a request (`−328…−424 B`), and 26 rows are byte-identical;
   the five `WriteFileStreams` rows vary by `−2…+15 B` from run-to-run temporary
   path length.
3. Transport time fell `23–34%`, and rows that never touch the client stayed
   inside the `−9…+6%` drift range of the allocation-identical control set.
4. Six million-call stress processes allocate `3688.0 B/op` instead of
   `4088.0 B/op`, with no Gen1/Gen2 collections and no retained-memory growth.
5. Path-backed multipart remains filesystem-dominated and unchanged within
   drift.

The canonical run, row-by-row comparison with `bb633f5`, and six stress runs
are available in [`benchmark-data.json`](benchmark-data.json). Raw
BenchmarkDotNet exports and complete console logs are temporary run artifacts
and are not stored in the repository.
