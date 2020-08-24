using System.Collections.Generic;
namespace Models.Data
{
    public class Combo : Entity
    {
        public int ComboId {get;set;}
        public string NomeCombo {get;set;}
        public string Descricao {get;set;}
        public List<Entity> ItemsCombo {get;} = new List<Entity>();
    }
}