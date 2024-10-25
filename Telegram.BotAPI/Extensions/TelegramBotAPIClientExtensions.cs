using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.BotAPI.MethodArgs;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Types.Stickers;

namespace Telegram.BotAPI.Extensions;

// TODO: Documentation comments https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
public static partial class TelegramBotAPIClientExtensions
{
    public static async Task<ResponseAPI<User>> GetMeAsync(this TelegramBotAPIClient api, GetMeArgs args = null)
    {
        return await api.RequestAsync<User>("getMe", args);
    }

    public static async Task<ResponseAPI<bool>> LogOutAsync(this TelegramBotAPIClient api, LogOutArgs args = null)
    {
        return await api.RequestAsync<bool>("logOut", args);
    }

    public static async Task<ResponseAPI<bool>> CloseAsync(this TelegramBotAPIClient api, CloseArgs args = null)
    {
        return await api.RequestAsync<bool>("close", args);
    }

    public static async Task<ResponseAPI<Message>> SendMessageAsync(this TelegramBotAPIClient api, SendMessageArgs args = null)
    {
        return await api.RequestAsync<Message>("sendMessage", args);
    }

    public static async Task<ResponseAPI<Message>> ForwardMessageAsync(this TelegramBotAPIClient api, ForwardMessageArgs args = null)
    {
        return await api.RequestAsync<Message>("forwardMessage", args);
    }

    public static async Task<ResponseAPI<List<MessageIdStruct>>> ForwardMessagesAsync(this TelegramBotAPIClient api, ForwardMessagesArgs args = null)
    {
        return await api.RequestAsync<List<MessageIdStruct>>("forwardMessages", args);
    }

    public static async Task<ResponseAPI<MessageIdStruct>> CopyMessageAsync(this TelegramBotAPIClient api, CopyMessageArgs args = null)
    {
        return await api.RequestAsync<MessageIdStruct>("copyMessage", args);
    }

    public static async Task<ResponseAPI<List<MessageIdStruct>>> CopyMessagesAsync(this TelegramBotAPIClient api, CopyMessagesArgs args = null)
    {
        return await api.RequestAsync<List<MessageIdStruct>>("copyMessages", args);
    }

    public static async Task<ResponseAPI<Message>> SendPhotoAsync(this TelegramBotAPIClient api, SendPhotoArgs args = null)
    {
        return await api.RequestAsync<Message>("sendPhoto", args);
    }

    public static async Task<ResponseAPI<Message>> SendAudioAsync(this TelegramBotAPIClient api, SendAudioArgs args = null)
    {
        return await api.RequestAsync<Message>("sendAudio", args);
    }

    public static async Task<ResponseAPI<Message>> SendDocumentAsync(this TelegramBotAPIClient api, SendDocumentArgs args = null)
    {
        return await api.RequestAsync<Message>("sendDocument", args);
    }

    public static async Task<ResponseAPI<Message>> SendVideoAsync(this TelegramBotAPIClient api, SendVideoArgs args = null)
    {
        return await api.RequestAsync<Message>("sendVideo", args);
    }

    public static async Task<ResponseAPI<Message>> SendAnimationAsync(this TelegramBotAPIClient api, SendAnimationArgs args = null)
    {
        return await api.RequestAsync<Message>("sendAnimation", args);
    }

    public static async Task<ResponseAPI<Message>> SendVoiceAsync(this TelegramBotAPIClient api, SendVoiceArgs args = null)
    {
        return await api.RequestAsync<Message>("sendVoice", args);
    }

    /**
     * size <= 8 MB
     * duration <= 1 minutes
     * ratio 1:1
     * resolution 640x640
     */
    public static async Task<ResponseAPI<Message>> SendVideoNoteAsync(this TelegramBotAPIClient api, SendVideoNoteArgs args = null)
    {
        return await api.RequestAsync<Message>("sendVideoNote", args);
    }

    public static async Task<ResponseAPI<Message>> SendPaidMediaAsync(this TelegramBotAPIClient api, SendPaidMediaArgs args = null)
    {
        return await api.RequestAsync<Message>("sendPaidMedia", args);
    }

    public static async Task<ResponseAPI<List<Message>>> SendMediaGroupAsync(this TelegramBotAPIClient api, SendMediaGroupArgs args = null)
    {
        return await api.RequestAsync<List<Message>>("sendMediaGroup", args);
    }

    public static async Task<ResponseAPI<Message>> SendLocationAsync(this TelegramBotAPIClient api, SendLocationArgs args = null)
    {
        return await api.RequestAsync<Message>("sendLocation", args);
    }

    public static async Task<ResponseAPI<Message>> SendVenueAsync(this TelegramBotAPIClient api, SendVenueArgs args = null)
    {
        return await api.RequestAsync<Message>("sendVenue", args);
    }

    public static async Task<ResponseAPI<Message>> SendContactAsync(this TelegramBotAPIClient api, SendContactArgs args = null)
    {
        return await api.RequestAsync<Message>("sendContact", args);
    }

    public static async Task<ResponseAPI<Message>> SendPollAsync(this TelegramBotAPIClient api, SendPollArgs args = null)
    {
        return await api.RequestAsync<Message>("sendPoll", args);
    }

    public static async Task<ResponseAPI<Message>> SendDiceAsync(this TelegramBotAPIClient api, SendDiceArgs args = null)
    {
        return await api.RequestAsync<Message>("sendDice", args);
    }

    public static async Task<ResponseAPI<bool>> SendChatActionAsync(this TelegramBotAPIClient api, SendChatActionArgs args = null)
    {
        return await api.RequestAsync<bool>("sendChatAction", args);
    }

    public static async Task<ResponseAPI<bool>> SetMessageReactionAsync(this TelegramBotAPIClient api, SetMessageReactionArgs args = null)
    {
        return await api.RequestAsync<bool>("setMessageReaction", args);
    }

    public static async Task<ResponseAPI<UserProfilePhotos>> GetUserProfilePhotosAsync(this TelegramBotAPIClient api, GetUserProfilePhotosArgs args = null)
    {
        return await api.RequestAsync<UserProfilePhotos>("getUserProfilePhotos", args);
    }

    public static async Task<ResponseAPI<FileStruct>> GetFileAsync(this TelegramBotAPIClient api, GetFileArgs args = null)
    {
        return await api.RequestAsync<FileStruct>("getFile", args);
    }

    public static async Task<ResponseAPI<bool>> BanChatMemberAsync(this TelegramBotAPIClient api, BanChatMemberArgs args = null)
    {
        return await api.RequestAsync<bool>("banChatMember", args);
    }

    public static async Task<ResponseAPI<bool>> UnbanChatMemberAsync(this TelegramBotAPIClient api, UnbanChatMemberArgs args = null)
    {
        return await api.RequestAsync<bool>("unbanChatMember", args);
    }

    public static async Task<ResponseAPI<bool>> RestrictChatMemberAsync(this TelegramBotAPIClient api, RestrictChatMemberArgs args = null)
    {
        return await api.RequestAsync<bool>("restrictChatMember", args);
    }

    public static async Task<ResponseAPI<bool>> PromoteChatMemberAsync(this TelegramBotAPIClient api, PromoteChatMemberArgs args = null)
    {
        return await api.RequestAsync<bool>("promoteChatMember", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatAdministratorCustomTitleAsync(this TelegramBotAPIClient api, SetChatAdministratorCustomTitleArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatAdministratorCustomTitle", args);
    }

    public static async Task<ResponseAPI<bool>> BanChatSenderChatAsync(this TelegramBotAPIClient api, BanChatSenderChatArgs args = null)
    {
        return await api.RequestAsync<bool>("banChatSenderChat", args);
    }

    public static async Task<ResponseAPI<bool>> UnbanChatSenderChatAsync(this TelegramBotAPIClient api, UnbanChatSenderChatArgs args = null)
    {
        return await api.RequestAsync<bool>("unbanChatSenderChat", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatPermissionsAsync(this TelegramBotAPIClient api, SetChatPermissionsArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatPermissions", args);
    }

    public static async Task<ResponseAPI<string>> ExportChatInviteLinkAsync(this TelegramBotAPIClient api, ExportChatInviteLinkArgs args = null)
    {
        return await api.RequestAsync<string>("exportChatInviteLink", args);
    }

    public static async Task<ResponseAPI<ChatInviteLink>> CreateChatInviteLinkAsync(this TelegramBotAPIClient api, CreateChatInviteLinkArgs args = null)
    {
        return await api.RequestAsync<ChatInviteLink>("createChatInviteLink", args);
    }

    public static async Task<ResponseAPI<ChatInviteLink>> EditChatInviteLinkAsync(this TelegramBotAPIClient api, EditChatInviteLinkArgs args = null)
    {
        return await api.RequestAsync<ChatInviteLink>("editChatInviteLink", args);
    }

    public static async Task<ResponseAPI<ChatInviteLink>> CreateChatSubscriptionInviteLinkAsync(this TelegramBotAPIClient api, CreateChatSubscriptionInviteLinkArgs args = null)
    {
        return await api.RequestAsync<ChatInviteLink>("createChatSubscriptionInviteLink", args);
    }

    public static async Task<ResponseAPI<ChatInviteLink>> EditChatSubscriptionInviteLinkAsync(this TelegramBotAPIClient api, EditChatSubscriptionInviteLinkArgs args = null)
    {
        return await api.RequestAsync<ChatInviteLink>("editChatSubscriptionInviteLink", args);
    }

    public static async Task<ResponseAPI<ChatInviteLink>> RevokeChatInviteLinkAsync(this TelegramBotAPIClient api, RevokeChatInviteLinkArgs args = null)
    {
        return await api.RequestAsync<ChatInviteLink>("revokeChatInviteLink", args);
    }

    public static async Task<ResponseAPI<bool>> ApproveChatJoinRequestAsync(this TelegramBotAPIClient api, ApproveChatJoinRequestArgs args = null)
    {
        return await api.RequestAsync<bool>("approveChatJoinRequest", args);
    }

    public static async Task<ResponseAPI<bool>> DeclineChatJoinRequestAsync(this TelegramBotAPIClient api, DeclineChatJoinRequestArgs args = null)
    {
        return await api.RequestAsync<bool>("declineChatJoinRequest", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatPhotoAsync(this TelegramBotAPIClient api, SetChatPhotoArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatPhoto", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteChatPhotoAsync(this TelegramBotAPIClient api, DeleteChatPhotoArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteChatPhoto", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatTitleAsync(this TelegramBotAPIClient api, SetChatTitleArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatTitle", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatDescriptionAsync(this TelegramBotAPIClient api, SetChatDescriptionArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatDescription", args);
    }

    public static async Task<ResponseAPI<bool>> PinChatMessageAsync(this TelegramBotAPIClient api, PinChatMessageArgs args = null)
    {
        return await api.RequestAsync<bool>("pinChatMessage", args);
    }

    public static async Task<ResponseAPI<bool>> UnpinChatMessageAsync(this TelegramBotAPIClient api, UnpinChatMessageArgs args = null)
    {
        return await api.RequestAsync<bool>("unpinChatMessage", args);
    }

    public static async Task<ResponseAPI<bool>> UnpinAllChatMessagesAsync(this TelegramBotAPIClient api, UnpinAllChatMessagesArgs args = null)
    {
        return await api.RequestAsync<bool>("unpinAllChatMessages", args);
    }

    public static async Task<ResponseAPI<bool>> LeaveChatAsync(this TelegramBotAPIClient api, LeaveChatArgs args = null)
    {
        return await api.RequestAsync<bool>("leaveChat", args);
    }

    public static async Task<ResponseAPI<ChatFullInfo>> GetChatAsync(this TelegramBotAPIClient api, GetChatArgs args = null)
    {
        return await api.RequestAsync<ChatFullInfo>("getChat", args);
    }

    public static async Task<ResponseAPI<List<ChatMember>>> GetChatAdministratorsAsync(this TelegramBotAPIClient api, GetChatAdministratorsArgs args = null)
    {
        return await api.RequestAsync<List<ChatMember>>("getChatAdministrators", args);
    }

    public static async Task<ResponseAPI<int>> GetChatMemberCountAsync(this TelegramBotAPIClient api, GetChatMemberCountArgs args = null)
    {
        return await api.RequestAsync<int>("getChatMemberCount", args);
    }

    public static async Task<ResponseAPI<ChatMember>> GetChatMemberAsync(this TelegramBotAPIClient api, GetChatMemberArgs args = null)
    {
        return await api.RequestAsync<ChatMember>("getChatMember", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatStickerSetAsync(this TelegramBotAPIClient api, SetChatStickerSetArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatStickerSet", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteChatStickerSetAsync(this TelegramBotAPIClient api, DeleteChatStickerSetArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteChatStickerSet", args);
    }

    public static async Task<ResponseAPI<List<Sticker>>> GetForumTopicIconStickersAsync(this TelegramBotAPIClient api, GetForumTopicIconStickersArgs args = null)
    {
        return await api.RequestAsync<List<Sticker>>("getForumTopicIconStickers", args);
    }

    public static async Task<ResponseAPI<ForumTopic>> CreateForumTopicAsync(this TelegramBotAPIClient api, CreateForumTopicArgs args = null)
    {
        return await api.RequestAsync<ForumTopic>("createForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> EditForumTopicAsync(this TelegramBotAPIClient api, EditForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("editForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> CloseForumTopicAsync(this TelegramBotAPIClient api, CloseForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("closeForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> ReopenForumTopicAsync(this TelegramBotAPIClient api, ReopenForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("reopenForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteForumTopicAsync(this TelegramBotAPIClient api, DeleteForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> UnpinAllForumTopicMessagesAsync(this TelegramBotAPIClient api, UnpinAllForumTopicMessagesArgs args = null)
    {
        return await api.RequestAsync<bool>("unpinAllForumTopicMessages", args);
    }

    public static async Task<ResponseAPI<bool>> EditGeneralForumTopicAsync(this TelegramBotAPIClient api, EditGeneralForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("editGeneralForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> CloseGeneralForumTopicAsync(this TelegramBotAPIClient api, CloseGeneralForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("closeGeneralForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> ReopenGeneralForumTopicAsync(this TelegramBotAPIClient api, ReopenGeneralForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("reopenGeneralForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> HideGeneralForumTopicAsync(this TelegramBotAPIClient api, HideGeneralForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("hideGeneralForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> UnhideGeneralForumTopicAsync(this TelegramBotAPIClient api, UnhideGeneralForumTopicArgs args = null)
    {
        return await api.RequestAsync<bool>("unhideGeneralForumTopic", args);
    }

    public static async Task<ResponseAPI<bool>> UnpinAllGeneralForumTopicMessagesAsync(this TelegramBotAPIClient api, UnpinAllGeneralForumTopicMessagesArgs args = null)
    {
        return await api.RequestAsync<bool>("unpinAllGeneralForumTopicMessages", args);
    }

    public static async Task<ResponseAPI<bool>> AnswerCallbackQueryAsync(this TelegramBotAPIClient api, AnswerCallbackQueryArgs args = null)
    {
        return await api.RequestAsync<bool>("answerCallbackQuery", args);
    }

    public static async Task<ResponseAPI<UserChatBoosts>> GetUserChatBoostsAsync(this TelegramBotAPIClient api, GetUserChatBoostsArgs args = null)
    {
        return await api.RequestAsync<UserChatBoosts>("getUserChatBoosts", args);
    }

    public static async Task<ResponseAPI<BusinessConnection>> GetBusinessConnectionAsync(this TelegramBotAPIClient api, GetBusinessConnectionArgs args = null)
    {
        return await api.RequestAsync<BusinessConnection>("getBusinessConnection", args);
    }

    public static async Task<ResponseAPI<bool>> SetMyCommandsAsync(this TelegramBotAPIClient api, SetMyCommandsArgs args = null)
    {
        return await api.RequestAsync<bool>("setMyCommands", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteMyCommandsAsync(this TelegramBotAPIClient api, DeleteMyCommandsArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteMyCommands", args);
    }

    public static async Task<ResponseAPI<List<BotCommand>>> GetMyCommandsAsync(this TelegramBotAPIClient api, GetMyCommandsArgs args = null)
    {
        return await api.RequestAsync<List<BotCommand>>("getMyCommands", args);
    }

    public static async Task<ResponseAPI<bool>> SetMyNameAsync(this TelegramBotAPIClient api, SetMyNameArgs args = null)
    {
        return await api.RequestAsync<bool>("setMyName", args);
    }

    public static async Task<ResponseAPI<BotName>> GetMyNameAsync(this TelegramBotAPIClient api, GetMyNameArgs args = null)
    {
        return await api.RequestAsync<BotName>("getMyName", args);
    }

    public static async Task<ResponseAPI<bool>> SetMyDescriptionAsync(this TelegramBotAPIClient api, SetMyDescriptionArgs args = null)
    {
        return await api.RequestAsync<bool>("setMyDescription", args);
    }

    public static async Task<ResponseAPI<BotDescription>> GetMyDescriptionAsync(this TelegramBotAPIClient api, GetMyDescriptionArgs args = null)
    {
        return await api.RequestAsync<BotDescription>("getMyDescription", args);
    }

    public static async Task<ResponseAPI<bool>> SetMyShortDescriptionAsync(this TelegramBotAPIClient api, SetMyShortDescriptionArgs args = null)
    {
        return await api.RequestAsync<bool>("setMyShortDescription", args);
    }

    public static async Task<ResponseAPI<BotShortDescription>> GetMyShortDescriptionAsync(this TelegramBotAPIClient api, GetMyShortDescriptionArgs args = null)
    {
        return await api.RequestAsync<BotShortDescription>("getMyShortDescription", args);
    }

    public static async Task<ResponseAPI<bool>> SetChatMenuButtonAsync(this TelegramBotAPIClient api, SetChatMenuButtonArgs args = null)
    {
        return await api.RequestAsync<bool>("setChatMenuButton", args);
    }

    public static async Task<ResponseAPI<MenuButton>> GetChatMenuButtonAsync(this TelegramBotAPIClient api, GetChatMenuButtonArgs args = null)
    {
        return await api.RequestAsync<MenuButton>("getChatMenuButton", args);
    }

    public static async Task<ResponseAPI<bool>> SetMyDefaultAdministratorRightsAsync(this TelegramBotAPIClient api, SetMyDefaultAdministratorRightsArgs args = null)
    {
        return await api.RequestAsync<bool>("setMyDefaultAdministratorRights", args);
    }

    public static async Task<ResponseAPI<ChatAdministratorRights>> GetMyDefaultAdministratorRightsAsync(this TelegramBotAPIClient api, GetMyDefaultAdministratorRightsArgs args = null)
    {
        return await api.RequestAsync<ChatAdministratorRights>("getMyDefaultAdministratorRights", args);
    }
}
