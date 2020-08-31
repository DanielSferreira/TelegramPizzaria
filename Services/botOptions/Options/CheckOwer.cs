using System.Collections.Generic;
using BotOptions.Options;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class CheckOwer : IOption
    {
        public CheckOwer()
        {
            OptionFromOrigin = "Fazer um novo pedido";
            LabelQuestionCurrent =  "Quer ver os pedidos feitos? \n <b>Não</b> tem problema";
            //OptionQuestionCurrent = getCombos();
            OptionQuestionCurrent = new List<string>() {
                    "Os pedidos em andamento",
                    "Os pedidos já entregues",
            };
        }
    }
}