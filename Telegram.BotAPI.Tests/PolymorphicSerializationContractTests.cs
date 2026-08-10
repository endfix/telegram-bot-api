using FluentAssertions;
using Telegram.BotAPI.Types;
using Xunit;

namespace Telegram.BotAPI.Tests;

public class PolymorphicSerializationContractTests
{
    [Theory]
    [InlineData("Polymorphic/reaction_type_emoji.json", typeof(ReactionTypeEmoji))]
    [InlineData("Polymorphic/reaction_type_custom_emoji.json", typeof(ReactionTypeCustomEmoji))]
    [InlineData("Polymorphic/reaction_type_paid.json", typeof(ReactionTypePaid))]
    public void ReactionType_Discriminator_SelectsExpectedSubtype(string fixturePath, Type expectedType)
    {
        var value = JsonContract.DeserializeFixture<ReactionType>(fixturePath);

        value.Should().BeOfType(expectedType);
        JsonContract.AssertRoundtripsToEquivalentJson<ReactionType>(fixturePath);
    }

    [Theory]
    [InlineData("Polymorphic/message_origin_user.json", typeof(MessageOriginUser))]
    [InlineData("Polymorphic/message_origin_hidden_user.json", typeof(MessageOriginHiddenUser))]
    [InlineData("Polymorphic/message_origin_chat.json", typeof(MessageOriginChat))]
    [InlineData("Polymorphic/message_origin_channel.json", typeof(MessageOriginChannel))]
    public void MessageOrigin_Discriminator_SelectsExpectedSubtype(string fixturePath, Type expectedType)
    {
        var value = JsonContract.DeserializeFixture<MessageOrigin>(fixturePath);

        value.Should().BeOfType(expectedType);
        JsonContract.AssertRoundtripsToEquivalentJson<MessageOrigin>(fixturePath);
    }

    [Theory]
    [InlineData("Polymorphic/paid_media_preview.json", typeof(PaidMediaPreview))]
    [InlineData("Polymorphic/paid_media_photo.json", typeof(PaidMediaPhoto))]
    [InlineData("Polymorphic/paid_media_video.json", typeof(PaidMediaVideo))]
    [InlineData("Polymorphic/paid_media_live_photo.json", typeof(PaidMediaLivePhoto))]
    public void PaidMedia_Discriminator_SelectsExpectedSubtype(string fixturePath, Type expectedType)
    {
        var value = JsonContract.DeserializeFixture<PaidMedia>(fixturePath);

        value.Should().BeOfType(expectedType);
        JsonContract.AssertRoundtripsToEquivalentJson<PaidMedia>(fixturePath);
    }

    [Theory]
    [InlineData("Polymorphic/chat_member_owner.json", typeof(ChatMemberOwner))]
    [InlineData("Polymorphic/chat_member_administrator.json", typeof(ChatMemberAdministrator))]
    [InlineData("Polymorphic/chat_member_member.json", typeof(ChatMemberMember))]
    [InlineData("Polymorphic/chat_member_restricted.json", typeof(ChatMemberRestricted))]
    [InlineData("Polymorphic/chat_member_left.json", typeof(ChatMemberLeft))]
    [InlineData("Polymorphic/chat_member_banned.json", typeof(ChatMemberBanned))]
    public void ChatMember_Discriminator_SelectsExpectedSubtype(string fixturePath, Type expectedType)
    {
        var value = JsonContract.DeserializeFixture<ChatMember>(fixturePath);

        value.Should().BeOfType(expectedType);
        JsonContract.AssertRoundtripsToEquivalentJson<ChatMember>(fixturePath);
    }
}
