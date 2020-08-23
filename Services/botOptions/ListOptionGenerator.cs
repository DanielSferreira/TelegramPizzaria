using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Models;

namespace TelegramPizzaria.Services.botOptions
{
    public class ListOptionGenerator
    {

        private readonly TelegramBotClient client;

        public ListOptionGenerator(TelegramBotClient _client)
        {
            client = _client;
        }

        private ListBotOptions OptionList = new ListBotOptions();
        private int OptionListNumInList = 0;

        private void getOptionAndSetAnswer(string option)
        {
            var lista = OptionList.getNextMessage[OptionListNumInList];
            var listaOption = lista.OptionQuestionCurrent();
            int res = listaOption.IndexOf(option);

            if(listaOption.Find(i => i == option) == "")
                return;
            else
            {
                if(res >= 0){
                    int nextIntList = lista.Next(res);
                    OptionListNumInList = nextIntList; 
                }
            }
        } 

        public async void textOp(Telegram.Bot.Args.MessageEventArgs e)
        {
            getOptionAndSetAnswer(e.Message.Text);

            var kUp = new List<KeyboardButton[]>();
            foreach (var item in OptionList.getNextMessage[OptionListNumInList].OptionQuestionCurrent())
                kUp.Add(new KeyboardButton[]{item.ToString()});

            await client.SendLocationAsync(
                chatId: e.Message.Chat,    
                latitude: (float)-22.7398134,
                longitude: (float)-43.3893701
            );
            // await client.SendTextMessageAsync(
            //     chatId: e.Message.Chat,
            //     text: OptionList.getNextMessage[OptionListNumInList].LabelQuestionCurrent(),
            //     replyMarkup: new ReplyKeyboardMarkup(
            //         kUp.ToArray(),
            //         resizeKeyboard: true
            //     )
            // );
        }
    }
}