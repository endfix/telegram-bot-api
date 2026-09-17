# ASP.NET Core webhook example

This example receives Telegram updates over HTTPS and demonstrates the same
application lifetime model as the long-polling sample:

- one singleton `IBotApiClient` represents one bot;
- the supplied `HttpClient` is a singleton owned and disposed by the DI
  container, with `SocketsHttpHandler.PooledConnectionLifetime` refreshing
  pooled connections;
- a hosted service registers the webhook after Kestrel is listening and removes
  it on shutdown without dropping pending updates;
- each POST is processed in a newly created async DI scope, so scoped handlers
  and database contexts are not captured by the singleton client.

Telegram requires an HTTPS webhook URL. Run the app locally over HTTP and
expose `/webhook/update` through a tunnel such as
[cloudflared](https://developers.cloudflare.com/cloudflare-one/connections/connect-apps/)
or ngrok.

The endpoint validates `X-Telegram-Bot-Api-Secret-Token` before reading the
body. Malformed JSON is rejected with `400`. Handler failures are logged and
the endpoint still returns `200`, matching the library's best-effort
at-most-once delivery: Telegram will not retry a successfully acknowledged
update.

Configure secrets, then run:

```powershell
dotnet user-secrets set "TELEGRAM_BOT_TOKEN" "<token>" --project Telegram.BotAPI.Examples/Webhook/Telegram.BotAPI.Example.Webhook.csproj
dotnet user-secrets set "TelegramBotApi:WebhookUrl" "https://<tunnel-host>/webhook/update" --project Telegram.BotAPI.Examples/Webhook/Telegram.BotAPI.Example.Webhook.csproj
dotnet user-secrets set "TelegramBotApi:SecretToken" "<random-secret>" --project Telegram.BotAPI.Examples/Webhook/Telegram.BotAPI.Example.Webhook.csproj
```

`TelegramBotApi:WebhookUrl` and `TelegramBotApi:SecretToken` may also be set as
`TELEGRAM_WEBHOOK_URL` and `TELEGRAM_WEBHOOK_SECRET`. The secret may contain
only `A-Za-z0-9_-` and must be 1-256 characters, as required by Telegram.

```powershell
cloudflared tunnel --url http://localhost:8080
dotnet run --project Telegram.BotAPI.Examples/Webhook/Telegram.BotAPI.Example.Webhook.csproj
```

Send a text message to the bot; the example echoes it. Other update types are
logged and acknowledged. Press `Ctrl+C` to stop; the host deletes the webhook
and leaves pending updates in place so long polling can pick them up.
