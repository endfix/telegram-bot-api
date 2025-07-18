using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
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

    public async Task<ApiResponse<File>> GetFileAsync(GetFileParameters parameters)
    {
        return await RequestAsync<File>(new ApiRequest("getFile", parameters));
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
}
