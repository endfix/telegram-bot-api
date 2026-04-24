using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    #region Getting updates
    public async Task<IReadOnlyList<Update>?> GetUpdatesAsync(GetUpdatesParameters? parameters = null, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync<IReadOnlyList<Update>>(new ApiRequest("getUpdates", parameters), cancellationToken);
    }

    public async Task<bool> SetWebhookAsync(SetWebhookParameters parameters, CancellationToken cancellationToken = default)
     => await ExecuteAsync<bool>(new ApiRequest("setWebhook", parameters), cancellationToken);


    public async Task<bool> DeleteWebhookAsync(DeleteWebhookParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteWebhook", parameters), cancellationToken);


    public async Task<WebhookInfo> GetWebhookInfoAsync(GetWebhookInfoParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters), cancellationToken);

    #endregion

    #region Available methods
    public async Task<User> GetMeAsync(GetMeParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<User>(new ApiRequest("getMe", parameters), cancellationToken);


    public async Task<bool> LogOutAsync(LogOutParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("logOut", parameters), cancellationToken);


    public async Task<bool> CloseAsync(CloseParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("close", parameters), cancellationToken);


    public async Task<Message> SendMessageAsync(SendMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendMessage", parameters), cancellationToken);


    public async Task<Message> ForwardMessageAsync(ForwardMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("forwardMessage", parameters), cancellationToken);


    public async Task<IReadOnlyList<MessageIdStruct>> ForwardMessagesAsync(ForwardMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<MessageIdStruct>>(new ApiRequest("forwardMessages", parameters), cancellationToken);


    public async Task<MessageIdStruct> CopyMessageAsync(CopyMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<MessageIdStruct>(new ApiRequest("copyMessage", parameters), cancellationToken);


    public async Task<IReadOnlyList<MessageIdStruct>> CopyMessagesAsync(CopyMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<MessageIdStruct>>(new ApiRequest("copyMessages", parameters), cancellationToken);


    public async Task<Message> SendPhotoAsync(SendPhotoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendPhoto", parameters), cancellationToken);


    public async Task<Message> SendAudioAsync(SendAudioParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendAudio", parameters), cancellationToken);


    public async Task<Message> SendDocumentAsync(SendDocumentParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendDocument", parameters), cancellationToken);


    public async Task<Message> SendVideoAsync(SendVideoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendVideo", parameters), cancellationToken);


    public async Task<Message> SendAnimationAsync(SendAnimationParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendAnimation", parameters), cancellationToken);


    public async Task<Message> SendVoiceAsync(SendVoiceParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendVoice", parameters), cancellationToken);


    public async Task<Message> SendVideoNoteAsync(SendVideoNoteParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendVideoNote", parameters), cancellationToken);


    public async Task<Message> SendPaidMediaAsync(SendPaidMediaParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendPaidMedia", parameters), cancellationToken);


    public async Task<IReadOnlyList<Message>> SendMediaGroupAsync(SendMediaGroupParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<Message>>(new ApiRequest("sendMediaGroup", parameters), cancellationToken);


    public async Task<Message> SendLocationAsync(SendLocationParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendLocation", parameters), cancellationToken);


    public async Task<Message> SendVenueAsync(SendVenueParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendVenue", parameters), cancellationToken);


    public async Task<Message> SendContactAsync(SendContactParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendContact", parameters), cancellationToken);


    public async Task<Message> SendPollAsync(SendPollParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendPoll", parameters), cancellationToken);


    public async Task<Message> SendChecklistAsync(SendChecklistParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendChecklist", parameters), cancellationToken);


    public async Task<Message> SendDiceAsync(SendDiceParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendDice", parameters), cancellationToken);


    public async Task<bool> SendMessageDraftAsync(SendMessageDraftParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("sendMessageDraft", parameters), cancellationToken);


    public async Task<bool> SendChatActionAsync(SendChatActionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("sendChatAction", parameters), cancellationToken);


    public async Task<bool> SetMessageReactionAsync(SetMessageReactionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMessageReaction", parameters), cancellationToken);


    public async Task<UserProfilePhotos> GetUserProfilePhotosAsync(GetUserProfilePhotosParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<UserProfilePhotos>(new ApiRequest("getUserProfilePhotos", parameters), cancellationToken);


    public async Task<UserProfileAudios> GetUserProfileAudiosAsync(GetUserProfileAudiosParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<UserProfileAudios>(new ApiRequest("getUserProfileAudios", parameters), cancellationToken);


    public async Task<bool> SetUserEmojiStatusAsync(SetUserEmojiStatusParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setUserEmojiStatus", parameters), cancellationToken);


    public async Task<FileStruct> GetFileAsync(GetFileParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<FileStruct>(new ApiRequest("getFile", parameters), cancellationToken);


    public async Task<bool> BanChatMemberAsync(BanChatMemberParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("banChatMember", parameters), cancellationToken);


    public async Task<bool> UnbanChatMemberAsync(UnbanChatMemberParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unbanChatMember", parameters), cancellationToken);


    public async Task<bool> RestrictChatMemberAsync(RestrictChatMemberParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("restrictChatMember", parameters), cancellationToken);


    public async Task<bool> PromoteChatMemberAsync(PromoteChatMemberParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("promoteChatMember", parameters), cancellationToken);


    public async Task<bool> SetChatAdministratorCustomTitleAsync(SetChatAdministratorCustomTitleParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatAdministratorCustomTitle", parameters), cancellationToken);


    public async Task<bool> SetChatMemberTagAsync(SetChatMemberTagParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatMemberTag", parameters), cancellationToken);


    public async Task<bool> BanChatSenderChatAsync(BanChatSenderChatParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("banChatSenderChat", parameters), cancellationToken);


    public async Task<bool> UnbanChatSenderChatAsync(UnbanChatSenderChatParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unbanChatSenderChat", parameters), cancellationToken);


    public async Task<bool> SetChatPermissionsAsync(SetChatPermissionsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatPermissions", parameters), cancellationToken);


    public async Task<string> ExportChatInviteLinkAsync(ExportChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<string>(new ApiRequest("exportChatInviteLink", parameters), cancellationToken);


    public async Task<ChatInviteLink> CreateChatInviteLinkAsync(CreateChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatInviteLink>(new ApiRequest("createChatInviteLink", parameters), cancellationToken);


    public async Task<ChatInviteLink> EditChatInviteLinkAsync(EditChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatInviteLink>(new ApiRequest("editChatInviteLink", parameters), cancellationToken);


    public async Task<ChatInviteLink> CreateChatSubscriptionInviteLinkAsync(CreateChatSubscriptionInviteLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatInviteLink>(new ApiRequest("createChatSubscriptionInviteLink", parameters), cancellationToken);


    public async Task<ChatInviteLink> EditChatSubscriptionInviteLinkAsync(EditChatSubscriptionInviteLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatInviteLink>(new ApiRequest("editChatSubscriptionInviteLink", parameters), cancellationToken);


    public async Task<ChatInviteLink> RevokeChatInviteLinkAsync(RevokeChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatInviteLink>(new ApiRequest("revokeChatInviteLink", parameters), cancellationToken);


    public async Task<bool> ApproveChatJoinRequestAsync(ApproveChatJoinRequestParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("approveChatJoinRequest", parameters), cancellationToken);


    public async Task<bool> DeclineChatJoinRequestAsync(DeclineChatJoinRequestParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("declineChatJoinRequest", parameters), cancellationToken);


    public async Task<bool> SetChatPhotoAsync(SetChatPhotoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatPhoto", parameters), cancellationToken);


    public async Task<bool> DeleteChatPhotoAsync(DeleteChatPhotoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteChatPhoto", parameters), cancellationToken);


    public async Task<bool> SetChatTitleAsync(SetChatTitleParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatTitle", parameters), cancellationToken);


    public async Task<bool> SetChatDescriptionAsync(SetChatDescriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatDescription", parameters), cancellationToken);


    public async Task<bool> PinChatMessageAsync(PinChatMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("pinChatMessage", parameters), cancellationToken);


    public async Task<bool> UnpinChatMessageAsync(UnpinChatMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unpinChatMessage", parameters), cancellationToken);


    public async Task<bool> UnpinAllChatMessagesAsync(UnpinAllChatMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unpinAllChatMessages", parameters), cancellationToken);


    public async Task<bool> LeaveChatAsync(LeaveChatParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("leaveChat", parameters), cancellationToken);


    public async Task<ChatFullInfo> GetChatAsync(GetChatParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatFullInfo>(new ApiRequest("getChat", parameters), cancellationToken);


    public async Task<IReadOnlyList<ChatMember>> GetChatAdministratorsAsync(GetChatAdministratorsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<ChatMember>>(new ApiRequest("getChatAdministrators", parameters), cancellationToken);


    public async Task<int> GetChatMemberCountAsync(GetChatMemberCountParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<int>(new ApiRequest("getChatMemberCount", parameters), cancellationToken);


    public async Task<ChatMember> GetChatMemberAsync(GetChatMemberParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatMember>(new ApiRequest("getChatMember", parameters), cancellationToken);


    public async Task<bool> SetChatStickerSetAsync(SetChatStickerSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatStickerSet", parameters), cancellationToken);


    public async Task<bool> DeleteChatStickerSetAsync(DeleteChatStickerSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteChatStickerSet", parameters), cancellationToken);


    public async Task<IReadOnlyList<Sticker>> GetForumTopicIconStickersAsync(GetForumTopicIconStickersParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getForumTopicIconStickers", parameters), cancellationToken);


    public async Task<ForumTopic> CreateForumTopicAsync(CreateForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ForumTopic>(new ApiRequest("createForumTopic", parameters), cancellationToken);


    public async Task<bool> EditForumTopicAsync(EditForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("editForumTopic", parameters), cancellationToken);


    public async Task<bool> CloseForumTopicAsync(CloseForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("closeForumTopic", parameters), cancellationToken);


    public async Task<bool> ReopenForumTopicAsync(ReopenForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("reopenForumTopic", parameters), cancellationToken);


    public async Task<bool> DeleteForumTopicAsync(DeleteForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteForumTopic", parameters), cancellationToken);


    public async Task<bool> UnpinAllForumTopicMessagesAsync(UnpinAllForumTopicMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unpinAllForumTopicMessages", parameters), cancellationToken);


    public async Task<bool> EditGeneralForumTopicAsync(EditGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("editGeneralForumTopic", parameters), cancellationToken);


    public async Task<bool> CloseGeneralForumTopicAsync(CloseGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("closeGeneralForumTopic", parameters), cancellationToken);


    public async Task<bool> ReopenGeneralForumTopicAsync(ReopenGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("reopenGeneralForumTopic", parameters), cancellationToken);


    public async Task<bool> HideGeneralForumTopicAsync(HideGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("hideGeneralForumTopic", parameters), cancellationToken);


    public async Task<bool> UnhideGeneralForumTopicAsync(UnhideGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unhideGeneralForumTopic", parameters), cancellationToken);


    public async Task<bool> UnpinAllGeneralForumTopicMessagesAsync(UnpinAllGeneralForumTopicMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("unpinAllGeneralForumTopicMessages", parameters), cancellationToken);


    public async Task<bool> AnswerCallbackQueryAsync(AnswerCallbackQueryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("answerCallbackQuery", parameters), cancellationToken);


    public async Task<UserChatBoosts> GetUserChatBoostsAsync(GetUserChatBoostsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<UserChatBoosts>(new ApiRequest("getUserChatBoosts", parameters), cancellationToken);


    public async Task<BusinessConnection> GetBusinessConnectionAsync(GetBusinessConnectionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<BusinessConnection>(new ApiRequest("getBusinessConnection", parameters), cancellationToken);


    public async Task<string> GetManagedBotTokenAsync(GetManagedBotTokenParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<string>(new ApiRequest("getManagedBotToken", parameters), cancellationToken);


    public async Task<string> ReplaceManagedBotTokenAsync(ReplaceManagedBotTokenParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<string>(new ApiRequest("replaceManagedBotToken", parameters), cancellationToken);


    public async Task<bool> SetMyCommandsAsync(SetMyCommandsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMyCommands", parameters), cancellationToken);


    public async Task<bool> DeleteMyCommandsAsync(DeleteMyCommandsParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteMyCommands", parameters), cancellationToken);


    public async Task<IReadOnlyList<BotCommand>> GetMyCommandsAsync(GetMyCommandsParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<BotCommand>>(new ApiRequest("getMyCommands", parameters), cancellationToken);


    public async Task<bool> SetMyNameAsync(SetMyNameParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMyName", parameters), cancellationToken);


    public async Task<BotName> GetMyNameAsync(GetMyNameParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<BotName>(new ApiRequest("getMyName", parameters), cancellationToken);


    public async Task<bool> SetMyDescriptionAsync(SetMyDescriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMyDescription", parameters), cancellationToken);


    public async Task<BotDescription> GetMyDescriptionAsync(GetMyDescriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<BotDescription>(new ApiRequest("getMyDescription", parameters), cancellationToken);


    public async Task<bool> SetMyShortDescriptionAsync(SetMyShortDescriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMyShortDescription", parameters), cancellationToken);


    public async Task<BotShortDescription> GetMyShortDescriptionAsync(GetMyShortDescriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<BotShortDescription>(new ApiRequest("getMyShortDescription", parameters), cancellationToken);


    public async Task<bool> SetMyProfilePhotoAsync(SetMyProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMyProfilePhoto", parameters), cancellationToken);


    public async Task<BotShortDescription> RemoveMyProfilePhotoAsync(RemoveMyProfilePhotoParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<BotShortDescription>(new ApiRequest("removeMyProfilePhoto", parameters), cancellationToken);


    public async Task<bool> SetChatMenuButtonAsync(SetChatMenuButtonParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setChatMenuButton", parameters), cancellationToken);


    public async Task<MenuButton> GetChatMenuButtonAsync(GetChatMenuButtonParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<MenuButton>(new ApiRequest("getChatMenuButton", parameters), cancellationToken);


    public async Task<bool> SetMyDefaultAdministratorRightsAsync(SetMyDefaultAdministratorRightsParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setMyDefaultAdministratorRights", parameters), cancellationToken);


    public async Task<ChatAdministratorRights> GetMyDefaultAdministratorRightsAsync(GetMyDefaultAdministratorRightsParameters? parameters = null, CancellationToken cancellationToken = default)
         => await ExecuteAsync<ChatAdministratorRights>(new ApiRequest("getMyDefaultAdministratorRights", parameters), cancellationToken);


    public async Task<GiftsStruct> GetAvailableGiftsAsync(GetAvailableGiftsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<GiftsStruct>(new ApiRequest("getAvailableGifts", parameters), cancellationToken);


    public async Task<bool> SendGiftAsync(SendGiftParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("sendGift", parameters), cancellationToken);


    public async Task<bool> GiftPremiumSubscriptionAsync(GiftPremiumSubscriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("giftPremiumSubscription", parameters), cancellationToken);


    public async Task<bool> VerifyUserAsync(VerifyUserParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("verifyUser", parameters), cancellationToken);


    public async Task<bool> VerifyChatAsync(VerifyChatParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("verifyChat", parameters), cancellationToken);


    public async Task<bool> RemoveUserVerificationAsync(RemoveUserVerificationParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("removeUserVerification", parameters), cancellationToken);


    public async Task<bool> RemoveChatVerificationAsync(RemoveChatVerificationParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("removeChatVerification", parameters), cancellationToken);


    public async Task<bool> ReadBusinessMessageAsync(ReadBusinessMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("readBusinessMessage", parameters), cancellationToken);


    public async Task<bool> DeleteBusinessMessagesAsync(DeleteBusinessMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteBusinessMessages", parameters), cancellationToken);


    public async Task<bool> SetBusinessAccountNameAsync(SetBusinessAccountNameParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setBusinessAccountName", parameters), cancellationToken);


    public async Task<bool> SetBusinessAccountUsernameAsync(SetBusinessAccountUsernameParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setBusinessAccountUsername", parameters), cancellationToken);


    public async Task<bool> SetBusinessAccountBioAsync(SetBusinessAccountBioParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setBusinessAccountBio", parameters), cancellationToken);


    public async Task<bool> SetBusinessAccountProfilePhotoAsync(SetBusinessAccountProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setBusinessAccountProfilePhoto", parameters), cancellationToken);


    public async Task<bool> RemoveBusinessAccountProfilePhotoAsync(RemoveBusinessAccountProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("removeBusinessAccountProfilePhoto", parameters), cancellationToken);


    public async Task<bool> SetBusinessAccountGiftSettingsAsync(SetBusinessAccountGiftSettingsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setBusinessAccountGiftSettings", parameters), cancellationToken);


    public async Task<StarAmount> GetBusinessAccountStarBalanceAsync(GetBusinessAccountStarBalanceParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<StarAmount>(new ApiRequest("getBusinessAccountStarBalance", parameters), cancellationToken);


    public async Task<bool> TransferBusinessAccountStarsAsync(TransferBusinessAccountStarsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("transferBusinessAccountStars", parameters), cancellationToken);


    public async Task<OwnedGifts> GetBusinessAccountGiftsAsync(GetBusinessAccountGiftsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<OwnedGifts>(new ApiRequest("getBusinessAccountGifts", parameters), cancellationToken);


    public async Task<OwnedGifts> GetUserGiftsASync(GetUserGiftsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<OwnedGifts>(new ApiRequest("getUserGifts", parameters), cancellationToken);


    public async Task<OwnedGifts> GetChatGiftsAsync(GetChatGiftsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<OwnedGifts>(new ApiRequest("getChatGifts", parameters), cancellationToken);


    public async Task<bool> ConvertGiftToStarsAsync(ConvertGiftToStarsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("convertGiftToStars", parameters), cancellationToken);


    public async Task<bool> UpgradeGiftAsync(UpgradeGiftParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("upgradeGift", parameters), cancellationToken);


    public async Task<bool> TransferGiftAsync(TransferGiftParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("transferGift", parameters), cancellationToken);


    public async Task<Story> PostStoryAsync(PostStoryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Story>(new ApiRequest("postStory", parameters), cancellationToken);


    public async Task<Story> RepostStoryAsync(RepostStoryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Story>(new ApiRequest("repostStory", parameters), cancellationToken);


    public async Task<Story> EditStoryAsync(EditStoryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Story>(new ApiRequest("editStory", parameters), cancellationToken);


    public async Task<Story> DeleteStoryAsync(DeleteStoryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Story>(new ApiRequest("deleteStory", parameters), cancellationToken);

    #endregion

    #region Updating messages
    public async Task<Message> EditMessageTextAsync(EditMessageTextParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("editMessageText", parameters), cancellationToken);


    public async Task<Message> EditMessageCaptionAsync(EditMessageCaptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("editMessageCaption", parameters), cancellationToken);


    public async Task<Message> EditMessageMediaAsync(EditMessageMediaParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("editMessageMedia", parameters), cancellationToken);


    public async Task<Message> EditMessageLiveLocationAsync(EditMessageLiveLocationParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);


    public async Task<Message> StopMessageLiveLocationAsync(StopMessageLiveLocationParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);


    public async Task<Message> EditMessageChecklistAsync(EditMessageChecklistParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("editMessageChecklist", parameters), cancellationToken);


    public async Task<Message> EditMessageReplyMarkupAsync(EditMessageReplyMarkupParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);


    public async Task<Poll> StopPollAsync(StopPollParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Poll>(new ApiRequest("stopPoll", parameters), cancellationToken);


    public async Task<bool> ApproveSuggestedPostAsync(ApproveSuggestedPostParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("approveSuggestedPost", parameters), cancellationToken);


    public async Task<bool> DeclineSuggestedPostAsync(DeclineSuggestedPostParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("declineSuggestedPost", parameters), cancellationToken);


    public async Task<bool> DeleteMessageAsync(DeleteMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteMessage", parameters), cancellationToken);


    public async Task<bool> DeleteMessagesAsync(DeleteMessagesParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteMessages", parameters), cancellationToken);

    #endregion

    #region Stickers
    public async Task<Message> SendStickerAsync(SendStickerParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendSticker", parameters), cancellationToken);


    public async Task<StickerSet> GetStickerSetAsync(GetStickerSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<StickerSet>(new ApiRequest("getStickerSet", parameters), cancellationToken);


    public async Task<IReadOnlyList<Sticker>> GetCustomEmojiStickersAsync(GetCustomEmojiStickersParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getCustomEmojiStickers", parameters), cancellationToken);


    public async Task<FileStruct> UploadStickerFileAsync(UploadStickerFileParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<FileStruct>(new ApiRequest("uploadStickerFile", parameters), cancellationToken);


    public async Task<bool> CreateNewStickerSetAsync(CreateNewStickerSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("createNewStickerSet", parameters), cancellationToken);


    public async Task<bool> AddStickerToSetAsync(AddStickerToSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("addStickerToSet", parameters), cancellationToken);


    public async Task<bool> SetStickerPositionInSetAsync(SetStickerPositionInSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters), cancellationToken);


    public async Task<bool> DeleteStickerFromSetAsync(DeleteStickerFromSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters), cancellationToken);


    public async Task<bool> ReplaceStickerInSetAsync(ReplaceStickerInSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("replaceStickerInSet", parameters), cancellationToken);


    public async Task<bool> SetStickerEmojiListAsync(SetStickerEmojiListParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setStickerEmojiList", parameters), cancellationToken);


    public async Task<bool> SetStickerKeywordsAsync(SetStickerKeywordsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setStickerKeywords", parameters), cancellationToken);


    public async Task<bool> SetStickerMaskPositionAsync(SetStickerMaskPositionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters), cancellationToken);


    public async Task<bool> SetStickerSetTitleAsync(SetStickerSetTitleParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setStickerSetTitle", parameters), cancellationToken);


    public async Task<bool> SetStickerSetThumbnailAsync(SetStickerSetThumbnailParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters), cancellationToken);


    public async Task<bool> SetCustomEmojiStickerSetThumbnailAsync(SetCustomEmojiStickerSetThumbnailParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters), cancellationToken);


    public async Task<bool> DeleteStickerSetAsync(DeleteStickerSetParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("deleteStickerSet", parameters), cancellationToken);

    #endregion

    #region Inline mode
    public async Task<bool> AnswerInlineQueryAsync(AnswerInlineQueryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("answerInlineQuery", parameters), cancellationToken);


    public async Task<SentWebAppMessage> AnswerWebAppQueryAsync(AnswerWebAppQueryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters), cancellationToken);


    public async Task<PreparedInlineMessage> SavePreparedInlineMessageAsync(SavePreparedInlineMessageParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters), cancellationToken);


    public async Task<PreparedKeyboardButton> SavePreparedKeyboardButtonAsync(SavePreparedKeyboardButtonParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<PreparedKeyboardButton>(new ApiRequest("savePreparedKeyboardButton", parameters), cancellationToken);

    #endregion

    #region Payments
    public async Task<Message> SendInvoiceAsync(SendInvoiceParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendInvoice", parameters), cancellationToken);


    public async Task<string> CreateInvoiceLinkAsync(CreateInvoiceLinkParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<string>(new ApiRequest("createInvoiceLink", parameters), cancellationToken);


    public async Task<bool> AnswerShippingQueryAsync(AnswerShippingQueryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("answerShippingQuery", parameters), cancellationToken);


    public async Task<bool> AnswerPreCheckoutQueryAsync(AnswerPreCheckoutQueryParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters), cancellationToken);


    public async Task<StarAmount> GetMyStarBalanceAsync(GetMyStarBalanceParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<StarAmount>(new ApiRequest("getMyStarBalance", parameters), cancellationToken);


    public async Task<StarTransactions> GetStarTransactionsAsync(GetStarTransactionsyParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters), cancellationToken);


    public async Task<bool> RefundStarPaymentAsync(RefundStarPaymentParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("refundStarPayment", parameters), cancellationToken);


    public async Task<bool> EditUserStarSubscriptionAsync(EditUserStarSubscriptionParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("editUserStarSubscription", parameters), cancellationToken);

    #endregion

    #region Telegram Passport
    public async Task<bool> SetPassportDataErrorsAsync(SetPassportDataErrorsParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<bool>(new ApiRequest("setPassportDataErrors", parameters), cancellationToken);

    #endregion

    #region Games
    public async Task<Message> SendGameAsync(SendGameParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("sendGame", parameters), cancellationToken);


    public async Task<Message> SetGameScoreAsync(SetGameScoreParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<Message>(new ApiRequest("setGameScore", parameters), cancellationToken);


    public async Task<IReadOnlyList<GameHighScore>> GetGameHighScoresAsync(GetGameHighScoresParameters parameters, CancellationToken cancellationToken = default)
         => await ExecuteAsync<IReadOnlyList<GameHighScore>>(new ApiRequest("getGameHighScores", parameters), cancellationToken);
    #endregion
}
