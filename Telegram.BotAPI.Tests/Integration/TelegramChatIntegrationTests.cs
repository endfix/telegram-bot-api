using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Types;
using Xunit;
using Xunit.Sdk;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

[Trait("Category", "Integration")]
[Collection(TelegramIntegrationCollection.Name)]
public sealed class TelegramChatIntegrationTests : IDisposable
{
    private readonly HttpClient _httpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(30)
    };
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

    [TelegramIntegrationFact]
    public async Task BotChatSettings_RollBack()
    {
        var chatId = GetId(TelegramIntegrationFactAttribute.ChatIdVariable);
        const string languageCode = "eo";
        var commandScope = new BotCommandScopeChat { ChatId = chatId };
        var originalMenuButton = await _client.GetChatMenuButtonAsync(chatId);
        var originalCommands = await _client.GetMyCommandsAsync(commandScope);
        var originalName = await _client.GetMyNameAsync(languageCode);
        var originalDescription = await _client.GetMyDescriptionAsync(languageCode);
        var originalShortDescription = await _client.GetMyShortDescriptionAsync(languageCode);
        var menuChanged = false;
        var commandsChanged = false;
        var nameChanged = false;
        var descriptionChanged = false;
        var shortDescriptionChanged = false;
        var suffix = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        try
        {
            Assert.True(await _client.SetChatMenuButtonAsync(
                chatId,
                new MenuButtonWebApp
                {
                    Text = "Endfix integration",
                    WebApp = new WebAppInfo
                    {
                        Url = "https://endfix.github.io/telegram-bot-api/"
                    }
                }));
            menuChanged = true;
            var menuButton = Assert.IsType<MenuButtonWebApp>(await _client.GetChatMenuButtonAsync(chatId));
            Assert.Equal("Endfix integration", menuButton.Text);

            var temporaryCommands = new[]
            {
                new BotCommand
                {
                    Command = "endfix_test",
                    Description = "Endfix integration test"
                }
            };
            Assert.True(await _client.SetMyCommandsAsync(temporaryCommands, commandScope));
            commandsChanged = true;
            var commands = await _client.GetMyCommandsAsync(commandScope);
            var command = Assert.Single(commands);
            Assert.Equal("endfix_test", command.Command);

            Assert.True(await _client.SetMyNameAsync($"Endfix integration {suffix}", languageCode));
            nameChanged = true;
            Assert.Equal($"Endfix integration {suffix}", (await _client.GetMyNameAsync(languageCode)).Name);

            Assert.True(await _client.SetMyDescriptionAsync(
                $"Endfix integration description {suffix}",
                languageCode));
            descriptionChanged = true;
            Assert.Equal(
                $"Endfix integration description {suffix}",
                (await _client.GetMyDescriptionAsync(languageCode)).Description);

            Assert.True(await _client.SetMyShortDescriptionAsync(
                $"Endfix integration {suffix}",
                languageCode));
            shortDescriptionChanged = true;
            Assert.Equal(
                $"Endfix integration {suffix}",
                (await _client.GetMyShortDescriptionAsync(languageCode)).ShortDescription);
        }
        finally
        {
            if (shortDescriptionChanged)
            {
                Assert.True(await _client.SetMyShortDescriptionAsync(
                    originalShortDescription.ShortDescription,
                    languageCode));
            }

            if (descriptionChanged)
            {
                Assert.True(await _client.SetMyDescriptionAsync(
                    originalDescription.Description,
                    languageCode));
            }

            if (nameChanged)
            {
                Assert.True(await _client.SetMyNameAsync(originalName.Name, languageCode));
            }

            if (commandsChanged)
            {
                if (originalCommands.Count == 0)
                {
                    Assert.True(await _client.DeleteMyCommandsAsync(commandScope));
                }
                else
                {
                    Assert.True(await _client.SetMyCommandsAsync(originalCommands, commandScope));
                }
            }

            if (menuChanged)
            {
                Assert.True(await _client.SetChatMenuButtonAsync(chatId, originalMenuButton));
            }
        }

        Assert.Equal(
            originalMenuButton.Serialize(),
            (await _client.GetChatMenuButtonAsync(chatId)).Serialize());
        Assert.Equal(
            originalCommands.Select(command => (command.Command, command.Description, command.IsEphemeral)),
            (await _client.GetMyCommandsAsync(commandScope))
                .Select(command => (command.Command, command.Description, command.IsEphemeral)));
        Assert.Equal(originalName.Name, (await _client.GetMyNameAsync(languageCode)).Name);
        Assert.Equal(
            originalDescription.Description,
            (await _client.GetMyDescriptionAsync(languageCode)).Description);
        Assert.Equal(
            originalShortDescription.ShortDescription,
            (await _client.GetMyShortDescriptionAsync(languageCode)).ShortDescription);
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
        Assert.True(administrator.CanRestrictMembers);
        Assert.True(administrator.CanPromoteMembers);
        Assert.True(administrator.CanManageTags);
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

    [TelegramGroupIntegrationFact]
    public async Task GroupDefaultPermissions_RollBack()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var original = Assert.IsType<ChatPermissions>((await _client.GetChatAsync(groupId)).Permissions);
        var temporary = CopyPermissions(
            original,
            canSendPolls: original.CanSendPolls is not true);

        try
        {
            Assert.True(await _client.SetChatPermissionsAsync(
                groupId,
                temporary,
                useIndependentChatPermissions: true));

            var changed = Assert.IsType<ChatPermissions>((await _client.GetChatAsync(groupId)).Permissions);
            Assert.Equal(temporary.CanSendPolls, changed.CanSendPolls);
        }
        finally
        {
            Assert.True(await _client.SetChatPermissionsAsync(
                groupId,
                original,
                useIndependentChatPermissions: true));

            var restored = Assert.IsType<ChatPermissions>((await _client.GetChatAsync(groupId)).Permissions);
            Assert.Equal(original.Serialize(), restored.Serialize());
        }
    }

    [TelegramModerationIntegrationFact]
    public async Task TestUserRestriction_RollBack()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var userId = GetId(TelegramIntegrationFactAttribute.TestUserIdVariable);
        var original = await _client.GetChatMemberAsync(groupId, userId);
        Assert.IsType<ChatMemberMember>(original);

        try
        {
            Assert.True(await _client.RestrictChatMemberAsync(
                groupId,
                userId,
                new ChatPermissions { CanSendMessages = false },
                useIndependentChatPermissions: true));

            var restricted = Assert.IsType<ChatMemberRestricted>(
                await _client.GetChatMemberAsync(groupId, userId));
            Assert.True(restricted.IsMember);
            Assert.False(restricted.CanSendMessages);
        }
        finally
        {
            Assert.True(await _client.RestrictChatMemberAsync(
                groupId,
                userId,
                AllChatPermissions,
                useIndependentChatPermissions: true));

            Assert.IsType<ChatMemberMember>(await _client.GetChatMemberAsync(groupId, userId));
        }
    }

    [TelegramModerationIntegrationFact]
    public async Task TestUserTag_RollBack()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var userId = GetId(TelegramIntegrationFactAttribute.TestUserIdVariable);
        var bot = await _client.GetMeAsync();
        var botMember = Assert.IsType<ChatMemberAdministrator>(
            await _client.GetChatMemberAsync(groupId, bot.Id));
        Assert.True(
            botMember.CanManageTags,
            "Grant the bot the Manage Tags administrator right to run this test.");

        var original = Assert.IsType<ChatMemberMember>(
            await _client.GetChatMemberAsync(groupId, userId));
        const string temporaryTag = "Member test";
        var tagChanged = false;

        try
        {
            Assert.True(await _client.SetChatMemberTagAsync(groupId, userId, temporaryTag));
            tagChanged = true;
            var changed = Assert.IsType<ChatMemberMember>(
                await _client.GetChatMemberAsync(groupId, userId));
            Assert.Equal(temporaryTag, changed.Tag);
        }
        finally
        {
            if (tagChanged)
            {
                Assert.True(await _client.SetChatMemberTagAsync(groupId, userId, original.Tag));
                var restored = Assert.IsType<ChatMemberMember>(
                    await _client.GetChatMemberAsync(groupId, userId));
                Assert.Equal(original.Tag, restored.Tag);
            }
        }
    }

    [TelegramModerationIntegrationFact]
    public async Task TestUserPromotionAndCustomTitle_RollBack()
    {
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        var userId = GetId(TelegramIntegrationFactAttribute.TestUserIdVariable);
        var bot = await _client.GetMeAsync();
        var botMember = Assert.IsType<ChatMemberAdministrator>(
            await _client.GetChatMemberAsync(groupId, bot.Id));
        Assert.True(
            botMember.CanPromoteMembers,
            "Grant the bot the Add New Admins administrator right to run this test.");

        var original = Assert.IsType<ChatMemberMember>(
            await _client.GetChatMemberAsync(groupId, userId));
        var promoted = false;

        try
        {
            Assert.True(await _client.PromoteChatMemberAsync(
                groupId,
                userId,
                canDeleteMessages: true));
            promoted = true;

            var administrator = Assert.IsType<ChatMemberAdministrator>(
                await _client.GetChatMemberAsync(groupId, userId));
            Assert.True(administrator.CanDeleteMessages);

            Assert.True(await _client.SetChatAdministratorCustomTitleAsync(
                groupId,
                userId,
                "Admin test"));
            administrator = Assert.IsType<ChatMemberAdministrator>(
                await _client.GetChatMemberAsync(groupId, userId));
            Assert.Equal("Admin test", administrator.CustomTitle);
        }
        finally
        {
            if (promoted)
            {
                Assert.True(await _client.PromoteChatMemberAsync(CreateDemotion(groupId, userId)));
                Assert.True(await _client.SetChatMemberTagAsync(groupId, userId, original.Tag));
                var restored = Assert.IsType<ChatMemberMember>(
                    await _client.GetChatMemberAsync(groupId, userId));
                Assert.Equal(original.Tag, restored.Tag);
            }
        }
    }

    [TelegramPremiumIntegrationFact]
    public async Task PremiumOwner_CustomEmojiButton_RoundTrips()
    {
        var userId = GetId(TelegramIntegrationFactAttribute.ChatIdVariable);
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        await RequirePremiumUserAsync(groupId, userId);

        var stickers = await _client.GetForumTopicIconStickersAsync();
        var customEmojiId = stickers
            .Select(sticker => sticker.CustomEmojiId)
            .FirstOrDefault(id => !string.IsNullOrWhiteSpace(id));
        Assert.False(string.IsNullOrWhiteSpace(customEmojiId));

        Message? message = null;
        try
        {
            message = await _client.SendMessageAsync(new SendMessageParameters
            {
                ChatId = userId,
                Text = "Endfix Telegram Premium integration: custom emoji button",
                ReplyMarkup = new InlineKeyboardMarkup
                {
                    InlineKeyboard =
                    [
                        [
                            new InlineKeyboardButton
                            {
                                Text = "Premium",
                                IconCustomEmojiId = customEmojiId,
                                Style = KeyboardButtonStyle.Success,
                                CallbackData = "premium_test"
                            }
                        ]
                    ]
                }
            });

            var button = Assert.Single(Assert.Single(message.ReplyMarkup!.InlineKeyboard));
            Assert.Equal(customEmojiId, button.IconCustomEmojiId);
            Assert.Equal(KeyboardButtonStyle.Success, button.Style);
        }
        finally
        {
            if (message is not null)
            {
                await _client.DeleteMessageAsync(userId, message.MessageId);
            }
        }
    }

    [TelegramPremiumIntegrationFact]
    public async Task PremiumUser_ReadOnlyProfileCollections_Deserialize()
    {
        var userId = GetId(TelegramIntegrationFactAttribute.ChatIdVariable);
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        await RequirePremiumUserAsync(groupId, userId);

        var profileAudios = await _client.GetUserProfileAudiosAsync(userId, limit: 1);
        var userGifts = await _client.GetUserGiftsAsync(userId, limit: 1);
        var availableGifts = await _client.GetAvailableGiftsAsync();

        Assert.InRange(profileAudios.Audios.Count, 0, profileAudios.TotalCount);
        Assert.InRange(userGifts.Gifts.Count, 0, userGifts.TotalCount);
        Assert.NotNull(availableGifts.Gifts);
    }

    [TelegramEmojiStatusIntegrationFact]
    public async Task PremiumUser_EmojiStatus_MutationIsAcceptedAndRestored()
    {
        var userId = GetId(TelegramIntegrationFactAttribute.ChatIdVariable);
        var groupId = GetId(TelegramIntegrationFactAttribute.GroupIdVariable);
        await RequirePremiumUserAsync(groupId, userId);

        var originalChat = await _client.GetChatAsync(userId);
        var originalEmojiId = originalChat.EmojiStatusCustomEmojiId;
        var originalExpirationDate = originalChat.EmojiStatusExpirationDate;
        var stickers = await _client.GetForumTopicIconStickersAsync();
        var testEmojiId = stickers
            .Select(sticker => sticker.CustomEmojiId)
            .FirstOrDefault(id =>
                !string.IsNullOrWhiteSpace(id) &&
                !string.Equals(id, originalEmojiId, StringComparison.Ordinal));
        Assert.False(string.IsNullOrWhiteSpace(testEmojiId));

        try
        {
            Assert.True(await _client.SetUserEmojiStatusAsync(userId, testEmojiId));
        }
        finally
        {
            Assert.True(await _client.SetUserEmojiStatusAsync(
                userId,
                originalEmojiId ?? string.Empty,
                originalExpirationDate));
        }
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
        var messagePinned = false;
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
            messagePinned = true;
            Assert.Equal(message.MessageId, (await _client.GetChatAsync(groupId)).PinnedMessage?.MessageId);

            Assert.True(await _client.UnpinChatMessageAsync(groupId, messageId: message.MessageId));
            Assert.NotEqual(message.MessageId, (await _client.GetChatAsync(groupId)).PinnedMessage?.MessageId);
            messagePinned = false;

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
                try
                {
                    if (messagePinned)
                    {
                        await _client.UnpinChatMessageAsync(groupId, messageId: message.MessageId);
                    }
                }
                finally
                {
                    await _client.DeleteMessageAsync(groupId, message.MessageId);
                }
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
        const string editedInviteLinkName = "Endfix channel invite edited";
        Message? message = null;
        var messagePinned = false;
        ChatInviteLink? inviteLink = null;
        var inviteLinkRevoked = false;

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

            Assert.True(await _client.SetMessageReactionAsync(
                channelId,
                message.MessageId,
                [new ReactionTypeEmoji { Emoji = "👍" }]));
            Assert.True(await _client.SetMessageReactionAsync(
                channelId,
                message.MessageId,
                []));

            Assert.True(await _client.PinChatMessageAsync(channelId, message.MessageId, disableNotification: true));
            messagePinned = true;
            Assert.Equal(message.MessageId, (await _client.GetChatAsync(channelId)).PinnedMessage?.MessageId);

            Assert.True(await _client.UnpinChatMessageAsync(channelId, messageId: message.MessageId));
            Assert.NotEqual(message.MessageId, (await _client.GetChatAsync(channelId)).PinnedMessage?.MessageId);
            messagePinned = false;

            Assert.True(await _client.GetChatMemberCountAsync(channelId) > 0);

            inviteLink = await _client.CreateChatInviteLinkAsync(
                channelId,
                name: "Endfix channel integration");
            Assert.False(inviteLink.IsRevoked);

            inviteLink = await _client.EditChatInviteLinkAsync(
                channelId,
                inviteLink.InviteLink,
                name: editedInviteLinkName);
            Assert.Equal(editedInviteLinkName, inviteLink.Name);

            inviteLink = await _client.RevokeChatInviteLinkAsync(
                channelId,
                inviteLink.InviteLink);
            inviteLinkRevoked = true;
            Assert.True(inviteLink.IsRevoked);
        }
        finally
        {
            if (inviteLink is not null && !inviteLinkRevoked)
            {
                await _client.RevokeChatInviteLinkAsync(channelId, inviteLink.InviteLink);
            }

            if (message is not null)
            {
                try
                {
                    if (messagePinned)
                    {
                        await _client.UnpinChatMessageAsync(channelId, messageId: message.MessageId);
                    }
                }
                finally
                {
                    await _client.DeleteMessageAsync(channelId, message.MessageId);
                }
            }

            Assert.True(await _client.SetChatTitleAsync(channelId, original.Title!));
            Assert.True(await _client.SetChatDescriptionAsync(channelId, original.Description));
        }
    }

    [TelegramChannelIntegrationFact]
    public async Task ChannelPhoto_RollBack()
    {
        var channelId = GetId(TelegramIntegrationFactAttribute.ChannelIdVariable);
        var initiallyHadPhoto = (await _client.GetChatAsync(channelId)).Photo is not null;
        byte[]? restorationBytes = null;
        var photoPresent = initiallyHadPhoto;
        var restorationCompleted = false;

        try
        {
            if (!initiallyHadPhoto)
            {
                Assert.True(await _client.SetChatPhotoAsync(
                    channelId,
                    new InputPhotoFile(FixturePath("cover.jpg"))));
                photoPresent = true;
            }

            restorationBytes = await DownloadChatPhotoAsync(channelId);

            Assert.True(await _client.SetChatPhotoAsync(
                channelId,
                new InputPhotoFile(FixturePath("album-photo.jpg"))));
            photoPresent = true;
            Assert.NotNull((await _client.GetChatAsync(channelId)).Photo);

            Assert.True(await _client.DeleteChatPhotoAsync(channelId));
            photoPresent = false;
            Assert.Null((await _client.GetChatAsync(channelId)).Photo);

            Assert.True(await _client.SetChatPhotoAsync(
                channelId,
                new InputPhotoFile(InputFileSource.FromMemory(
                    restorationBytes,
                    "restored-channel-photo.jpg"))));
            photoPresent = true;
            restorationCompleted = true;
            Assert.NotNull((await _client.GetChatAsync(channelId)).Photo);
        }
        finally
        {
            if (initiallyHadPhoto && !restorationCompleted && restorationBytes is not null)
            {
                Assert.True(await _client.SetChatPhotoAsync(
                    channelId,
                    new InputPhotoFile(InputFileSource.FromMemory(
                        restorationBytes,
                        "original-channel-photo.jpg"))));
            }
            else if (!initiallyHadPhoto && photoPresent)
            {
                Assert.True(await _client.DeleteChatPhotoAsync(channelId));
            }
        }

        Assert.Equal(initiallyHadPhoto, (await _client.GetChatAsync(channelId)).Photo is not null);
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

    private static readonly ChatPermissions AllChatPermissions = new()
    {
        CanSendMessages = true,
        CanSendAudios = true,
        CanSendDocuments = true,
        CanSendPhotos = true,
        CanSendVideos = true,
        CanSendVideoNotes = true,
        CanSendVoiceNotes = true,
        CanSendPolls = true,
        CanSendOtherMessages = true,
        CanAddWebPagePreviews = true,
        CanReactToMessages = true,
        CanEditTag = true,
        CanChangeInfo = true,
        CanInviteUsers = true,
        CanPinMessages = true,
        CanManageTopics = true
    };

    private static string FixturePath(string fileName)
        => Path.Combine(AppContext.BaseDirectory, "Fixtures", "Media", fileName);

    private async Task<byte[]> DownloadChatPhotoAsync(long chatId)
    {
        var photo = Assert.IsType<ChatPhoto>((await _client.GetChatAsync(chatId)).Photo);
        var file = await _client.GetFileAsync(photo.BigFileId);
        Assert.False(string.IsNullOrWhiteSpace(file.FilePath));
        var content = await _client.GetFileBytesAsync(file.FilePath!);
        Assert.NotEmpty(content);
        return content;
    }

    private static PromoteChatMemberParameters CreateDemotion(long chatId, long userId)
        => new()
        {
            ChatId = chatId,
            UserId = userId,
            IsAnonymous = false,
            CanManageChat = false,
            CanDeleteMessages = false,
            CanManageVideoChats = false,
            CanRestrictMembers = false,
            CanPromoteMembers = false,
            CanChangeInfo = false,
            CanInviteUsers = false,
            CanPostStories = false,
            CanEditStories = false,
            CanDeleteStories = false,
            CanPostMessages = false,
            CanEditMessages = false,
            CanPinMessages = false,
            CanManageTopics = false,
            CanManageDirectMessages = false,
            CanManageTags = false,
            CanSendWelcomeMessages = false
        };

    private static ChatPermissions CopyPermissions(
        ChatPermissions source,
        bool? canSendPolls = null)
        => new()
        {
            CanSendMessages = source.CanSendMessages,
            CanSendAudios = source.CanSendAudios,
            CanSendDocuments = source.CanSendDocuments,
            CanSendPhotos = source.CanSendPhotos,
            CanSendVideos = source.CanSendVideos,
            CanSendVideoNotes = source.CanSendVideoNotes,
            CanSendVoiceNotes = source.CanSendVoiceNotes,
            CanSendPolls = canSendPolls ?? source.CanSendPolls,
            CanSendOtherMessages = source.CanSendOtherMessages,
            CanAddWebPagePreviews = source.CanAddWebPagePreviews,
            CanReactToMessages = source.CanReactToMessages,
            CanEditTag = source.CanEditTag,
            CanChangeInfo = source.CanChangeInfo,
            CanInviteUsers = source.CanInviteUsers,
            CanPinMessages = source.CanPinMessages,
            CanManageTopics = source.CanManageTopics
        };

    private async Task RequirePremiumUserAsync(long groupId, long userId)
    {
        var member = await _client.GetChatMemberAsync(groupId, userId);
        if (member.User.IsPremium is not true)
        {
            throw SkipException.ForSkip(
                "The configured private-chat user does not currently have Telegram Premium.");
        }
    }

    private static long GetId(string variable)
        => long.Parse(TelegramIntegrationSettings.Get(variable)
            ?? throw new InvalidOperationException($"{variable} is not configured."));
}
