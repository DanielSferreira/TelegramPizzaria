using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TelegramPizzaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramAPIController : Controller
    {
        public TelegramAPIController()
        {
            var botClient = new TelegramBotClient("1379984187:AAF4ib9EzgcVSMfsiPWRWWa2x93-775x_RU");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
        }
        [HttpGet("listar")]
        public string Index()
        {
            return "View()";
        }


        [HttpGet("Wellcome")]
        public string Wellcome()
        {
            return "View()";
        }
        [HttpGet]
        public string Get()
        {
            return "View()";
        }
    }
}