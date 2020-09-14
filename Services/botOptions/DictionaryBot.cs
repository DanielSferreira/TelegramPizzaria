using System.Collections.Generic;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class DictionaryBot
    {
        private Dictionary<string, IOption> dict;
        public DictionaryBot()
        {
            dict = new Dictionary<string, IOption>();

            dict.Add("O que deseja", new WellcomeMessage());
            dict.Add("Fazer um novo pedido", new MakeOrder());
            dict.Add("Conferir um pedido feito", new CheckOwer());
            dict.Add("Combo", new RequestLocation());
            dict.Add("SLG", new RequestCity());
            dict.Add("city", new RequestAddress());
            dict.Add("Adrress", new GetAdrress());
            dict.Add("Sim.", new AfterConfirmAddress());
            dict.Add("Não.", new CheckOwer());
        }

        public IOption returnNewAction(string par)
        {
            
            if(par.Contains("Combo: ") == true) return dict["Combo"];
            
            try
            { return dict[par]; }
            catch (System.Exception)
            {            
                return dict["O que deseja"];
                throw;
            }
        }
    }
}