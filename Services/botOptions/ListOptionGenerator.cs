using Telegram.Bot;
using TelegramPizzaria.Services.AdrressForOrder;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using TelegramPizzaria.Services.botOptions.Options;
using System;
using Services.MakeOrder;

namespace TelegramPizzaria.Services.botOptions
{
    public class ListOptionGenerator
    {

        private readonly TelegramBotClient client;
        private MapChoices opt;
        DateTime timeComparer = new DateTime();

        LocationHelper H_Location;
        public ListOptionGenerator(TelegramBotClient _client)
        {
            client = _client;
            opt = new MapChoices();
            H_Location = new LocationHelper();
        }

        private Telegram.Bot.Args.MessageEventArgs MessagesE;

        public void UpdateMessageEvent(Telegram.Bot.Args.MessageEventArgs e)
            => MessagesE = e;


        private OrderCombo orderCombo;
        public void MakeOrderCombo()
        {
            if (MessagesE.Message.Text.Contains("Combo: ") == true)
            {
                orderCombo = new OrderCombo();
                orderCombo.combo_name = MessagesE.Message.Text;
                orderCombo.id_user = MessagesE.Message.MessageId;
            }
            if (MessagesE.Message.Text.Contains("Tudo Bem!") == true)
            {
                orderCombo.Address = $"{H_Location.endereco}, {H_Location.city} - {H_Location.slg}";
                orderCombo.Data = System.DateTime.Now;
                orderCombo.addNewOrderCombo();
            }
            if (MessagesE.Message.Text.StartsWith("nº: ") == true)
            {
                int beginS = MessagesE.Message.Text.IndexOf(":");
                var tex = MessagesE.Message.Text.Substring(MessagesE.Message.Text.IndexOf(":")+2).Split(" ");
                opt.FindInDict("nº: ",System.Convert.ToInt32(tex[0]));
            }
            if (MessagesE.Message.Text.EndsWith("Já peguei, esse Pedido!"))
            {
                string[] tex = MessagesE.Message.Text.Split(" ");
                opt.FindInDict("removerPedido",System.Convert.ToInt32(tex[0]));
            }

        }
        public void GatwayMessages()
        {
                System.Console.WriteLine(MessagesE.Message.Text);
            if (timeComparer == MessagesE.Message.Date)
                return;

            timeComparer = MessagesE.Message.Date;
            opt.FindInDict(H_Location.LocationSequenceHelper(MessagesE));
            MakeOrderCombo();

            switch (opt.TypeMessage())
            {
                case (int)ButtonsTypes.Botoes:
                    MessageWithOptions();
                    break;
                case (int)ButtonsTypes.SemBotoes:
                    Message();
                    break;
                case (int)ButtonsTypes.Location:
                    Message();
                    break;
                case (int)ButtonsTypes.BotoesAdrress:
                    MessageAddress();
                    break;
                case (int)ButtonsTypes.Mapa:
                    MapAddress();
                    break;
            }
        }
        public async void MessageWithOptions()
        {
            await client.SendTextMessageAsync(
                chatId: MessagesE.Message.Chat,
                parseMode: ParseMode.Html,
                text: opt.labelCurrentDict(),
                replyMarkup: new ReplyKeyboardMarkup(
                    opt.getButtons(),
                    resizeKeyboard: true
                )
            );
        }
        public async void Message()
        {
            await client.SendTextMessageAsync(
                    chatId: MessagesE.Message.Chat,
                    parseMode: ParseMode.Html,
                    text: opt.labelCurrentDict(),
                    replyMarkup: new ReplyKeyboardRemove()
            );
        }
        public async void MessageAddress()
        {
            await client.SendTextMessageAsync(
                chatId: MessagesE.Message.Chat,
                parseMode: ParseMode.Html,
                text: $"<b>{opt.labelCurrentDict()}:</b>  \n {H_Location.endereco}, {H_Location.city}, - {H_Location.slg}",
                replyMarkup: new ReplyKeyboardMarkup(
                    opt.getButtons(),
                    resizeKeyboard: true
                )
            );
        }
        public async void MapAddress()
        {
            System.Console.WriteLine($"SLG {H_Location.slg}, cidade {H_Location.city} e rua {H_Location.endereco}");
            var address = new GetAddressFromApi();
            var loc = address.Location(H_Location.slg, H_Location.city, H_Location.endereco);
            await client.SendLocationAsync(
                chatId: MessagesE.Message.Chat,
                latitude: loc.latitude,
                longitude: loc.longitude
            );
            await client.SendTextMessageAsync(
                chatId: MessagesE.Message.Chat,
                parseMode: ParseMode.Html,
                text: opt.labelCurrentDict(),
                replyMarkup: new ReplyKeyboardMarkup(
                    opt.getButtons(),
                    resizeKeyboard: true
                )
            );
        }
    }
}