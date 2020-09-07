using System.Collections.Generic;
using Telegram.Bot;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class GetAdrress : IOption
    {
        public GetAdrress()
        {
            OptionFromOrigin = "Address";
            LabelQuestionCurrent = "Antes de continuar, comfirme seu endereço: \n ";
        }
    }
}