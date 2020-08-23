using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramPizzaria.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;

        public UpdateService(IBotService bs, ILogger<UpdateService> l)
        {
            _botService = bs;
            _logger = l;
        }
        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;
            var message = update.Message;
            _logger.LogInformation("Received Message from {0}", message.Chat.Id);
            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    await _botService.client.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;

                case MessageType.Photo:
                    // Download Photo
                    var fileId = message.Photo.LastOrDefault()?.FileId;
                    var file = await _botService.client.GetFileAsync(fileId);

                    var filename = file.FileId + "." + file.FilePath.Split('.').Last();
                    using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                    {
                        await _botService.client.DownloadFileAsync(file.FilePath, saveImageStream);
                    }

                    await _botService.client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
                    break;
            }
        }

        public string FecharApi()
        {
            return _botService.CloseApi();
        }
        public string OpenApi()
        {
            return _botService.OpenApi();
        }
    }
}