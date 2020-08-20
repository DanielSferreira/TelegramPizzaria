using System;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Models;
using TelegramPizzaria._Services.botOptions;

namespace TelegramPizzaria._Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _config;

        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            client = new TelegramBotClient(_config.BotToken);
            client.OnMessage += maintence;
            client.StartReceiving();
        }
        public TelegramBotClient client { get; }

        public void maintence(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                new ListOptionGenerator(client).textOp(e);
            }
        }

        public string CloseApi()
        {
            client.StopReceiving();
            return "Api foi fechada";
        }
        public string OpenApi()
        {
            client.StartReceiving();
            return "Api foi Aberta";
        }
    }
}