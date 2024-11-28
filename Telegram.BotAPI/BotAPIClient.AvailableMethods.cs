using System.Threading.Tasks;
using System;
using Telegram.BotAPI.Requests.AvailableMethods;
using Telegram.BotAPI.Core;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI;

public partial class BotAPIClient
{
    /// <summary>
    /// As of <see href="https://telegram.org/blog/video-messages-and-telescope">v.4.0</see>, 
    /// Telegram clients support rounded square MPEG4 videos of up to 1 minute long. Use this method to send video messages.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>On success, the sent <see cref="Message">Message</see> is returned.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<ResponseAPI<Message>> SendVideoNoteAsync(SendVideoNoteParameters parameters)
    {
        return await RequestAsync<Message>("sendVideoNote", parameters);
    }
}
