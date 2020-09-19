using Microsoft.AspNetCore.Mvc;
using TelegramPizzaria.Services;

namespace TelegramPizzaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramAPIController : Controller
    {
        public readonly IUpdateService _updateService;
        
        public TelegramAPIController(IUpdateService up) => _updateService = up;        
        
        [HttpGet("open")]
        public string Open() => _updateService.OpenApi();

        [HttpGet("close")]
        public string Close()=> _updateService.FecharApi();
        
    }
}