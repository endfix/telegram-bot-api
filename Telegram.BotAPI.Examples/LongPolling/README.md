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

The harness removes an existing webhook without dropping pending updates because
Telegram does not allow long polling while a webhook is active. Press `Ctrl+C`
to stop it.
