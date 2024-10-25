using System.Collections.Generic;
using Telegram.BotAPI.Types.Input;

namespace Telegram.BotAPI.MethodArgs;

public sealed class GetUpdatesArgs : RequestArgs
{
    public long Offset { get; set; }

    public int Limit { get; set; }

    public int Timeout { get; set; }

    public List<string> AllowedUpdates { get; set; }
}

public sealed class SetWebhookArgs : RequestArgs
{
    public string Url { get; set; }

    public string IpAddress { get; set; }

    public int MaxConnections { get; set; }

    public List<string> AllowedUpdates { get; set; }

    public bool DropPendingUpdates { get; set; }

    public string SecretToken { get; set; }

    public SetWebhookArgs()
    {
        //
    }

    public SetWebhookArgs(string certificateFilePath)
    {
        AddInputFile(new InputCertificateFile(certificateFilePath));
    }
}

public sealed class DeleteWebhookArgs : RequestArgs
{
    public bool DropPendingUpdates { get; set; }
}

public sealed class GetWebhookInfoArgs : RequestArgs
{
    //
}
