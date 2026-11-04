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

        if (!IsValidMethodName(methodName))
        {
            throw new ArgumentException(
                "The API method name may contain only ASCII letters, digits, and underscores.",
                nameof(methodName));
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

    private static bool IsValidMethodName(string methodName)
    {
        if (!IsAsciiLetter(methodName[0]))
        {
            return false;
        }

        foreach (var character in methodName)
        {
            if (!IsAsciiLetter(character) &&
                (uint)(character - '0') > '9' - '0' &&
                character != '_')
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsAsciiLetter(char character)
        => (uint)(character - 'A') <= 'Z' - 'A' ||
           (uint)(character - 'a') <= 'z' - 'a';
}
