# .NET Framework smoke test

This project targets `net48` and references the library project. On .NET
Framework the project reference selects the `netstandard2.0` asset, so the run
verifies the fallback package path on a real .NET Framework runtime.

The local part runs without credentials and checks serializer hardening, URL
path validation, polling retry and fatal-error behavior, and disposal of an
active polling session. When `TELEGRAM_BOT_TOKEN` and `TELEGRAM_BOT_CHAT_ID` are
set, it also performs live Bot API calls and removes the messages it creates.

From the repository root (Windows with the .NET Framework 4.8 targeting pack):

```powershell
$s = Get-Content "$env:APPDATA\Microsoft\UserSecrets\<user-secrets-id>\secrets.json" -Raw | ConvertFrom-Json
$env:TELEGRAM_BOT_TOKEN = $s.TELEGRAM_BOT_TOKEN
$env:TELEGRAM_BOT_CHAT_ID = $s.TELEGRAM_BOT_CHAT_ID
dotnet run --project eng/NetFrameworkSmoke/Telegram.BotAPI.NetFrameworkSmoke.csproj -c Release
```

Live checks are skipped when either variable is missing. A webhook must not be
configured for the live long-polling check; that check is skipped otherwise.
