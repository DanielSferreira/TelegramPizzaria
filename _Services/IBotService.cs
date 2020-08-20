
using Telegram.Bot;
namespace TelegramPizzaria._Services 
{
    public interface IBotService
    {
        TelegramBotClient client {get;}
        public string CloseApi();
        public string OpenApi();
    }
}