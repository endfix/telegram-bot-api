using System.Collections.Generic;

namespace Telegram.BotAPI.Extensions;

public static class ObjectExtensions
{
    public static Dictionary<string, object> ToDictionary(this object obj)
    {
        return (obj.Serialize()).Deserialize<Dictionary<string, object>>();
    }
}
