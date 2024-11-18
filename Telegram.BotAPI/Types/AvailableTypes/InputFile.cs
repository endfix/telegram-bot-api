using System.IO;

namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class InputFile(string path)
{
    public abstract string Name { get; }

    public string FileName { get; private set; } = Path.GetFileName(path);

    public byte[] Bytes { get; private set; } = System.IO.File.ReadAllBytes(path);

    public static class Types
    {
        public const string CERTIFICATE = "certificate";

        public const string PHOTO = "photo";

        public const string AUDIO = "audio";

        public const string DOCUMENT = "document";

        public const string VIDEO = "video";

        public const string ANIMATION = "animation";

        public const string VOICE = "voice";

        public const string VIDEO_NOTE = "video_note";

        public const string STICKER = "sticker";
    }
}

public sealed class InputCertificateFile(string path) : InputFile(path)
{
    public override string Name => Types.CERTIFICATE;
}

public sealed class InputPhotoFile(string path) : InputFile(path)
{
    public override string Name => Types.PHOTO;
}

public sealed class InputAudioFile(string path) : InputFile(path)
{
    public override string Name => Types.AUDIO;
}

public sealed class InputDocumentFile(string path) : InputFile(path)
{
    public override string Name => Types.DOCUMENT;
}

public sealed class InputVideoFile(string path) : InputFile(path)
{
    public override string Name => Types.VIDEO;
}

public sealed class InputAnimationFile(string path) : InputFile(path)
{
    public override string Name => Types.ANIMATION;
}

public sealed class InputVoiceFile(string path) : InputFile(path)
{
    public override string Name => Types.VOICE;
}

public sealed class InputVideoNoteFile(string path) : InputFile(path)
{
    public override string Name => Types.VIDEO_NOTE;
}

public sealed class InputStickerFile(string path) : InputFile(path)
{
    public override string Name => Types.STICKER;
}
