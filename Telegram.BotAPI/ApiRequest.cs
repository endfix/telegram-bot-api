using System;

namespace Telegram.BotAPI;

public sealed class ApiRequest
{
    
    public string MethodName { get; private set; }

    public ApiRequestParameters Parameters { get; private set; }

    public ApiRequest(string methodName, ApiRequestParameters parameters)
    {
        MethodName = methodName;
        Parameters = parameters;
    }
}
