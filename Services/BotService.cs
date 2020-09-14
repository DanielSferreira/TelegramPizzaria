using System;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Models;
using TelegramPizzaria.Services.botOptions;

namespace TelegramPizzaria.Services
{
    public class BotService : IBotService
    {
        public TelegramBotClient client { get; }

        public BotService(IOptions<BotConfiguration> config, TelegramBotClient tl )
        {
            client = tl;
            client.OnMessage += maintence;
            client.StartReceiving();
            listOptions = new ListOptionGenerator(client);
        }
        private ListOptionGenerator listOptions;
        public void maintence(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                //var listO = new ListOptionGenerator(client);
                listOptions.UpdateMessageEvent(e);
                listOptions.GatwayMessages();

            }
        }
        public string OpenApi()
        {
            client.StartReceiving();
            return "Api foi Aberta";
        }
        public string CloseApi()
        {
            client.StopReceiving();
            return "Api foi fechada";
        }
    }
}