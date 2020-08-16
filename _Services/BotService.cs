using Microsoft.Extensions.Options;
using MihaZupan;
using Telegram.Bot;
using TelegramPizzaria.Models;

namespace TelegramPizzaria._Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _config;

        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            // use proxy if configured in appsettings.*.json
            client = new TelegramBotClient(_config.BotToken);
            // client = string.IsNullOrEmpty(_config.Socks5Host)
            //     ? new TelegramBotClient(_config.BotToken)
            //     : new TelegramBotClient(
            //         _config.BotToken,
            //         new HttpToSocks5Proxy(_config.Socks5Host, _config.Socks5Port));
        }
        public TelegramBotClient client { get; } 
    }
}