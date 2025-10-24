using System;

namespace Telegram.BotAPI;

public sealed class ApiRequest(string methodName, ApiRequestParameters parameters)
{
    public string Id => Guid.NewGuid().ToString();

    public string MethodName => methodName;

    public ApiRequestParameters Parameters => parameters;
}
