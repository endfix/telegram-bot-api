namespace Telegram.BotAPI.Types;

public readonly struct DocumentSource
{
    private readonly object _value;
    private DocumentSource(object value) => _value = value;

    public static implicit operator DocumentSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator DocumentSource(InputDocumentFile inputDocumentFile) => new(inputDocumentFile);

    public object Value => _value;
}
