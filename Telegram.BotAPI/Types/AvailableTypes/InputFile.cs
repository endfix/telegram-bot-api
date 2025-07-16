using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputFile(string path)
{
    public abstract InputFileTypes Name { get; }

    public string FileName { get; private set; } = System.IO.Path.GetFileName(path);

    public byte[] Bytes { get; private set; } = System.IO.File.ReadAllBytes(path);
}

public sealed class InputCertificateFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Certificate;
}

public sealed class InputPhotoFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Photo;
}

public sealed class InputAudioFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Audio;
}

public sealed class InputDocumentFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Document;
}

public sealed class InputVideoFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Video;
}

public sealed class InputAnimationFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Animation;
}

public sealed class InputVoiceFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Voice;
}

public sealed class InputVideoNoteFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.VideoNote;
}

public sealed class InputStickerFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Sticker;
}

public sealed class InputCoverFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Cover;
}

public sealed class InputThumbnailFile(string path) : InputFile(path)
{
    public override InputFileTypes Name => InputFileTypes.Thumbnail;
}