# Telegram Bot API (С#)
[![Bot%20API](https://img.shields.io/badge/Bot%20API-9.2-red.svg)](https://core.telegram.org/bots/api#august-15-2025)


## Download file

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

```
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