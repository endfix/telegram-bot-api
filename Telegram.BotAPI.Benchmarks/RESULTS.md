# Current performance results

Captured on November 10, 2026 for `v2.0.0` (Bot API 10.4), commit
`bb633f586ae4d5bda59502a0e6b32ab95bef5291` (`v2.0.0-0-gbb633f5`). The
previous canonical snapshot is commit
`cfaa5ce15fde576063faf98ff4f3a7747eb6cf72` (`v1.0.0-5-gcfaa5ce`) from
September 24.

## Summary

`2.0.0` is a breaking release that adds the Bot API 10.4 types and changes
`chat_id` to an optional `ChatIdSource?` on request parameters. It does not
change the local request algorithm: no-file parameterized requests are still
sent as `application/json`, and multipart is still used only when a request
carries a file source.

Two allocation changes follow directly from the new API surface:

- `Message` grew by exactly three reference properties (`Widget`,
  `PaidMessagesWaived`, `TonWalletTransfer`), so one instance is `968 B`
  instead of `944 B` (+24 B).
- `SendMessageParameters.ChatId` is now `ChatIdSource?`. `ChatIdSource` is a
  `readonly struct` with a single reference field (8 B) and
  `Nullable<ChatIdSource>` is 16 B, so every parameter object carrying a
  `chat_id` grew by 8 B.

Timings are not directly comparable with September: the same machine drifted
by a median of +5.3% across all 82 rows, and pure `File.OpenRead` rows moved
by +19.6…21.7%. The report therefore uses an alternating old/new A/B control
on the same machine to decide whether `2.0.0` regressed anything. Across
three independent protocols the transport delta changes sign and never
exceeds the run-to-run scatter, so there is no reproducible timing
regression.

Six independent million-call stress processes allocated exactly
`4088.0 B/op` (the September figure was `4064.0 B/op`; the +24 B is the
`Message` growth) and still retained less managed memory after a full GC.

## Reproducibility

| Property | Value |
| --- | --- |
| Commit | `bb633f586ae4d5bda59502a0e6b32ab95bef5291` |
| Version description | `v2.0.0-0-gbb633f5` |
| Working tree | Clean before the run |
| Full-run window | `09:44–10:09`, `Europe/Moscow` |
| OS | Windows 10 `10.0.19045.6466` |
| CPU | Intel Xeon E5-2690 v3, 12 physical / 24 logical cores |
| SDK / runtime | .NET SDK `9.0.320`, runtime `9.0.22` |
| JIT / GC | X64 RyuJIT x86-64-v3, concurrent Workstation GC |
| Library asset | Native `net8.0` |
| JSON runtime | Platform-provided `System.Text.Json` 9 |
| BenchmarkDotNet | `0.15.8`, DefaultJob, separate process |
| Power plan | High performance |
| Result | 82/82 scenarios, 25 minutes 25 seconds |

The previous snapshot used SDK `9.0.318` and runtime `9.0.20`. A control run
of the September sources on runtime `9.0.22` produced the same allocations as
the September snapshot (`1712 B` for `DeserializeMessage`, `320 B` for
`DeserializeParameters`), so the runtime patch is not responsible for any
allocation difference in this report.

All numeric data behind this report is available in
[`benchmark-data.json`](benchmark-data.json). JSON numbers use invariant
culture; BenchmarkDotNet timings are normalized to nanoseconds.

Full-run command:

```powershell
dotnet run --project Telegram.BotAPI.Benchmarks\Telegram.BotAPI.Benchmarks.csproj `
  -c Release --no-launch-profile -- --filter * --join
```

Every comparison below matches rows by benchmark type, method, and parameters.

## Machine drift

Comparing the full `2.0.0` run with the September canonical snapshot gives a
median delta of `+5.3%` and a mean of `+7.0%` across 82 matching rows. The
slowest rows are the ones that do not touch library code at all:

| Diagnostic row | September | November | Change |
| --- | ---: | ---: | ---: |
| `OpenLocalFile` 256 B | 189.2 μs | 226.3 μs | +19.6% |
| `OpenLocalFile` 1 MiB | 185.9 μs | 226.2 μs | +21.7% |
| `PrepareSingleFile` 256 B | 211.9 μs | 258.2 μs | +21.8% |
| `WriteScalar` 64 KiB | 2.45 μs | 2.98 μs | +21.4% |

`File.OpenRead` alone moved by about a fifth without a single line of library
code changing, so absolute September-versus-November timings cannot separate
a regression from machine state. Only the A/B control below is used for the
timing verdict.

## A/B control: `cfaa5ce` versus `bb633f5`

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

## Allocation changes in 2.0.0

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
no media, so they measure the type floor rather than a real update. A focused
run on November 12, 2026 added a photo post as Telegram actually delivers it:
media group, author, chat, four photo sizes, caption text and three caption
entities (bold, URL, mention with a nested user).

| Scenario | Mean | Allocated | Gen0 / 1000 ops |
| --- | ---: | ---: | ---: |
| `SerializeMessage` (synthetic) | 3.22 µs | 600 B | 0.038 |
| `DeserializeMessage` (synthetic) | 1.15 µs | 1,736 B | 0.111 |
| `SerializePhotoMessage` | 9.58 µs | 2,720 B | 0.168 |
| `DeserializePhotoMessage` | 8.45 µs | 4,080 B | 0.259 |

A realistic photo post costs `2.35×` the allocation and `7.4×` the time of the
synthetic message. The extra `2,344 B` are the objects the JSON describes, not
serializer overhead: four `PhotoSize` instances, three `MessageEntity`
instances, two `User` instances, the caption and file-id strings, and the
`List<T>` backing arrays. All of them are small and short-lived, so the cost
stays in generation 0: `0.2594` collections per 1,000 operations is one Gen0
collection per roughly 3,850 messages, with no Gen1 or Gen2 activity.

Run details: same host and BenchmarkDotNet setup as the canonical snapshot,
`--filter '*SerializationBenchmarks*'`, 10 benchmarks, 3 minutes 27 seconds,
.NET 9.0.23 (the canonical run used 9.0.22). These two benchmarks are not in
[`benchmark-data.json`](benchmark-data.json) yet; the next full run will add
them as canonical rows.

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

Focused run on November 12, 2026, same host as the other focused runs,
`--filter '*TransportBenchmarks*'`:

| Scenario | Before | After | Change |
| --- | ---: | ---: | ---: |
| `RequestAndDeserialize` | 4.363 µs / 4,157 B / Gen0 0.2441 | 3.596 µs / 3,758 B / Gen0 0.2365 | −17.6% time, −399 B, −3.1% Gen0 |
| `RequestWithoutParametersAndDeserialize` | 3.260 µs / 3,707 B / Gen0 0.2289 | 2.642 µs / 3,348 B / Gen0 0.2098 | −19.0% time, −359 B, −8.3% Gen0 |

The saving is smaller than the probe cost because the benchmark token and
method names are short, so the discarded strings were shorter than in the
probe. The cached entry stays at zero allocation on every subsequent call, and
the memory cost is one dictionary entry plus one `Uri` (about 600 B) per
distinct method name that a client actually uses.

The `RequestAndDeserialize` and `RequestWithoutParametersAndDeserialize` rows
in [`benchmark-data.json`](benchmark-data.json) still hold the pre-cache values;
the next full run will refresh them.

## Absolute snapshot versus `cfaa5ce`

These numbers are recorded for the canonical snapshot. Read the deltas with
the machine-drift caveat above; they are not evidence of a code change.

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

`WriteSingleFile` at 64 KiB is `2.98 μs` versus `OpenLocalFile` `226.3 μs`.
Path-backed uploads remain filesystem-dominated.

## Stress: 1,000,000 local `sendMessage` calls

Three sequential and three parallel (`maxParallel = 10`) processes. Every run
used concurrent Workstation GC.

| Profile | Elapsed | Allocated/op | Retained delta | Gen1 / Gen2 |
| --- | ---: | ---: | ---: | --- |
| Sequential 1 | 5.42 s | 4088.0 B | −16.4 KB | 0 / 0 |
| Sequential 2 | 5.55 s | 4088.0 B | −8.3 KB | 0 / 0 |
| Sequential 3 | 5.47 s | 4088.0 B | −8.3 KB | 0 / 0 |
| Parallel 1 | 2.10 s | 4088.0 B | −15.5 KB | 0 / 0 |
| Parallel 2 | 2.12 s | 4088.0 B | −15.5 KB | 0 / 0 |
| Parallel 3 | 2.13 s | 4088.0 B | −15.5 KB | 0 / 0 |

The `+24 B/op` versus September is the `Message` growth, not a runtime or GC
change: the old sources running on runtime `9.0.22` also allocate
`4064.0 B/op`. Retained managed memory after a full GC still decreases in
every run, and there are no Gen1 or Gen2 collections in a million calls.

Working Set still grows (sequential `44 → 60 MB`, parallel `58 → 65 MB`)
because the process starts from a small footprint and then pays for JIT,
ThreadPool, and runtime caches. That is the same pattern as the previous
snapshots.

## What these results do not prove

- They do not measure Telegram, network, TLS, rate limits, or data-center latency.
- `Stream.Null` does not model real data transmission.
- They do not compare different machines, GC modes, or runtime patches.
- A small timing delta without a focused repeat is not a proven regression.
- The A/B transport rows are smaller than the run-to-run scatter of this
  in-memory benchmark, so no timing direction should be quoted from them.

## Review conclusion

Commit `bb633f5` (`v2.0.0`) is the performance snapshot for the 2.0 line:

1. The local request algorithm did not change; no-file requests stay JSON.
2. Allocations moved only where the API surface moved: `+24 B` for `Message`
   and `+8 B` for `SendMessageParameters.ChatId`.
3. Transport timing differences did not reproduce across three protocols and
   changed sign; they are machine state, not a regression.
4. Path-backed multipart is stable and still dominated by opening files.
5. Stress shows no retained-memory growth, no Gen1/Gen2 collections, and a
   per-operation allocation that matches the measured type size.

The canonical run, row-by-row comparison with `cfaa5ce`, and six stress runs
are available in [`benchmark-data.json`](benchmark-data.json). Raw
BenchmarkDotNet exports and complete console logs are temporary run artifacts
and are not stored in the repository.
