using System.IO;

namespace Telegram.BotAPI.Types.Input;

public abstract class InputFile(string path)
{
    public abstract string Name { get; }

    public string FileName { get; private set; } = Path.GetFileName(path);

    public byte[] Bytes { get; private set; } = File.ReadAllBytes(path);
}

public sealed class InputCertificateFile(string path) : InputFile(path)
{
    public override string Name => "certificate";
}
