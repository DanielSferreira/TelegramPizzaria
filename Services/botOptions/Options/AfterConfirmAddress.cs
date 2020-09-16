using System.Collections.Generic;
namespace TelegramPizzaria.Services.botOptions.Options
{
    public class AfterConfirmAddress : IOption
    {
        public AfterConfirmAddress()
        {
            OptionFromOrigin = (int)ButtonsTypes.Mapa;
            LabelQuestionCurrent = "O Pedido vai ser entregue aqui:";
            OptionQuestionCurrent = new List<string>() {
                    "Tudo Bem!",
                    "Não. Voltar por inicio",
            };
        }
    }
}