using System.Collections.Generic;
using BotOptions.Options;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class DictionaryBot
    {
        private Dictionary<string, IOption> dict;
        public DictionaryBot()
        {
            dict = new Dictionary<string, IOption>();

            dict.Add("O que deseja", new WellcomeMessage());
            dict.Add("Vamos fazer um pedido?, escolha o combo", new MakeOrder());
            dict.Add("Quer ver os pedidos feitos? \n <b>Não</b> tem problema", new CheckOwer());
        }

        public IOption returnNewAction(string par)
        {

            try
            {
            System.Console.WriteLine($"Tentei Aqui: {par} ");
                return dict[par];
            }
            catch (System.Exception)
            {            System.Console.WriteLine("Mas Cai aqui");
                return dict["O que deseja"];
                throw;
            }
            //return new WellcomeMessage();
        }
    }
}