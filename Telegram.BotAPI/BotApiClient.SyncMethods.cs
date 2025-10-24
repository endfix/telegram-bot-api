using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    #region Getting updates
    public Update[] GetUpdates(GetUpdatesParameters parameters = null)
    {
        return GetUpdatesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetWebhook(SetWebhookParameters parameters = null)
    {
        return SetWebhookAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteWebhook(DeleteWebhookParameters parameters = null)
    {
        return DeleteWebhookAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public WebhookInfo GetWebhookInfo(GetWebhookInfoParameters parameters = null)
    {
        return GetWebhookInfoAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Available methods
    public User GetMe(GetMeParameters parameters = null)
    {
        return GetMeAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool LogOut(LogOutParameters parameters)
    {
        return LogOutAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool Close(CloseParameters parameters)
    {
        return CloseAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendMessage(SendMessageParameters parameters)
    {
        return SendMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message ForwardMessage(ForwardMessageParameters parameters)
    {
        return ForwardMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public MessageIdStruct[] ForwardMessages(ForwardMessagesParameters parameters)
    {
        return ForwardMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public MessageIdStruct CopyMessage(CopyMessageParameters parameters)
    {
        return CopyMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public MessageIdStruct[] CopyMessages(CopyMessagesParameters parameters)
    {
        return CopyMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendPhoto(SendPhotoParameters parameters)
    {
        return SendPhotoAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendAudio(SendAudioParameters parameters)
    {
        return SendAudioAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendDocument(SendDocumentParameters parameters)
    {
        return SendDocumentAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendVideo(SendVideoParameters parameters)
    {
        return SendVideoAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendAnimation(SendAnimationParameters parameters)
    {
        return SendAnimationAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendVoice(SendVoiceParameters parameters)
    {
        return SendVoiceAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendVideoNote(SendVideoNoteParameters parameters)
    {
        return SendVideoNoteAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendPaidMedia(SendPaidMediaParameters parameters)
    {
        return SendPaidMediaAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message[] SendMediaGroup(SendMediaGroupParameters parameters)
    {
        return SendMediaGroupAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendLocation(SendLocationParameters parameters)
    {
        return SendLocationAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendVenue(SendVenueParameters parameters)
    {
        return SendVenueAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendContact(SendContactParameters parameters)
    {
        return SendContactAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendPoll(SendPollParameters parameters)
    {
        return SendPollAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendChecklist(SendChecklistParameters parameters)
    {
        return SendChecklistAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SendDice(SendDiceParameters parameters)
    {
        return SendDiceAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SendChatAction(SendChatActionParameters parameters)
    {
        return SendChatActionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetMessageReaction(SetMessageReactionParameters parameters)
    {
        return SetMessageReactionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public UserProfilePhotos GetUserProfilePhotos(GetUserProfilePhotosParameters parameters)
    {
        return GetUserProfilePhotosAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetUserEmojiStatus(SetUserEmojiStatusParameters parameters)
    {
        return SetUserEmojiStatusAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public FileStruct GetFile(GetFileParameters parameters)
    {
        return GetFileAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool BanChatMember(BanChatMemberParameters parameters)
    {
        return BanChatMemberAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnbanChatMember(UnbanChatMemberParameters parameters)
    {
        return UnbanChatMemberAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool RestrictChatMember(RestrictChatMemberParameters parameters)
    {
        return RestrictChatMemberAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool PromoteChatMember(PromoteChatMemberParameters parameters)
    {
        return PromoteChatMemberAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatAdministratorCustomTitle(SetChatAdministratorCustomTitleParameters parameters)
    {
        return SetChatAdministratorCustomTitleAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool BanChatSenderChat(BanChatSenderChatParameters parameters)
    {
        return BanChatSenderChatAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnbanChatSenderChat(UnbanChatSenderChatParameters parameters)
    {
        return UnbanChatSenderChatAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatPermissions(SetChatPermissionsParameters parameters)
    {
        return SetChatPermissionsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public string ExportChatInviteLink(ExportChatInviteLinkParameters parameters)
    {
        return ExportChatInviteLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatInviteLink CreateChatInviteLink(CreateChatInviteLinkParameters parameters)
    {
        return CreateChatInviteLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatInviteLink EditChatInviteLink(EditChatInviteLinkParameters parameters)
    {
        return EditChatInviteLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatInviteLink CreateChatSubscriptionInviteLink(CreateChatSubscriptionInviteLinkParameters parameters)
    {
        return CreateChatSubscriptionInviteLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatInviteLink EditChatSubscriptionInviteLink(EditChatSubscriptionInviteLinkParameters parameters)
    {
        return EditChatSubscriptionInviteLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatInviteLink RevokeChatInviteLink(RevokeChatInviteLinkParameters parameters)
    {
        return RevokeChatInviteLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ApproveChatJoinRequest(ApproveChatJoinRequestParameters parameters)
    {
        return ApproveChatJoinRequestAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeclineChatJoinRequest(DeclineChatJoinRequestParameters parameters)
    {
        return DeclineChatJoinRequestAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatPhoto(SetChatPhotoParameters parameters)
    {
        return SetChatPhotoAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteChatPhoto(DeleteChatPhotoParameters parameters)
    {
        return DeleteChatPhotoAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatTitle(SetChatTitleParameters parameters)
    {
        return SetChatTitleAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatDescription(SetChatDescriptionParameters parameters)
    {
        return SetChatDescriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool PinChatMessage(PinChatMessageParameters parameters)
    {
        return PinChatMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnpinChatMessage(UnpinChatMessageParameters parameters)
    {
        return UnpinChatMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnpinAllChatMessages(UnpinAllChatMessagesParameters parameters)
    {
        return UnpinAllChatMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool LeaveChat(LeaveChatParameters parameters)
    {
        return LeaveChatAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatFullInfo GetChat(GetChatParameters parameters)
    {
        return GetChatAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatMember[] GetChatAdministrators(GetChatAdministratorsParameters parameters)
    {
        return GetChatAdministratorsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public int GetChatMemberCount(GetChatMemberCountParameters parameters)
    {
        return GetChatMemberCountAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatMember GetChatMember(GetChatMemberParameters parameters)
    {
        return GetChatMemberAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatStickerSet(SetChatStickerSetParameters parameters)
    {
        return SetChatStickerSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteChatStickerSet(DeleteChatStickerSetParameters parameters)
    {
        return DeleteChatStickerSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Sticker[] GetForumTopicIconStickers(GetForumTopicIconStickersParameters parameters)
    {
        return GetForumTopicIconStickersAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ForumTopic CreateForumTopic(CreateForumTopicParameters parameters)
    {
        return CreateForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool EditForumTopic(EditForumTopicParameters parameters)
    {
        return EditForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool CloseForumTopic(CloseForumTopicParameters parameters)
    {
        return CloseForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ReopenForumTopic(ReopenForumTopicParameters parameters)
    {
        return ReopenForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteForumTopic(DeleteForumTopicParameters parameters)
    {
        return DeleteForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnpinAllForumTopicMessages(UnpinAllForumTopicMessagesParameters parameters)
    {
        return UnpinAllForumTopicMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool EditGeneralForumTopic(EditGeneralForumTopicParameters parameters)
    {
        return EditGeneralForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool CloseGeneralForumTopic(CloseGeneralForumTopicParameters parameters)
    {
        return CloseGeneralForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ReopenGeneralForumTopic(ReopenGeneralForumTopicParameters parameters)
    {
        return ReopenGeneralForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool HideGeneralForumTopic(HideGeneralForumTopicParameters parameters)
    {
        return HideGeneralForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnhideGeneralForumTopic(UnhideGeneralForumTopicParameters parameters)
    {
        return UnhideGeneralForumTopicAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UnpinAllGeneralForumTopicMessages(UnpinAllGeneralForumTopicMessagesParameters parameters)
    {
        return UnpinAllGeneralForumTopicMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool AnswerCallbackQuery(AnswerCallbackQueryParameters parameters)
    {
        return AnswerCallbackQueryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public UserChatBoosts GetUserChatBoosts(GetUserChatBoostsParameters parameters)
    {
        return GetUserChatBoostsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public BusinessConnection GetBusinessConnection(GetBusinessConnectionParameters parameters)
    {
        return GetBusinessConnectionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetMyCommands(SetMyCommandsParameters parameters)
    {
        return SetMyCommandsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteMyCommands(DeleteMyCommandsParameters parameters = null)
    {
        return DeleteMyCommandsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public BotCommand[] GetMyCommands(GetMyCommandsParameters parameters = null)
    {
        return GetMyCommandsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetMyName(SetMyNameParameters parameters)
    {
        return SetMyNameAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public BotName GetMyName(GetMyNameParameters parameters)
    {
        return GetMyNameAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetMyDescription(SetMyDescriptionParameters parameters)
    {
        return SetMyDescriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public BotDescription GetMyDescription(GetMyDescriptionParameters parameters)
    {
        return GetMyDescriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetMyShortDescription(SetMyShortDescriptionParameters parameters)
    {
        return SetMyShortDescriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public BotShortDescription GetMyShortDescription(GetMyShortDescriptionParameters parameters)
    {
        return GetMyShortDescriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetChatMenuButton(SetChatMenuButtonParameters parameters)
    {
        return SetChatMenuButtonAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public MenuButton GetChatMenuButton(GetChatMenuButtonParameters parameters)
    {
        return GetChatMenuButtonAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetMyDefaultAdministratorRights(SetMyDefaultAdministratorRightsParameters parameters)
    {
        return SetMyDefaultAdministratorRightsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public ChatAdministratorRights GetMyDefaultAdministratorRights(GetMyDefaultAdministratorRightsParameters parameters)
    {
        return GetMyDefaultAdministratorRightsAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Updating messages
    public Message EditMessageText(EditMessageTextParameters parameters)
    {
        return EditMessageTextAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message EditMessageCaption(EditMessageCaptionParameters parameters)
    {
        return EditMessageCaptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message EditMessageMedia(EditMessageMediaParameters parameters)
    {
        return EditMessageMediaAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message EditMessageLiveLocation(EditMessageLiveLocationParameters parameters)
    {
        return EditMessageLiveLocationAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message StopMessageLiveLocation(StopMessageLiveLocationParameters parameters)
    {
        return StopMessageLiveLocationAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message EditMessageChecklist(EditMessageChecklistParameters parameters)
    {
        return EditMessageChecklistAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message EditMessageReplyMarkup(EditMessageReplyMarkupParameters parameters)
    {
        return EditMessageReplyMarkupAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Poll StopPoll(StopPollParameters parameters)
    {
        return StopPollAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ApproveSuggestedPost(ApproveSuggestedPostParameters parameters)
    {
        return ApproveSuggestedPostAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeclineSuggestedPost(DeclineSuggestedPostParameters parameters)
    {
        return DeclineSuggestedPostAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteMessage(DeleteMessageParameters parameters)
    {
        return DeleteMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteMessages(DeleteMessagesParameters parameters)
    {
        return DeleteMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public GiftsStruct GetAvailableGifts(GetAvailableGiftsParameters parameters)
    {
        return GetAvailableGiftsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SendGift(SendGiftParameters parameters)
    {
        return SendGiftAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool GiftPremiumSubscription(GiftPremiumSubscriptionParameters parameters)
    {
        return GiftPremiumSubscriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool VerifyUser(VerifyUserParameters parameters)
    {
        return VerifyUserAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool VerifyChat(VerifyChatParameters parameters)
    {
        return VerifyChatAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool RemoveUserVerification(RemoveUserVerificationParameters parameters)
    {
        return RemoveUserVerificationAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool RemoveChatVerification(RemoveChatVerificationParameters parameters)
    {
        return RemoveChatVerificationAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ReadBusinessMessage(ReadBusinessMessageParameters parameters)
    {
        return ReadBusinessMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteBusinessMessages(DeleteBusinessMessagesParameters parameters)
    {
        return DeleteBusinessMessagesAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetBusinessAccountName(SetBusinessAccountNameParameters parameters)
    {
        return SetBusinessAccountNameAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetBusinessAccountUsername(SetBusinessAccountUsernameParameters parameters)
    {
        return SetBusinessAccountUsernameAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetBusinessAccountBio(SetBusinessAccountBioParameters parameters)
    {
        return SetBusinessAccountBioAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetBusinessAccountProfilePhoto(SetBusinessAccountProfilePhotoParameters parameters)
    {
        return SetBusinessAccountProfilePhotoAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool RemoveBusinessAccountProfilePhoto(RemoveBusinessAccountProfilePhotoParameters parameters)
    {
        return RemoveBusinessAccountProfilePhotoAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetBusinessAccountGiftSettings(SetBusinessAccountGiftSettingsParameters parameters)
    {
        return SetBusinessAccountGiftSettingsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public StarAmount GetBusinessAccountStarBalance(GetBusinessAccountStarBalanceParameters parameters)
    {
        return GetBusinessAccountStarBalanceAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool TransferBusinessAccountStars(TransferBusinessAccountStarsParameters parameters)
    {
        return TransferBusinessAccountStarsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public OwnedGifts GetBusinessAccountGifts(GetBusinessAccountGiftsParameters parameters)
    {
        return GetBusinessAccountGiftsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ConvertGiftToStars(ConvertGiftToStarsParameters parameters)
    {
        return ConvertGiftToStarsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool UpgradeGift(UpgradeGiftParameters parameters)
    {
        return UpgradeGiftAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool TransferGift(TransferGiftParameters parameters)
    {
        return TransferGiftAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Story PostStory(PostStoryParameters parameters)
    {
        return PostStoryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Story EditStory(EditStoryParameters parameters)
    {
        return EditStoryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Story DeleteStory(DeleteStoryParameters parameters)
    {
        return DeleteStoryAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Stickers
    public Message SendSticker(SendStickerParameters parameters)
    {
        return SendStickerAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public StickerSet GetStickerSet(GetStickerSetParameters parameters)
    {
        return GetStickerSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Sticker[] GetCustomEmojiStickers(GetCustomEmojiStickersParameters parameters)
    {
        return GetCustomEmojiStickersAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public FileStruct UploadStickerFile(UploadStickerFileParameters parameters)
    {
        return UploadStickerFileAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool CreateNewStickerSet(CreateNewStickerSetParameters parameters)
    {
        return CreateNewStickerSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool AddStickerToSet(AddStickerToSetParameters parameters)
    {
        return AddStickerToSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetStickerPositionInSet(SetStickerPositionInSetParameters parameters)
    {
        return SetStickerPositionInSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteStickerFromSet(DeleteStickerFromSetParameters parameters)
    {
        return DeleteStickerFromSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool ReplaceStickerInSet(ReplaceStickerInSetParameters parameters)
    {
        return ReplaceStickerInSetAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetStickerEmojiList(SetStickerEmojiListParameters parameters)
    {
        return SetStickerEmojiListAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetStickerKeywords(SetStickerKeywordsParameters parameters)
    {
        return SetStickerKeywordsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetStickerMaskPosition(SetStickerMaskPositionParameters parameters)
    {
        return SetStickerMaskPositionAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetStickerSetTitle(SetStickerSetTitleParameters parameters)
    {
        return SetStickerSetTitleAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetStickerSetThumbnail(SetStickerSetThumbnailParameters parameters)
    {
        return SetStickerSetThumbnailAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool SetCustomEmojiStickerSetThumbnail(SetCustomEmojiStickerSetThumbnailParameters parameters)
    {
        return SetCustomEmojiStickerSetThumbnailAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool DeleteStickerSet(DeleteStickerSetParameters parameters)
    {
        return DeleteStickerSetAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Inline mode
    public bool AnswerInlineQuery(AnswerInlineQueryParameters parameters)
    {
        return AnswerInlineQueryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public SentWebAppMessage AnswerWebAppQuery(AnswerWebAppQueryParameters parameters)
    {
        return AnswerWebAppQueryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public PreparedInlineMessage SavePreparedInlineMessage(SavePreparedInlineMessageParameters parameters)
    {
        return SavePreparedInlineMessageAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Payments
    public Message SendInvoice(SendInvoiceParameters parameters)
    {
        return SendInvoiceAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public string CreateInvoiceLink(CreateInvoiceLinkParameters parameters)
    {
        return CreateInvoiceLinkAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool AnswerShippingQuery(AnswerShippingQueryParameters parameters)
    {
        return AnswerShippingQueryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool AnswerPreCheckoutQuery(AnswerPreCheckoutQueryParameters parameters)
    {
        return AnswerPreCheckoutQueryAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public StarAmount GetMyStarBalance(GetMyStarBalanceParameters parameters)
    {
        return GetMyStarBalanceAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public StarTransactions GetStarTransactions(GetStarTransactionsyParameters parameters)
    {
        return GetStarTransactionsAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool RefundStarPayment(RefundStarPaymentParameters parameters)
    {
        return RefundStarPaymentAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public bool EditUserStarSubscription(EditUserStarSubscriptionParameters parameters)
    {
        return EditUserStarSubscriptionAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Telegram Passport
    public bool SetPassportDataErrors(SetPassportDataErrorsParameters parameters)
    {
        return SetPassportDataErrorsAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion

    #region Games
    public Message SendGame(SendGameParameters parameters)
    {
        return SendGameAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public Message SetGameScore(SetGameScoreParameters parameters)
    {
        return SetGameScoreAsync(parameters).GetAwaiter().GetResult().Result;
    }

    public GameHighScore[] GetGameHighScores(GetGameHighScoresParameters parameters)
    {
        return GetGameHighScoresAsync(parameters).GetAwaiter().GetResult().Result;
    }
    #endregion
}
