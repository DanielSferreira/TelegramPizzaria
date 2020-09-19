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
            dict.Add("Não.", new RequestLocation());
            dict.Add("Tudo Bem!", new SaveOrder());
            dict.Add("Os pedidos em andamento", new LoadOrder());
            dict.Add("Os pedidos já entregues", new LoadOrderCompleted());
        }

        public IOption returnNewAction(string par)
        {
            
            if(par.StartsWith("Combo: ") == true) return dict["Combo"];
            
            try
            { return dict[par]; }
            catch (System.Exception)
            {            
                return dict["O que deseja"];
                throw;
            }
        }
        public IOption returnNewAction(string par, int args)
        {
            dict.Add("nº: ", new LoadOrderDetails(args));
            dict.Add("removerPedido", new RemoveOrderDetails(args));
            return dict[par];
            
        }
    }
}