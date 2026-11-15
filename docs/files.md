# Files: uploads and downloads

The [README](../README.md) shows a short upload and download example. This page
covers the source types, ownership rules, and download behavior in full.

## Uploading files

Typed input files accept a local path or a repeatable `InputFileSource`. Choose
the source according to where the content already lives and how often it will
be sent.

Use a path for a large or one-off local file. The source is lazy and does not
buffer the complete file in memory:

```cs
var document = new InputDocumentFile(
    InputFileSource.FromPath("report.pdf"));
```

Passing the path directly as `new InputDocumentFile("report.pdf")` remains a
short equivalent. Constructing a path source does not access the filesystem.
The file is opened again for every request attempt, and normal `FileStream`
exceptions surface when the request consumes it or when `InputFile.GetStream()`
is called directly.

Use an in-memory source when the content is already available as bytes, or when
a small or medium payload is sent repeatedly and the application deliberately
wants to avoid opening its file for every attempt:

```cs
var document = new InputDocumentFile(
    InputFileSource.FromMemory(reportBytes, "report.pdf"));

await api.SendDocumentAsync(chatId, document);
```

`FromMemory` takes its own snapshot of the supplied bytes. Reading a large file
into a byte array solely for one upload usually adds memory use and a copy
without avoiding the original disk read. Local benchmarks show that an already
loaded memory source has much lower request-preparation overhead than opening a
path, but they intentionally exclude the cost of loading that byte array and
network transfer normally dominates a Telegram upload.

For databases, object storage, generated content and other stream-backed data,
provide a factory that returns a new readable stream for each request attempt.
In this example, `objectStorage` represents an application-owned storage client,
such as an Amazon S3, Azure Blob Storage or MinIO client:

```cs
var photo = new InputPhotoFile(
    InputFileSource.FromStream(
        () => objectStorage.OpenRead("photos/current.jpg"),
        "current.jpg"));
```

During an API request, the library owns and disposes every stream returned by the
factory. The factory may be called repeatedly for retries or repeated requests, and
concurrently when the same source is used by parallel requests. Every call must
return an independent readable stream. The library reads from its current position
without seeking or rewinding, then disposes it. Do not return the same stream instance
from multiple calls. Streams opened while retrying the same request must expose
equivalent upload content. An exception thrown by the factory propagates to the
caller and stops that request, including an automatic retry. Code that calls
`InputFile.GetStream()` directly owns and must dispose the returned stream itself.

## Downloading files

Use this method to get basic information about a file and prepare it for downloading. For the moment, bots can download files of up to 20MB in size.

```cs
var message = await api.SendDocumentAsync(
    chatId: 1234567890,
    document: new InputDocumentFile("report.pdf"));

var file = await api.GetFileAsync(message.Document!.FileId);
var fileBytes = await api.GetFileBytesAsync(file.FilePath!);

await File.WriteAllBytesAsync("downloaded-report.pdf", fileBytes);
```

For larger files, stream the response directly to a destination instead of
buffering it in a `byte[]`:

```cs
await using var destination = File.Create("downloaded-report.pdf");
await api.DownloadFileAsync(file.FilePath!, destination);
```

`DownloadFileAsync` leaves the destination stream open and positioned after
the downloaded content. Both download methods reject absolute paths,
parent-directory segments, query strings, fragments, and backslashes.
