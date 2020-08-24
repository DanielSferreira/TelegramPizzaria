using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Data;
namespace Models
{
    public class ContextDb : DbContext
    {
        public DbSet<Pizza> pizzas { get; set; }
        public DbSet<listIngredientes> listIngredientes { get; set; }
        public DbSet<Combo> combos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=C:\\Users\\DAN\\Documents\\projetos\\Dotnet\\TelegramPizzaria\\data.db");
    }    
}