using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Data
namespace Models
{
    public class ContextDb : DBContext
    {
        public DbSet<Pizzas> pizzas { get; set; }
        public DbSet<Combos> combos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=data.db");
    }    
}