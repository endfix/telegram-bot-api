using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<Message>> EditMessageTextAsync(EditMessageTextParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageText", parameters));
    }

    public async Task<ApiResponse<Message>> EditMessageCaptionAsync(EditMessageCaptionParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageCaption", parameters));
    }

    public async Task<ApiResponse<Message>> EditMessageMediaAsync(EditMessageMediaParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageMedia", parameters));
    }

    public async Task<ApiResponse<Message>> EditMessageLiveLocationAsync(EditMessageLiveLocationParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters));
    }

    public async Task<ApiResponse<Message>> StopMessageLiveLocationAsync(StopMessageLiveLocationParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters));
    }

    public async Task<ApiResponse<Message>> EditMessageChecklistAsync(EditMessageChecklistParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageChecklist", parameters));
    }

    public async Task<ApiResponse<Message>> EditMessageReplyMarkupAsync(EditMessageReplyMarkupParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters));
    }

    public async Task<ApiResponse<Poll>> StopPollAsync(StopPollParameters parameters)
    {
        return await RequestAsync<Poll>(new ApiRequest("stopPoll", parameters));
    }
    
    public async Task<ApiResponse<bool>> ApproveSuggestedPostAsync(ApproveSuggestedPostParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("approveSuggestedPost", parameters));
    }

    public async Task<ApiResponse<bool>> DeclineSuggestedPostAsync(DeclineSuggestedPostParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("declineSuggestedPost", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteMessageAsync(DeleteMessageParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteMessage", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteMessagesAsync(DeleteMessagesParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteMessages", parameters));
    }

    public async Task<ApiResponse<GiftsStruct>> GetAvailableGiftsAsync(GetAvailableGiftsParameters parameters)
    {
        return await RequestAsync<GiftsStruct>(new ApiRequest("getAvailableGifts", parameters));
    }

    public async Task<ApiResponse<bool>> SendGiftAsync(SendGiftParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("sendGift", parameters));
    }

    public async Task<ApiResponse<bool>> GiftPremiumSubscriptionAsync(GiftPremiumSubscriptionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("giftPremiumSubscription", parameters));
    }

    public async Task<ApiResponse<bool>> VerifyUserAsync(VerifyUserParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("verifyUser", parameters));
    }

    public async Task<ApiResponse<bool>> VerifyChatAsync(VerifyChatParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("verifyChat", parameters));
    }

    public async Task<ApiResponse<bool>> RemoveUserVerificationAsync(RemoveUserVerificationParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("removeUserVerification", parameters));
    }

    public async Task<ApiResponse<bool>> RemoveChatVerificationAsync(RemoveChatVerificationParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("removeChatVerification", parameters));
    }

    public async Task<ApiResponse<bool>> ReadBusinessMessageAsync(ReadBusinessMessageParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("readBusinessMessage", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteBusinessMessagesAsync(DeleteBusinessMessagesParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteBusinessMessages", parameters));
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountNameAsync(SetBusinessAccountNameParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountName", parameters));
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountUsernameAsync(SetBusinessAccountUsernameParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountUsername", parameters));
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountBioAsync(SetBusinessAccountBioParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountBio", parameters));
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountProfilePhotoAsync(SetBusinessAccountProfilePhotoParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountProfilePhoto", parameters));
    }

    public async Task<ApiResponse<bool>> RemoveBusinessAccountProfilePhotoAsync(RemoveBusinessAccountProfilePhotoParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("removeBusinessAccountProfilePhoto", parameters));
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountGiftSettingsAsync(SetBusinessAccountGiftSettingsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountGiftSettings", parameters));
    }

    public async Task<ApiResponse<StarAmount>> GetBusinessAccountStarBalanceAsync(GetBusinessAccountStarBalanceParameters parameters)
    {
        return await RequestAsync<StarAmount>(new ApiRequest("getBusinessAccountStarBalance", parameters));
    }

    public async Task<ApiResponse<bool>> TransferBusinessAccountStarsAsync(TransferBusinessAccountStarsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("transferBusinessAccountStars", parameters));
    }

    public async Task<ApiResponse<OwnedGifts>> GetBusinessAccountGiftsAsync(GetBusinessAccountGiftsParameters parameters)
    {
        return await RequestAsync<OwnedGifts>(new ApiRequest("getBusinessAccountGifts", parameters));
    }

    public async Task<ApiResponse<bool>> ConvertGiftToStarsAsync(ConvertGiftToStarsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("convertGiftToStars", parameters));
    }

    public async Task<ApiResponse<bool>> UpgradeGiftAsync(UpgradeGiftParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("upgradeGift", parameters));
    }

    public async Task<ApiResponse<bool>> TransferGiftAsync(TransferGiftParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("transferGift", parameters));
    }

    public async Task<ApiResponse<Story>> PostStoryAsync(PostStoryParameters parameters)
    {
        return await RequestAsync<Story>(new ApiRequest("postStory", parameters));
    }

    public async Task<ApiResponse<Story>> EditStoryAsync(EditStoryParameters parameters)
    {
        return await RequestAsync<Story>(new ApiRequest("editStory", parameters));
    }

    public async Task<ApiResponse<Story>> DeleteStoryAsync(DeleteStoryParameters parameters)
    {
        return await RequestAsync<Story>(new ApiRequest("deleteStory", parameters));
    }
}
