using System.Collections.Generic;
using Models;
using System.Linq;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class LoadOrderCompleted : IOption
    {
        private ContextDb  db;
        public LoadOrderCompleted()
        {
            db = new ContextDb();
            OptionFromOrigin = (int)ButtonsTypes.SemBotoes;
            LabelQuestionCurrent = getCombos();
            OptionQuestionCurrent = new List<string>() {
                "Inicio"
            };
        }
        public string getCombos()
        { 
            string stringCombos = "";
            var ListCombos = db.ordersCompleted.Select(x => "nº: " + x.OrdersCompletedId + " - " + x.ComboNameReference + "\n").ToList();
            
            foreach (var item in ListCombos)
                stringCombos = string.Concat(stringCombos, item);
            
            return stringCombos;
        }
    }
}