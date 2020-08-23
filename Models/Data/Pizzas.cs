using System.Collections.Generic;
namespace Models.Data
{
    class Pizza
    {
        public int PizzaId {get;set}
        public string NomePizza {get;set}
        public string Descricao {get;set}
        public List<string> Ingredintes {get;set}
    }
}