using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Models;

namespace TelegramPizzaria._Services.botOptions
{
    public class ListOptionGenerator
    {

        private readonly TelegramBotClient client;

        public ListOptionGenerator(TelegramBotClient _client)
        {
            client = _client;
        }

        private ListBotOptions teste = new ListBotOptions();
        private void getOptionAndSetAnswer(string option)
        {
            var teste = new ListBotOptions();
        }

        public async void textOp(Telegram.Bot.Args.MessageEventArgs e)
        {

            var kUp = new List<KeyboardButton>();

            foreach (var item in teste.First.OptionQuestionCurrent())
                kUp.Add(new KeyboardButton(item.ToString()));
            
             var buttonOption = new ReplyKeyboardMarkup(
                new KeyboardButton[][]
                {
                    kUp.ToArray()
                },
                resizeKeyboard: true
            );
            await client.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: teste.First.LabelQuestionCurrent(),
                replyMarkup: buttonOption
            );
        }
    }
}