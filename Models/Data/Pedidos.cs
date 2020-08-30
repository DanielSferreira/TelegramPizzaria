namespace Models.Data
{
    public class Pedido : Entity
    {
        public int PedidoId {get;set;}
        public string NomeCliente {get;set;}
        public string Endereço {get;set;}
        public Combo Combo {get;set;}
    }
}