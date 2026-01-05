using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    #region Getting updates
    public async Task<ApiResponse<Update[]>> GetUpdatesAsync(GetUpdatesParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Update[]>(new ApiRequest("getUpdates", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetWebhookAsync(SetWebhookParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setWebhook", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteWebhookAsync(DeleteWebhookParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteWebhook", parameters), cancellationToken);
    }

    public async Task<ApiResponse<WebhookInfo>> GetWebhookInfoAsync(GetWebhookInfoParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters), cancellationToken);
    }
    #endregion

    #region Available methods
    public async Task<ApiResponse<User>> GetMeAsync(GetMeParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<User>(new ApiRequest("getMe", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> LogOutAsync(LogOutParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("logOut", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> CloseAsync(CloseParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("close", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendMessageAsync(SendMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> ForwardMessageAsync(ForwardMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("forwardMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<MessageIdStruct[]>> ForwardMessagesAsync(ForwardMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<MessageIdStruct[]>(new ApiRequest("forwardMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<MessageIdStruct>> CopyMessageAsync(CopyMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<MessageIdStruct>(new ApiRequest("copyMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<MessageIdStruct[]>> CopyMessagesAsync(CopyMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<MessageIdStruct[]>(new ApiRequest("copyMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendPhotoAsync(SendPhotoParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendPhoto", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendAudioAsync(SendAudioParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendAudio", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendDocumentAsync(SendDocumentParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendDocument", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendVideoAsync(SendVideoParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVideo", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendAnimationAsync(SendAnimationParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendAnimation", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendVoiceAsync(SendVoiceParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVoice", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendVideoNoteAsync(SendVideoNoteParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVideoNote", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendPaidMediaAsync(SendPaidMediaParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendPaidMedia", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message[]>> SendMediaGroupAsync(SendMediaGroupParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message[]>(new ApiRequest("sendMediaGroup", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendLocationAsync(SendLocationParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendLocation", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendVenueAsync(SendVenueParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVenue", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendContactAsync(SendContactParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendContact", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendPollAsync(SendPollParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendPoll", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendChecklistAsync(SendChecklistParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendChecklist", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SendDiceAsync(SendDiceParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendDice", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SendMessageDraftAsync(SendMessageDraftParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("sendMessageDraft", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SendChatActionAsync(SendChatActionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("sendChatAction", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetMessageReactionAsync(SetMessageReactionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setMessageReaction", parameters), cancellationToken);
    }

    public async Task<ApiResponse<UserProfilePhotos>> GetUserProfilePhotosAsync(GetUserProfilePhotosParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<UserProfilePhotos>(new ApiRequest("getUserProfilePhotos", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetUserEmojiStatusAsync(SetUserEmojiStatusParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setUserEmojiStatus", parameters), cancellationToken);
    }

    public async Task<ApiResponse<FileStruct>> GetFileAsync(GetFileParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<FileStruct>(new ApiRequest("getFile", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> BanChatMemberAsync(BanChatMemberParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("banChatMember", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnbanChatMemberAsync(UnbanChatMemberParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unbanChatMember", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> RestrictChatMemberAsync(RestrictChatMemberParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("restrictChatMember", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> PromoteChatMemberAsync(PromoteChatMemberParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("promoteChatMember", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatAdministratorCustomTitleAsync(SetChatAdministratorCustomTitleParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatAdministratorCustomTitle", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> BanChatSenderChatAsync(BanChatSenderChatParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("banChatSenderChat", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnbanChatSenderChatAsync(UnbanChatSenderChatParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unbanChatSenderChat", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatPermissionsAsync(SetChatPermissionsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatPermissions", parameters), cancellationToken);
    }

    public async Task<ApiResponse<string>> ExportChatInviteLinkAsync(ExportChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<string>(new ApiRequest("exportChatInviteLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatInviteLink>> CreateChatInviteLinkAsync(CreateChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("createChatInviteLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatInviteLink>> EditChatInviteLinkAsync(EditChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("editChatInviteLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatInviteLink>> CreateChatSubscriptionInviteLinkAsync(CreateChatSubscriptionInviteLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("createChatSubscriptionInviteLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatInviteLink>> EditChatSubscriptionInviteLinkAsync(EditChatSubscriptionInviteLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("editChatSubscriptionInviteLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatInviteLink>> RevokeChatInviteLinkAsync(RevokeChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("revokeChatInviteLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ApproveChatJoinRequestAsync(ApproveChatJoinRequestParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("approveChatJoinRequest", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeclineChatJoinRequestAsync(DeclineChatJoinRequestParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("declineChatJoinRequest", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatPhotoAsync(SetChatPhotoParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatPhoto", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteChatPhotoAsync(DeleteChatPhotoParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteChatPhoto", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatTitleAsync(SetChatTitleParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatTitle", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatDescriptionAsync(SetChatDescriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatDescription", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> PinChatMessageAsync(PinChatMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("pinChatMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnpinChatMessageAsync(UnpinChatMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinChatMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnpinAllChatMessagesAsync(UnpinAllChatMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinAllChatMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> LeaveChatAsync(LeaveChatParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("leaveChat", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatFullInfo>> GetChatAsync(GetChatParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatFullInfo>(new ApiRequest("getChat", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatMember[]>> GetChatAdministratorsAsync(GetChatAdministratorsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatMember[]>(new ApiRequest("getChatAdministrators", parameters), cancellationToken);
    }

    public async Task<ApiResponse<int>> GetChatMemberCountAsync(GetChatMemberCountParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<int>(new ApiRequest("getChatMemberCount", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatMember>> GetChatMemberAsync(GetChatMemberParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatMember>(new ApiRequest("getChatMember", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatStickerSetAsync(SetChatStickerSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatStickerSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteChatStickerSetAsync(DeleteChatStickerSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteChatStickerSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Sticker[]>> GetForumTopicIconStickersAsync(GetForumTopicIconStickersParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Sticker[]>(new ApiRequest("getForumTopicIconStickers", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ForumTopic>> CreateForumTopicAsync(CreateForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ForumTopic>(new ApiRequest("createForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> EditForumTopicAsync(EditForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("editForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> CloseForumTopicAsync(CloseForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("closeForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ReopenForumTopicAsync(ReopenForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("reopenForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteForumTopicAsync(DeleteForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnpinAllForumTopicMessagesAsync(UnpinAllForumTopicMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinAllForumTopicMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> EditGeneralForumTopicAsync(EditGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("editGeneralForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> CloseGeneralForumTopicAsync(CloseGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("closeGeneralForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ReopenGeneralForumTopicAsync(ReopenGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("reopenGeneralForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> HideGeneralForumTopicAsync(HideGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("hideGeneralForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnhideGeneralForumTopicAsync(UnhideGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unhideGeneralForumTopic", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UnpinAllGeneralForumTopicMessagesAsync(UnpinAllGeneralForumTopicMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinAllGeneralForumTopicMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> AnswerCallbackQueryAsync(AnswerCallbackQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("answerCallbackQuery", parameters), cancellationToken);
    }

    public async Task<ApiResponse<UserChatBoosts>> GetUserChatBoostsAsync(GetUserChatBoostsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<UserChatBoosts>(new ApiRequest("getUserChatBoosts", parameters), cancellationToken);
    }

    public async Task<ApiResponse<BusinessConnection>> GetBusinessConnectionAsync(GetBusinessConnectionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<BusinessConnection>(new ApiRequest("getBusinessConnection", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetMyCommandsAsync(SetMyCommandsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyCommands", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteMyCommandsAsync(DeleteMyCommandsParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteMyCommands", parameters), cancellationToken);
    }

    public async Task<ApiResponse<BotCommand[]>> GetMyCommandsAsync(GetMyCommandsParameters parameters = null, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<BotCommand[]>(new ApiRequest("getMyCommands", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetMyNameAsync(SetMyNameParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyName", parameters), cancellationToken);
    }

    public async Task<ApiResponse<BotName>> GetMyNameAsync(GetMyNameParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<BotName>(new ApiRequest("getMyName", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetMyDescriptionAsync(SetMyDescriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyDescription", parameters), cancellationToken);
    }

    public async Task<ApiResponse<BotDescription>> GetMyDescriptionAsync(GetMyDescriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<BotDescription>(new ApiRequest("getMyDescription", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetMyShortDescriptionAsync(SetMyShortDescriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyShortDescription", parameters), cancellationToken);
    }

    public async Task<ApiResponse<BotShortDescription>> GetMyShortDescriptionAsync(GetMyShortDescriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<BotShortDescription>(new ApiRequest("getMyShortDescription", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetChatMenuButtonAsync(SetChatMenuButtonParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatMenuButton", parameters), cancellationToken);
    }

    public async Task<ApiResponse<MenuButton>> GetChatMenuButtonAsync(GetChatMenuButtonParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<MenuButton>(new ApiRequest("getChatMenuButton", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetMyDefaultAdministratorRightsAsync(SetMyDefaultAdministratorRightsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyDefaultAdministratorRights", parameters), cancellationToken);
    }

    public async Task<ApiResponse<ChatAdministratorRights>> GetMyDefaultAdministratorRightsAsync(GetMyDefaultAdministratorRightsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<ChatAdministratorRights>(new ApiRequest("getMyDefaultAdministratorRights", parameters), cancellationToken);
    }
    #endregion

    #region Updating messages
    public async Task<ApiResponse<Message>> EditMessageTextAsync(EditMessageTextParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageText", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> EditMessageCaptionAsync(EditMessageCaptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageCaption", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> EditMessageMediaAsync(EditMessageMediaParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageMedia", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> EditMessageLiveLocationAsync(EditMessageLiveLocationParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> StopMessageLiveLocationAsync(StopMessageLiveLocationParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> EditMessageChecklistAsync(EditMessageChecklistParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageChecklist", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> EditMessageReplyMarkupAsync(EditMessageReplyMarkupParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Poll>> StopPollAsync(StopPollParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Poll>(new ApiRequest("stopPoll", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ApproveSuggestedPostAsync(ApproveSuggestedPostParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("approveSuggestedPost", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeclineSuggestedPostAsync(DeclineSuggestedPostParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("declineSuggestedPost", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteMessageAsync(DeleteMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteMessagesAsync(DeleteMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<GiftsStruct>> GetAvailableGiftsAsync(GetAvailableGiftsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<GiftsStruct>(new ApiRequest("getAvailableGifts", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SendGiftAsync(SendGiftParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("sendGift", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> GiftPremiumSubscriptionAsync(GiftPremiumSubscriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("giftPremiumSubscription", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> VerifyUserAsync(VerifyUserParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("verifyUser", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> VerifyChatAsync(VerifyChatParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("verifyChat", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> RemoveUserVerificationAsync(RemoveUserVerificationParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("removeUserVerification", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> RemoveChatVerificationAsync(RemoveChatVerificationParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("removeChatVerification", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ReadBusinessMessageAsync(ReadBusinessMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("readBusinessMessage", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteBusinessMessagesAsync(DeleteBusinessMessagesParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteBusinessMessages", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountNameAsync(SetBusinessAccountNameParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountName", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountUsernameAsync(SetBusinessAccountUsernameParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountUsername", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountBioAsync(SetBusinessAccountBioParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountBio", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountProfilePhotoAsync(SetBusinessAccountProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountProfilePhoto", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> RemoveBusinessAccountProfilePhotoAsync(RemoveBusinessAccountProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("removeBusinessAccountProfilePhoto", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetBusinessAccountGiftSettingsAsync(SetBusinessAccountGiftSettingsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setBusinessAccountGiftSettings", parameters), cancellationToken);
    }

    public async Task<ApiResponse<StarAmount>> GetBusinessAccountStarBalanceAsync(GetBusinessAccountStarBalanceParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<StarAmount>(new ApiRequest("getBusinessAccountStarBalance", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> TransferBusinessAccountStarsAsync(TransferBusinessAccountStarsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("transferBusinessAccountStars", parameters), cancellationToken);
    }

    public async Task<ApiResponse<OwnedGifts>> GetBusinessAccountGiftsAsync(GetBusinessAccountGiftsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<OwnedGifts>(new ApiRequest("getBusinessAccountGifts", parameters), cancellationToken);
    }

    public async Task<ApiResponse<OwnedGifts>> GetUserGiftsASync(GetUserGiftsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<OwnedGifts>(new ApiRequest("getUserGifts", parameters), cancellationToken);
    }

    public async Task<ApiResponse<OwnedGifts>> GetChatGiftsAsync(GetChatGiftsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<OwnedGifts>(new ApiRequest("getChatGifts", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ConvertGiftToStarsAsync(ConvertGiftToStarsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("convertGiftToStars", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> UpgradeGiftAsync(UpgradeGiftParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("upgradeGift", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> TransferGiftAsync(TransferGiftParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("transferGift", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Story>> PostStoryAsync(PostStoryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Story>(new ApiRequest("postStory", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Story>> EditStoryAsync(EditStoryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Story>(new ApiRequest("editStory", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Story>> DeleteStoryAsync(DeleteStoryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Story>(new ApiRequest("deleteStory", parameters), cancellationToken);
    }
    #endregion

    #region Stickers
    public async Task<ApiResponse<Message>> SendStickerAsync(SendStickerParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendSticker", parameters), cancellationToken);
    }

    public async Task<ApiResponse<StickerSet>> GetStickerSetAsync(GetStickerSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<StickerSet>(new ApiRequest("getStickerSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Sticker[]>> GetCustomEmojiStickersAsync(GetCustomEmojiStickersParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Sticker[]>(new ApiRequest("getCustomEmojiStickers", parameters), cancellationToken);
    }

    public async Task<ApiResponse<FileStruct>> UploadStickerFileAsync(UploadStickerFileParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<FileStruct>(new ApiRequest("uploadStickerFile", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> CreateNewStickerSetAsync(CreateNewStickerSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("createNewStickerSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> AddStickerToSetAsync(AddStickerToSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("addStickerToSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetStickerPositionInSetAsync(SetStickerPositionInSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteStickerFromSetAsync(DeleteStickerFromSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> ReplaceStickerInSetAsync(ReplaceStickerInSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("replaceStickerInSet", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetStickerEmojiListAsync(SetStickerEmojiListParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerEmojiList", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetStickerKeywordsAsync(SetStickerKeywordsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerKeywords", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetStickerMaskPositionAsync(SetStickerMaskPositionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetStickerSetTitleAsync(SetStickerSetTitleParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerSetTitle", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetStickerSetThumbnailAsync(SetStickerSetThumbnailParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> SetCustomEmojiStickerSetThumbnailAsync(SetCustomEmojiStickerSetThumbnailParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> DeleteStickerSetAsync(DeleteStickerSetParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteStickerSet", parameters), cancellationToken);
    }
    #endregion

    #region Inline mode
    public async Task<ApiResponse<bool>> AnswerInlineQueryAsync(AnswerInlineQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("answerInlineQuery", parameters), cancellationToken);
    }

    public async Task<ApiResponse<SentWebAppMessage>> AnswerWebAppQueryAsync(AnswerWebAppQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters), cancellationToken);
    }

    public async Task<ApiResponse<PreparedInlineMessage>> SavePreparedInlineMessageAsync(SavePreparedInlineMessageParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters), cancellationToken);
    }
    #endregion

    #region Payments
    public async Task<ApiResponse<Message>> SendInvoiceAsync(SendInvoiceParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendInvoice", parameters), cancellationToken);
    }

    public async Task<ApiResponse<string>> CreateInvoiceLinkAsync(CreateInvoiceLinkParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<string>(new ApiRequest("createInvoiceLink", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> AnswerShippingQueryAsync(AnswerShippingQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("answerShippingQuery", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> AnswerPreCheckoutQueryAsync(AnswerPreCheckoutQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters), cancellationToken);
    }

    public async Task<ApiResponse<StarAmount>> GetMyStarBalanceAsync(GetMyStarBalanceParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<StarAmount>(new ApiRequest("getMyStarBalance", parameters), cancellationToken);
    }

    public async Task<ApiResponse<StarTransactions>> GetStarTransactionsAsync(GetStarTransactionsyParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> RefundStarPaymentAsync(RefundStarPaymentParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("refundStarPayment", parameters), cancellationToken);
    }

    public async Task<ApiResponse<bool>> EditUserStarSubscriptionAsync(EditUserStarSubscriptionParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("editUserStarSubscription", parameters), cancellationToken);
    }
    #endregion

    #region Telegram Passport
    public async Task<ApiResponse<bool>> SetPassportDataErrorsAsync(SetPassportDataErrorsParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<bool>(new ApiRequest("setPassportDataErrors", parameters), cancellationToken);
    }
    #endregion

    #region Games
    public async Task<ApiResponse<Message>> SendGameAsync(SendGameParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("sendGame", parameters), cancellationToken);
    }

    public async Task<ApiResponse<Message>> SetGameScoreAsync(SetGameScoreParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<Message>(new ApiRequest("setGameScore", parameters), cancellationToken);
    }

    public async Task<ApiResponse<GameHighScore[]>> GetGameHighScoresAsync(GetGameHighScoresParameters parameters, CancellationToken cancellationToken = default)
    {
        return await RequestAsync<GameHighScore[]>(new ApiRequest("getGameHighScores", parameters), cancellationToken);
    }
    #endregion
}
