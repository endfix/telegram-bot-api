using System;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Exceptions;

/// <summary>
/// Represents an unsuccessful response returned by the Telegram Bot API.
/// </summary>
/// <param name="errorCode">The Telegram API error code.</param>
/// <param name="description">The error description returned by Telegram.</param>
/// <param name="parameters">Optional response parameters supplied by Telegram.</param>
public sealed class ApiRequestException(int errorCode, string? description, ApiResponseParameters? parameters = null) 
    : Exception(description ?? $"API Error {errorCode}")
{
    /// <summary>
    /// Gets the Telegram API error code.
    /// </summary>
    public int ErrorCode { get; } = errorCode;

    /// <summary>
    /// Gets additional Telegram response parameters, if supplied.
    /// </summary>
    public ApiResponseParameters? Parameters { get; } = parameters;
}
