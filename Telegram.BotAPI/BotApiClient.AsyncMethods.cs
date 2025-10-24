using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    #region Getting updates
    public async Task<ApiResponse<Update[]>> GetUpdatesAsync(GetUpdatesParameters parameters = null)
    {
        return await RequestAsync<Update[]>(new ApiRequest("getUpdates", parameters));
    }

    public async Task<ApiResponse<bool>> SetWebhookAsync(SetWebhookParameters parameters = null)
    {
        return await RequestAsync<bool>(new ApiRequest("setWebhook", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteWebhookAsync(DeleteWebhookParameters parameters = null)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteWebhook", parameters));
    }

    public async Task<ApiResponse<WebhookInfo>> GetWebhookInfoAsync(GetWebhookInfoParameters parameters = null)
    {
        return await RequestAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters));
    }
    #endregion

    #region Available methods
    public async Task<ApiResponse<User>> GetMeAsync(GetMeParameters parameters = null)
    {
        return await RequestAsync<User>(new ApiRequest("getMe", parameters));
    }

    public async Task<ApiResponse<bool>> LogOutAsync(LogOutParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("logOut", parameters));
    }

    public async Task<ApiResponse<bool>> CloseAsync(CloseParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("close", parameters));
    }

    public async Task<ApiResponse<Message>> SendMessageAsync(SendMessageParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendMessage", parameters));
    }

    public async Task<ApiResponse<Message>> ForwardMessageAsync(ForwardMessageParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("forwardMessage", parameters));
    }

    public async Task<ApiResponse<MessageIdStruct[]>> ForwardMessagesAsync(ForwardMessagesParameters parameters)
    {
        return await RequestAsync<MessageIdStruct[]>(new ApiRequest("forwardMessages", parameters));
    }

    public async Task<ApiResponse<MessageIdStruct>> CopyMessageAsync(CopyMessageParameters parameters)
    {
        return await RequestAsync<MessageIdStruct>(new ApiRequest("copyMessage", parameters));
    }

    public async Task<ApiResponse<MessageIdStruct[]>> CopyMessagesAsync(CopyMessagesParameters parameters)
    {
        return await RequestAsync<MessageIdStruct[]>(new ApiRequest("copyMessages", parameters));
    }

    public async Task<ApiResponse<Message>> SendPhotoAsync(SendPhotoParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendPhoto", parameters));
    }

    public async Task<ApiResponse<Message>> SendAudioAsync(SendAudioParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendAudio", parameters));
    }

    public async Task<ApiResponse<Message>> SendDocumentAsync(SendDocumentParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendDocument", parameters));
    }

    public async Task<ApiResponse<Message>> SendVideoAsync(SendVideoParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVideo", parameters));
    }

    public async Task<ApiResponse<Message>> SendAnimationAsync(SendAnimationParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendAnimation", parameters));
    }

    public async Task<ApiResponse<Message>> SendVoiceAsync(SendVoiceParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVoice", parameters));
    }

    public async Task<ApiResponse<Message>> SendVideoNoteAsync(SendVideoNoteParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVideoNote", parameters));
    }

    public async Task<ApiResponse<Message>> SendPaidMediaAsync(SendPaidMediaParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendPaidMedia", parameters));
    }

    public async Task<ApiResponse<Message[]>> SendMediaGroupAsync(SendMediaGroupParameters parameters)
    {
        return await RequestAsync<Message[]>(new ApiRequest("sendMediaGroup", parameters));
    }

    public async Task<ApiResponse<Message>> SendLocationAsync(SendLocationParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendLocation", parameters));
    }

    public async Task<ApiResponse<Message>> SendVenueAsync(SendVenueParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendVenue", parameters));
    }

    public async Task<ApiResponse<Message>> SendContactAsync(SendContactParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendContact", parameters));
    }

    public async Task<ApiResponse<Message>> SendPollAsync(SendPollParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendPoll", parameters));
    }

    public async Task<ApiResponse<Message>> SendChecklistAsync(SendChecklistParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendChecklist", parameters));
    }

    public async Task<ApiResponse<Message>> SendDiceAsync(SendDiceParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendDice", parameters));
    }

    public async Task<ApiResponse<bool>> SendChatActionAsync(SendChatActionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("sendChatAction", parameters));
    }

    public async Task<ApiResponse<bool>> SetMessageReactionAsync(SetMessageReactionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setMessageReaction", parameters));
    }

    public async Task<ApiResponse<UserProfilePhotos>> GetUserProfilePhotosAsync(GetUserProfilePhotosParameters parameters)
    {
        return await RequestAsync<UserProfilePhotos>(new ApiRequest("getUserProfilePhotos", parameters));
    }

    public async Task<ApiResponse<bool>> SetUserEmojiStatusAsync(SetUserEmojiStatusParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setUserEmojiStatus", parameters));
    }

    public async Task<ApiResponse<FileStruct>> GetFileAsync(GetFileParameters parameters)
    {
        return await RequestAsync<FileStruct>(new ApiRequest("getFile", parameters));
    }

    public async Task<ApiResponse<bool>> BanChatMemberAsync(BanChatMemberParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("banChatMember", parameters));
    }

    public async Task<ApiResponse<bool>> UnbanChatMemberAsync(UnbanChatMemberParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unbanChatMember", parameters));
    }

    public async Task<ApiResponse<bool>> RestrictChatMemberAsync(RestrictChatMemberParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("restrictChatMember", parameters));
    }

    public async Task<ApiResponse<bool>> PromoteChatMemberAsync(PromoteChatMemberParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("promoteChatMember", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatAdministratorCustomTitleAsync(SetChatAdministratorCustomTitleParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatAdministratorCustomTitle", parameters));
    }

    public async Task<ApiResponse<bool>> BanChatSenderChatAsync(BanChatSenderChatParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("banChatSenderChat", parameters));
    }

    public async Task<ApiResponse<bool>> UnbanChatSenderChatAsync(UnbanChatSenderChatParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unbanChatSenderChat", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatPermissionsAsync(SetChatPermissionsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatPermissions", parameters));
    }

    public async Task<ApiResponse<string>> ExportChatInviteLinkAsync(ExportChatInviteLinkParameters parameters)
    {
        return await RequestAsync<string>(new ApiRequest("exportChatInviteLink", parameters));
    }

    public async Task<ApiResponse<ChatInviteLink>> CreateChatInviteLinkAsync(CreateChatInviteLinkParameters parameters)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("createChatInviteLink", parameters));
    }

    public async Task<ApiResponse<ChatInviteLink>> EditChatInviteLinkAsync(EditChatInviteLinkParameters parameters)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("editChatInviteLink", parameters));
    }

    public async Task<ApiResponse<ChatInviteLink>> CreateChatSubscriptionInviteLinkAsync(CreateChatSubscriptionInviteLinkParameters parameters)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("createChatSubscriptionInviteLink", parameters));
    }

    public async Task<ApiResponse<ChatInviteLink>> EditChatSubscriptionInviteLinkAsync(EditChatSubscriptionInviteLinkParameters parameters)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("editChatSubscriptionInviteLink", parameters));
    }

    public async Task<ApiResponse<ChatInviteLink>> RevokeChatInviteLinkAsync(RevokeChatInviteLinkParameters parameters)
    {
        return await RequestAsync<ChatInviteLink>(new ApiRequest("revokeChatInviteLink", parameters));
    }

    public async Task<ApiResponse<bool>> ApproveChatJoinRequestAsync(ApproveChatJoinRequestParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("approveChatJoinRequest", parameters));
    }

    public async Task<ApiResponse<bool>> DeclineChatJoinRequestAsync(DeclineChatJoinRequestParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("declineChatJoinRequest", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatPhotoAsync(SetChatPhotoParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatPhoto", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteChatPhotoAsync(DeleteChatPhotoParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteChatPhoto", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatTitleAsync(SetChatTitleParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatTitle", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatDescriptionAsync(SetChatDescriptionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatDescription", parameters));
    }

    public async Task<ApiResponse<bool>> PinChatMessageAsync(PinChatMessageParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("pinChatMessage", parameters));
    }

    public async Task<ApiResponse<bool>> UnpinChatMessageAsync(UnpinChatMessageParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinChatMessage", parameters));
    }

    public async Task<ApiResponse<bool>> UnpinAllChatMessagesAsync(UnpinAllChatMessagesParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinAllChatMessages", parameters));
    }

    public async Task<ApiResponse<bool>> LeaveChatAsync(LeaveChatParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("leaveChat", parameters));
    }

    public async Task<ApiResponse<ChatFullInfo>> GetChatAsync(GetChatParameters parameters)
    {
        return await RequestAsync<ChatFullInfo>(new ApiRequest("getChat", parameters));
    }

    public async Task<ApiResponse<ChatMember[]>> GetChatAdministratorsAsync(GetChatAdministratorsParameters parameters)
    {
        return await RequestAsync<ChatMember[]>(new ApiRequest("getChatAdministrators", parameters));
    }

    public async Task<ApiResponse<int>> GetChatMemberCountAsync(GetChatMemberCountParameters parameters)
    {
        return await RequestAsync<int>(new ApiRequest("getChatMemberCount", parameters));
    }

    public async Task<ApiResponse<ChatMember>> GetChatMemberAsync(GetChatMemberParameters parameters)
    {
        return await RequestAsync<ChatMember>(new ApiRequest("getChatMember", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatStickerSetAsync(SetChatStickerSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatStickerSet", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteChatStickerSetAsync(DeleteChatStickerSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteChatStickerSet", parameters));
    }

    public async Task<ApiResponse<Sticker[]>> GetForumTopicIconStickersAsync(GetForumTopicIconStickersParameters parameters)
    {
        return await RequestAsync<Sticker[]>(new ApiRequest("getForumTopicIconStickers", parameters));
    }

    public async Task<ApiResponse<ForumTopic>> CreateForumTopicAsync(CreateForumTopicParameters parameters)
    {
        return await RequestAsync<ForumTopic>(new ApiRequest("createForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> EditForumTopicAsync(EditForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("editForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> CloseForumTopicAsync(CloseForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("closeForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> ReopenForumTopicAsync(ReopenForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("reopenForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteForumTopicAsync(DeleteForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> UnpinAllForumTopicMessagesAsync(UnpinAllForumTopicMessagesParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinAllForumTopicMessages", parameters));
    }

    public async Task<ApiResponse<bool>> EditGeneralForumTopicAsync(EditGeneralForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("editGeneralForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> CloseGeneralForumTopicAsync(CloseGeneralForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("closeGeneralForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> ReopenGeneralForumTopicAsync(ReopenGeneralForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("reopenGeneralForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> HideGeneralForumTopicAsync(HideGeneralForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("hideGeneralForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> UnhideGeneralForumTopicAsync(UnhideGeneralForumTopicParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unhideGeneralForumTopic", parameters));
    }

    public async Task<ApiResponse<bool>> UnpinAllGeneralForumTopicMessagesAsync(UnpinAllGeneralForumTopicMessagesParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("unpinAllGeneralForumTopicMessages", parameters));
    }

    public async Task<ApiResponse<bool>> AnswerCallbackQueryAsync(AnswerCallbackQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerCallbackQuery", parameters));
    }

    public async Task<ApiResponse<UserChatBoosts>> GetUserChatBoostsAsync(GetUserChatBoostsParameters parameters)
    {
        return await RequestAsync<UserChatBoosts>(new ApiRequest("getUserChatBoosts", parameters));
    }

    public async Task<ApiResponse<BusinessConnection>> GetBusinessConnectionAsync(GetBusinessConnectionParameters parameters)
    {
        return await RequestAsync<BusinessConnection>(new ApiRequest("getBusinessConnection", parameters));
    }

    public async Task<ApiResponse<bool>> SetMyCommandsAsync(SetMyCommandsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyCommands", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteMyCommandsAsync(DeleteMyCommandsParameters parameters = null)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteMyCommands", parameters));
    }

    public async Task<ApiResponse<BotCommand[]>> GetMyCommandsAsync(GetMyCommandsParameters parameters = null)
    {
        return await RequestAsync<BotCommand[]>(new ApiRequest("getMyCommands", parameters));
    }

    public async Task<ApiResponse<bool>> SetMyNameAsync(SetMyNameParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyName", parameters));
    }

    public async Task<ApiResponse<BotName>> GetMyNameAsync(GetMyNameParameters parameters)
    {
        return await RequestAsync<BotName>(new ApiRequest("getMyName", parameters));
    }

    public async Task<ApiResponse<bool>> SetMyDescriptionAsync(SetMyDescriptionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyDescription", parameters));
    }

    public async Task<ApiResponse<BotDescription>> GetMyDescriptionAsync(GetMyDescriptionParameters parameters)
    {
        return await RequestAsync<BotDescription>(new ApiRequest("getMyDescription", parameters));
    }

    public async Task<ApiResponse<bool>> SetMyShortDescriptionAsync(SetMyShortDescriptionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyShortDescription", parameters));
    }

    public async Task<ApiResponse<BotShortDescription>> GetMyShortDescriptionAsync(GetMyShortDescriptionParameters parameters)
    {
        return await RequestAsync<BotShortDescription>(new ApiRequest("getMyShortDescription", parameters));
    }

    public async Task<ApiResponse<bool>> SetChatMenuButtonAsync(SetChatMenuButtonParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setChatMenuButton", parameters));
    }

    public async Task<ApiResponse<MenuButton>> GetChatMenuButtonAsync(GetChatMenuButtonParameters parameters)
    {
        return await RequestAsync<MenuButton>(new ApiRequest("getChatMenuButton", parameters));
    }

    public async Task<ApiResponse<bool>> SetMyDefaultAdministratorRightsAsync(SetMyDefaultAdministratorRightsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setMyDefaultAdministratorRights", parameters));
    }

    public async Task<ApiResponse<ChatAdministratorRights>> GetMyDefaultAdministratorRightsAsync(GetMyDefaultAdministratorRightsParameters parameters)
    {
        return await RequestAsync<ChatAdministratorRights>(new ApiRequest("getMyDefaultAdministratorRights", parameters));
    }
    #endregion

    #region Updating messages
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
    #endregion

    #region Stickers
    public async Task<ApiResponse<Message>> SendStickerAsync(SendStickerParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendSticker", parameters));
    }

    public async Task<ApiResponse<StickerSet>> GetStickerSetAsync(GetStickerSetParameters parameters)
    {
        return await RequestAsync<StickerSet>(new ApiRequest("getStickerSet", parameters));
    }

    public async Task<ApiResponse<Sticker[]>> GetCustomEmojiStickersAsync(GetCustomEmojiStickersParameters parameters)
    {
        return await RequestAsync<Sticker[]>(new ApiRequest("getCustomEmojiStickers", parameters));
    }

    public async Task<ApiResponse<FileStruct>> UploadStickerFileAsync(UploadStickerFileParameters parameters)
    {
        return await RequestAsync<FileStruct>(new ApiRequest("uploadStickerFile", parameters));
    }

    public async Task<ApiResponse<bool>> CreateNewStickerSetAsync(CreateNewStickerSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("createNewStickerSet", parameters));
    }

    public async Task<ApiResponse<bool>> AddStickerToSetAsync(AddStickerToSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("addStickerToSet", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerPositionInSetAsync(SetStickerPositionInSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteStickerFromSetAsync(DeleteStickerFromSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters));
    }

    public async Task<ApiResponse<bool>> ReplaceStickerInSetAsync(ReplaceStickerInSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("replaceStickerInSet", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerEmojiListAsync(SetStickerEmojiListParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerEmojiList", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerKeywordsAsync(SetStickerKeywordsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerKeywords", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerMaskPositionAsync(SetStickerMaskPositionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerSetTitleAsync(SetStickerSetTitleParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerSetTitle", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerSetThumbnailAsync(SetStickerSetThumbnailParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters));
    }

    public async Task<ApiResponse<bool>> SetCustomEmojiStickerSetThumbnailAsync(SetCustomEmojiStickerSetThumbnailParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteStickerSetAsync(DeleteStickerSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteStickerSet", parameters));
    }
    #endregion

    #region Inline mode
    public async Task<ApiResponse<bool>> AnswerInlineQueryAsync(AnswerInlineQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerInlineQuery", parameters));
    }

    public async Task<ApiResponse<SentWebAppMessage>> AnswerWebAppQueryAsync(AnswerWebAppQueryParameters parameters)
    {
        return await RequestAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters));
    }

    public async Task<ApiResponse<PreparedInlineMessage>> SavePreparedInlineMessageAsync(SavePreparedInlineMessageParameters parameters)
    {
        return await RequestAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters));
    }
    #endregion

    #region Payments
    public async Task<ApiResponse<Message>> SendInvoiceAsync(SendInvoiceParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendInvoice", parameters));
    }

    public async Task<ApiResponse<string>> CreateInvoiceLinkAsync(CreateInvoiceLinkParameters parameters)
    {
        return await RequestAsync<string>(new ApiRequest("createInvoiceLink", parameters));
    }

    public async Task<ApiResponse<bool>> AnswerShippingQueryAsync(AnswerShippingQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerShippingQuery", parameters));
    }

    public async Task<ApiResponse<bool>> AnswerPreCheckoutQueryAsync(AnswerPreCheckoutQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters));
    }

    public async Task<ApiResponse<StarAmount>> GetMyStarBalanceAsync(GetMyStarBalanceParameters parameters)
    {
        return await RequestAsync<StarAmount>(new ApiRequest("getMyStarBalance", parameters));
    }

    public async Task<ApiResponse<StarTransactions>> GetStarTransactionsAsync(GetStarTransactionsyParameters parameters)
    {
        return await RequestAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters));
    }

    public async Task<ApiResponse<bool>> RefundStarPaymentAsync(RefundStarPaymentParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("refundStarPayment", parameters));
    }

    public async Task<ApiResponse<bool>> EditUserStarSubscriptionAsync(EditUserStarSubscriptionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("editUserStarSubscription", parameters));
    }
    #endregion

    #region Telegram Passport
    public async Task<ApiResponse<bool>> SetPassportDataErrorsAsync(SetPassportDataErrorsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setPassportDataErrors", parameters));
    }
    #endregion

    #region Games
    public async Task<ApiResponse<Message>> SendGameAsync(SendGameParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendGame", parameters));
    }

    public async Task<ApiResponse<Message>> SetGameScoreAsync(SetGameScoreParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("setGameScore", parameters));
    }

    public async Task<ApiResponse<GameHighScore[]>> GetGameHighScoresAsync(GetGameHighScoresParameters parameters)
    {
        return await RequestAsync<GameHighScore[]>(new ApiRequest("getGameHighScores", parameters));
    }
    #endregion
}
