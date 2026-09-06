using System;

namespace Endfix.Telegram.BotAPI.Protocol;

/// <summary>
/// Represents a Telegram Bot API method invocation and its optional parameters.
/// </summary>
public sealed class ApiRequest
{
    /// <summary>
    /// Creates an API request.
    /// </summary>
    /// <param name="methodName">The Telegram Bot API method name.</param>
    /// <param name="parameters">The method parameters, or <see langword="null"/> for a parameterless request.</param>
    public ApiRequest(string methodName, ApiRequestParameters? parameters)
    {
        if (string.IsNullOrWhiteSpace(methodName))
        {
            throw new ArgumentException("The API method name cannot be null or empty.", nameof(methodName));
        }

        MethodName = methodName;
        Parameters = parameters;
    }

    /// <summary>
    /// Gets the Telegram Bot API method name.
    /// </summary>
    public string MethodName { get; }

    /// <summary>
    /// Gets the method parameters, if any.
    /// </summary>
    public ApiRequestParameters? Parameters { get; }
}
