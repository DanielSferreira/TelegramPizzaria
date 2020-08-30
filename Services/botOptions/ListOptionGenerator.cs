using Telegram.Bot;
using TelegramPizzaria.Models;
using TelegramPizzaria.Services.AdrressForOrder;
using Telegram.Bot.Types.ReplyMarkups;

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
            opt.FindOptions(e.Message.Text);

            await client.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: opt.labelCurrent(),
                replyMarkup: new ReplyKeyboardMarkup(
                    opt.getButtons(),
                    resizeKeyboard: true
                )
            );
        }
    }
}