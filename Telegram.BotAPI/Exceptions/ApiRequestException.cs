using System;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Exceptions;

public sealed class ApiRequestException(int errorCode, string? description, ApiResponseParameters? parameters) 
    : Exception(description ?? $"API Error {errorCode}")
{
    public int ErrorCode { get; } = errorCode;

    public ApiResponseParameters? Parameters { get; } = parameters;
}
