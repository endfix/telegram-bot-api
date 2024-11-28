using System.Threading.Tasks;
using Telegram.BotAPI.Core;
using Telegram.BotAPI.Requests.Stickers;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI;

public partial class BotAPIClient
{
    /// <summary>
    /// Use this method to send static .WEBP, animated .TGS, or video .WEBM stickers. 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>On success, the sent <see cref="Message">Message</see> is returned.</returns>
    public async Task<ResponseAPI<Message>> SendStickerAsync(SendStickerParameters parameters)
    {
        //parameters.ReplyParameters ??= new ReplyParameters();
        //parameters.ReplyMarkup ??= new 

        return await RequestAsync<Message>("sendSticker", parameters);
    }

    /*public async Task<ResponseAPI<Message>> SendStickerAsync(SendStickerParameters parameters)
    {
        parameters.ReplyParameters ??= new ReplyParameters();
        //parameters.ReplyMarkup ??= new 

        return await RequestAsync<Message>("sendSticker", parameters);
    }*/
}
