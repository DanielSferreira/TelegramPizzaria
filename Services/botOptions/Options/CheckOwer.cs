using System.Collections.Generic;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class CheckOwer : IOption
    {
        public CheckOwer()
        {
            OptionFromOrigin = "botoes";
            LabelQuestionCurrent = "Quer ver os pedidos feitos? \n <b>Não</b> tem problema";
            //OptionQuestionCurrent = getCombos();
            OptionQuestionCurrent = new List<string>() {
                    "Os pedidos em andamento",
                    "Os pedidos já entregues",
            };
        }
    }
}