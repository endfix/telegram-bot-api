# Telegram Bot API (С#)
[![Bot%20API](https://img.shields.io/badge/Bot%20API-9.2-red.svg)](https://core.telegram.org/bots/api#august-15-2025)
[![.NET%20Standart](https://img.shields.io/badge/.NET%20Standart-2.0-blue.svg)](https://core.telegram.org/bots/api#august-15-2025)

The Bot API is an HTTP-based interface created for developers keen on building bots for Telegram on programming language the C Sharp.

## Initialization
Each bot is given a unique authentication token [when it is created](https://core.telegram.org/bots/features#botfather). The token looks something like ```123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11```, but we'll use simply **\<token\>** in this document instead. You can learn about obtaining tokens and generating new ones in [this document](https://core.telegram.org/bots/features#botfather).
```cs
var api = new BotApiClient(
    "<token>",
    new HttpClient(new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromSeconds(5), MaxConnectionsPerServer = 10 }) { Timeout = TimeSpan.FromMinutes(5) }
);
```

## Long polling mode
```cs
_ = Task.Run(async () =>
{
    var lastUpdateId = 0L;
    while (true)
    {
        var updates = (await api.GetUpdatesAsync(new GetUpdatesParameters
        {
            Offset = lastUpdateId
        })).Result;
        
        foreach (var update in updates)
        {
            if (update.Type == UpdateTypes.Message && update.Message.Document != null)
            {
                var file = (await api.GetFileAsync(new GetFileParameters
                {
                    FileId = update.Message.Document.FileId
                })).Result;
                
                var fileBytes = (await api.GetFileBytesAsync(filePath: file.FilePath)).Result;
                File.WriteAllBytes($"D:\\{update.Message.Document.FileName}", fileBytes);
            }     
            lastUpdateId = update.UpdateId + 1;
        }      
        await Task.Delay(1000);
    }
});
```



## Download file
Use this method to get basic information about a file and prepare it for downloading. For the moment, bots can download files of up to 20MB in size.
```cs
var message = (await api.SendDocumentAsync(new SendDocumentParameters
{
	ChatId = 1234567890,
	Document = new InputDocumentFile("path to file")
})).Result;

var file = (await api.GetFileAsync(new GetFileParameters
{
	FileId = message.Document.FileId
})).Result;

var fileBytes = (await api.GetFileBytesAsync(filePath: file.Result.FilePath)).Result;

File.WriteAllBytes("downloaded file", fileBytes);
```