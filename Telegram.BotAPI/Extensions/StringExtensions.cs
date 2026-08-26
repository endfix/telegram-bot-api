using System.Text;

namespace Endfix.Telegram.BotAPI.Extensions;

public static class StringExtensions
{
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
