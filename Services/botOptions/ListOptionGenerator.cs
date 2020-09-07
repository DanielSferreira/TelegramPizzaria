using Telegram.Bot;
using TelegramPizzaria.Services.AdrressForOrder;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

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
        {
            MessagesE = e;
        }

        public void GatwayMessages()
        {
            opt.FindInDict(MessagesE.Message.Text);

            if (opt.TypeMessage() == "botoes")
                MessageWithOptions();
            else if (opt.TypeMessage() == "Sem Botoes")
                Message();
            else if (opt.TypeMessage() == "Address")
                MessageAddress();

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
                text: opt.labelCurrentDict()+ MessagesE.Message.Text,
                replyMarkup: new ReplyKeyboardRemove()
            );
        }
    }
}