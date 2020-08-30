using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Models;
using TelegramPizzaria.Services.botOptions;
// await client.SendLocationAsync(
            //     chatId: e.Message.Chat,    
            //     latitude: (float)-22.7398134,
            //     longitude: (float)-43.3893701
            // );
namespace TelegramPizzaria.Services.AdrressForOrder
{
    public class MapChoices 
    {
        private ListBotOptions OptionList = new ListBotOptions();
        private int OptionListNumInList = 0;
        
        public void FindOptions(string option)
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
        private List<KeyboardButton[]> kUp = new List<KeyboardButton[]>();
        public List<KeyboardButton[]> generateButtons()
        {
            kUp = new List<KeyboardButton[]>();
            foreach (var item in OptionList.getNextMessage[OptionListNumInList].OptionQuestionCurrent())
                kUp.Add(new KeyboardButton[]{item.ToString()});
            
            return kUp;
        }

        public string labelCurrent()
        {
            return OptionList.getNextMessage[OptionListNumInList].LabelQuestionCurrent();
        }

        public KeyboardButton[][] getButtons()
        {
            return generateButtons().ToArray();
        }
    }
}