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
        }

        public IOption returnNewAction(string par)
        {
            try
            {
                return dict[par];
            }
            catch (System.Exception)
            {            
                return dict["O que deseja"];
                throw;
            }
            //return new WellcomeMessage();
        }
    }
}