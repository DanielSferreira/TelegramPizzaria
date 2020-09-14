
namespace TelegramPizzaria.Services.botOptions.Options
{
    public class RequestAddress : IOption
    {
        public RequestAddress()
        {
            OptionFromOrigin = (int)ButtonsTypes.Location;
            LabelQuestionCurrent = "Digite agora o nome da sua rua <b>SEM</b> o número da casa";
        }
    }
    public class RequestLocation : IOption
    {
        public RequestLocation()
        {
            OptionFromOrigin = (int)ButtonsTypes.Location;
            LabelQuestionCurrent = "Para entrega, digite a sigla do seu estado";
        }
    }
    public class RequestCity : IOption
    {
        public RequestCity()
        {
            OptionFromOrigin = (int)ButtonsTypes.Location;
            LabelQuestionCurrent = "Agora digite sua cidade";
        }
    }
}