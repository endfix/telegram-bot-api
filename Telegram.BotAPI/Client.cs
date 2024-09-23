using System.Text.RegularExpressions;
using Telegram.BotAPI.Structs;
using Telegram.BotAPI.Serialization.Extensions;

namespace Telegram.BotAPI
{
    public class Client
    {
        private const string BASE_URL = "https://api.telegram.org";

        public string Token { get; set; }

        private static HttpClient _client;

        public Client()
        {
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10)
            };

            _client = new(handler: handler)
            {
                Timeout = TimeSpan.FromMinutes(10)
            };
        }

        private async Task<ResponseAPI<T>> GetAsync<T>(string method)
        {
            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    throw new ArgumentNullException(nameof(Token));
                }

                var url = $"{BASE_URL}/bot{Token}/{method}";

                var response = await _client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var responseApi = ConvertToType<T>(json);

                if (!responseApi.Ok)
                {
                    if (responseApi.ErrorCode == 429)
                    {
                        var match = Regex.Match(responseApi.Description, @"retry after (\d+)");
                        var delay = match.Success ? int.Parse(match.Groups[1].Value) + 60 : 60;

                        await Task.Delay(delay * 1000);

                        return await GetAsync<T>(url);
                    }
                }

                return responseApi;
            }
            catch (Exception e)
            {
                var statusCode = 500;
                if (e is HttpRequestException httpRequestException && httpRequestException.StatusCode != null)
                {
                    statusCode = (int) httpRequestException.StatusCode;
                }

                return new ResponseAPI<T>
                {
                    Ok = false,
                    ErrorCode = statusCode,
                    Description = e.Message,
                    Result = default
                };
            }
        }

        private async Task<ResponseAPI<T>> PostAsync<T>(string method, Dictionary<string, string> postfields)
        {
            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    throw new ArgumentNullException(nameof(Token));
                }

                var url = $"{BASE_URL}/bot{Token}/{method}";
                
                var responseMessage = await _client.PostAsync(url, new FormUrlEncodedContent(postfields));
                var json = await responseMessage.Content.ReadAsStringAsync();
                var responseApi = ConvertToType<T>(json);

                if (!responseApi.Ok && responseApi.ErrorCode == 429)
                {
                    var match = Regex.Match(responseApi.Description, @"retry after (\d+)");
                    var delay = match.Success ? int.Parse(match.Groups[1].Value) + 60 : 60;

                    await Task.Delay(delay * 1000);

                    return await PostAsync<T>(url, postfields);
                }

                return responseApi;
            }
            catch (Exception e)
            {
                var statusCode = 500;
                if (e is HttpRequestException httpRequestException && httpRequestException.StatusCode != null)
                {
                    statusCode = (int)httpRequestException.StatusCode;
                }

                return new ResponseAPI<T>
                {
                    Ok = false,
                    ErrorCode = statusCode,
                    Description = e.Message,
                    Result = default
                };
            }
        }

        private async Task<ResponseAPI<T>> PostMultipartAsync<T>(string method, string contentType, string fileName, byte[] fileData, Dictionary<string, string> postfields)
        {
            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    throw new ArgumentNullException(nameof(Token));
                }

                var data = new MultipartFormDataContent();
                foreach (var postfield in postfields)
                {
                    data.Add(new StringContent(postfield.Value), postfield.Key); //"\"{0}\""
                }
                data.Add(new StreamContent(new MemoryStream(fileData)), contentType, fileName);

                var url = $"{BASE_URL}/bot{Token}/{method}";

                var response = await _client.PostAsync(url, data);
                var json = await response.Content.ReadAsStringAsync();
                var responseApi = ConvertToType<T>(json);

                if (!responseApi.Ok && responseApi.ErrorCode == 429)
                {
                    var match = Regex.Match(responseApi.Description, @"retry after (\d+)");
                    var delay = match.Success ? int.Parse(match.Groups[1].Value) + 60 : 60;

                    await Task.Delay(delay * 1000);

                    return await PostMultipartAsync<T>(url, contentType, fileName, fileData, postfields);
                }

                return responseApi;
            }
            catch (Exception e)
            {
                var statusCode = 500;
                if (e is HttpRequestException httpRequestException && httpRequestException.StatusCode != null)
                {
                    statusCode = (int)httpRequestException.StatusCode;
                }

                return new ResponseAPI<T>
                {
                    Ok = false,
                    ErrorCode = statusCode,
                    Description = e.Message,
                    Result = default
                };
            }
        }

        private async Task<ResponseAPI<byte[]>> GetBytesAsync(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    throw new ArgumentNullException(nameof(Token));
                }

                var url = $"{BASE_URL}/file/bot{Token}/{path}";

                var response = await _client.GetAsync($"{BASE_URL}{path}");

                return new ResponseAPI<byte[]>
                {
                    Ok = true,
                    Result = await response.Content.ReadAsByteArrayAsync()
                };
            }
            catch (Exception e)
            {
                var statusCode = 500;
                if (e is HttpRequestException httpRequestException && httpRequestException.StatusCode != null)
                {
                    statusCode = (int)httpRequestException.StatusCode;
                }

                return new ResponseAPI<byte[]>
                {
                    Ok = false,
                    ErrorCode = statusCode,
                    Description = e.Message,
                    Result = default
                };
            }
        }

        // https://core.telegram.org/bots/api#getfile 
        public async Task<ResponseAPI<Structs.File>> GetFileAsync(string fileId)
        {
            var postfields = new Dictionary<string, string>
            {
                { "file_id", fileId }
            };

            return await PostAsync<Structs.File>("getFile", postfields);
        }

        // https://core.telegram.org/bots/api#file
        public async Task<ResponseAPI<byte[]>> GetFileContentAsync(string filePath)
        {
            return await GetBytesAsync(filePath);
        }

        // https://core.telegram.org/bots/api#answercallbackquery
        public async Task<ResponseAPI<string>> AnswerCallbackQueryAsync(
            string callbackQueryId,
            string text = "",
            bool showAlert = false,
            string url = "",
            int cacheTime = 0)
        {
            var postfields = new Dictionary<string, string>
            {
                { "callback_query_id", callbackQueryId },
                { "text", text },
                { "show_alert", showAlert.ToString() },
                { "url", url },
                { "cache_time", cacheTime.ToString() }
            };

            return await PostAsync<string>("answerCallbackQuery", postfields);
        }

        // https://core.telegram.org/bots/api#approvechatjoinrequest
        public async Task<ResponseAPI<bool>> ApproveChatJoinRequest(string chatId, long userId)
        {
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "user_id", userId.ToString() }
            };

            return await PostAsync<bool>("approveChatJoinRequest", postfields);
        }

        /**
         * https://core.telegram.org/bots/api#getupdates
         * if webhook is enable to error 
         * description: Conflict: can't use getUpdates method while webhook is active; use deleteWebhook to delete the webhook first
         * */
        public async Task<ResponseAPI<Update[]>> GetUpdatesAsync(int offset = 0, int limit = 100, int timeout = 0, List<string> allowedUpdates = null)
        {
            allowedUpdates ??= new List<string>();

            var postfields = new Dictionary<string, string>
            {
                { "offset", offset.ToString() },
                { "limit", limit.ToString() },
                { "timeout", timeout.ToString() },
                { "allowed_updates", allowedUpdates.Serialize() }
            };

            return await PostAsync<Update[]>("getUpdates", postfields);
        }

        // https://core.telegram.org/bots/api#sendgame
        public async Task<ResponseAPI<Message>> SendGameAsync(
            long chatId,
            string gameShortName,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId.ToString() },
                { "game_short_name", gameShortName },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendGame", postfields);
        }

        // https://core.telegram.org/bots/api#sendmessage
        public async Task<ResponseAPI<Message>> SendMessageAsync(
            string chatId,
            string text,
            string businessConnectionId = "",
            int messageThreadId = 0,
            string parseMode = "html",
            List<MessageEntity> entities = null,
            LinkPreviewOptions linkPreviewOptions = null,
            bool disableNotification = false,
            bool protectContent = false,
            string messageEffectId = "",
            ReplyParameters replyParameters = null,
            ReplyMarkupType replyMarkup = null)
        {
            linkPreviewOptions ??= new LinkPreviewOptions { IsDisabled = true };
            replyParameters ??= new ReplyParameters();
            replyMarkup ??= new ReplyMarkupType();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "text", text },
                { "business_connection_id", businessConnectionId },
                { "message_thread_id", messageThreadId.ToString() },
                { "parse_mode", parseMode },
                { "entities", entities.Serialize() },
                { "link_preview_options", linkPreviewOptions.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "message_effect_id", messageEffectId },
                { "reply_parameters", replyParameters.Serialize() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendMessage", postfields);
        }

        // https://core.telegram.org/bots/api#editmessagetext
        public async Task<ResponseAPI<Message>> EditMessageTextAsync(
            string chatId,
            long message_id,
            string text,
            string parseMode = "html",
            string inline_message_id = "",
            List<MessageEntity> entities = null,
            bool disableWebPagePreview = true,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "message_id", message_id.ToString() },
                { "inline_message_id", inline_message_id },
                { "text", text },
                { "parse_mode", parseMode },
                { "entities", entities.Serialize() },
                { "disable_web_page_preview", disableWebPagePreview.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("editMessageText", postfields);
        }

        // https://core.telegram.org/bots/api#sendphoto
        public async Task<ResponseAPI<Message>> SendPhotoAsync(
            string chatId,
            string photo,
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            bool hasSpoiler = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "photo", photo },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "has_spoiler", hasSpoiler.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendPhoto", postfields);
        }

        // https://core.telegram.org/bots/api#sendphoto
        public async Task<ResponseAPI<Message>> SendPhotoAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            bool hasSpoiler = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "has_spoiler", hasSpoiler.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendPhoto", "photo", fileName, fileData, postfields);
        }

        // https://core.telegram.org/bots/api#sendanimation
        public async Task<ResponseAPI<Message>> SendAnimationAsync(
            string chatId,
            string animation,
            //int duration = 0,
            //int width = 0,
            //int height = 0,
            //string thumbnail = "",
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            bool hasSpoiler = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "animation", animation },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "has_spoiler", hasSpoiler.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendAnimation", postfields);
        }

        // https://core.telegram.org/bots/api#sendanimation
        public async Task<ResponseAPI<Message>> SendAnimationAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            //int duration = 0,
            //int width = 0,
            //int height = 0,
            //string thumbnail = "",
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            bool hasSpoiler = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "has_spoiler", hasSpoiler.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendAnimation", "animation", fileName, fileData, postfields);
        }

        // https://core.telegram.org/bots/api#sendvideo
        public async Task<ResponseAPI<Message>> SendVideoAsync(
            string chatId,
            string video,
            //int duration = 0,
            //int width = 0,
            //int height = 0,
            //string thumbnail = "",
            string caption = "",
            string parseMode = "html",
            bool supportsStreaming = true,
            List<MessageEntity> captionEntities = null,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            bool hasSpoiler = false,
            ReplyMarkupType replyMarkup = null)
        {
           replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "video", video },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "supports_streaming", supportsStreaming.ToString() },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "has_spoiler", hasSpoiler.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendVideo", postfields);
        }


        // https://core.telegram.org/bots/api#sendvideo
        public async Task<ResponseAPI<Message>> SendVideoAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            //int duration = 0,
            //int width = 0,
            //int height = 0,
            //string thumbnail = "",
            string caption = "",
            string parseMode = "html",
            bool supportsStreaming = true,
            List<MessageEntity> captionEntities = null,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            bool hasSpoiler = false,
            ReplyMarkupType replyMarkup = null)
        {
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "supports_streaming", supportsStreaming.ToString() },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "has_spoiler", hasSpoiler.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendVideo", "video", fileName, fileData, postfields);
        }

        /**
         * size <= 8 MB
         * duration <= 1 minutes
         * ratio 1:1
         * resolution 640x640
         * https://core.telegram.org/bots/api#sendvideonote
         */
        public async Task<ResponseAPI<Message>> SendVideoNoteAsync(
            string chatId,
            string videoNote,
            //int duration = 0,
            //int length = 0,
            //string thumbnail = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "video_note", videoNote },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendVideoNote", postfields);
        }

        // https://core.telegram.org/bots/api#sendvideonote
        public async Task<ResponseAPI<Message>> SendVideoNoteAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            //int duration = 0,
            //int length = 0,
            //string thumbnail = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendVideoNote", "video_note", fileName, fileData, postfields);
        }

        // https://core.telegram.org/bots/api#sendaudio
        public async Task<ResponseAPI<Message>> SendAudioAsync(
            string chatId,
            string audio,
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            //int duration = 0,
            string performer = "",
            string title = "",
            //string thumbnail = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "audio", audio },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "performer", performer },
                { "title", title },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendAudio", postfields);
        }

        // https://core.telegram.org/bots/api#sendaudio
        public async Task<ResponseAPI<Message>> SendAudioAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            //int duration = 0,
            string performer = "",
            string title = "",
            //string thumbnail = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "performer", performer },
                { "title", title },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendAudio", "audio", fileName, fileData, postfields);
        }

        // https://core.telegram.org/bots/api#senddocument
        public async Task<ResponseAPI<Message>> SendDocumentAsync(
            string chatId,
            string document,
            //string thumbnail = "",
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            bool disableContentTypeDetection = false,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "document", document },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_content_type_detection", disableContentTypeDetection.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendDocument", postfields);
        }

        // https://core.telegram.org/bots/api#senddocument
        public async Task<ResponseAPI<Message>> SendDocumentAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            //string thumbnail = "",
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            bool disableContentTypeDetection = false,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "disable_content_type_detection", disableContentTypeDetection.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendDocument", "document", fileName, fileData, postfields);
        }

        // https://core.telegram.org/bots/api#sendvoice
        public async Task<ResponseAPI<Message>> SendVoiceAsync(
            string chatId,
            string voice,
            int messageThreadId = 0,
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            string duration = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "voice", voice },
                { "message_thread_id", messageThreadId.ToString() },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "duration", duration },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendVoice", postfields);
        }

        // https://core.telegram.org/bots/api#sendvoice
        public async Task<ResponseAPI<Message>> SendVoiceAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            int messageThreadId = 0,
            string caption = "",
            string parseMode = "html",
            List<MessageEntity> captionEntities = null,
            string duration = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "message_thread_id", messageThreadId.ToString() },
                { "caption", caption },
                { "parse_mode", parseMode },
                { "caption_entities", captionEntities.Serialize() },
                { "duration", duration },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendVoice", "voice", fileName, fileData, postfields);
        }

        // https://core.telegram.org/bots/api#sendlocation
        public async Task<ResponseAPI<Message>> SendLocationAsync(
            string chatId,
            double latitude,
            double longitude,
            int messageThreadId = 0,
            double horizontalAccuracy = 0,
            int livePeriod = 60,
            int heading = 1,
            int proximityAlertRadius = 1,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "latitude", latitude.ToString() },
                { "longitude", longitude.ToString() },
                { "message_thread_id", messageThreadId.ToString() },
                { "horizontal_accuracy", horizontalAccuracy.ToString() },
                { "live_period", livePeriod.ToString() },
                { "heading", heading.ToString() },
                { "proximity_alert_radius", proximityAlertRadius.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendLocation", postfields);
        }

        // https://core.telegram.org/bots/api#sendvenue
        public async Task<ResponseAPI<Message>> SendVenueAsync(
            string chatId,
            double latitude,
            double longitude,
            string title,
            string address,
            int messageThreadId = 0,
            string foursquareId = "",
            string foursquareType = "",
            string googlePlaceId = "",
            string googlePlaceType = "",
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "latitude", latitude.ToString() },
                { "longitude", longitude.ToString() },
                { "title", title },
                { "address", address },
                { "message_thread_id", messageThreadId.ToString() },
                { "foursquare_id", foursquareId },
                { "foursquare_type", foursquareType },
                { "google_place_id", googlePlaceId },
                { "google_place_type", googlePlaceType },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendVenue", postfields);
        }

        /**
         * https://core.telegram.org/bots/api#sendcontact
         * TODO: sendContact not work (wrong phone number specified)
         */
        public async Task<ResponseAPI<Message>> SendContactAsync(
            string chatId,
            string phoneNumber,
            string firstName,
            string lastName = "",
            string vcard = "",
            int messageThreadId = 0,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "phone_number", phoneNumber },
                { "first_name", firstName },
                { "last_name", lastName },
                { "vcard", vcard },
                { "message_thread_id", messageThreadId.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendContact", postfields);
        }

        // https://core.telegram.org/bots/api#sendpoll
        public async Task<ResponseAPI<Message>> SendPollAsync(
            string chatId,
            string question,
            List<string> options,
            int messageThreadId = 0,
            bool isAnonymous = false,
            string type = "",
            bool allowsMultipleAnswers = false,
            int correctOptionId = 0,
            string explanation = "",
            string explanationParseMode = "",
            List<MessageEntity> explanationEntities = null,
            int openPeriod = 0,
            int closeDate = 0,
            bool isClosed = false,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId.ToString() },
                { "question", question },
                { "options", options.Serialize() },
                { "message_thread_id", messageThreadId.ToString() },
                { "is_anonymous", isAnonymous.ToString() },
                { "type", type },
                { "allows_multiple_answers", allowsMultipleAnswers.ToString() },
                { "correct_option_id", correctOptionId.ToString() },
                { "explanation", explanation },
                { "explanation_parse_mode", explanationParseMode },
                { "explanation_entities", explanationEntities.Serialize() },
                { "open_period", openPeriod.ToString() },
                { "close_date", closeDate.ToString() },
                { "is_closed", isClosed.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendPoll", postfields);
        }

        // https://core.telegram.org/bots/api#senddice
        public async Task<ResponseAPI<Message>> SendDiceAsync(
            string chatId,
            string emoji = "",
            int messageThreadId = 0,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "emoji", emoji },
                { "message_thread_id", messageThreadId.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendDice", postfields);
        }

        // https://core.telegram.org/bots/api#sendsticker
        public async Task<ResponseAPI<Message>> SendStickerAsync(
            string chatId,
            string sticker,
            int messageThreadId = 0,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "sticker", sticker },
                { "message_thread_id", messageThreadId.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostAsync<Message>("sendSticker", postfields);
        }

        // https://core.telegram.org/bots/api#sendsticker
        public async Task<ResponseAPI<Message>> SendStickerAsync(
            string chatId,
            string fileName,
            byte[] fileData,
            int messageThreadId = 0,
            bool disableNotification = false,
            bool protectContent = false,
            string replyToMessageId = "",
            bool allowSendingWithoutReply = false,
            ReplyMarkupType replyMarkup = null)
        {
            replyMarkup ??= new ReplyMarkupType();
            
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "message_thread_id", messageThreadId.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "reply_to_message_id", replyToMessageId },
                { "allow_sending_without_reply", allowSendingWithoutReply.ToString() },
                { "reply_markup", replyMarkup.Serialize() }
            };

            return await PostMultipartAsync<Message>("sendSticker", "sticker", fileName, fileData, postfields);
        }

        // TODO: sendChatAction

        // https://core.telegram.org/bots/api#sendmediagroup
        public async Task<ResponseAPI<List<Message>>> SendMediaGroupAsync(
            string chatId,
            List<InputMedia> media,
            string businessConnectionId = "",
            int messageThreadId = 0,
            bool disableNotification = false,
            bool protectContent = false,
            string messageEffectId = "",
            ReplyParameters replyParameters = null)
        {
            replyParameters ??= new ReplyParameters();

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "media", media.Serialize() },
                { "business_connection_id", businessConnectionId },
                { "message_thread_id", messageThreadId.ToString() },
                { "disable_notification", disableNotification.ToString() },
                { "protect_content", protectContent.ToString() },
                { "message_effect_id", messageEffectId },
                { "reply_parameters", replyParameters.Serialize() }
            };

            return await PostAsync<List<Message>>("sendMediaGroup", postfields);
        }

        // https://core.telegram.org/bots/api#getuserprofilephotos
        public async Task<ResponseAPI<UserProfilePhotos>> GetUserProfilePhotosAsync(long userId, int offset = 0, int limit = 100)
        {
            var postfields = new Dictionary<string, string>
            {
                { "user_id", userId.ToString() },
                { "offset", offset.ToString() },
                { "limit", limit.ToString() }
            };

            return await PostAsync<UserProfilePhotos>("getUserProfilePhotos", postfields);
        }

        // https://core.telegram.org/bots/api#deletemessage
        public async Task<ResponseAPI<bool>> DeleteMessageAsync(string chatId, long messageId)
        {
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "message_id", messageId.ToString() }
            };

            return await PostAsync<bool>("deleteMessage", postfields);
        }

        // https://core.telegram.org/bots/api#deletemessages
        public async Task<ResponseAPI<bool>> DeleteMessagesAsync(string chatId, List<long> messageIds)
        {
            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId },
                { "message_ids", messageIds.Serialize() }
            };

            return await PostAsync<bool>("deleteMessages", postfields);
        }

        // https://core.telegram.org/bots/api#setwebhook
        public async Task<ResponseAPI<bool>> SetWebhookAsync(
            string url = "",
            int maxConnections = 100,
            List<string> allowedUpdates = null,
            bool dropPendingUpdates = true,
            string secretToken = "")
        {
            allowedUpdates ??= new List<string>();

            var postfields = new Dictionary<string, string>
            {
                { "url", url },
                //{ "certificate", "" },
                //{ "ip_address", "" },
                { "max_connections", maxConnections.ToString() },
                { "allowed_updates", allowedUpdates.Serialize() },
                { "drop_pending_updates", dropPendingUpdates.ToString() },
                { "secret_token", secretToken }
            };

            return await PostAsync<bool>("setWebhook", postfields);
        }

        // https://core.telegram.org/bots/api#getwebhookinfo
        public async Task<ResponseAPI<WebhookInfo>> GetWebhookInfoAsync()
        {
            return await GetAsync<WebhookInfo>("getWebhookInfo");
        }

        // https://core.telegram.org/bots/api#getme
        public async Task<ResponseAPI<User>> GetMeAsync()
        {
            return await GetAsync<User>("getMe");
        }

        // https://core.telegram.org/bots/api#logout
        public async Task<ResponseAPI<bool>> LogOutAsync()
        {
            return await GetAsync<bool>("logout");
        }

        // https://core.telegram.org/bots/api#getmycommands
        public async Task<ResponseAPI<List<BotCommand>>> GetMyCommandsAsync(
            BotCommandScope scope = null,
            string languageCode = "")
        {
            scope ??= new BotCommandScope.DefaultStruct();

            var postfields = new Dictionary<string, string>
            {
                { "scope", scope.Serialize() },
                { "language_code", languageCode }
            };

            return await PostAsync<List<BotCommand>>("getMyCommands", postfields);
        }

        // https://core.telegram.org/bots/api#setmycommands
        public async Task<ResponseAPI<bool>> SetMyCommandsAsync(
            List<BotCommand> commands,
            BotCommandScope scope = null,
            string languageCode = "")
        {
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }
            
            scope ??= new BotCommandScope.DefaultStruct();

            var postfields = new Dictionary<string, string>
            {
                { "commands", commands.Serialize() },
                { "scope", scope.Serialize() },
                { "language_code", languageCode }
            };

            return await PostAsync<bool>("setMyCommands", postfields);
        }

        // https://core.telegram.org/bots/api#deletemycommands
        public async Task<ResponseAPI<bool>> DeleteMyCommandsAsync(
            BotCommandScope scope = null,
            string languageCode = "")
        {
            scope ??= new BotCommandScope.DefaultStruct();

            var postfields = new Dictionary<string, string>
            {
                { "scope", scope.Serialize() },
                { "language_code", languageCode }
            };

            return await PostAsync<bool>("deleteMyCommands", postfields);
        }

        // https://core.telegram.org/bots/api#getmyname
        public async Task<ResponseAPI<BotName>> GetMyNameAsync(string languageCode = "")
        {
            var postfields = new Dictionary<string, string>
            {
                { "language_code", languageCode }
            };

            return await PostAsync<BotName>("getMyName", postfields);
        }

        // https://core.telegram.org/bots/api#setmyname
        public async Task<ResponseAPI<bool>> SetMyNameAsync(string name = "", string languageCode = "")
        {
            var postfields = new Dictionary<string, string>
            {
                { "name", name },
                { "language_code", languageCode }
            };

            return await PostAsync<bool>("setMyName", postfields);
        }

        // https://core.telegram.org/bots/api#getmydescription
        public async Task<ResponseAPI<BotDescription>> GetMyDescriptionAsync(string languageCode = "")
        {
            var postfields = new Dictionary<string, string>
            {
                { "language_code", languageCode }
            };

            return await PostAsync<BotDescription>("getMyDescription", postfields);
        }

        // https://core.telegram.org/bots/api#setmydescription
        public async Task<ResponseAPI<bool>> SetMyDescriptionAsync(string description = "", string languageCode = "")
        {
            var postfields = new Dictionary<string, string>
            {
                { "description", description },
                { "language_code", languageCode }
            };

            return await PostAsync<bool>("setMyDescription", postfields);
        }

        // https://core.telegram.org/bots/api#getmyshortdescription
        public async Task<ResponseAPI<BotShortDescription>> GetMyShortDescriptionAsync(string languageCode = "")
        {
            var postfields = new Dictionary<string, string>
            {
                { "language_code", languageCode }
            };

            return await PostAsync<BotShortDescription>("getMyShortDescription", postfields);
        }

        // https://core.telegram.org/bots/api#setmyshortdescription
        public async Task<ResponseAPI<bool>> SetMyShortDescriptionAsync(string shortDescription = "", string languageCode = "")
        {
            var postfields = new Dictionary<string, string>
            {
                { "short_description", shortDescription },
                { "language_code", languageCode }
            };

            return await PostAsync<bool>("setMyShortDescription", postfields);
        }

        // https://core.telegram.org/bots/api#getchatmenubutton
        public async Task<ResponseAPI<MenuButton>> GetChatMenuButtonAsync(long chatId = 0)
        {
            var postfields = new Dictionary<string, string>();
            if (chatId > 0)
            {
                postfields.Add("chat_id", chatId.ToString());
            }

            return await PostAsync<MenuButton>("getChatMenuButton", postfields);
        }

        // https://core.telegram.org/bots/api#setchatmenubutton
        public async Task<ResponseAPI<bool>> SetChatMenuButtonAsync(long chatId = 0, MenuButton menuButton = null)
        {
            menuButton ??= new MenuButton.DefaultStruct();

            var postfields = new Dictionary<string, string>
            {
                { "menu_button", menuButton.Serialize() }
            };

            if (chatId > 0)
            {
                postfields.Add("chat_id", chatId.ToString());
            }

            return await PostAsync<bool>("setChatMenuButton", postfields);
        }

        // https://core.telegram.org/bots/api#getchat
        public async Task<ResponseAPI<ChatFullInfo>> GetChatAsync(string chatId)
        {
            if (string.IsNullOrEmpty(chatId))
            {
                throw new ArgumentNullException(nameof(chatId));
            }

            var postfields = new Dictionary<string, string>
            {
                { "chat_id", chatId }
            };
            
            return await PostAsync<ChatFullInfo>("getChat", postfields);
        }

        private static ResponseAPI<T> ConvertToType<T>(string json)
        {
            return json.Deserialize<ResponseAPI<T>>();
        }
    }
}
