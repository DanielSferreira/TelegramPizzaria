using System;
using System.Collections.Generic;
using Models;
using Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TelegramPizzaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteDBController : Controller
    {
        private ContextDb  db;
        public TesteDBController()
        {
            db = new ContextDb();
            Console.WriteLine("Finalizando");
        }
        
        [HttpGet("banco")]
        public string Open()
        {
            return "O banco vai Abrir";
        }
        [HttpGet("abc/{id}")]
        public IActionResult abc(int id)
        {
            var pizza = db.pizzas
                    .Where(e => e.PizzaId == id)
                    .Single();

            pizza.Ingredientes = db.pizzas
                    .Where(e => e.PizzaId == id)
                    .Select(e => e.Ingredientes)
                    .Single();
            Console.WriteLine($"Nome é: {pizza.NomePizza}");
            return Json(pizza);
        }
    }
}