using System;

namespace Telegram.BotAPI.Core;

public class DebugEventArgs(string message) : EventArgs
{
    public string Message { get; private set; } = message;
}
