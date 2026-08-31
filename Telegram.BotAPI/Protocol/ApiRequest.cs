using System;

namespace Endfix.Telegram.BotAPI.Protocol;

public sealed class ApiRequest
{
    public ApiRequest(string methodName, ApiRequestParameters? parameters)
    {
        if (string.IsNullOrWhiteSpace(methodName))
        {
            throw new ArgumentException("The API method name cannot be null or empty.", nameof(methodName));
        }

        MethodName = methodName;
        Parameters = parameters;
    }

    public string MethodName { get; }

    public ApiRequestParameters? Parameters { get; }
}
