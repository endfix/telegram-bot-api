using System.IO;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputFile(string path)
{
    public abstract InputFileTypes Type { get; }

    public string FileName { get; } = Path.GetFileName(path);

    public Stream GetStream()
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
    }
}

public sealed class InputCertificateFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Certificate;
}

public sealed class InputPhotoFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Photo;
}

public sealed class InputAudioFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Audio;
}

public sealed class InputDocumentFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Document;
}

public sealed class InputVideoFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Video;
}

public sealed class InputAnimationFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Animation;
}

public sealed class InputVoiceFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Voice;
}

public sealed class InputVideoNoteFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.VideoNote;
}

public sealed class InputStickerFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Sticker;
}

public sealed class InputCoverFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Cover;
}

public sealed class InputThumbnailFile(string path) : InputFile(path)
{
    public override InputFileTypes Type => InputFileTypes.Thumbnail;
}
