using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramPizzaria._Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
        string FecharApi();
        string OpenApi();
    }
}