namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a document supplied by a file ID, URL, or input file.</summary>
public readonly struct DocumentSource : IFileSource
{
    private readonly object _value;
    private DocumentSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a document source.</summary>
    /// <param name="fileIdOrUrl">Telegram file ID or HTTP URL of the document.</param>
    /// <returns>A document source containing the supplied value.</returns>
    public static implicit operator DocumentSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a document source.</summary>
    /// <param name="inputDocumentFile">Document file to upload.</param>
    /// <returns>A document source containing the supplied input file.</returns>
    public static implicit operator DocumentSource(InputDocumentFile inputDocumentFile) => new(inputDocumentFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
