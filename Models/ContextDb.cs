using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Data;
namespace Models
{
    public class ContextDb : DbContext
    {
        public DbSet<Pizza> pizzas { get; set; }
        public DbSet<Bebida> bebidas { get; set; }
        public DbSet<listIngredientes> listIngredientes { get; set; }
        public DbSet<Combo> combos { get; set; }
        public DbSet<Orders> orders { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=data.db");
    }    
}