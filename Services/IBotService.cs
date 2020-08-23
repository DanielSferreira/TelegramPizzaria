
using Telegram.Bot;
namespace TelegramPizzaria.Services 
{
    public interface IBotService
    {
        TelegramBotClient client {get;}
        public string CloseApi();
        public string OpenApi();
    }
}