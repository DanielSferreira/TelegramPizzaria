using System.Collections.Generic;
using Telegram.Bot;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class RequestAddress : IOption
    {
        public RequestAddress()
        {
            OptionFromOrigin = "Sem Botoes";
            LabelQuestionCurrent = "Beleza, escolheu o combo. agora digita o endereço aqui";
            //OptionQuestionCurrent = new List<string>() {"a"}; 
        }
    }
}