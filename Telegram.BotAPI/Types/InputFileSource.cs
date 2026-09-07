using System;
using System.IO;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a repeatable source for a file uploaded with a Telegram API request.
/// </summary>
public abstract class InputFileSource
{
    private protected InputFileSource(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("The file name cannot be null or empty.", nameof(fileName));
        }

        FileName = Path.GetFileName(fileName);
        if (FileName.Length == 0)
        {
            throw new ArgumentException("The file name cannot be empty.", nameof(fileName));
        }
    }

    /// <summary>
    /// Gets the file name sent in the multipart content disposition.
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Creates a source that opens the specified local file for every request attempt.
    /// </summary>
    /// <remarks>
    /// The file is not opened until the request consumes the source. File-system
    /// errors are reported by <see cref="InputFile.GetStream"/> at that time.
    /// </remarks>
    /// <param name="path">Path of the local file.</param>
    /// <returns>A repeatable file source backed by the local path.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="path"/> is empty, consists only of white-space characters,
    /// or does not contain a file name.
    /// </exception>
    public static InputFileSource FromPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("The file path cannot be null or empty.", nameof(path));
        }

        return new PathInputFileSource(path);
    }

    /// <summary>
    /// Creates a source from an in-memory snapshot of the supplied content.
    /// </summary>
    /// <param name="content">File content copied into the source.</param>
    /// <param name="fileName">File name sent in the multipart content disposition.</param>
    /// <returns>A repeatable in-memory file source.</returns>
    public static InputFileSource FromMemory(ReadOnlyMemory<byte> content, string fileName) =>
        new MemoryInputFileSource(content.ToArray(), fileName);

    /// <summary>
    /// Creates a source that obtains a new readable stream for every request attempt.
    /// The factory may be invoked repeatedly or concurrently and must return an
    /// independent readable stream on every call. The consumer reads from the current
    /// position without seeking or rewinding and owns the returned stream.
    /// Calls made while retrying the same request must expose equivalent content.
    /// Exceptions thrown by the factory propagate to the caller and stop the request.
    /// </summary>
    /// <param name="streamFactory">Factory that returns a new independent readable stream on every call.</param>
    /// <param name="fileName">File name sent in the multipart content disposition.</param>
    /// <returns>A repeatable stream-backed file source.</returns>
    public static InputFileSource FromStream(Func<Stream> streamFactory, string fileName)
    {
        if (streamFactory is null)
        {
            throw new ArgumentNullException(nameof(streamFactory));
        }

        return new StreamInputFileSource(streamFactory, fileName);
    }

    internal abstract Stream OpenRead();

    private sealed class PathInputFileSource(string path) : InputFileSource(path)
    {
        private readonly string _path = path;

        internal override Stream OpenRead() =>
            new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
    }

    private sealed class MemoryInputFileSource(byte[] content, string fileName) : InputFileSource(fileName)
    {
        internal override Stream OpenRead() => new MemoryStream(content, writable: false);
    }

    private sealed class StreamInputFileSource(Func<Stream> streamFactory, string fileName) : InputFileSource(fileName)
    {
        internal override Stream OpenRead()
        {
            var stream = streamFactory()
                ?? throw new InvalidOperationException("The input file stream factory returned null.");

            if (stream.CanRead)
            {
                return stream;
            }

            stream.Dispose();
            throw new InvalidOperationException("The input file stream factory returned an unreadable stream.");
        }
    }
}
