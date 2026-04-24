namespace Telegram.BotAPI.Protocol;

public sealed class ApiRequest(string methodName, ApiRequestParameters? parameters)
{
    public string MethodName => methodName;

    public ApiRequestParameters? Parameters => parameters;
}
