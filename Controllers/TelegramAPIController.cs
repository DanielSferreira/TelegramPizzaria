using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramPizzaria.Services;
using TelegramPizzaria.Services.botOptions;

using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;


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
            _updateService = up;
        }
        
        [HttpGet("open")]
        public string Open() => _updateService.OpenApi();

        [HttpGet("close")]
        public string Close()=> _updateService.FecharApi();
        
        [HttpGet("getEndereco")]
        public IActionResult getLagiLongitudeByCEP()
        {
            var clt = new RestClient("https://www.cepaberto.com/api/v3/");
            //var request = new RestRequest("address")
            var request = new RestRequest("address")
                .AddHeader("Authorization", "Token token=e715441276928dba38f999dc19d28666")
                .AddParameter("estado", "RJ")
                .AddParameter("cidade", "Belford Roxo")
                .AddParameter("logradouro", "rua apiacas");
            var res = clt.Get(request);
            var a = JsonConvert.DeserializeObject(res.Content);

            return Json(a);
        }
        
    }
        public class Cidade {
            public int ddd { get; set; } 
            public string ibge { get; set; } 
            public string nome { get; set; } 
        }
        public class Estado {
            public string sigla { get; set; } 
        }
        public class Localizacao {
            public double altitude { get; set; } 
            public string cep { get; set; } 
            public string latitude { get; set; } 
            public string longitude { get; set; } 
            public Cidade cidade { get; set; } 
            public Estado estado { get; set; } 
        }
}