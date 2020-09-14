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
            OptionFromOrigin = (int)ButtonsTypes.Botoes;
            LabelQuestionCurrent = "Vamos fazer um pedido?, \n Escolha o combo";
            OptionQuestionCurrent = getCombos();
        }
        public List<string> getCombos()
        { 
            var combo = db.combos.Select(x => x.NomeCombo).ToList();
            return combo;
        }
    }
}