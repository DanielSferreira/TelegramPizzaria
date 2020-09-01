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

        public async void textOp(Telegram.Bot.Args.MessageEventArgs e)
        {
            opt.FindInDict(e.Message.Text);

            await client.SendTextMessageAsync(
                chatId: e.Message.Chat,
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