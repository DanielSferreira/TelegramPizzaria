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

        private ListBotOptions OptionList = new ListBotOptions();
        private void getOptionAndSetAnswer(string option)
        {
            string res = OptionList.wellcome_message.OptionQuestionCurrent().Find(i => i == option);
            Console.WriteLine($"A resposta {res}");
        } 

        public async void textOp(Telegram.Bot.Args.MessageEventArgs e)
        {
            getOptionAndSetAnswer(e.Message.Text);
            var kUp = new List<KeyboardButton[]>();

            foreach (var item in OptionList.wellcome_message.OptionQuestionCurrent())
                kUp.Add(new KeyboardButton[]{item.ToString()});

            await client.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: OptionList.wellcome_message.LabelQuestionCurrent(),
                replyMarkup: new ReplyKeyboardMarkup(
                    kUp.ToArray(),
                    resizeKeyboard: true
                )
            );
        }
    }
}