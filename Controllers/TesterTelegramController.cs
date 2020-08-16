using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramPizzaria._Services;

namespace TelegramPizzaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesterTelegramController : Controller
    {
        public readonly IUpdateService _updateService;
        public TesterTelegramController(IUpdateService up)
        {
            Console.WriteLine("AAAAA");
            _updateService = up;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update up)
        {
            await _updateService.EchoAsync(up);
            return Ok();
        }
        [HttpGet("texto")]
        public string Texto()
        {
            return "Está Funcionando";
        }
    }
}