# Long polling event harness

This example demonstrates both `ILogger` integration and interactive Bot API
updates. It logs every received `Update` as JSON and handles callback queries,
inline queries, Mini App data and join requests.

Configure `TELEGRAM_BOT_TOKEN` through an environment variable or .NET User
Secrets, then run:

```powershell
dotnet run --project Telegram.BotAPI.Examples/LongPolling/Telegram.BotAPI.Example.LongPolling.csproj
```

Send `/probe` to the bot and press **Callback query**. Then press **Inline
query**, enter any text after the bot username and select the returned result.

Send `/webapp`, press **Open event Mini App**, then press **Send test data** in
the Mini App. The resulting `web_app_data` update is logged and acknowledged.

Set `TELEGRAM_BOT_CHAT_ID` to the owner's private chat ID and
`TELEGRAM_BOT_GROUP_ID` to a group where the bot is an administrator with the
**Invite Users** right. Optionally set `TELEGRAM_BOT_TEST_USER_ID` to deliver
the generated link directly to a cooperating account that has started the bot.
Send `/join decline` or `/join approve` from either the owner or that allowlisted
test account. The harness safely unbans the test account when necessary,
verifies that it has otherwise left the group, delivers the link into the
command's current private-chat topic, processes the next matching request and
revokes its temporary 15-minute link.

The harness removes an existing webhook without dropping pending updates because
Telegram does not allow long polling while a webhook is active. Press `Ctrl+C`
to stop it.
