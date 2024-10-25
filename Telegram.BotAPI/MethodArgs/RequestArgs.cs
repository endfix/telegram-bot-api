using System.Collections.Generic;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Types.Input;

namespace Telegram.BotAPI.MethodArgs;

public abstract class RequestArgs
{
    private List<InputFile> InputFiles { get; set; } = [];

    protected void AddInputFile(InputFile inputFile)
    {
        InputFiles.Add(inputFile);
    }

    public List<InputFile> GetInputFiles()
    {
        return InputFiles;
    }
}

public sealed class GetMeArgs : RequestArgs
{
    //
}

public sealed class LogOutArgs : RequestArgs
{
    //
}

public sealed class CloseArgs : RequestArgs
{
    //
}

public sealed class SendMessageArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Text { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> Entities { get; set; }

    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class ForwardMessageArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageThreadId { set; get; }

    public string FromChatId { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public int MessageId { set; get; }
}

public sealed class ForwardMessagesArgs : RequestArgs
{
    public string ChatId { set; get; }

    public int MessageThreadId { set; get; }

    public string FromChatId { get; set; }

    public List<int> MessageIds { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }
}

public sealed class CopyMessageArgs : RequestArgs
{
    public string ChatId { set; get; }

    public int MessageThreadId { get; set; }

    public string FromChatId { get; set; }

    public int MessageId { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class CopyMessagesArgs : RequestArgs
{
    public string ChatId { set; get; }

    public int MessageThreadId { get; set; }

    public string FromChatId { get; set; }

    public List<int> MessageIds { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool RemoveCaption { get; set; }
}

public sealed class SendPhotoArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; } = 0;

    public object Photo { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool HasSpoiler { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendAudioArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Audio { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public int Duration { get; set; }

    public string Performer { get; set; }

    public string Title { get; set; }

    public object Thumbnail { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendDocumentArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Document { get; set; }

    public object Thumbnail { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool DisableContentTypeDetection { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendVideoArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Video { get; set; }

    public int Duration { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public object Thumbnail { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool HasSpoiler { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendAnimationArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Animation { get; set; }

    public int Duration { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public object Thumbnail { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool HasSpoiler { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendVoiceArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Voice { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public int Duration { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendVideoNoteArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object VideoNote { get; set; }

    public int Duration { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public object Thumbnail { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendPaidMediaArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; } = string.Empty;

    public string ChatId { get; set; }

    public int StarCount { get; set; }

    public List<InputPaidMedia> Media { get; set; } = [];

    public string Payload { get; set; }

    public string Caption { get; set; } = string.Empty;

    public string ParseMode { get; set; } = "html";

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public ReplyParameters ReplyParameters { get; set; } = new ReplyParameters();

    public ReplyMarkup ReplyMarkup { get; set; } = new ReplyMarkup();
}

public sealed class SendMediaGroupArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; } = string.Empty;

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public List<InputMedia> Media { get; set; } = [];

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; } = new ReplyParameters();
}

public sealed class SendLocationArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public float HorizontalAccuracy { get; set; }

    public int LivePeriod { get; set; }

    public int Heading { get; set; }

    public int ProximityAlertRadius { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendVenueArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string FoursquareId { get; set; }

    public string FoursquareType { get; set; }

    public string GooglePlaceId { get; set; }

    public string GooglePlaceType { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendContactArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Vcard { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendPollArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Question { get; set; }

    public string QuestionParseMode { get; set; }

    public List<MessageEntity> QuestionEntities { get; set; }

    public List<InputPollOption> Options { get; set; }

    public bool IsAnonymous { get; set; }

    public string Type { get; set; }

    public bool AllowsMultipleAnswers { get; set; }

    public int CorrectOptionId { get; set; }

    public string Explanation { get; set; }

    public string ExplanationParseMode { get; set; }

    public List<MessageEntity> ExplanationEntities { get; set; }

    public int OpenPeriod { get; set; }

    public int CloseDate { get; set; }

    public bool IsClosed { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendDiceArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Emoji { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

public sealed class SendChatActionArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Action { get; set; }
}

public sealed class SetMessageReactionArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageId { get; set; }

    public List<ReactionType> Reaction { get; set; }

    public bool IsBig { get; set; }
}

public sealed class GetUserProfilePhotosArgs : RequestArgs
{
    public long UserId { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }
}

public sealed class GetFileArgs : RequestArgs
{
    public string FileId { get; set; }
}

public sealed class BanChatMemberArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long UserId { get; set; }

    public int UntilDate { get; set; }

    public bool RevokeMessages { get; set; }
}

public sealed class UnbanChatMemberArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long UserId { get; set; }

    public bool OnlyIfBanned { get; set; }
}

public sealed class RestrictChatMemberArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long UserId { get; set; }

    public ChatPermissions Permissions { get; set; }

    public bool UseIndependentChatPermissions { get; set; }

    public int UntilDate { get; set; }
}

public sealed class PromoteChatMemberArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long UserId { get; set; }

    public bool IsAnonymous { get; set; }

    public bool CanManageChat { get; set; }

    public bool CanDeleteMessages { get; set; }

    public bool CanManageVideoChats { get; set; }

    public bool CanRestrictMembers { get; set; }

    public bool CanPromoteMembers { get; set; }

    public bool CanChangeInfo { get; set; }

    public bool CanInviteUsers { get; set; }

    public bool CanPostStories { get; set; }

    public bool CanEditStories { get; set; }

    public bool CanDeleteStories { get; set; }

    public bool CanPostMessages { get; set; }

    public bool CanEditMessages { get; set; }

    public bool CanPinMessages { get; set; }

    public bool CanManageTopics { get; set; }
}

public sealed class SetChatAdministratorCustomTitleArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long UserId { get; set; }

    public string CustomTitle { get; set; }
}

public sealed class BanChatSenderChatArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long SenderChatId { get; set; }
}

public sealed class UnbanChatSenderChatArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long SenderChatId { get; set; }
}

public sealed class SetChatPermissionsArgs : RequestArgs
{
    public string ChatId { get; set; }

    public ChatPermissions Permissions { get; set; }

    public bool UseIndependentChatPermissions { get; set; }
}

public sealed class ExportChatInviteLinkArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class CreateChatInviteLinkArgs : RequestArgs
{
    public string ChatId { get; set; }

    public string Name { get; set; }

    public int ExpireDate { get; set; }

    public int MemberLimit { get; set; }

    public bool CreatesJoinRequest { get; set; }
}

public sealed class EditChatInviteLinkArgs : RequestArgs
{
    public string ChatId { get; set; }

    public string InviteLink { get; set; }

    public string Name { set; get; }

    public int ExpireDate { set; get; }

    public int MemberLimit { get; set; }

    public bool CreatesJoinRequest { set; get; }
}

public sealed class CreateChatSubscriptionInviteLinkArgs : RequestArgs
{
    public string ChatId { set; get; }

    public string Name { set; get; }

    public int SubscriptionPeriod { get; set; }

    public int SubscriptionPrice { get; set; }
}

public sealed class EditChatSubscriptionInviteLinkArgs : RequestArgs
{
    public string ChatId { set; get; }

    public string InviteLink { set; get; }

    public string Name { set; get; }
}

public sealed class RevokeChatInviteLinkArgs : RequestArgs
{
    public string ChatId { set; get; }

    public string InviteLink { set; get; }
}

public sealed class ApproveChatJoinRequestArgs : RequestArgs
{
    public string ChatId { set; get; }

    public long UserId { set; get; }
}

public sealed class DeclineChatJoinRequestArgs : RequestArgs
{
    public string ChatId { set; get; }

    public long UserId { set; get; }
}

public sealed class SetChatPhotoArgs : RequestArgs
{
    public string ChatId { set; get; }

    public InputFile Photo { set; get; }
}

public sealed class DeleteChatPhotoArgs : RequestArgs
{
    public string ChatId { set; get; }
}

public sealed class SetChatTitleArgs : RequestArgs
{
    public string ChatId { set; get; }

    public string Title { set; get; }
}

public sealed class SetChatDescriptionArgs : RequestArgs
{
    public string ChatId { set; get; }

    public string Description { set; get; }
}

public sealed class PinChatMessageArgs : RequestArgs
{
    public string BusinessConnectionId { set; get; }

    public string ChatId { get; set; }

    public int MessageId { set; get; }

    public bool DisableNotification { set; get; }
}

public sealed class UnpinChatMessageArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageId { get; set; }
}

public sealed class UnpinAllChatMessagesArgs : RequestArgs
{
    public string ChatId { set; get; }
}

public sealed class LeaveChatArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class GetChatArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class GetChatAdministratorsArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class GetChatMemberCountArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class GetChatMemberArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long UserId { get; set; }
}

public sealed class SetChatStickerSetArgs : RequestArgs
{
    public string ChatId { set; get; }

    public string StickerSetName { set; get; }
}

public sealed class DeleteChatStickerSetArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class GetForumTopicIconStickersArgs : RequestArgs
{
    //
}

public sealed class CreateForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }

    public string Name { get; set; }

    public int IconColor { get; set; }

    public string IconCustomEmojiId { get; set; }
}

public sealed class EditForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageThreadId { set; get; }

    public string Name { get; set; }

    public string IconCustomEmojiId { get; set; }
}

public sealed class CloseForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageThreadId { set; get; }
}

public sealed class ReopenForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageThreadId { set; get; }
}

public sealed class DeleteForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageThread_id { get; set; }
}

public sealed class UnpinAllForumTopicMessagesArgs : RequestArgs
{
    public string ChatId { get; set; }

    public int MessageThreadId { set; get; }
}

public sealed class EditGeneralForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }

    public string Name { get; set; }
}

public sealed class CloseGeneralForumTopicArgs : RequestArgs
{
    public string ChatId { set; get; }
}

public sealed class ReopenGeneralForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class HideGeneralForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class UnhideGeneralForumTopicArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class UnpinAllGeneralForumTopicMessagesArgs : RequestArgs
{
    public string ChatId { get; set; }
}

public sealed class AnswerCallbackQueryArgs : RequestArgs
{
    public string CallbackQueryId { get; set; }

    public string Text { get; set; }

    public bool ShowAlert { get; set; }

    public string Url { get; set; }

    public int CacheTime { get; set; }
}

public sealed class GetUserChatBoostsArgs : RequestArgs
{
    public long ChatId { get; set; }

    public long UserId { get; set; }
}

public sealed class GetBusinessConnectionArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }
}

public sealed class SetMyCommandsArgs : RequestArgs
{
    public List<BotCommand> Commands { get; set; }

    public BotCommandScope Scope { get; set; }

    public string LanguageCode { get; set; }
}

public sealed class DeleteMyCommandsArgs : RequestArgs
{
    public BotCommandScope Scope { get; set; }
    public string LanguageCode { get; set; }
}

public sealed class GetMyCommandsArgs : RequestArgs
{
    public BotCommandScope Scope { get; set; }
    public string LanguageCode { get; set; }
}

public sealed class SetMyNameArgs : RequestArgs
{
    public string Name { get; set; }

    public string LanguageCode { get; set; }
}

public class GetMyNameArgs : RequestArgs
{
    public string LanguageCode { get; set; }
}

public sealed class SetMyDescriptionArgs : RequestArgs
{
    public string Description { get; set; }

    public string LanguageCode { get; set; }
}

public sealed class GetMyDescriptionArgs : RequestArgs
{
    public string LanguageCode { get; set; }
}

public sealed class SetMyShortDescriptionArgs : RequestArgs
{
    public string ShortDescription { get; set; }

    public string LanguageCode { get; set; }
}

public sealed class GetMyShortDescriptionArgs : RequestArgs
{
    public string LanguageCode { get; set; }
}

public sealed class SetChatMenuButtonArgs : RequestArgs
{
    public long ChatId { get; set; }

    public MenuButton MenuButton { get; set; }
}

public sealed class GetChatMenuButtonArgs : RequestArgs
{
    public long ChatId { get; set; }
}

public sealed class SetMyDefaultAdministratorRightsArgs : RequestArgs
{
    public ChatAdministratorRights Rights { get; set; }

    public bool ForChannels { get; set; }
}

public sealed class GetMyDefaultAdministratorRightsArgs : RequestArgs
{
    public bool ForChannels { get; set; }
}
