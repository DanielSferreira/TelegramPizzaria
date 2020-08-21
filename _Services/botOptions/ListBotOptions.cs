using System.Collections.Generic;

namespace TelegramPizzaria._Services.botOptions 
{
    public class ListBotOptions
    {
        
        public LabelWithOptions wellcome_message = new LabelWithOptions("O que deseja",new List<string>() {
            "Fazer um novo pedido",
            "Conferir um pedido feito",
        });

        public LabelWithOptions do_ower = new LabelWithOptions("Para Fazer o Pedido", new List<string>(){
            "Escolher um combo 1",
            "Escolher um combo 2",
            "Escolher um combo 3",
            "Escolher um combo 4"
        });
    }
}