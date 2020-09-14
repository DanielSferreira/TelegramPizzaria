using System.Collections.Generic;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class GetAdrress : IOption
    {
        public GetAdrress()
        {
            OptionFromOrigin = (int)ButtonsTypes.BotoesAdrress;
            LabelQuestionCurrent = "O endereço está correto?";
            OptionQuestionCurrent = new List<string>() {
                    "Sim.",
                    "Não.",
            };  
        }
    }
}