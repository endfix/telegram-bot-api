using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Endfix.Telegram.BotAPI.Benchmarks;

if (args.Contains("--stress", StringComparer.OrdinalIgnoreCase))
{
    await StressRunner.RunAsync();
    return;
}

var projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
var config = ManualConfig.Create(DefaultConfig.Instance)
    .WithArtifactsPath(projectPath);

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
