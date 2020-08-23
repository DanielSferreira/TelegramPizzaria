using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramPizzaria.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
        string FecharApi();
        string OpenApi();
    }
}