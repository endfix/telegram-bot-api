using Endfix.Telegram.BotAPI.Enums;
using System;
using System.IO;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a typed file uploaded with a Telegram API request.
/// </summary>
public abstract class InputFile
{
    private readonly InputFileSource _source;

    /// <summary>Initializes an uploaded file from a local file path.</summary>
    /// <param name="path">Path of the local file.</param>
    protected InputFile(string path)
        : this(InputFileSource.FromPath(path))
    {
    }

    /// <summary>Initializes an uploaded file from a repeatable source.</summary>
    /// <param name="source">Source used to open a fresh stream for each request attempt.</param>
    protected InputFile(InputFileSource source)
    {
        _source = source ?? throw new System.ArgumentNullException(nameof(source));
    }

    /// <summary>
    /// Gets the Telegram file field type represented by this input.
    /// </summary>
    public abstract InputFileType Type { get; }

    /// <summary>
    /// Gets the file name sent in multipart content disposition.
    /// </summary>
    public string FileName => _source.FileName;

    /// <summary>
    /// Opens a new, independent readable stream. Reading begins at the stream's
    /// current position; the library does not seek or rewind it. The caller owns
    /// and must dispose the returned stream. Each call remains valid independently
    /// of streams returned by earlier or concurrent calls.
    /// </summary>
    /// <returns>A new readable stream owned by the caller.</returns>
    /// <exception cref="FileNotFoundException">A path-backed source file does not exist.</exception>
    /// <exception cref="DirectoryNotFoundException">A path-backed source directory does not exist.</exception>
    /// <exception cref="UnauthorizedAccessException">The source cannot be opened for reading.</exception>
    /// <exception cref="IOException">An I/O error occurs while opening a path-backed source.</exception>
    /// <exception cref="InvalidOperationException">
    /// A stream factory returns <see langword="null"/> or an unreadable stream.
    /// </exception>
    public Stream GetStream() => _source.OpenRead();
}

/// <summary>Represents a certificate file uploaded to Telegram.</summary>
public sealed class InputCertificateFile : InputFile
{
    /// <summary>Creates an input certificate file from a local path.</summary>
    /// <param name="path">Path of the local certificate file.</param>
    public InputCertificateFile(string path) : base(path) { }
    /// <summary>Creates an input certificate file from a repeatable source.</summary>
    /// <param name="source">Source used to open the certificate file.</param>
    public InputCertificateFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Certificate;
}

/// <summary>Represents a photo file uploaded to Telegram.</summary>
public sealed class InputPhotoFile : InputFile
{
    /// <summary>Creates an input photo file from a local path.</summary>
    /// <param name="path">Path of the local photo file.</param>
    public InputPhotoFile(string path) : base(path) { }
    /// <summary>Creates an input photo file from a repeatable source.</summary>
    /// <param name="source">Source used to open the photo file.</param>
    public InputPhotoFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Photo;
}

/// <summary>Represents an audio file uploaded to Telegram.</summary>
public sealed class InputAudioFile : InputFile
{
    /// <summary>Creates an input audio file from a local path.</summary>
    /// <param name="path">Path of the local audio file.</param>
    public InputAudioFile(string path) : base(path) { }
    /// <summary>Creates an input audio file from a repeatable source.</summary>
    /// <param name="source">Source used to open the audio file.</param>
    public InputAudioFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Audio;
}

/// <summary>Represents a document file uploaded to Telegram.</summary>
public sealed class InputDocumentFile : InputFile
{
    /// <summary>Creates an input document file from a local path.</summary>
    /// <param name="path">Path of the local document file.</param>
    public InputDocumentFile(string path) : base(path) { }
    /// <summary>Creates an input document file from a repeatable source.</summary>
    /// <param name="source">Source used to open the document file.</param>
    public InputDocumentFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Document;
}

/// <summary>Represents a video file uploaded to Telegram.</summary>
public sealed class InputVideoFile : InputFile
{
    /// <summary>Creates an input video file from a local path.</summary>
    /// <param name="path">Path of the local video file.</param>
    public InputVideoFile(string path) : base(path) { }
    /// <summary>Creates an input video file from a repeatable source.</summary>
    /// <param name="source">Source used to open the video file.</param>
    public InputVideoFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Video;
}

/// <summary>Represents an animation file uploaded to Telegram.</summary>
public sealed class InputAnimationFile : InputFile
{
    /// <summary>Creates an input animation file from a local path.</summary>
    /// <param name="path">Path of the local animation file.</param>
    public InputAnimationFile(string path) : base(path) { }
    /// <summary>Creates an input animation file from a repeatable source.</summary>
    /// <param name="source">Source used to open the animation file.</param>
    public InputAnimationFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Animation;
}

/// <summary>Represents a voice file uploaded to Telegram.</summary>
public sealed class InputVoiceFile : InputFile
{
    /// <summary>Creates an input voice file from a local path.</summary>
    /// <param name="path">Path of the local voice file.</param>
    public InputVoiceFile(string path) : base(path) { }
    /// <summary>Creates an input voice file from a repeatable source.</summary>
    /// <param name="source">Source used to open the voice file.</param>
    public InputVoiceFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Voice;
}

/// <summary>Represents a video note file uploaded to Telegram.</summary>
public sealed class InputVideoNoteFile : InputFile
{
    /// <summary>Creates an input video note file from a local path.</summary>
    /// <param name="path">Path of the local video note file.</param>
    public InputVideoNoteFile(string path) : base(path) { }
    /// <summary>Creates an input video note file from a repeatable source.</summary>
    /// <param name="source">Source used to open the video note file.</param>
    public InputVideoNoteFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.VideoNote;
}

/// <summary>Represents a sticker file uploaded to Telegram.</summary>
public sealed class InputStickerFile : InputFile
{
    /// <summary>Creates an input sticker file from a local path.</summary>
    /// <param name="path">Path of the local sticker file.</param>
    public InputStickerFile(string path) : base(path) { }
    /// <summary>Creates an input sticker file from a repeatable source.</summary>
    /// <param name="source">Source used to open the sticker file.</param>
    public InputStickerFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Sticker;
}

/// <summary>Represents a cover file uploaded to Telegram.</summary>
public sealed class InputCoverFile : InputFile
{
    /// <summary>Creates an input cover file from a local path.</summary>
    /// <param name="path">Path of the local cover file.</param>
    public InputCoverFile(string path) : base(path) { }
    /// <summary>Creates an input cover file from a repeatable source.</summary>
    /// <param name="source">Source used to open the cover file.</param>
    public InputCoverFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Cover;
}

/// <summary>Represents a thumbnail file uploaded to Telegram.</summary>
public sealed class InputThumbnailFile : InputFile
{
    /// <summary>Creates an input thumbnail file from a local path.</summary>
    /// <param name="path">Path of the local thumbnail file.</param>
    public InputThumbnailFile(string path) : base(path) { }
    /// <summary>Creates an input thumbnail file from a repeatable source.</summary>
    /// <param name="source">Source used to open the thumbnail file.</param>
    public InputThumbnailFile(InputFileSource source) : base(source) { }
    /// <inheritdoc />
    public override InputFileType Type => InputFileType.Thumbnail;
}
