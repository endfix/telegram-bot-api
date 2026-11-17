using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Endfix.Telegram.BotAPI.Benchmarks;

var pollingStressIndex = Array.FindIndex(
    args,
    argument => argument.Equals("--polling-stress", StringComparison.OrdinalIgnoreCase));

if (pollingStressIndex >= 0)
{
    var updates = ReadIntOption(args, "--polling-updates", 50_000);
    var repetitions = ReadIntOption(args, "--polling-repetitions", 3);

    await PollingStressRunner.RunAsync(updates, repetitions);
    return;
}

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

static int ReadIntOption(string[] arguments, string name, int defaultValue)
{
    var index = Array.FindIndex(
        arguments,
        argument => argument.Equals(name, StringComparison.OrdinalIgnoreCase));

    return index >= 0 &&
           index + 1 < arguments.Length &&
           int.TryParse(arguments[index + 1], out var value)
        ? value
        : defaultValue;
}
