using System.Collections.Generic;
using Models;
using System.Linq;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class LoadOrder : IOption
    {
        private ContextDb  db;
        public LoadOrder()
        {
            db = new ContextDb();
            OptionFromOrigin = (int)ButtonsTypes.Botoes;
            LabelQuestionCurrent = "Pedidos feitos";
            OptionQuestionCurrent = getCombos();
        }
        public List<string> getCombos()
        { 
            var combo = db.orders.Select(x => "nº: " + x.OrdersId + " - " + x.ComboNameReference).ToList();
            return combo;
        }
    }
}