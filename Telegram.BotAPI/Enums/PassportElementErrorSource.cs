namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the part of a Telegram Passport element that contains an error.</summary>
public enum PassportElementErrorSource
{
    /// <summary>A data field.</summary>
    Data,

    /// <summary>The front side of a document.</summary>
    FrontSide,

    /// <summary>The reverse side of a document.</summary>
    ReverseSide,

    /// <summary>A selfie with the document.</summary>
    Selfie,

    /// <summary>One uploaded document file.</summary>
    File,

    /// <summary>A group of uploaded document files.</summary>
    Files,

    /// <summary>One uploaded translation file.</summary>
    TranslationFile,

    /// <summary>A group of uploaded translation files.</summary>
    TranslationFiles,

    /// <summary>An unspecified part of the element.</summary>
    Unspecified
}
