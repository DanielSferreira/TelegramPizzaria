using System.Collections.Generic;

namespace TelegramPizzaria.Services.botOptions 
{
    public class ListBotOptions
    {
        public LabelWithOptions wellcome_message;
        public LabelWithOptions do_ower;
        public LabelWithOptions check_ower;
        
        public List<LabelWithOptions> getNextMessage = new List<LabelWithOptions>();

        public ListBotOptions()
        {
            getNextMessage.Add(new LabelWithOptions(
                "O que deseja",
                new List<string>() {
                    "Fazer um novo pedido",
                    "Conferir um pedido feito",
                },
                new List<int>() {
                    1,
                    2,
                }
            ));
            getNextMessage.Add(new LabelWithOptions(
                "Vamos fazer um pedido?, escolha o combo",
                new List<string>() {
                    "Combo pizza grande",
                    "Combo pizza bem grande",
                    "Combo pizza média",
                },
                new List<int>() {
                    0,
                    0,
                    0,
                }
            ));
            getNextMessage.Add(new LabelWithOptions(
                "Quer ver os pedidos feitos? \n *Não* tem problema",
                new List<string>() {
                    "Os pedidos em andamento",
                    "Os pedidos já entregues",
                },
                new List<int>() {
                    0,
                    0,
                }
            ));
        }
    }
}