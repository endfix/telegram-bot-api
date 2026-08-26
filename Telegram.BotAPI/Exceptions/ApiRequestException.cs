using System;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Exceptions;

public sealed class ApiRequestException(int errorCode, string? description, ApiResponseParameters? parameters = null) 
    : Exception(description ?? $"API Error {errorCode}")
{
    public int ErrorCode { get; } = errorCode;

    public ApiResponseParameters? Parameters { get; } = parameters;
}
