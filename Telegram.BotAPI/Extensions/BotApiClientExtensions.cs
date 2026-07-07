using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static class IBotApiClientExtensions
{
    #region Getting updates
    public static async Task<IReadOnlyList<Update>?> GetUpdatesAsync(this IBotApiClient client, GetUpdatesParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Update>>(new ApiRequest("getUpdates", parameters), cancellationToken);

    public static async Task<bool> SetWebhookAsync(this IBotApiClient client, SetWebhookParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setWebhook", parameters), cancellationToken);

    public static async Task<bool> DeleteWebhookAsync(this IBotApiClient client, DeleteWebhookParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteWebhook", parameters), cancellationToken);

    public static async Task<WebhookInfo> GetWebhookInfoAsync(this IBotApiClient client, GetWebhookInfoParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters), cancellationToken);
    #endregion

    #region Available methods
    public static async Task<User> GetMeAsync(this IBotApiClient client, GetMeParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<User>(new ApiRequest("getMe", parameters), cancellationToken);

    public static async Task<bool> LogOutAsync(this IBotApiClient client, LogOutParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("logOut", parameters), cancellationToken);

    public static async Task<bool> CloseAsync(this IBotApiClient client, CloseParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("close", parameters), cancellationToken);

    public static async Task<Message> SendMessageAsync(this IBotApiClient client, SendMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendMessage", parameters), cancellationToken);

    public static async Task<Message> ForwardMessageAsync(this IBotApiClient client, ForwardMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("forwardMessage", parameters), cancellationToken);

    public static async Task<IReadOnlyList<MessageIdStruct>> ForwardMessagesAsync(this IBotApiClient client, ForwardMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<MessageIdStruct>>(new ApiRequest("forwardMessages", parameters), cancellationToken);

    public static async Task<MessageIdStruct> CopyMessageAsync(this IBotApiClient client, CopyMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<MessageIdStruct>(new ApiRequest("copyMessage", parameters), cancellationToken);

    public static async Task<IReadOnlyList<MessageIdStruct>> CopyMessagesAsync(this IBotApiClient client, CopyMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<MessageIdStruct>>(new ApiRequest("copyMessages", parameters), cancellationToken);

    public static async Task<Message> SendPhotoAsync(this IBotApiClient client, SendPhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendPhoto", parameters), cancellationToken);

    public static async Task<Message> SendLivePhotoAsync(this IBotApiClient client, SendLivePhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendLivePhoto", parameters), cancellationToken);

    public static async Task<Message> SendAudioAsync(this IBotApiClient client, SendAudioParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendAudio", parameters), cancellationToken);

    public static async Task<Message> SendDocumentAsync(this IBotApiClient client, SendDocumentParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendDocument", parameters), cancellationToken);

    public static async Task<Message> SendVideoAsync(this IBotApiClient client, SendVideoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVideo", parameters), cancellationToken);

    public static async Task<Message> SendAnimationAsync(this IBotApiClient client, SendAnimationParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendAnimation", parameters), cancellationToken);

    public static async Task<Message> SendVoiceAsync(this IBotApiClient client, SendVoiceParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVoice", parameters), cancellationToken);

    public static async Task<Message> SendVideoNoteAsync(this IBotApiClient client, SendVideoNoteParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVideoNote", parameters), cancellationToken);

    public static async Task<Message> SendPaidMediaAsync(this IBotApiClient client, SendPaidMediaParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendPaidMedia", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Message>> SendMediaGroupAsync(this IBotApiClient client, SendMediaGroupParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Message>>(new ApiRequest("sendMediaGroup", parameters), cancellationToken);

    public static async Task<Message> SendLocationAsync(this IBotApiClient client, SendLocationParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendLocation", parameters), cancellationToken);

    public static async Task<Message> SendVenueAsync(this IBotApiClient client, SendVenueParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVenue", parameters), cancellationToken);

    public static async Task<Message> SendContactAsync(this IBotApiClient client, SendContactParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendContact", parameters), cancellationToken);

    public static async Task<Message> SendPollAsync(this IBotApiClient client, SendPollParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendPoll", parameters), cancellationToken);

    public static async Task<Message> SendChecklistAsync(this IBotApiClient client, SendChecklistParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendChecklist", parameters), cancellationToken);

    public static async Task<Message> SendDiceAsync(this IBotApiClient client, SendDiceParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendDice", parameters), cancellationToken);

    public static async Task<bool> SendMessageDraftAsync(this IBotApiClient client, SendMessageDraftParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendMessageDraft", parameters), cancellationToken);

    public static async Task<bool> SendChatActionAsync(this IBotApiClient client, SendChatActionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendChatAction", parameters), cancellationToken);

    public static async Task<bool> SetMessageReactionAsync(this IBotApiClient client, SetMessageReactionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMessageReaction", parameters), cancellationToken);

    public static async Task<UserProfilePhotos> GetUserProfilePhotosAsync(this IBotApiClient client, GetUserProfilePhotosParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<UserProfilePhotos>(new ApiRequest("getUserProfilePhotos", parameters), cancellationToken);

    public static async Task<UserProfileAudios> GetUserProfileAudiosAsync(this IBotApiClient client, GetUserProfileAudiosParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<UserProfileAudios>(new ApiRequest("getUserProfileAudios", parameters), cancellationToken);

    public static async Task<bool> SetUserEmojiStatusAsync(this IBotApiClient client, SetUserEmojiStatusParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setUserEmojiStatus", parameters), cancellationToken);

    public static async Task<FileStruct> GetFileAsync(this IBotApiClient client, GetFileParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<FileStruct>(new ApiRequest("getFile", parameters), cancellationToken);

    public static async Task<bool> BanChatMemberAsync(this IBotApiClient client, BanChatMemberParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("banChatMember", parameters), cancellationToken);

    public static async Task<bool> UnbanChatMemberAsync(this IBotApiClient client, UnbanChatMemberParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unbanChatMember", parameters), cancellationToken);

    public static async Task<bool> RestrictChatMemberAsync(this IBotApiClient client, RestrictChatMemberParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("restrictChatMember", parameters), cancellationToken);

    public static async Task<bool> PromoteChatMemberAsync(this IBotApiClient client, PromoteChatMemberParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("promoteChatMember", parameters), cancellationToken);

    public static async Task<bool> SetChatAdministratorCustomTitleAsync(this IBotApiClient client, SetChatAdministratorCustomTitleParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatAdministratorCustomTitle", parameters), cancellationToken);

    public static async Task<bool> SetChatMemberTagAsync(this IBotApiClient client, SetChatMemberTagParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatMemberTag", parameters), cancellationToken);


    public static async Task<bool> BanChatSenderChatAsync(this IBotApiClient client, BanChatSenderChatParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("banChatSenderChat", parameters), cancellationToken);


    public static async Task<bool> UnbanChatSenderChatAsync(this IBotApiClient client, UnbanChatSenderChatParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unbanChatSenderChat", parameters), cancellationToken);

    public static async Task<bool> SetChatPermissionsAsync(this IBotApiClient client, SetChatPermissionsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatPermissions", parameters), cancellationToken);

    public static async Task<string> ExportChatInviteLinkAsync(this IBotApiClient client, ExportChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("exportChatInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> CreateChatInviteLinkAsync(this IBotApiClient client, CreateChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("createChatInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> EditChatInviteLinkAsync(this IBotApiClient client, EditChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("editChatInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> CreateChatSubscriptionInviteLinkAsync(this IBotApiClient client, CreateChatSubscriptionInviteLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("createChatSubscriptionInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> EditChatSubscriptionInviteLinkAsync(this IBotApiClient client, EditChatSubscriptionInviteLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("editChatSubscriptionInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> RevokeChatInviteLinkAsync(this IBotApiClient client, RevokeChatInviteLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("revokeChatInviteLink", parameters), cancellationToken);

    public static async Task<bool> ApproveChatJoinRequestAsync(this IBotApiClient client, ApproveChatJoinRequestParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("approveChatJoinRequest", parameters), cancellationToken);

    public static async Task<bool> DeclineChatJoinRequestAsync(this IBotApiClient client, DeclineChatJoinRequestParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("declineChatJoinRequest", parameters), cancellationToken);

    public static async Task<bool> AnswerChatJoinRequestQueryAsync(this IBotApiClient client, AnswerChatJoinRequestQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerChatJoinRequestQuery", parameters), cancellationToken);

    public static async Task<bool> SendChatJoinRequestWebAppAsync(this IBotApiClient client, SendChatJoinRequestWebAppParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendChatJoinRequestWebApp", parameters), cancellationToken);

    public static async Task<bool> SetChatPhotoAsync(this IBotApiClient client, SetChatPhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatPhoto", parameters), cancellationToken);

    public static async Task<bool> DeleteChatPhotoAsync(this IBotApiClient client, DeleteChatPhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteChatPhoto", parameters), cancellationToken);

    public static async Task<bool> SetChatTitleAsync(this IBotApiClient client, SetChatTitleParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatTitle", parameters), cancellationToken);

    public static async Task<bool> SetChatDescriptionAsync(this IBotApiClient client, SetChatDescriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatDescription", parameters), cancellationToken);

    public static async Task<bool> PinChatMessageAsync(this IBotApiClient client, PinChatMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("pinChatMessage", parameters), cancellationToken);

    public static async Task<bool> UnpinChatMessageAsync(this IBotApiClient client, UnpinChatMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinChatMessage", parameters), cancellationToken);

    public static async Task<bool> UnpinAllChatMessagesAsync(this IBotApiClient client, UnpinAllChatMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinAllChatMessages", parameters), cancellationToken);

    public static async Task<bool> LeaveChatAsync(this IBotApiClient client, LeaveChatParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("leaveChat", parameters), cancellationToken);

    public static async Task<ChatFullInfo> GetChatAsync(this IBotApiClient client, GetChatParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatFullInfo>(new ApiRequest("getChat", parameters), cancellationToken);

    public static async Task<IReadOnlyList<ChatMember>> GetChatAdministratorsAsync(this IBotApiClient client, GetChatAdministratorsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<ChatMember>>(new ApiRequest("getChatAdministrators", parameters), cancellationToken);

    public static async Task<int> GetChatMemberCountAsync(this IBotApiClient client, GetChatMemberCountParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<int>(new ApiRequest("getChatMemberCount", parameters), cancellationToken);

    public static async Task<ChatMember> GetChatMemberAsync(this IBotApiClient client, GetChatMemberParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatMember>(new ApiRequest("getChatMember", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Message>> GetUserPersonalChatMessagesAsync(this IBotApiClient client, GetUserPersonalChatMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Message>>(new ApiRequest("getUserPersonalChatMessages", parameters), cancellationToken);

    public static async Task<bool> SetChatStickerSetAsync(this IBotApiClient client, SetChatStickerSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatStickerSet", parameters), cancellationToken);

    public static async Task<bool> DeleteChatStickerSetAsync(this IBotApiClient client, DeleteChatStickerSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteChatStickerSet", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Sticker>> GetForumTopicIconStickersAsync(this IBotApiClient client, GetForumTopicIconStickersParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getForumTopicIconStickers", parameters), cancellationToken);

    public static async Task<ForumTopic> CreateForumTopicAsync(this IBotApiClient client, CreateForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ForumTopic>(new ApiRequest("createForumTopic", parameters), cancellationToken);

    public static async Task<bool> EditForumTopicAsync(this IBotApiClient client, EditForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editForumTopic", parameters), cancellationToken);

    public static async Task<bool> CloseForumTopicAsync(this IBotApiClient client, CloseForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("closeForumTopic", parameters), cancellationToken);

    public static async Task<bool> ReopenForumTopicAsync(this IBotApiClient client, ReopenForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("reopenForumTopic", parameters), cancellationToken);

    public static async Task<bool> DeleteForumTopicAsync(this IBotApiClient client, DeleteForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteForumTopic", parameters), cancellationToken);

    public static async Task<bool> UnpinAllForumTopicMessagesAsync(this IBotApiClient client, UnpinAllForumTopicMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinAllForumTopicMessages", parameters), cancellationToken);

    public static async Task<bool> EditGeneralForumTopicAsync(this IBotApiClient client, EditGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> CloseGeneralForumTopicAsync(this IBotApiClient client, CloseGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("closeGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> ReopenGeneralForumTopicAsync(this IBotApiClient client, ReopenGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("reopenGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> HideGeneralForumTopicAsync(this IBotApiClient client, HideGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("hideGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> UnhideGeneralForumTopicAsync(this IBotApiClient client, UnhideGeneralForumTopicParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unhideGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> UnpinAllGeneralForumTopicMessagesAsync(this IBotApiClient client, UnpinAllGeneralForumTopicMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinAllGeneralForumTopicMessages", parameters), cancellationToken);

    public static async Task<bool> AnswerCallbackQueryAsync(this IBotApiClient client, AnswerCallbackQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerCallbackQuery", parameters), cancellationToken);

    public static async Task<SentGuestMessage> AnswerGuestQueryAsync(this IBotApiClient client, AnswerGuestQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<SentGuestMessage>(new ApiRequest("answerGuestQuery", parameters), cancellationToken);

    public static async Task<UserChatBoosts> GetUserChatBoostsAsync(this IBotApiClient client, GetUserChatBoostsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<UserChatBoosts>(new ApiRequest("getUserChatBoosts", parameters), cancellationToken);

    public static async Task<BusinessConnection> GetBusinessConnectionAsync(this IBotApiClient client, GetBusinessConnectionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BusinessConnection>(new ApiRequest("getBusinessConnection", parameters), cancellationToken);

    public static async Task<string> GetManagedBotTokenAsync(this IBotApiClient client, GetManagedBotTokenParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("getManagedBotToken", parameters), cancellationToken);

    public static async Task<string> ReplaceManagedBotTokenAsync(this IBotApiClient client, ReplaceManagedBotTokenParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("replaceManagedBotToken", parameters), cancellationToken);

    public static async Task<BotAccessSettings> GetManagedBotAccessSettingsAsync(this IBotApiClient client, GetManagedBotAccessSettingsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotAccessSettings>(new ApiRequest("getManagedBotAccessSettings", parameters), cancellationToken);

    public static async Task<bool> SetManagedBotAccessSettingsAsync(this IBotApiClient client, SetManagedBotAccessSettingsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setManagedBotAccessSettings", parameters), cancellationToken);

    public static async Task<bool> SetMyCommandsAsync(this IBotApiClient client, SetMyCommandsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyCommands", parameters), cancellationToken);

    public static async Task<bool> DeleteMyCommandsAsync(this IBotApiClient client, DeleteMyCommandsParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMyCommands", parameters), cancellationToken);

    public static async Task<IReadOnlyList<BotCommand>> GetMyCommandsAsync(this IBotApiClient client, GetMyCommandsParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<BotCommand>>(new ApiRequest("getMyCommands", parameters), cancellationToken);

    public static async Task<bool> SetMyNameAsync(this IBotApiClient client, SetMyNameParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyName", parameters), cancellationToken);

    public static async Task<BotName> GetMyNameAsync(this IBotApiClient client, GetMyNameParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotName>(new ApiRequest("getMyName", parameters), cancellationToken);

    public static async Task<bool> SetMyDescriptionAsync(this IBotApiClient client, SetMyDescriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyDescription", parameters), cancellationToken);

    public static async Task<BotDescription> GetMyDescriptionAsync(this IBotApiClient client, GetMyDescriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotDescription>(new ApiRequest("getMyDescription", parameters), cancellationToken);

    public static async Task<bool> SetMyShortDescriptionAsync(this IBotApiClient client, SetMyShortDescriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyShortDescription", parameters), cancellationToken);

    public static async Task<BotShortDescription> GetMyShortDescriptionAsync(this IBotApiClient client, GetMyShortDescriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotShortDescription>(new ApiRequest("getMyShortDescription", parameters), cancellationToken);

    public static async Task<bool> SetMyProfilePhotoAsync(this IBotApiClient client, SetMyProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyProfilePhoto", parameters), cancellationToken);

    public static async Task<BotShortDescription> RemoveMyProfilePhotoAsync(this IBotApiClient client, RemoveMyProfilePhotoParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotShortDescription>(new ApiRequest("removeMyProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> SetChatMenuButtonAsync(this IBotApiClient client, SetChatMenuButtonParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatMenuButton", parameters), cancellationToken);

    public static async Task<MenuButton> GetChatMenuButtonAsync(this IBotApiClient client, GetChatMenuButtonParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<MenuButton>(new ApiRequest("getChatMenuButton", parameters), cancellationToken);

    public static async Task<bool> SetMyDefaultAdministratorRightsAsync(this IBotApiClient client, SetMyDefaultAdministratorRightsParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyDefaultAdministratorRights", parameters), cancellationToken);

    public static async Task<ChatAdministratorRights> GetMyDefaultAdministratorRightsAsync(this IBotApiClient client, GetMyDefaultAdministratorRightsParameters? parameters = null, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatAdministratorRights>(new ApiRequest("getMyDefaultAdministratorRights", parameters), cancellationToken);

    public static async Task<GiftsStruct> GetAvailableGiftsAsync(this IBotApiClient client, GetAvailableGiftsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<GiftsStruct>(new ApiRequest("getAvailableGifts", parameters), cancellationToken);

    public static async Task<bool> SendGiftAsync(this IBotApiClient client, SendGiftParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendGift", parameters), cancellationToken);

    public static async Task<bool> GiftPremiumSubscriptionAsync(this IBotApiClient client, GiftPremiumSubscriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("giftPremiumSubscription", parameters), cancellationToken);

    public static async Task<bool> VerifyUserAsync(this IBotApiClient client, VerifyUserParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("verifyUser", parameters), cancellationToken);

    public static async Task<bool> VerifyChatAsync(this IBotApiClient client, VerifyChatParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("verifyChat", parameters), cancellationToken);

    public static async Task<bool> RemoveUserVerificationAsync(this IBotApiClient client, RemoveUserVerificationParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeUserVerification", parameters), cancellationToken);

    public static async Task<bool> RemoveChatVerificationAsync(this IBotApiClient client, RemoveChatVerificationParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeChatVerification", parameters), cancellationToken);

    public static async Task<bool> ReadBusinessMessageAsync(this IBotApiClient client, ReadBusinessMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("readBusinessMessage", parameters), cancellationToken);

    public static async Task<bool> DeleteBusinessMessagesAsync(this IBotApiClient client, DeleteBusinessMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteBusinessMessages", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountNameAsync(this IBotApiClient client, SetBusinessAccountNameParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountName", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountUsernameAsync(this IBotApiClient client, SetBusinessAccountUsernameParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountUsername", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountBioAsync(this IBotApiClient client, SetBusinessAccountBioParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountBio", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountProfilePhotoAsync(this IBotApiClient client, SetBusinessAccountProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> RemoveBusinessAccountProfilePhotoAsync(this IBotApiClient client, RemoveBusinessAccountProfilePhotoParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeBusinessAccountProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountGiftSettingsAsync(this IBotApiClient client, SetBusinessAccountGiftSettingsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountGiftSettings", parameters), cancellationToken);

    public static async Task<StarAmount> GetBusinessAccountStarBalanceAsync(this IBotApiClient client, GetBusinessAccountStarBalanceParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarAmount>(new ApiRequest("getBusinessAccountStarBalance", parameters), cancellationToken);

    public static async Task<bool> TransferBusinessAccountStarsAsync(this IBotApiClient client, TransferBusinessAccountStarsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("transferBusinessAccountStars", parameters), cancellationToken);

    public static async Task<OwnedGifts> GetBusinessAccountGiftsAsync(this IBotApiClient client, GetBusinessAccountGiftsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<OwnedGifts>(new ApiRequest("getBusinessAccountGifts", parameters), cancellationToken);

    public static async Task<OwnedGifts> GetUserGiftsASync(this IBotApiClient client, GetUserGiftsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<OwnedGifts>(new ApiRequest("getUserGifts", parameters), cancellationToken);

    public static async Task<OwnedGifts> GetChatGiftsAsync(this IBotApiClient client, GetChatGiftsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<OwnedGifts>(new ApiRequest("getChatGifts", parameters), cancellationToken);

    public static async Task<bool> ConvertGiftToStarsAsync(this IBotApiClient client, ConvertGiftToStarsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("convertGiftToStars", parameters), cancellationToken);

    public static async Task<bool> UpgradeGiftAsync(this IBotApiClient client, UpgradeGiftParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("upgradeGift", parameters), cancellationToken);

    public static async Task<bool> TransferGiftAsync(this IBotApiClient client, TransferGiftParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("transferGift", parameters), cancellationToken);

    public static async Task<Story> PostStoryAsync(this IBotApiClient client, PostStoryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("postStory", parameters), cancellationToken);

    public static async Task<Story> RepostStoryAsync(this IBotApiClient client, RepostStoryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("repostStory", parameters), cancellationToken);

    public static async Task<Story> EditStoryAsync(this IBotApiClient client, EditStoryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("editStory", parameters), cancellationToken);

    public static async Task<Story> DeleteStoryAsync(this IBotApiClient client, DeleteStoryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("deleteStory", parameters), cancellationToken);
    #endregion

    #region Updating messages
    public static async Task<Message> EditMessageTextAsync(this IBotApiClient client, EditMessageTextParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageText", parameters), cancellationToken);

    public static async Task<Message> EditMessageCaptionAsync(this IBotApiClient client, EditMessageCaptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageCaption", parameters), cancellationToken);

    public static async Task<Message> EditMessageMediaAsync(this IBotApiClient client, EditMessageMediaParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageMedia", parameters), cancellationToken);

    public static async Task<Message> EditMessageLiveLocationAsync(this IBotApiClient client, EditMessageLiveLocationParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);

    public static async Task<Message> StopMessageLiveLocationAsync(this IBotApiClient client, StopMessageLiveLocationParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);

    public static async Task<Message> EditMessageChecklistAsync(this IBotApiClient client, EditMessageChecklistParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageChecklist", parameters), cancellationToken);

    public static async Task<Message> EditMessageReplyMarkupAsync(this IBotApiClient client, EditMessageReplyMarkupParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);

    public static async Task<Poll> StopPollAsync(this IBotApiClient client, StopPollParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Poll>(new ApiRequest("stopPoll", parameters), cancellationToken);

    public static async Task<bool> ApproveSuggestedPostAsync(this IBotApiClient client, ApproveSuggestedPostParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("approveSuggestedPost", parameters), cancellationToken);

    public static async Task<bool> DeclineSuggestedPostAsync(this IBotApiClient client, DeclineSuggestedPostParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("declineSuggestedPost", parameters), cancellationToken);

    public static async Task<bool> DeleteMessageAsync(this IBotApiClient client, DeleteMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMessage", parameters), cancellationToken);
    public static async Task<bool> DeleteMessagesAsync(this IBotApiClient client, DeleteMessagesParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMessages", parameters), cancellationToken);
    public static async Task<bool> DeleteMessageReactionAsync(this IBotApiClient client, DeleteMessageReactionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMessageReaction", parameters), cancellationToken);
    public static async Task<bool> DeleteAllMessageReactionsAsync(this IBotApiClient client, DeleteAllMessageReactionsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteAllMessageReactions", parameters), cancellationToken);
    #endregion

    #region Stickers
    public static async Task<Message> SendStickerAsync(this IBotApiClient client, SendStickerParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendSticker", parameters), cancellationToken);

    public static async Task<StickerSet> GetStickerSetAsync(this IBotApiClient client, GetStickerSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StickerSet>(new ApiRequest("getStickerSet", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Sticker>> GetCustomEmojiStickersAsync(this IBotApiClient client, GetCustomEmojiStickersParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getCustomEmojiStickers", parameters), cancellationToken);

    public static async Task<FileStruct> UploadStickerFileAsync(this IBotApiClient client, UploadStickerFileParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<FileStruct>(new ApiRequest("uploadStickerFile", parameters), cancellationToken);

    public static async Task<bool> CreateNewStickerSetAsync(this IBotApiClient client, CreateNewStickerSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("createNewStickerSet", parameters), cancellationToken);

    public static async Task<bool> AddStickerToSetAsync(this IBotApiClient client, AddStickerToSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("addStickerToSet", parameters), cancellationToken);

    public static async Task<bool> SetStickerPositionInSetAsync(this IBotApiClient client, SetStickerPositionInSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters), cancellationToken);

    public static async Task<bool> DeleteStickerFromSetAsync(this IBotApiClient client, DeleteStickerFromSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters), cancellationToken);

    public static async Task<bool> ReplaceStickerInSetAsync(this IBotApiClient client, ReplaceStickerInSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("replaceStickerInSet", parameters), cancellationToken);

    public static async Task<bool> SetStickerEmojiListAsync(this IBotApiClient client, SetStickerEmojiListParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerEmojiList", parameters), cancellationToken);

    public static async Task<bool> SetStickerKeywordsAsync(this IBotApiClient client, SetStickerKeywordsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerKeywords", parameters), cancellationToken);

    public static async Task<bool> SetStickerMaskPositionAsync(this IBotApiClient client, SetStickerMaskPositionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters), cancellationToken);

    public static async Task<bool> SetStickerSetTitleAsync(this IBotApiClient client, SetStickerSetTitleParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerSetTitle", parameters), cancellationToken);

    public static async Task<bool> SetStickerSetThumbnailAsync(this IBotApiClient client, SetStickerSetThumbnailParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters), cancellationToken);

    public static async Task<bool> SetCustomEmojiStickerSetThumbnailAsync(this IBotApiClient client, SetCustomEmojiStickerSetThumbnailParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters), cancellationToken);

    public static async Task<bool> DeleteStickerSetAsync(this IBotApiClient client, DeleteStickerSetParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteStickerSet", parameters), cancellationToken);
    #endregion

    #region Rich messages
    public static async Task<Message> SendRichMessageAsync(this IBotApiClient client, SendRichMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendRichMessage", parameters), cancellationToken);

    public static async Task<bool> SendRichMessageDraftAsync(this IBotApiClient client, SendRichMessageDraftParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendRichMessageDraft", parameters), cancellationToken);
    #endregion

    #region Inline mode
    public static async Task<bool> AnswerInlineQueryAsync(this IBotApiClient client, AnswerInlineQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerInlineQuery", parameters), cancellationToken);

    public static async Task<SentWebAppMessage> AnswerWebAppQueryAsync(this IBotApiClient client, AnswerWebAppQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters), cancellationToken);

    public static async Task<PreparedInlineMessage> SavePreparedInlineMessageAsync(this IBotApiClient client, SavePreparedInlineMessageParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters), cancellationToken);

    public static async Task<PreparedKeyboardButton> SavePreparedKeyboardButtonAsync(this IBotApiClient client, SavePreparedKeyboardButtonParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<PreparedKeyboardButton>(new ApiRequest("savePreparedKeyboardButton", parameters), cancellationToken);
    #endregion

    #region Payments
    public static async Task<Message> SendInvoiceAsync(this IBotApiClient client, SendInvoiceParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendInvoice", parameters), cancellationToken);

    public static async Task<string> CreateInvoiceLinkAsync(this IBotApiClient client, CreateInvoiceLinkParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("createInvoiceLink", parameters), cancellationToken);

    public static async Task<bool> AnswerShippingQueryAsync(this IBotApiClient client, AnswerShippingQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerShippingQuery", parameters), cancellationToken);

    public static async Task<bool> AnswerPreCheckoutQueryAsync(this IBotApiClient client, AnswerPreCheckoutQueryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters), cancellationToken);

    public static async Task<StarAmount> GetMyStarBalanceAsync(this IBotApiClient client, GetMyStarBalanceParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarAmount>(new ApiRequest("getMyStarBalance", parameters), cancellationToken);

    public static async Task<StarTransactions> GetStarTransactionsAsync(this IBotApiClient client, GetStarTransactionsyParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters), cancellationToken);

    public static async Task<bool> RefundStarPaymentAsync(this IBotApiClient client, RefundStarPaymentParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("refundStarPayment", parameters), cancellationToken);

    public static async Task<bool> EditUserStarSubscriptionAsync(this IBotApiClient client, EditUserStarSubscriptionParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editUserStarSubscription", parameters), cancellationToken);
    #endregion

    #region Telegram Passport
    public static async Task<bool> SetPassportDataErrorsAsync(this IBotApiClient client, SetPassportDataErrorsParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setPassportDataErrors", parameters), cancellationToken);
    #endregion

    #region Games
    public static async Task<Message> SendGameAsync(this IBotApiClient client, SendGameParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendGame", parameters), cancellationToken);

    public static async Task<Message> SetGameScoreAsync(this IBotApiClient client, SetGameScoreParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("setGameScore", parameters), cancellationToken);

    public static async Task<IReadOnlyList<GameHighScore>> GetGameHighScoresAsync(this IBotApiClient client, GetGameHighScoresParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<GameHighScore>>(new ApiRequest("getGameHighScores", parameters), cancellationToken);
    #endregion
}
