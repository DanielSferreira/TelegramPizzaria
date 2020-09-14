using Telegram.Bot;
using TelegramPizzaria.Services.AdrressForOrder;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using TelegramPizzaria.Services.botOptions.Options;
namespace TelegramPizzaria.Services.botOptions
{
    public class ListOptionGenerator
    {

        private readonly TelegramBotClient client;
        private MapChoices opt;

        public ListOptionGenerator(TelegramBotClient _client)
        {
            client = _client;
            opt = new MapChoices();
        }

        private Telegram.Bot.Args.MessageEventArgs MessagesE;

        public void UpdateMessageEvent(Telegram.Bot.Args.MessageEventArgs e)
            => MessagesE = e;
        
        private string endereco = "";
        private string slg = "";
        private string city = "";

        LocationHelper H_Location = new LocationHelper();
        public void GatwayMessages()
        {
            opt.FindInDict(H_Location.LocationSequenceHelper(MessagesE));
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
                text: $"<b>{opt.labelCurrentDict()}:</b>  \n {H_Location.slg}, {H_Location.city}, - {H_Location.endereco}",
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
            var loc = address.Location(slg, city, endereco);
            await client.SendLocationAsync(
                chatId: MessagesE.Message.Chat,
                latitude: loc.latitude,
                longitude: loc.longitude
            );
        }
    }
}