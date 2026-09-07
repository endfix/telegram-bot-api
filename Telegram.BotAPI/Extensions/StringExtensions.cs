using System.Text;

namespace Endfix.Telegram.BotAPI.Extensions;

/// <summary>Provides string conversion helpers.</summary>
public static class StringExtensions
{
    /// <summary>Converts a PascalCase or camelCase identifier to snake_case.</summary>
    /// <param name="text">Identifier to convert.</param>
    /// <returns>The snake_case identifier, or the original value when it is null or empty.</returns>
    public static string ToSnake(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var sb = new StringBuilder(text.Length + text.Length / 2);

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (char.IsUpper(c))
            {
                if (i > 0) sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
