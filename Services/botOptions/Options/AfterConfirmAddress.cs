using TelegramPizzaria.Services.botOptions.Options;
namespace TelegramPizzaria.Services.botOptions.Options
{
    public class AfterConfirmAddress : IOption
    {
        public AfterConfirmAddress()
        {
            OptionFromOrigin = (int)ButtonsTypes.Mapa;
            LabelQuestionCurrent = "O Pedido vai ser entregue aqui:";
        }
    }
}