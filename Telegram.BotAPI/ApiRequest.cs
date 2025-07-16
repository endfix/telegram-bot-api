using System;

namespace Telegram.BotAPI;

public sealed class ApiRequest(string methodName, ApiRequestParameters parameters)
{
    public string Id { get; } = Guid.NewGuid().ToString();

    public string MethodName { get; } = methodName;

    public ApiRequestParameters Parameters { get; } = parameters;
}
