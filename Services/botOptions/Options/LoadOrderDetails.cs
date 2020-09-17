using System.Collections.Generic;
using Models;
using System.Linq;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class LoadOrderDetails : IOption
    {
        private ContextDb db;
        private int orders;
        public LoadOrderDetails(int id)
        {
            db = new ContextDb();
            OptionFromOrigin = (int)ButtonsTypes.Botoes;
            LabelQuestionCurrent = MessageComboText(id);
            OptionQuestionCurrent = new List<string>() {
                $"{orders} Já peguei, esse Pedido!",
                "Inicio"
            };
        }
        public string MessageComboText(int id)
        {
            try
            {
                var x = db.orders.Where(xi => xi.OrdersId == id).FirstOrDefault();
                this.orders  = x.OrdersId;
                return $"<b>Número do Pedido:</b> {x.OrdersId}\n<b>Combo:</b>{x.ComboNameReference}\n<b>Data Pedido:</b> {x.DateOrder.ToString()}\n<b>Endereço:</b> {x.Address}";
            }
            catch (System.Exception)
            {
                return "!Erro ao buscar";
                throw;
            }


        }
    }
}