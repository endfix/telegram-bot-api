using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static class BotApiClientExtensions
{
    #region Available Methods
    public static async Task<ApiResponse<User>> GetMeAsync(this BotApiClient api, GetMeParameters parameters = null)
    {
        return await api.RequestAsync<User>(new ApiRequest("getMe", parameters));
    }

    public static async Task<ApiResponse<bool>> LogOutAsync(this BotApiClient api, LogOutParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("logOut", parameters));
    }

    public static async Task<ApiResponse<bool>> CloseAsync(this BotApiClient api, CloseParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("close", parameters));
    }

    public static async Task<ApiResponse<Message>> SendMessageAsync(this BotApiClient api, SendMessageParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendMessage", parameters));
    }

    public static async Task<ApiResponse<Message>> ForwardMessageAsync(this BotApiClient api, ForwardMessageParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("forwardMessage", parameters));
    }

    public static async Task<ApiResponse<MessageIdStruct[]>> ForwardMessagesAsync(this BotApiClient api, ForwardMessagesParameters parameters)
    {
        return await api.RequestAsync<MessageIdStruct[]>(new ApiRequest("forwardMessages", parameters));
    }

    public static async Task<ApiResponse<MessageIdStruct>> CopyMessageAsync(this BotApiClient api, CopyMessageParameters parameters)
    {
        return await api.RequestAsync<MessageIdStruct>(new ApiRequest("copyMessage", parameters));
    }

    public static async Task<ApiResponse<MessageIdStruct[]>> CopyMessagesAsync(this BotApiClient api, CopyMessagesParameters parameters)
    {
        return await api.RequestAsync<MessageIdStruct[]>(new ApiRequest("copyMessages", parameters));
    }

    public static async Task<ApiResponse<Message>> SendPhotoAsync(this BotApiClient api, SendPhotoParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendPhoto", parameters));
    }

    public static async Task<ApiResponse<Message>> SendAudioAsync(this BotApiClient api, SendAudioParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendAudio", parameters));
    }

    public static async Task<ApiResponse<Message>> SendDocumentAsync(this BotApiClient api, SendDocumentParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendDocument", parameters));
    }

    public static async Task<ApiResponse<Message>> SendVideoAsync(this BotApiClient api, SendVideoParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendVideo", parameters));
    }

    public static async Task<ApiResponse<Message>> SendAnimationAsync(this BotApiClient api, SendAnimationParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendAnimation", parameters));
    }

    public static async Task<ApiResponse<Message>> SendVoiceAsync(this BotApiClient api, SendVoiceParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendVoice", parameters));
    }

    public static async Task<ApiResponse<Message>> SendVideoNoteAsync(this BotApiClient api, SendVideoNoteParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendVideoNote", parameters));
    }

    public static async Task<ApiResponse<Message>> SendPaidMediaAsync(this BotApiClient api, SendPaidMediaParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendPaidMedia", parameters));
    }

    public static async Task<ApiResponse<Message[]>> SendMediaGroupAsync(this BotApiClient api, SendMediaGroupParameters parameters)
    {
        return await api.RequestAsync<Message[]>(new ApiRequest("sendMediaGroup", parameters));
    }

    public static async Task<ApiResponse<Message>> SendLocationAsync(this BotApiClient api, SendLocationParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendLocation", parameters));
    }

    public static async Task<ApiResponse<Message>> SendVenueAsync(this BotApiClient api, SendVenueParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendVenue", parameters));
    }

    public static async Task<ApiResponse<Message>> SendContactAsync(this BotApiClient api, SendContactParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendContact", parameters));
    }

    public static async Task<ApiResponse<Message>> SendPollAsync(this BotApiClient api, SendPollParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendPoll", parameters));
    }

    public static async Task<ApiResponse<Message>> SendDiceAsync(this BotApiClient api, SendDiceParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendDice", parameters));
    }

    public static async Task<ApiResponse<bool>> SendChatActionAsync(this BotApiClient api, SendChatActionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("sendChatAction", parameters));
    }

    public static async Task<ApiResponse<bool>> SetMessageReactionAsync(this BotApiClient api, SetMessageReactionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setMessageReaction", parameters));
    }

    public static async Task<ApiResponse<UserProfilePhotos>> GetUserProfilePhotosAsync(this BotApiClient api, GetUserProfilePhotosParameters parameters)
    {
        return await api.RequestAsync<UserProfilePhotos>(new ApiRequest("getUserProfilePhotos", parameters));
    }

    public static async Task<ApiResponse<bool>> SetUserEmojiStatusAsync(this BotApiClient api, SetUserEmojiStatusParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setUserEmojiStatus", parameters));
    }

    public static async Task<ApiResponse<File>> GetFileAsync(this BotApiClient api, GetFileParameters parameters)
    {
        return await api.RequestAsync<File>(new ApiRequest("getFile", parameters));
    }

    public static async Task<ApiResponse<bool>> BanChatMemberAsync(this BotApiClient api, BanChatMemberParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("banChatMember", parameters));
    }

    public static async Task<ApiResponse<bool>> UnbanChatMemberAsync(this BotApiClient api, UnbanChatMemberParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unbanChatMember", parameters));
    }

    public static async Task<ApiResponse<bool>> RestrictChatMemberAsync(this BotApiClient api, RestrictChatMemberParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("restrictChatMember", parameters));
    }

    public static async Task<ApiResponse<bool>> PromoteChatMemberAsync(this BotApiClient api, PromoteChatMemberParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("promoteChatMember", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatAdministratorCustomTitleAsync(this BotApiClient api, SetChatAdministratorCustomTitleParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatAdministratorCustomTitle", parameters));
    }

    public static async Task<ApiResponse<bool>> BanChatSenderChatAsync(this BotApiClient api, BanChatSenderChatParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("banChatSenderChat", parameters));
    }

    public static async Task<ApiResponse<bool>> UnbanChatSenderChatAsync(this BotApiClient api, UnbanChatSenderChatParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unbanChatSenderChat", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatPermissionsAsync(this BotApiClient api, SetChatPermissionsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatPermissions", parameters));
    }

    public static async Task<ApiResponse<string>> ExportChatInviteLinkAsync(this BotApiClient api, ExportChatInviteLinkParameters parameters)
    {
        return await api.RequestAsync<string>(new ApiRequest("exportChatInviteLink", parameters));
    }

    public static async Task<ApiResponse<ChatInviteLink>> CreateChatInviteLinkAsync(this BotApiClient api, CreateChatInviteLinkParameters parameters)
    {
        return await api.RequestAsync<ChatInviteLink>(new ApiRequest("createChatInviteLink", parameters));
    }

    public static async Task<ApiResponse<ChatInviteLink>> EditChatInviteLinkAsync(this BotApiClient api, EditChatInviteLinkParameters parameters)
    {
        return await api.RequestAsync<ChatInviteLink>(new ApiRequest("editChatInviteLink", parameters));
    }

    public static async Task<ApiResponse<ChatInviteLink>> CreateChatSubscriptionInviteLinkAsync(this BotApiClient api, CreateChatSubscriptionInviteLinkParameters parameters)
    {
        return await api.RequestAsync<ChatInviteLink>(new ApiRequest("createChatSubscriptionInviteLink", parameters));
    }

    public static async Task<ApiResponse<ChatInviteLink>> EditChatSubscriptionInviteLinkAsync(this BotApiClient api, EditChatSubscriptionInviteLinkParameters parameters)
    {
        return await api.RequestAsync<ChatInviteLink>(new ApiRequest("editChatSubscriptionInviteLink", parameters));
    }

    public static async Task<ApiResponse<ChatInviteLink>> RevokeChatInviteLinkAsync(this BotApiClient api, RevokeChatInviteLinkParameters parameters)
    {
        return await api.RequestAsync<ChatInviteLink>(new ApiRequest("revokeChatInviteLink", parameters));
    }

    public static async Task<ApiResponse<bool>> ApproveChatJoinRequestAsync(this BotApiClient api, ApproveChatJoinRequestParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("approveChatJoinRequest", parameters));
    }

    public static async Task<ApiResponse<bool>> DeclineChatJoinRequestAsync(this BotApiClient api, DeclineChatJoinRequestParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("declineChatJoinRequest", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatPhotoAsync(this BotApiClient api, SetChatPhotoParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatPhoto", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteChatPhotoAsync(this BotApiClient api, DeleteChatPhotoParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteChatPhoto", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatTitleAsync(this BotApiClient api, SetChatTitleParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatTitle", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatDescriptionAsync(this BotApiClient api, SetChatDescriptionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatDescription", parameters));
    }

    public static async Task<ApiResponse<bool>> PinChatMessageAsync(this BotApiClient api, PinChatMessageParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("pinChatMessage", parameters));
    }

    public static async Task<ApiResponse<bool>> UnpinChatMessageAsync(this BotApiClient api, UnpinChatMessageParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unpinChatMessage", parameters));
    }

    public static async Task<ApiResponse<bool>> UnpinAllChatMessagesAsync(this BotApiClient api, UnpinAllChatMessagesParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unpinAllChatMessages", parameters));
    }

    public static async Task<ApiResponse<bool>> LeaveChatAsync(this BotApiClient api, LeaveChatParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("leaveChat", parameters));
    }

    public static async Task<ApiResponse<ChatFullInfo>> GetChatAsync(this BotApiClient api, GetChatParameters parameters)
    {
        return await api.RequestAsync<ChatFullInfo>(new ApiRequest("getChat", parameters));
    }

    public static async Task<ApiResponse<ChatMember[]>> GetChatAdministratorsAsync(this BotApiClient api, GetChatAdministratorsParameters parameters)
    {
        return await api.RequestAsync<ChatMember[]>(new ApiRequest("getChatAdministrators", parameters));
    }

    public static async Task<ApiResponse<int>> GetChatMemberCountAsync(this BotApiClient api, GetChatMemberCountParameters parameters)
    {
        return await api.RequestAsync<int>(new ApiRequest("getChatMemberCount", parameters));
    }

    public static async Task<ApiResponse<ChatMember>> GetChatMemberAsync(this BotApiClient api, GetChatMemberParameters parameters)
    {
        return await api.RequestAsync<ChatMember>(new ApiRequest("getChatMember", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatStickerSetAsync(this BotApiClient api, SetChatStickerSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatStickerSet", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteChatStickerSetAsync(this BotApiClient api, DeleteChatStickerSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteChatStickerSet", parameters));
    }

    public static async Task<ApiResponse<Sticker[]>> GetForumTopicIconStickersAsync(this BotApiClient api, GetForumTopicIconStickersParameters parameters)
    {
        return await api.RequestAsync<Sticker[]>(new ApiRequest("getForumTopicIconStickers", parameters));
    }

    public static async Task<ApiResponse<ForumTopic>> CreateForumTopicAsync(this BotApiClient api, CreateForumTopicParameters parameters)
    {
        return await api.RequestAsync<ForumTopic>(new ApiRequest("createForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> EditForumTopicAsync(this BotApiClient api, EditForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("editForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> CloseForumTopicAsync(this BotApiClient api, CloseForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("closeForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> ReopenForumTopicAsync(this BotApiClient api, ReopenForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("reopenForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteForumTopicAsync(this BotApiClient api, DeleteForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> UnpinAllForumTopicMessagesAsync(this BotApiClient api, UnpinAllForumTopicMessagesParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unpinAllForumTopicMessages", parameters));
    }

    public static async Task<ApiResponse<bool>> EditGeneralForumTopicAsync(this BotApiClient api, EditGeneralForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("editGeneralForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> CloseGeneralForumTopicAsync(this BotApiClient api, CloseGeneralForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("closeGeneralForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> ReopenGeneralForumTopicAsync(this BotApiClient api, ReopenGeneralForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("reopenGeneralForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> HideGeneralForumTopicAsync(this BotApiClient api, HideGeneralForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("hideGeneralForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> UnhideGeneralForumTopicAsync(this BotApiClient api, UnhideGeneralForumTopicParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unhideGeneralForumTopic", parameters));
    }

    public static async Task<ApiResponse<bool>> UnpinAllGeneralForumTopicMessagesAsync(this BotApiClient api, UnpinAllGeneralForumTopicMessagesParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("unpinAllGeneralForumTopicMessages", parameters));
    }

    public static async Task<ApiResponse<bool>> AnswerCallbackQueryAsync(this BotApiClient api, AnswerCallbackQueryParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("answerCallbackQuery", parameters));
    }

    public static async Task<ApiResponse<UserChatBoosts>> GetUserChatBoostsAsync(this BotApiClient api, GetUserChatBoostsParameters parameters)
    {
        return await api.RequestAsync<UserChatBoosts>(new ApiRequest("getUserChatBoosts", parameters));
    }

    public static async Task<ApiResponse<BusinessConnection>> GetBusinessConnectionAsync(this BotApiClient api, GetBusinessConnectionParameters parameters)
    {
        return await api.RequestAsync<BusinessConnection>(new ApiRequest("getBusinessConnection", parameters));
    }

    public static async Task<ApiResponse<bool>> SetMyCommandsAsync(this BotApiClient api, SetMyCommandsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setMyCommands", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteMyCommandsAsync(this BotApiClient api, DeleteMyCommandsParameters parameters = null)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteMyCommands", parameters));
    }

    public static async Task<ApiResponse<BotCommand[]>> GetMyCommandsAsync(this BotApiClient api, GetMyCommandsParameters parameters = null)
    {
        return await api.RequestAsync<BotCommand[]>(new ApiRequest("getMyCommands", parameters));
    }

    public static async Task<ApiResponse<bool>> SetMyNameAsync(this BotApiClient api, SetMyNameParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setMyName", parameters));
    }

    public static async Task<ApiResponse<BotName>> GetMyNameAsync(this BotApiClient api, GetMyNameParameters parameters)
    {
        return await api.RequestAsync<BotName>(new ApiRequest("getMyName", parameters));
    }

    public static async Task<ApiResponse<bool>> SetMyDescriptionAsync(this BotApiClient api, SetMyDescriptionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setMyDescription", parameters));
    }

    public static async Task<ApiResponse<BotDescription>> GetMyDescriptionAsync(this BotApiClient api, GetMyDescriptionParameters parameters)
    {
        return await api.RequestAsync<BotDescription>(new ApiRequest("getMyDescription", parameters));
    }

    public static async Task<ApiResponse<bool>> SetMyShortDescriptionAsync(this BotApiClient api, SetMyShortDescriptionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setMyShortDescription", parameters));
    }

    public static async Task<ApiResponse<BotShortDescription>> GetMyShortDescriptionAsync(this BotApiClient api, GetMyShortDescriptionParameters parameters)
    {
        return await api.RequestAsync<BotShortDescription>(new ApiRequest("getMyShortDescription", parameters));
    }

    public static async Task<ApiResponse<bool>> SetChatMenuButtonAsync(this BotApiClient api, SetChatMenuButtonParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setChatMenuButton", parameters));
    }

    public static async Task<ApiResponse<MenuButton>> GetChatMenuButtonAsync(this BotApiClient api, GetChatMenuButtonParameters parameters)
    {
        return await api.RequestAsync<MenuButton>(new ApiRequest("getChatMenuButton", parameters));
    }

    public static async Task<ApiResponse<bool>> SetMyDefaultAdministratorRightsAsync(this BotApiClient api, SetMyDefaultAdministratorRightsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setMyDefaultAdministratorRights", parameters));
    }

    public static async Task<ApiResponse<ChatAdministratorRights>> GetMyDefaultAdministratorRightsAsync(this BotApiClient api, GetMyDefaultAdministratorRightsParameters parameters)
    {
        return await api.RequestAsync<ChatAdministratorRights>(new ApiRequest("getMyDefaultAdministratorRights", parameters));
    }
    #endregion

    #region Updating Messages
    public static async Task<ApiResponse<Message>> EditMessageTextAsync(this BotApiClient api, EditMessageTextParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("editMessageText", parameters));
    }

    public static async Task<ApiResponse<Message>> EditMessageCaptionAsync(this BotApiClient api, EditMessageCaptionParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("editMessageCaption", parameters));
    }

    public static async Task<ApiResponse<Message>> EditMessageMediaAsync(this BotApiClient api, EditMessageMediaParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("editMessageMedia", parameters));
    }

    public static async Task<ApiResponse<Message>> EditMessageLiveLocationAsync(this BotApiClient api, EditMessageLiveLocationParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters));
    }

    public static async Task<ApiResponse<Message>> StopMessageLiveLocationAsync(this BotApiClient api, StopMessageLiveLocationParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters));
    }

    public static async Task<ApiResponse<Message>> EditMessageReplyMarkupAsync(this BotApiClient api, EditMessageReplyMarkupParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters));
    }

    public static async Task<ApiResponse<Poll>> StopPollAsync(this BotApiClient api, StopPollParameters parameters)
    {
        return await api.RequestAsync<Poll>(new ApiRequest("stopPoll", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteMessageAsync(this BotApiClient api, DeleteMessageParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteMessage", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteMessagesAsync(this BotApiClient api, DeleteMessagesParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteMessages", parameters));
    }

    public static async Task<ApiResponse<GiftsStruct>> GetAvailableGiftsAsync(this BotApiClient api, GetAvailableGiftsParameters parameters)
    {
        return await api.RequestAsync<GiftsStruct>(new ApiRequest("getAvailableGifts", parameters));
    }

    public static async Task<ApiResponse<bool>> SendGiftAsync(this BotApiClient api, SendGiftParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("sendGift", parameters));
    }

    /*public static async Task<ApiResponse<bool>> GiftPremiumSubscriptionAsync(this BotApiClient api, GiftPremiumSubscriptionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("giftPremiumSubscription", parameters));
    }*/

    public static async Task<ApiResponse<bool>> VerifyUserAsync(this BotApiClient api, VerifyUserParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("verifyUser", parameters));
    }

    public static async Task<ApiResponse<bool>> VerifyChatAsync(this BotApiClient api, VerifyChatParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("verifyChat", parameters));
    }

    public static async Task<ApiResponse<bool>> RemoveUserVerificationAsync(this BotApiClient api, RemoveUserVerificationParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("removeUserVerification", parameters));
    }

    public static async Task<ApiResponse<bool>> RemoveChatVerificationAsync(this BotApiClient api, RemoveChatVerificationParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("removeChatVerification", parameters));
    }

    /*public static async Task<ApiResponse<bool>> ReadBusinessMessageAsync(this BotApiClient api, ReadBusinessMessageParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("readBusinessMessage", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteBusinessMessagesAsync(this BotApiClient api, DeleteBusinessMessagesParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteBusinessMessages", parameters));
    }

    public static async Task<ApiResponse<bool>> SetBusinessAccountNameAsync(this BotApiClient api, SetBusinessAccountNameParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setBusinessAccountName", parameters));
    }

    public static async Task<ApiResponse<bool>> SetBusinessAccountUsernameAsync(this BotApiClient api, SetBusinessAccountUsernameParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setBusinessAccountUsername", parameters));
    }

    public static async Task<ApiResponse<bool>> SetBusinessAccountBioAsync(this BotApiClient api, SetBusinessAccountBioParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setBusinessAccountBio", parameters));
    }

    public static async Task<ApiResponse<bool>> SetBusinessAccountProfilePhotoAsync(this BotApiClient api, SetBusinessAccountProfilePhotoParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setBusinessAccountProfilePhoto", parameters));
    }

    public static async Task<ApiResponse<bool>> RemoveBusinessAccountProfilePhotoAsync(this BotApiClient api, RemoveBusinessAccountProfilePhotoParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("removeBusinessAccountProfilePhoto", parameters));
    }

    public static async Task<ApiResponse<bool>> SetBusinessAccountGiftSettingsAsync(this BotApiClient api, SetBusinessAccountGiftSettingsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setBusinessAccountGiftSettings", parameters));
    }

    public static async Task<ApiResponse<StarAmount>> GetBusinessAccountStarBalanceAsync(this BotApiClient api, GetBusinessAccountStarBalanceParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("getBusinessAccountStarBalance", parameters));
    }

    public static async Task<ApiResponse<bool>> TransferBusinessAccountStarsAsync(this BotApiClient api, TransferBusinessAccountStarsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("transferBusinessAccountStars", parameters));
    }

    public static async Task<ApiResponse<OwnedGifts>> GetBusinessAccountGiftsAsync(this BotApiClient api, GetBusinessAccountGiftsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("getBusinessAccountGifts", parameters));
    }

    public static async Task<ApiResponse<bool>> ConvertGiftToStarsAsync(this BotApiClient api, ConvertGiftToStarsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("convertGiftToStars", parameters));
    }

    public static async Task<ApiResponse<bool>> UpgradeGiftAsync(this BotApiClient api, UpgradeGiftParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("upgradeGift", parameters));
    }

    public static async Task<ApiResponse<bool>> TransferGiftAsync(this BotApiClient api, TransferGiftParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("transferGift", parameters));
    }

    public static async Task<ApiResponse<Story>> PostStoryAsync(this BotApiClient api, PostStoryParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("postStory", parameters));
    }

    public static async Task<ApiResponse<Story>> EditStoryAsync(this BotApiClient api, EditStoryParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("editStory", parameters));
    }

    public static async Task<ApiResponse<Story>> DeleteStoryAsync(this BotApiClient api, DeleteStoryParameters parameters)
    {
        return await api.RequestAsync<Story>(new ApiRequest("deleteStory", parameters));
    }*/
    #endregion

    #region Telegram Passport
    public static async Task<ApiResponse<bool>> SetPassportDataErrorsAsync(this BotApiClient api, SetPassportDataErrorsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setPassportDataErrors", parameters));
    }
    #endregion

    #region Payments
    public static async Task<ApiResponse<Message>> SendInvoiceAsync(this BotApiClient api, SendInvoiceParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendInvoice", parameters));
    }

    public static async Task<ApiResponse<string>> CreateInvoiceLinkAsync(this BotApiClient api, CreateInvoiceLinkParameters parameters)
    {
        return await api.RequestAsync<string>(new ApiRequest("createInvoiceLink", parameters));
    }

    public static async Task<ApiResponse<bool>> AnswerShippingQueryAsync(this BotApiClient api, AnswerShippingQueryParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("answerShippingQuery", parameters));
    }

    public static async Task<ApiResponse<bool>> AnswerPreCheckoutQueryAsync(this BotApiClient api, AnswerPreCheckoutQueryParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters));
    }

    public static async Task<ApiResponse<StarTransactions>> GetStarTransactionsAsync(this BotApiClient api, GetStarTransactionsyParameters parameters)
    {
        return await api.RequestAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters));
    }

    public static async Task<ApiResponse<bool>> RefundStarPaymentAsync(this BotApiClient api, RefundStarPaymentParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("refundStarPayment", parameters));
    }

    public static async Task<ApiResponse<bool>> EditUserStarSubscriptionAsync(this BotApiClient api, EditUserStarSubscriptionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("editUserStarSubscription", parameters));
    }
    #endregion

    #region Stickers
    public static async Task<ApiResponse<Message>> SendStickerAsync(this BotApiClient api, SendStickerParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendSticker", parameters));
    }

    public static async Task<ApiResponse<StickerSet>> GetStickerSetAsync(this BotApiClient api, GetStickerSetParameters parameters)
    {
        return await api.RequestAsync<StickerSet>(new ApiRequest("getStickerSet", parameters));
    }

    public static async Task<ApiResponse<Sticker[]>> GetCustomEmojiStickersAsync(this BotApiClient api, GetCustomEmojiStickersParameters parameters)
    {
        return await api.RequestAsync<Sticker[]>(new ApiRequest("getCustomEmojiStickers", parameters));
    }

    public static async Task<ApiResponse<File>> UploadStickerFileAsync(this BotApiClient api, UploadStickerFileParameters parameters)
    {
        return await api.RequestAsync<File>(new ApiRequest("uploadStickerFile", parameters));
    }

    public static async Task<ApiResponse<bool>> CreateNewStickerSetAsync(this BotApiClient api, CreateNewStickerSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("createNewStickerSet", parameters));
    }

    public static async Task<ApiResponse<bool>> AddStickerToSetAsync(this BotApiClient api, AddStickerToSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("addStickerToSet", parameters));
    }

    public static async Task<ApiResponse<bool>> SetStickerPositionInSetAsync(this BotApiClient api, SetStickerPositionInSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteStickerFromSetAsync(this BotApiClient api, DeleteStickerFromSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters));
    }

    public static async Task<ApiResponse<bool>> ReplaceStickerInSetAsync(this BotApiClient api, ReplaceStickerInSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("replaceStickerInSet", parameters));
    }

    public static async Task<ApiResponse<bool>> SetStickerEmojiListAsync(this BotApiClient api, SetStickerEmojiListParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setStickerEmojiList", parameters));
    }

    public static async Task<ApiResponse<bool>> SetStickerKeywordsAsync(this BotApiClient api, SetStickerKeywordsParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setStickerKeywords", parameters));
    }

    public static async Task<ApiResponse<bool>> SetStickerMaskPositionAsync(this BotApiClient api, SetStickerMaskPositionParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters));
    }

    public static async Task<ApiResponse<bool>> SetStickerSetTitleAsync(this BotApiClient api, SetStickerSetTitleParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setStickerSetTitle", parameters));
    }

    public static async Task<ApiResponse<bool>> SetStickerSetThumbnailAsync(this BotApiClient api, SetStickerSetThumbnailParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters));
    }

    public static async Task<ApiResponse<bool>> SetCustomEmojiStickerSetThumbnailAsync(this BotApiClient api, SetCustomEmojiStickerSetThumbnailParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteStickerSetAsync(this BotApiClient api, DeleteStickerSetParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteStickerSet", parameters));
    }
    #endregion

    #region Inline Mode
    public static async Task<ApiResponse<bool>> AnswerInlineQueryAsync(this BotApiClient api, AnswerInlineQueryParameters parameters)
    {
        return await api.RequestAsync<bool>(new ApiRequest("answerInlineQuery", parameters));
    }

    public static async Task<ApiResponse<SentWebAppMessage>> AnswerWebAppQueryAsync(this BotApiClient api, AnswerWebAppQueryParameters parameters)
    {
        return await api.RequestAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters));
    }

    public static async Task<ApiResponse<PreparedInlineMessage>> SavePreparedInlineMessageAsync(this BotApiClient api, SavePreparedInlineMessageParameters parameters)
    {
        return await api.RequestAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters));
    }
    #endregion

    #region Getting Updates
    public static async Task<ApiResponse<Update[]>> GetUpdatesAsync(this BotApiClient api, GetUpdatesParameters parameters = null)
    {
        return await api.RequestAsync<Update[]>(new ApiRequest("getUpdates", parameters));
    }

    public static async Task<ApiResponse<bool>> SetWebhookAsync(this BotApiClient api, SetWebhookParameters parameters = null)
    {
        return await api.RequestAsync<bool>(new ApiRequest("setWebhook", parameters));
    }

    public static async Task<ApiResponse<bool>> DeleteWebhookAsync(this BotApiClient api, DeleteWebhookParameters parameters = null)
    {
        return await api.RequestAsync<bool>(new ApiRequest("deleteWebhook", parameters));
    }

    public static async Task<ApiResponse<WebhookInfo>> GetWebhookInfoAsync(this BotApiClient api, GetWebhookInfoParameters parameters = null)
    {
        return await api.RequestAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters));
    }
    #endregion

    #region Games
    public static async Task<ApiResponse<Message>> SendGameAsync(this BotApiClient api, SendGameParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("sendGame", parameters));
    }

    public static async Task<ApiResponse<Message>> SetGameScoreAsync(this BotApiClient api, SetGameScoreParameters parameters)
    {
        return await api.RequestAsync<Message>(new ApiRequest("setGameScore", parameters));
    }

    public static async Task<ApiResponse<GameHighScore[]>> GetGameHighScoresAsync(this BotApiClient api, GetGameHighScoresParameters parameters)
    {
        return await api.RequestAsync<GameHighScore[]>(new ApiRequest("getGameHighScores", parameters));
    }
    #endregion
}
