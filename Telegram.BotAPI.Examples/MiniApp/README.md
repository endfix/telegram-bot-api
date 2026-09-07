# Telegram Mini App test harness

This static Mini App exercises client-side Telegram Web App capabilities needed
by the live integration tests. It contains no bot token or other server-side
secret.

## Run locally

```bash
dotnet run --project Telegram.BotAPI.Examples/MiniApp/Telegram.BotAPI.Example.MiniApp.csproj
```

The local host is useful for browser layout and JavaScript checks. Telegram
capabilities are available only when the page is launched as a Mini App.

## Host through Statically

After the files are pushed to the public repository, configure the bot's Main
App URL as:

```text
https://cdn.statically.io/gh/endfix/telegram-bot-api@main/Telegram.BotAPI.Examples/MiniApp/wwwroot/index.html
```

The `main` URL is convenient while developing. Use a release tag or commit SHA
instead of `main` when a stable, immutable test harness is required.

Open the Main App from Telegram and select **Request access**. Telegram should
show its native permission dialog. Once access is granted, the Bot API method
`setUserEmojiStatus` can be exercised for that user by the Premium live tests.
