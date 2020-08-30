namespace Models.Data
{
    public class Combo : Entity
    {
        public int ComboId {get;set;}
        public string NomeCombo {get;set;}
        public string Descricao {get;set;}
        public Pizza Pizza {get;set;}
        public Bebida Bebida {get;set;}
    }
}