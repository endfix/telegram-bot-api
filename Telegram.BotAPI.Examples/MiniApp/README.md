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

## Host through GitHub Pages

Enable **GitHub Actions** as the Pages source in the repository settings. The
`mini-app-pages.yml` workflow publishes `wwwroot` when its files change. Then
configure the bot's Main App URL as:

```text
https://endfix.github.io/telegram-bot-api/
```

The Mini App needs a web host rather than a source-file CDN: its entry point
must be served as `text/html`. Statically currently serves this repository's
HTML source without that media type, causing browsers to display the markup as
plain text.

Open the Main App from Telegram and select **Request access**. Telegram should
show its native permission dialog. Once access is granted, the Bot API method
`setUserEmojiStatus` can be exercised for that user by the Premium live tests.

The LongPolling example can also send a reply-keyboard Mini App button. Launch
the page through that button and select **Send test data** to deliver a
`web_app_data` update to the event harness.
