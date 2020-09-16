using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramPizzaria.Services.botOptions.Options;

namespace TelegramPizzaria.Services.AdrressForOrder
{
    public class MapChoices
    {
        private IOption DictOption;
        public void FindInDict(string option)
            => DictOption = new DictionaryBot().returnNewAction(option);
        public void FindInDict(string option, int args)
            => DictOption = new DictionaryBot().returnNewAction(option, args);

        public string labelCurrentDict()
            => DictOption.LabelQuestionCurrent;

        public int TypeMessage()
            => DictOption.OptionFromOrigin;

        public KeyboardButton[][] getButtons()
        {
            var kUp = new List<KeyboardButton[]>();
            foreach (var item in DictOption.OptionQuestionCurrent)
                kUp.Add(new KeyboardButton[] { item.ToString() });
            return kUp.ToArray();
        }
    }
}