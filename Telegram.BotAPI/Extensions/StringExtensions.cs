using System.Linq;

namespace Telegram.BotAPI.Extensions;

public static class StringExtensions
{
    public static string ToSnake(this string text)
    {
        return string.Concat(text.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + char.ToLowerInvariant(x).ToString() : char.ToLowerInvariant(x).ToString()));
    }
}
