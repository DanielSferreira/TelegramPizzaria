using System.Collections.Generic;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class WellcomeMessage : IOption
    {
        public WellcomeMessage()
        {
            OptionFromOrigin = "first";
            LabelQuestionCurrent = "O que Deseja?";
            OptionQuestionCurrent = new List<string>() {
                    "Fazer um novo pedido",
                    "Conferir um pedido feito",
            };
        }
    }
}