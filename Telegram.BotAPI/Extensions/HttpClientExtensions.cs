using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.BotAPI.Extensions;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string url, object args)
    {
        return await client.PostAsync(url, new StringContent(args.Serialize(), Encoding.UTF8, "application/json"));
    }

    public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
    {
        return (await content.ReadAsStringAsync()).Deserialize<T>();
    }
}
