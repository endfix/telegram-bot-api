using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Endfix.Telegram.BotAPI.Benchmarks;

var parallelStressIndex = Array.FindIndex(
    args,
    argument => argument.Equals("--stress-parallel", StringComparison.OrdinalIgnoreCase));

if (parallelStressIndex >= 0)
{
    var maxParallel = parallelStressIndex + 1 < args.Length &&
                      int.TryParse(args[parallelStressIndex + 1], out var parsedMaxParallel)
        ? parsedMaxParallel
        : 10;

    await StressRunner.RunAsync(maxParallel);
    return;
}

if (args.Contains("--stress", StringComparer.OrdinalIgnoreCase))
{
    await StressRunner.RunAsync(maxParallel: 1);
    return;
}

var projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
var config = ManualConfig.Create(DefaultConfig.Instance)
    .WithArtifactsPath(projectPath);

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
