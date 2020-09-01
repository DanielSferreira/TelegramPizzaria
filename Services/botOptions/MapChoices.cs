using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Services.botOptions;
using TelegramPizzaria.Services.botOptions.Options;
// await client.SendLocationAsync(
//     chatId: e.Message.Chat,    
//     latitude: (float)-22.7398134,
//     longitude: (float)-43.3893701
// );
namespace TelegramPizzaria.Services.AdrressForOrder
{
    public class MapChoices
    {
        private IOption DictOption;
        public void FindInDict(string option)
            => DictOption = new DictionaryBot().returnNewAction(option);

        public string labelCurrentDict()
            => DictOption.LabelQuestionCurrent;

        public KeyboardButton[][] getButtons()
        {
            var kUp = new List<KeyboardButton[]>();
            foreach (var item in DictOption.OptionQuestionCurrent)
                kUp.Add(new KeyboardButton[] { item.ToString() });
            return kUp.ToArray();
        }
    }
}