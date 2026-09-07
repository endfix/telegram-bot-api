# Benchmark snapshot

Captured on September 7, 2026 from library commit
`c19cb345a899b403feeb3527a81b275271b21ddf`. The library source matched that
commit; only benchmark reporting and documentation changes were pending while
this run was recorded.

| Property | Value |
| --- | --- |
| Library version | `v0.4.0-77-gc19cb34` |
| Commit count | 181 total; 77 since `v0.4.0` |
| Commit date | `2026-09-07T18:43:32+03:00` |
| Benchmark window | `2026-09-07T19:15:20+03:00` to `2026-09-07T19:42:09+03:00` |
| OS | Microsoft Windows 10 Pro `10.0.19045` |
| Architecture | X64 process / X64 OS |
| CPU | Intel Xeon E5-2690 v3 at 2.60 GHz, 12 physical / 24 logical cores |
| Memory | 15.9 GiB |
| .NET | SDK `9.0.317`; runtime `9.0.19`; X64 RyuJIT x86-64-v3 |
| BenchmarkDotNet | `0.15.8`, DefaultJob, high-performance power plan |
| Configuration | Release; 82 benchmarks; 26 minutes 45 seconds |

The raw measurements are available in [results.csv](results.csv). Absolute
timings should be compared on the same hardware and runtime configuration.
These benchmarks use local transports and do not measure Telegram or network
throughput. Ratios spanning different benchmark types in the joined report are
not meaningful because each type defines its own baseline.

## Stress profiles

Each profile executes 1,000,000 complete calls against the local test transport.

| Max parallel | Elapsed | Average | Throughput | CPU time | Retained delta | Working set delta | GC Gen0/1/2 |
| ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| 1 | 7.574 s | 7.57 us/op | 132,030 req/s | 8.406 s | +19.3 KB | +19.4 MB | 333/2/2 |
| 10 | 2.281 s | 2.28 us/op | 438,310 req/s | 19.797 s | +44.4 KB | +22.0 MB | 350/2/2 |

## Full BenchmarkDotNet report

```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Xeon CPU E5-2690 v3 2.60GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.317
  [Host]     : .NET 9.0.19 (9.0.19, 9.0.1926.36724), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 9.0.19 (9.0.19, 9.0.1926.36724), X64 RyuJIT x86-64-v3


```
| Type                                  | Method                                 | BlockCount | FileSize | FileCount | Mean           | Error        | StdDev       | Ratio    | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------- |--------------------------------------- |----------- |--------- |---------- |---------------:|-------------:|-------------:|---------:|--------:|-------:|-------:|----------:|------------:|
| **MultipartBenchmarks**                   | **SendMessage**                            | **?**          | **?**        | **?**         |     **4,227.0 ns** |     **81.72 ns** |     **72.44 ns** |     **1.00** |    **0.02** | **0.2060** |      **-** |    **3232 B** |        **1.00** |
| SerializationBenchmarks               | SerializeParameters                    | ?          | ?        | ?         |       566.2 ns |      2.58 ns |      2.29 ns |     0.13 |    0.00 | 0.0162 |      - |     264 B |        0.08 |
| TransportBenchmarks                   | RequestAndDeserialize                  | ?          | ?        | ?         |     6,098.9 ns |     40.13 ns |     33.51 ns |     1.44 |    0.03 | 0.3357 |      - |    5272 B |        1.63 |
| MultipartBenchmarks                   | SendPhotoByFileId                      | ?          | ?        | ?         |     4,405.2 ns |     51.68 ns |     48.34 ns |     1.04 |    0.02 | 0.2060 |      - |    3240 B |        1.00 |
| SerializationBenchmarks               | DeserializeParameters                  | ?          | ?        | ?         |       693.6 ns |      4.45 ns |      3.72 ns |     0.16 |    0.00 | 0.0200 |      - |     320 B |        0.10 |
| TransportBenchmarks                   | RequestWithoutParametersAndDeserialize | ?          | ?        | ?         |     3,425.5 ns |     30.45 ns |     28.48 ns |     0.81 |    0.01 | 0.2327 |      - |    3688 B |        1.14 |
| MultipartBenchmarks                   | SendPhotoByLocalFile                   | ?          | ?        | ?         |   226,509.6 ns |  2,127.68 ns |  1,886.13 ns |    53.60 |    0.99 |      - |      - |    3768 B |        1.17 |
| SerializationBenchmarks               | SerializeMessage                       | ?          | ?        | ?         |     2,823.8 ns |     22.54 ns |     21.09 ns |     0.67 |    0.01 | 0.0381 |      - |     600 B |        0.19 |
| MultipartBenchmarks                   | SendMediaGroupByFileId10               | ?          | ?        | ?         |    28,002.1 ns |    140.35 ns |    131.29 ns |     6.63 |    0.11 | 1.1597 |      - |   18200 B |        5.63 |
| SerializationBenchmarks               | DeserializeMessage                     | ?          | ?        | ?         |     1,215.9 ns |      9.37 ns |      8.30 ns |     0.29 |    0.01 | 0.1087 |      - |    1720 B |        0.53 |
| MultipartBenchmarks                   | SendMediaGroupByLocalFile10            | ?          | ?        | ?         | 2,071,362.6 ns | 12,898.48 ns | 11,434.17 ns |   490.17 |    8.55 |      - |      - |   28489 B |        8.81 |
| SerializationBenchmarks               | SerializeRichText                      | ?          | ?        | ?         |       524.5 ns |      2.00 ns |      1.78 ns |     0.12 |    0.00 | 0.0095 |      - |     160 B |        0.05 |
| MultipartBenchmarks                   | SendPollWithNestedLocalFiles           | ?          | ?        | ?         |   463,882.6 ns |  5,008.08 ns |  4,181.97 ns |   109.77 |    2.06 |      - |      - |   11568 B |        3.58 |
| SerializationBenchmarks               | DeserializeRichText                    | ?          | ?        | ?         |     3,272.1 ns |     21.88 ns |     17.08 ns |     0.77 |    0.01 | 0.0267 |      - |     464 B |        0.14 |
| MultipartBenchmarks                   | SendRichMessageWithNestedLocalFiles    | ?          | ?        | ?         |   464,030.8 ns |  6,560.77 ns |  7,555.39 ns |   109.81 |    2.52 |      - |      - |   11704 B |        3.62 |
| SerializationBenchmarks               | SerializeRichMessage                   | ?          | ?        | ?         |     4,743.6 ns |     15.68 ns |     14.66 ns |     1.12 |    0.02 | 0.1297 |      - |    2056 B |        0.64 |
| SerializationBenchmarks               | DeserializeRichMessage                 | ?          | ?        | ?         |    21,011.3 ns |    376.60 ns |    448.31 ns |     4.97 |    0.13 | 0.2747 |      - |    4392 B |        1.36 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **RichMessageComplexityBenchmarks**       | **Serialize**                              | **1**          | **?**        | **?**         |     **1,089.4 ns** |      **4.60 ns** |      **3.84 ns** |        **?** |       **?** | **0.0401** |      **-** |     **632 B** |           **?** |
| RichMessageComplexityBenchmarks       | Deserialize                            | 1          | ?        | ?         |     6,153.7 ns |     46.47 ns |     41.20 ns |        ? |       ? | 0.0839 |      - |    1328 B |           ? |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **RichMessageComplexityBenchmarks**       | **Serialize**                              | **5**          | **?**        | **?**         |     **3,482.4 ns** |     **40.97 ns** |     **36.32 ns** |        **?** |       **?** | **0.0877** |      **-** |    **1432 B** |           **?** |
| RichMessageComplexityBenchmarks       | Deserialize                            | 5          | ?        | ?         |    27,481.4 ns |    148.75 ns |    139.14 ns |        ? |       ? | 0.2441 |      - |    4104 B |           ? |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **RichMessageComplexityBenchmarks**       | **Serialize**                              | **10**         | **?**        | **?**         |     **6,606.6 ns** |    **111.81 ns** |     **99.12 ns** |        **?** |       **?** | **0.1526** |      **-** |    **2432 B** |           **?** |
| RichMessageComplexityBenchmarks       | Deserialize                            | 10         | ?        | ?         |    55,400.0 ns |  1,078.39 ns |  1,402.21 ns |        ? |       ? | 0.4272 |      - |    7616 B |           ? |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **RichMessageComplexityBenchmarks**       | **Serialize**                              | **50**         | **?**        | **?**         |    **30,650.8 ns** |    **277.46 ns** |    **245.96 ns** |        **?** |       **?** | **0.6104** |      **-** |   **10513 B** |           **?** |
| RichMessageComplexityBenchmarks       | Deserialize                            | 50         | ?        | ?         |   269,347.0 ns |    808.71 ns |    756.47 ns |        ? |       ? | 1.9531 |      - |   35641 B |           ? |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticStreamBenchmarks**   | **WriteFileStreams**                       | **?**          | **256**      | **1**         |   **272,104.8 ns** |  **5,306.61 ns** |  **6,317.14 ns** |    **1.001** |    **0.03** |      **-** |      **-** |    **3685 B** |        **1.00** |
| MultipartDiagnosticStreamBenchmarks   | WritePreloadedMemoryStreams            | ?          | 256      | 1         |     1,687.7 ns |     18.62 ns |     17.42 ns |    0.006 |    0.00 | 0.1488 |      - |    2360 B |        0.64 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticStreamBenchmarks**   | **WriteFileStreams**                       | **?**          | **256**      | **10**        | **2,355,176.7 ns** | **46,551.68 ns** | **66,763.03 ns** |    **1.001** |    **0.04** |      **-** |      **-** |   **18068 B** |        **1.00** |
| MultipartDiagnosticStreamBenchmarks   | WritePreloadedMemoryStreams            | ?          | 256      | 10        |    10,250.0 ns |     55.47 ns |     46.32 ns |    0.004 |    0.00 | 0.6714 |      - |   10736 B |        0.59 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticFileBenchmarks**     | **OpenLocalFile**                          | **?**          | **256**      | **?**         |   **196,047.1 ns** |  **1,144.45 ns** |  **1,070.52 ns** |    **46.31** |    **0.38** |      **-** |      **-** |     **240 B** |        **0.07** |
| MultipartDiagnosticPipelineBenchmarks | PrepareScalar                          | ?          | 256      | ?         |     4,233.2 ns |     28.95 ns |     27.08 ns |     1.00 |    0.01 | 0.2060 |      - |    3232 B |        1.00 |
| MultipartDiagnosticPipelineBenchmarks | WriteScalar                            | ?          | 256      | ?         |     5,977.7 ns |     39.81 ns |     37.24 ns |     1.41 |    0.01 | 0.2518 |      - |    4064 B |        1.26 |
| MultipartDiagnosticPipelineBenchmarks | PrepareSingleFile                      | ?          | 256      | ?         |   231,463.7 ns |  2,556.57 ns |  2,391.42 ns |    54.68 |    0.64 |      - |      - |    3768 B |        1.17 |
| MultipartDiagnosticPipelineBenchmarks | WriteSingleFile                        | ?          | 256      | ?         |   385,334.3 ns |  7,671.80 ns |  8,527.18 ns |    91.03 |    2.04 |      - |      - |    6824 B |        2.11 |
| MultipartDiagnosticPipelineBenchmarks | PrepareSingleMemoryFile                | ?          | 256      | ?         |     4,939.1 ns |     59.33 ns |     55.50 ns |     1.17 |    0.01 | 0.2136 |      - |    3456 B |        1.07 |
| MultipartDiagnosticPipelineBenchmarks | WriteSingleMemoryFile                  | ?          | 256      | ?         |     6,842.6 ns |     69.92 ns |     65.40 ns |     1.62 |    0.02 | 0.2747 |      - |    4416 B |        1.37 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMediaGroup10                    | ?          | 256      | ?         | 2,136,757.4 ns | 28,206.53 ns | 26,384.41 ns |   504.78 |    6.80 |      - |      - |   28489 B |        8.81 |
| MultipartDiagnosticPipelineBenchmarks | WriteMediaGroup10                      | ?          | 256      | ?         | 2,810,290.4 ns | 33,168.14 ns | 31,025.50 ns |   663.89 |    8.20 |      - |      - |   43568 B |       13.48 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMemoryMediaGroup10              | ?          | 256      | ?         |    35,347.1 ns |     97.65 ns |     86.57 ns |     8.35 |    0.06 | 1.5869 | 0.0610 |   25288 B |        7.82 |
| MultipartDiagnosticPipelineBenchmarks | WriteMemoryMediaGroup10                | ?          | 256      | ?         |    41,150.5 ns |    765.27 ns |    678.40 ns |     9.72 |    0.17 | 1.7700 | 0.0610 |   27880 B |        8.63 |
| MultipartDiagnosticPipelineBenchmarks | PrepareNestedPoll2                     | ?          | 256      | ?         |   468,211.4 ns |  5,899.90 ns |  5,518.77 ns |   110.61 |    1.44 |      - |      - |   11576 B |        3.58 |
| MultipartDiagnosticPipelineBenchmarks | WriteNestedPoll2                       | ?          | 256      | ?         |   712,117.0 ns |  5,041.16 ns |  4,468.85 ns |   168.23 |    1.46 | 0.9766 |      - |   16256 B |        5.03 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMemoryNestedPoll2               | ?          | 256      | ?         |    19,034.2 ns |    147.82 ns |    138.28 ns |     4.50 |    0.04 | 0.6714 |      - |   10952 B |        3.39 |
| MultipartDiagnosticPipelineBenchmarks | WriteMemoryNestedPoll2                 | ?          | 256      | ?         |    24,191.9 ns |    322.42 ns |    301.59 ns |     5.71 |    0.08 | 0.7629 |      - |   12400 B |        3.84 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticStreamBenchmarks**   | **WriteFileStreams**                       | **?**          | **65536**    | **1**         |   **286,273.9 ns** |  **5,043.81 ns** |  **4,717.99 ns** |    **1.000** |    **0.02** |      **-** |      **-** |    **3710 B** |        **1.00** |
| MultipartDiagnosticStreamBenchmarks   | WritePreloadedMemoryStreams            | ?          | 65536    | 1         |     1,677.4 ns |     18.73 ns |     16.60 ns |    0.006 |    0.00 | 0.1488 |      - |    2360 B |        0.64 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticStreamBenchmarks**   | **WriteFileStreams**                       | **?**          | **65536**    | **10**        | **2,348,938.3 ns** | **10,674.40 ns** |  **9,984.84 ns** |    **1.000** |    **0.01** |      **-** |      **-** |   **18331 B** |        **1.00** |
| MultipartDiagnosticStreamBenchmarks   | WritePreloadedMemoryStreams            | ?          | 65536    | 10        |    10,377.7 ns |     96.81 ns |     80.84 ns |    0.004 |    0.00 | 0.6714 |      - |   10736 B |        0.59 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticFileBenchmarks**     | **OpenLocalFile**                          | **?**          | **65536**    | **?**         |   **195,231.8 ns** |    **853.96 ns** |    **798.79 ns** |    **45.96** |    **0.64** |      **-** |      **-** |     **240 B** |        **0.07** |
| MultipartDiagnosticPipelineBenchmarks | PrepareScalar                          | ?          | 65536    | ?         |     4,248.4 ns |     63.25 ns |     59.16 ns |     1.00 |    0.02 | 0.2060 |      - |    3232 B |        1.00 |
| MultipartDiagnosticPipelineBenchmarks | WriteScalar                            | ?          | 65536    | ?         |     5,696.5 ns |    109.71 ns |    130.60 ns |     1.34 |    0.03 | 0.2518 |      - |    4064 B |        1.26 |
| MultipartDiagnosticPipelineBenchmarks | PrepareSingleFile                      | ?          | 65536    | ?         |   229,009.9 ns |  3,509.21 ns |  3,282.51 ns |    53.91 |    1.04 |      - |      - |    3768 B |        1.17 |
| MultipartDiagnosticPipelineBenchmarks | WriteSingleFile                        | ?          | 65536    | ?         |   387,741.0 ns |  7,696.32 ns |  6,822.59 ns |    91.28 |    1.97 |      - |      - |    6824 B |        2.11 |
| MultipartDiagnosticPipelineBenchmarks | PrepareSingleMemoryFile                | ?          | 65536    | ?         |     4,685.6 ns |     52.62 ns |     49.22 ns |     1.10 |    0.02 | 0.2136 |      - |    3456 B |        1.07 |
| MultipartDiagnosticPipelineBenchmarks | WriteSingleMemoryFile                  | ?          | 65536    | ?         |     6,372.4 ns |     45.36 ns |     42.43 ns |     1.50 |    0.02 | 0.2747 |      - |    4416 B |        1.37 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMediaGroup10                    | ?          | 65536    | ?         | 2,112,686.1 ns | 15,580.66 ns | 14,574.16 ns |   497.38 |    7.41 |      - |      - |   28489 B |        8.81 |
| MultipartDiagnosticPipelineBenchmarks | WriteMediaGroup10                      | ?          | 65536    | ?         | 2,821,370.1 ns | 22,495.41 ns | 21,042.22 ns |   664.22 |   10.06 |      - |      - |   43569 B |       13.48 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMemoryMediaGroup10              | ?          | 65536    | ?         |    34,705.2 ns |    183.47 ns |    171.62 ns |     8.17 |    0.12 | 1.5869 | 0.0610 |   25288 B |        7.82 |
| MultipartDiagnosticPipelineBenchmarks | WriteMemoryMediaGroup10                | ?          | 65536    | ?         |    41,444.1 ns |    296.98 ns |    277.79 ns |     9.76 |    0.14 | 1.7700 | 0.0610 |   27880 B |        8.63 |
| MultipartDiagnosticPipelineBenchmarks | PrepareNestedPoll2                     | ?          | 65536    | ?         |   464,864.3 ns |  1,812.44 ns |  1,513.47 ns |   109.44 |    1.50 |      - |      - |   11576 B |        3.58 |
| MultipartDiagnosticPipelineBenchmarks | WriteNestedPoll2                       | ?          | 65536    | ?         |   716,206.8 ns | 12,579.61 ns | 11,766.97 ns |   168.61 |    3.50 | 0.9766 |      - |   16256 B |        5.03 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMemoryNestedPoll2               | ?          | 65536    | ?         |    19,841.9 ns |    132.73 ns |    117.66 ns |     4.67 |    0.07 | 0.6714 |      - |   10952 B |        3.39 |
| MultipartDiagnosticPipelineBenchmarks | WriteMemoryNestedPoll2                 | ?          | 65536    | ?         |    24,705.9 ns |    214.97 ns |    201.09 ns |     5.82 |    0.09 | 0.7629 |      - |   12400 B |        3.84 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticStreamBenchmarks**   | **WriteFileStreams**                       | **?**          | **1048576**  | **1**         |   **419,303.6 ns** |  **1,644.68 ns** |  **1,538.44 ns** |    **1.000** |    **0.01** |      **-** |      **-** |    **3995 B** |        **1.00** |
| MultipartDiagnosticStreamBenchmarks   | WritePreloadedMemoryStreams            | ?          | 1048576  | 1         |     1,669.1 ns |      7.69 ns |      6.42 ns |    0.004 |    0.00 | 0.1488 |      - |    2360 B |        0.59 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticStreamBenchmarks**   | **WriteFileStreams**                       | **?**          | **1048576**  | **10**        | **3,584,551.5 ns** | **16,451.19 ns** | **15,388.45 ns** |    **1.000** |    **0.01** |      **-** |      **-** |   **18091 B** |        **1.00** |
| MultipartDiagnosticStreamBenchmarks   | WritePreloadedMemoryStreams            | ?          | 1048576  | 10        |    10,310.2 ns |    147.33 ns |    123.03 ns |    0.003 |    0.00 | 0.6714 |      - |   10736 B |        0.59 |
|                                       |                                        |            |          |           |                |              |              |          |         |        |        |           |             |
| **MultipartDiagnosticFileBenchmarks**     | **OpenLocalFile**                          | **?**          | **1048576**  | **?**         |   **200,026.6 ns** |  **2,663.24 ns** |  **2,491.20 ns** |    **48.36** |    **0.68** |      **-** |      **-** |     **240 B** |        **0.07** |
| MultipartDiagnosticPipelineBenchmarks | PrepareScalar                          | ?          | 1048576  | ?         |     4,136.7 ns |     32.63 ns |     30.52 ns |     1.00 |    0.01 | 0.2060 |      - |    3232 B |        1.00 |
| MultipartDiagnosticPipelineBenchmarks | WriteScalar                            | ?          | 1048576  | ?         |     5,887.0 ns |     44.59 ns |     41.71 ns |     1.42 |    0.01 | 0.2518 |      - |    4064 B |        1.26 |
| MultipartDiagnosticPipelineBenchmarks | PrepareSingleFile                      | ?          | 1048576  | ?         |   227,648.9 ns |  3,258.78 ns |  2,544.24 ns |    55.03 |    0.71 |      - |      - |    3768 B |        1.17 |
| MultipartDiagnosticPipelineBenchmarks | WriteSingleFile                        | ?          | 1048576  | ?         |   597,908.7 ns | 10,025.47 ns |  9,377.84 ns |   144.55 |    2.42 |      - |      - |    6824 B |        2.11 |
| MultipartDiagnosticPipelineBenchmarks | PrepareSingleMemoryFile                | ?          | 1048576  | ?         |     4,715.0 ns |     49.02 ns |     45.85 ns |     1.14 |    0.01 | 0.2136 |      - |    3456 B |        1.07 |
| MultipartDiagnosticPipelineBenchmarks | WriteSingleMemoryFile                  | ?          | 1048576  | ?         |     6,544.6 ns |     41.44 ns |     38.76 ns |     1.58 |    0.01 | 0.2747 |      - |    4416 B |        1.37 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMediaGroup10                    | ?          | 1048576  | ?         | 2,086,958.8 ns | 17,398.37 ns | 16,274.44 ns |   504.53 |    5.24 |      - |      - |   28489 B |        8.81 |
| MultipartDiagnosticPipelineBenchmarks | WriteMediaGroup10                      | ?          | 1048576  | ?         | 5,090,293.8 ns | 24,565.73 ns | 22,978.80 ns | 1,230.59 |   10.28 |      - |      - |   43570 B |       13.48 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMemoryMediaGroup10              | ?          | 1048576  | ?         |    34,658.2 ns |    375.26 ns |    351.02 ns |     8.38 |    0.10 | 1.5869 | 0.0610 |   25288 B |        7.82 |
| MultipartDiagnosticPipelineBenchmarks | WriteMemoryMediaGroup10                | ?          | 1048576  | ?         |    40,834.0 ns |    215.96 ns |    202.01 ns |     9.87 |    0.08 | 1.7700 | 0.0610 |   27880 B |        8.63 |
| MultipartDiagnosticPipelineBenchmarks | PrepareNestedPoll2                     | ?          | 1048576  | ?         |   459,476.9 ns |  3,947.25 ns |  3,499.14 ns |   111.08 |    1.14 |      - |      - |   11576 B |        3.58 |
| MultipartDiagnosticPipelineBenchmarks | WriteNestedPoll2                       | ?          | 1048576  | ?         | 1,177,690.1 ns | 11,028.01 ns |  9,776.04 ns |   284.71 |    3.05 |      - |      - |   16256 B |        5.03 |
| MultipartDiagnosticPipelineBenchmarks | PrepareMemoryNestedPoll2               | ?          | 1048576  | ?         |    18,880.4 ns |    162.42 ns |    143.98 ns |     4.56 |    0.05 | 0.6714 |      - |   10952 B |        3.39 |
| MultipartDiagnosticPipelineBenchmarks | WriteMemoryNestedPoll2                 | ?          | 1048576  | ?         |    24,733.3 ns |    487.52 ns |    633.91 ns |     5.98 |    0.16 | 0.7324 |      - |   12400 B |        3.84 |
