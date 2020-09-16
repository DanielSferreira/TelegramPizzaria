using System.Collections.Generic;
using Models;
using System.Linq;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class LoadOrderDetails : IOption
    {
        private ContextDb db;
        public LoadOrderDetails(double id)
        {
            db = new ContextDb();
            OptionFromOrigin = (int)ButtonsTypes.Botoes;
            LabelQuestionCurrent = getCombos(id);
        }
        public string getCombos(double id)
        {
            try
            {
                var x = db.orders.Where(xi => xi.OrdersId == id).FirstOrDefault();
                return $"<b>Número Pedido:</b> {x.UserID}\n<b>Combo:</b>{x.ComboNameReference}\n<b>Data Pedido:</b> {x.DateOrder.ToString()}\n<b>Endereço:</b> {x.Address}";
            }
            catch (System.Exception)
            {
                return "!Erro ao buscar";
                throw;
            }


        }
    }
}