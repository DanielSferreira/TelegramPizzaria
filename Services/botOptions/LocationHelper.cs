using System;

namespace TelegramPizzaria.Services.botOptions
{
    public class LocationHelper
    {
        
        public string endereco = "";
        public string slg = "";
        public string city = "";

        private string[] slgs = new string[] {
            "AC", "AL", "AP", "AM", "BA",
            "CE", "DF", "ES", "GO", "MA",
            "MT", "MS", "MG", "PA", "PB",
            "PR", "PE", "PI", "RJ", "RN",
            "RS", "RO", "RR", "SC", "SP",
            "SE", "TO"
        };

        private string FindSlg(string a)
        {
            foreach (var item in slgs)
                if (a.StartsWith(item) && a.EndsWith(item)) return item;
            
            return "erro";
        }

        bool CityBool = false;
        bool AddressBool = false;
        public string LocationSequenceHelper(Telegram.Bot.Args.MessageEventArgs MessagesE)
        {
            
                        
            if (FindSlg(MessagesE.Message.Text) != "erro")
            {
                slg = MessagesE.Message.Text;
                CityBool = true;
                return "SLG";
            }
            else if (CityBool == true)
            {
                city = MessagesE.Message.Text;
                CityBool = false;
                AddressBool = true;
                return "city";
            }
            else if (AddressBool == true)
            {
                endereco = MessagesE.Message.Text;
                AddressBool = false;
                return "Adrress";
            }
            
           return MessagesE.Message.Text;
        }
    }
}