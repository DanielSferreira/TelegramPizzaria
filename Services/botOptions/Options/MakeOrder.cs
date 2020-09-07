using System.Collections.Generic;
using Models;
using System.Linq;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class MakeOrder : IOption
    {
        private ContextDb  db;
        public MakeOrder()
        {
            db = new ContextDb();
            OptionFromOrigin = "botoes";
            LabelQuestionCurrent = "Vamos fazer um pedido?, escolha o combo";
            OptionQuestionCurrent = getCombos();
        }
        public List<string> getCombos()
        { 
            var combo = db.combos.Select(x => x.NomeCombo).ToList();
            // System.Console.WriteLine(combo.ToString());
            return combo;
        }
    }
}