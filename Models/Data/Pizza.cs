using System.Collections.Generic;
namespace Models.Data
{
    public class Pizza : Entity
    {
        public int PizzaId {get;set;}
        public string NomePizza {get;set;}
        public string Descricao {get;set;}
        public List<listIngredientes> Ingredientes {get;set;} = new List<listIngredientes>();
    }
    public class listIngredientes : Entity
    {
        public int Id {get;set;}
        public string item {get;set;}
    }
}