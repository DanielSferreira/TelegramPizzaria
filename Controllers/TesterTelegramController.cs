using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramPizzaria._Services;
using TelegramPizzaria._Services.botOptions;

namespace TelegramPizzaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesterTelegramController : Controller
    {
        public readonly IUpdateService _updateService;
        public TesterTelegramController(IUpdateService up)
        {
            ListBotOptions tester = new ListBotOptions();
            Console.WriteLine(tester.First.LabelQuestionCurrent());
            _updateService = up;
        }
        [HttpGet("open")]
        public string Open() => _updateService.OpenApi();

        [HttpGet("close")]
        public string Close()=> _updateService.FecharApi();
        
    }
}