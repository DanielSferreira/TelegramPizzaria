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
        [HttpGet("newPizza")]
        public IActionResult newPizz2a()
        {
            var pizza =  db.pizzas.Add(
                new Pizza() {
                    NomePizza = "Parmegiana",
                    Descricao = "Uma Pizza de Parmegiana",
                    Ingredientes = new List<listIngredientes>() {
                        new listIngredientes() { item = "Queijo" },
                        new listIngredientes() { item = "Oregano" },
                        new listIngredientes() { item = "Presunto" },
                        new listIngredientes() { item = "Molho de manjericão" }
                    }
                }
            );
            db.SaveChanges();
            var p = db.pizzas
                .Where(x => x.PizzaId > 0)
                .First();
            return Json(p);
        }
        [HttpGet("newBebida")]
        public IActionResult newPizz3a()
        {
            var bebidas =  db.bebidas.Add(
                new Bebida() {
                    NomeBebida = "Coca",
                    Descricao = "Uma Coquinha gelada",
                    
                }
            );
            db.SaveChanges();
            var p = db.bebidas
                .Where(x => x.BebidaId > 0)
                .First();
            return Json(p);
        }
        [HttpGet("novoCombo")]
        public IActionResult novoCombo()
        {
            var p = db.pizzas
                .Where(x => x.PizzaId > 0)
                .First();
            var b = db.bebidas
                .Where(x => x.BebidaId > 0)
                .First();
            var combo = db.combos.Add(
                new Combo() {
                    NomeCombo = $"{p.NomePizza} com {b.NomeBebida}",
                    Descricao = "Muita Pizza com uma Antartica geladinha",
                    Pizza = p,
                    Bebida = b 
                }
            );
            // db.SaveChanges();
            var c = db.combos.Where(a => a.ComboId ==5).First();
            return Json(c);
        }
        [HttpGet("getCombo")]
        public IActionResult abc()
        {
            var combo = db.combos.Where(x => x.ComboId > 0);
            System.Console.WriteLine(combo.ToString());
            return Json(combo);
        }
    }
}