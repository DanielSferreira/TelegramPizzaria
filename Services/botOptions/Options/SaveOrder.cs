namespace TelegramPizzaria.Services.botOptions.Options
{
    public class SaveOrder : IOption
    {
        public SaveOrder()
        {
            OptionFromOrigin = (int)ButtonsTypes.SemBotoes;
            LabelQuestionCurrent = "Pedido Feito com sucesso! Vamos agora voltar para o inicio";
        }
       
    }
}