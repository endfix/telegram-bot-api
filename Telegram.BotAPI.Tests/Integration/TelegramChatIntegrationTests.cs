using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

[Trait("Category", "Integration")]
[Collection(TelegramIntegrationCollection.Name)]
public sealed class TelegramChatIntegrationTests : IDisposable
{
    private readonly HttpClient _httpClient = new();
    private readonly BotApiClient _client;

    public TelegramChatIntegrationTests()
    {
        var token = TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.TokenVariable)
            ?? throw new InvalidOperationException("Telegram bot token is not configured.");
        _client = new BotApiClient(token, _httpClient);
    }

    [TelegramIntegrationFact]
    public async Task BotFatherCapabilities_AreEnabled()
    {
        var bot = await _client.GetMeAsync();

        Assert.True(bot.CanJoinGroups);
        Assert.True(bot.CanReadAllGroupMessages);
        Assert.True(bot.SupportsInlineQueries);
        Assert.True(bot.CanConnectToBusiness);
        Assert.True(bot.HasTopicsEnabled);
    }

    [TelegramGroupIntegrationFact]
    public async Task GroupConfiguration_IsUsable()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var bot = await _client.GetMeAsync();
        var chat = await _client.GetChatAsync(groupId);

        Assert.Equal(ChatFullInfoTypes.Supergroup, chat.Type);

        var administrators = await _client.GetChatAdministratorsAsync(groupId, returnBots: true);
        var botMember = Assert.Single(administrators, member => member.User.Id == bot.Id);
        var administrator = Assert.IsType<ChatMemberAdministrator>(botMember);
        Assert.True(administrator.CanManageChat);
        Assert.True(administrator.CanChangeInfo);
        Assert.True(administrator.CanDeleteMessages);
        Assert.True(administrator.CanInviteUsers);
        Assert.True(administrator.CanPinMessages);
        if (chat.IsForum is true)
        {
            Assert.True(administrator.CanManageTopics);
        }
    }

    [TelegramChannelIntegrationFact]
    public async Task ChannelConfiguration_IsUsable()
    {
        var channelId = GetId(TelegramIntegrationFactAttribute.ChannelIdVariable);
        var bot = await _client.GetMeAsync();
        var chat = await _client.GetChatAsync(channelId);

        Assert.Equal(ChatFullInfoTypes.Channel, chat.Type);

        var administrators = await _client.GetChatAdministratorsAsync(channelId, returnBots: true);
        var botMember = Assert.Single(administrators, member => member.User.Id == bot.Id);
        var administrator = Assert.IsType<ChatMemberAdministrator>(botMember);
        Assert.True(administrator.CanManageChat);
        Assert.True(administrator.CanChangeInfo);
        Assert.True(administrator.CanDeleteMessages);
        Assert.True(administrator.CanPostMessages);
        Assert.True(administrator.CanEditMessages);
    }

    [TelegramModerationIntegrationFact]
    public async Task TestUser_IsVisibleInGroup()
    {
        var member = await _client.GetChatMemberAsync(
            GetId(TelegramIntegrationFactAttribute.GroupIdVariable),
            GetId(TelegramIntegrationFactAttribute.TestUserIdVariable));

        Assert.False(member.User.IsBot);
        Assert.NotEqual(ChatMemberStatus.Creator, member.Status);
        Assert.NotEqual(ChatMemberStatus.Administrator, member.Status);
    }

    [TelegramRoutingIntegrationFact]
    public async Task ChannelAndGroup_AreLinkedForDiscussion()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var channelId = GetId(TelegramIntegrationFactAttribute.ChannelIdVariable);

        var group = await _client.GetChatAsync(groupId);
        var channel = await _client.GetChatAsync(channelId);

        Assert.Equal(channelId, group.LinkedChatId);
        Assert.Equal(groupId, channel.LinkedChatId);
    }

    [TelegramForumIntegrationFact]
    public async Task ForumConfiguration_IsUsable()
    {
        var forumId = GetId(TelegramIntegrationFactAttribute.ForumIdVariable);
        var bot = await _client.GetMeAsync();
        var forum = await _client.GetChatAsync(forumId);

        Assert.Equal(ChatFullInfoTypes.Supergroup, forum.Type);
        Assert.True(forum.IsForum);

        var administrators = await _client.GetChatAdministratorsAsync(forumId, returnBots: true);
        var botMember = Assert.Single(administrators, member => member.User.Id == bot.Id);
        var administrator = Assert.IsType<ChatMemberAdministrator>(botMember);
        Assert.True(administrator.CanManageTopics);
        Assert.True(administrator.CanDeleteMessages);
    }

    [TelegramForumIntegrationFact]
    public async Task ForumTopicLifecycle_RollBack()
    {
        var forumId = GetId(TelegramIntegrationFactAttribute.ForumIdVariable);
        ForumTopic? topic = null;
        var topicDeleted = false;

        try
        {
            topic = await _client.CreateForumTopicAsync(forumId, "Endfix integration topic");
            Assert.True(topic.MessageThreadId > 0);

            Assert.True(await _client.EditForumTopicAsync(
                forumId,
                topic.MessageThreadId,
                name: "Endfix integration topic edited"));

            var message = await _client.SendMessageAsync(
                forumId,
                "Endfix forum integration",
                messageThreadId: topic.MessageThreadId);
            Assert.Equal(topic.MessageThreadId, message.MessageThreadId);

            Assert.True(await _client.SetMessageReactionAsync(
                forumId,
                message.MessageId,
                [new ReactionTypeEmoji { Emoji = "👍" }]));
            Assert.True(await _client.SetMessageReactionAsync(
                forumId,
                message.MessageId,
                []));

            Assert.True(await _client.CloseForumTopicAsync(forumId, topic.MessageThreadId));
            Assert.True(await _client.ReopenForumTopicAsync(forumId, topic.MessageThreadId));
            Assert.True(await _client.DeleteForumTopicAsync(forumId, topic.MessageThreadId));
            topicDeleted = true;
        }
        finally
        {
            if (topic is not null && !topicDeleted)
            {
                await _client.DeleteForumTopicAsync(forumId, topic.MessageThreadId);
            }
        }
    }

    [TelegramGroupIntegrationFact]
    public async Task GroupMetadataMessageAndInviteLink_RollBack()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var original = await _client.GetChatAsync(groupId);
        var temporaryTitle = $"Endfix integration {DateTimeOffset.UtcNow:HHmmss}";
        const string temporaryDescription = "Endfix.Telegram.BotAPI integration test";
        Message? message = null;
        ChatInviteLink? inviteLink = null;
        var inviteLinkRevoked = false;

        try
        {
            Assert.True(await _client.SetChatTitleAsync(groupId, temporaryTitle));
            Assert.True(await _client.SetChatDescriptionAsync(groupId, temporaryDescription));

            var changed = await _client.GetChatAsync(groupId);
            Assert.Equal(temporaryTitle, changed.Title);
            Assert.Equal(temporaryDescription, changed.Description);

            message = await _client.SendMessageAsync(groupId, "Endfix group integration: before edit");
            var edited = await _client.EditMessageTextAsync(
                "Endfix group integration: after edit",
                chatId: groupId,
                messageId: message.MessageId);
            Assert.Equal("Endfix group integration: after edit", edited.Text);

            Assert.True(await _client.PinChatMessageAsync(groupId, message.MessageId, disableNotification: true));
            Assert.True(await _client.UnpinChatMessageAsync(groupId, messageId: message.MessageId));

            inviteLink = await _client.CreateChatInviteLinkAsync(
                groupId,
                name: "Endfix integration",
                memberLimit: 1);
            Assert.False(inviteLink.IsRevoked);

            inviteLink = await _client.EditChatInviteLinkAsync(
                groupId,
                inviteLink.InviteLink,
                name: "Endfix integration edited",
                memberLimit: 2);
            Assert.Equal("Endfix integration edited", inviteLink.Name);

            inviteLink = await _client.RevokeChatInviteLinkAsync(groupId, inviteLink.InviteLink);
            inviteLinkRevoked = true;
            Assert.True(inviteLink.IsRevoked);
        }
        finally
        {
            if (inviteLink is not null && !inviteLinkRevoked)
            {
                await _client.RevokeChatInviteLinkAsync(groupId, inviteLink.InviteLink);
            }

            if (message is not null)
            {
                await _client.DeleteMessageAsync(groupId, message.MessageId);
            }

            Assert.True(await _client.SetChatTitleAsync(groupId, original.Title!));
            Assert.True(await _client.SetChatDescriptionAsync(groupId, original.Description));
        }
    }

    [TelegramChannelIntegrationFact]
    public async Task ChannelMetadataAndMessage_RollBack()
    {
        var channelId = GetId(TelegramIntegrationFactAttribute.ChannelIdVariable);
        var original = await _client.GetChatAsync(channelId);
        var temporaryTitle = $"Endfix integration {DateTimeOffset.UtcNow:HHmmss}";
        const string temporaryDescription = "Endfix.Telegram.BotAPI channel integration test";
        Message? message = null;

        try
        {
            Assert.True(await _client.SetChatTitleAsync(channelId, temporaryTitle));
            Assert.True(await _client.SetChatDescriptionAsync(channelId, temporaryDescription));

            var changed = await _client.GetChatAsync(channelId);
            Assert.Equal(temporaryTitle, changed.Title);
            Assert.Equal(temporaryDescription, changed.Description);

            message = await _client.SendMessageAsync(channelId, "Endfix channel integration: before edit");
            var edited = await _client.EditMessageTextAsync(
                "Endfix channel integration: after edit",
                chatId: channelId,
                messageId: message.MessageId);
            Assert.Equal("Endfix channel integration: after edit", edited.Text);

            Assert.True(await _client.PinChatMessageAsync(channelId, message.MessageId, disableNotification: true));
            Assert.True(await _client.UnpinChatMessageAsync(channelId, messageId: message.MessageId));
        }
        finally
        {
            if (message is not null)
            {
                await _client.DeleteMessageAsync(channelId, message.MessageId);
            }

            Assert.True(await _client.SetChatTitleAsync(channelId, original.Title!));
            Assert.True(await _client.SetChatDescriptionAsync(channelId, original.Description));
        }
    }

    [TelegramRoutingIntegrationFact]
    public async Task Messages_CopyAndForwardAcrossConfiguredChats()
    {
        var privateChatId = GetId(TelegramIntegrationFactAttribute.ChatIdVariable);
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var channelId = GetId(TelegramIntegrationFactAttribute.ChannelIdVariable);
        Message? source = null;
        MessageIdStruct? copied = null;
        Message? forwarded = null;

        try
        {
            source = await _client.SendMessageAsync(groupId, "Endfix routing integration source");
            copied = await _client.CopyMessageAsync(channelId, groupId, source.MessageId);
            forwarded = await _client.ForwardMessageAsync(privateChatId, groupId, source.MessageId);

            Assert.True(copied.MessageId > 0);
            Assert.True(forwarded.MessageId > 0);
            Assert.Equal(privateChatId, forwarded.Chat.Id);
        }
        finally
        {
            if (forwarded is not null)
            {
                await _client.DeleteMessageAsync(privateChatId, forwarded.MessageId);
            }

            if (copied is not null)
            {
                await _client.DeleteMessageAsync(channelId, copied.MessageId);
            }

            if (source is not null)
            {
                await _client.DeleteMessageAsync(groupId, source.MessageId);
            }
        }
    }

    public void Dispose() => _httpClient.Dispose();

    private static long GetId(string variable)
        => long.Parse(TelegramIntegrationSettings.Get(variable)
            ?? throw new InvalidOperationException($"{variable} is not configured."));
}
