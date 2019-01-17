using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using uMediaBot.States;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace uMediaBot
{
    public class Renderer
    {
        private readonly ITelegramBotClient _bot;
        public Renderer(ITelegramBotClient client)
        {
            _bot = client;
        }

        public async void Render(BaseFolder folder, long chatId)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(CreateMatrix(3, folder.PossibleTransitions.Keys));

            await _bot.SendTextMessageAsync(chatId, folder.MessgagesAfterOpened()[0].Text, replyMarkup: replyKeyboard);


            KeyboardButton[][] CreateMatrix(int width, IEnumerable<string> baseKeys)
            {
                List<KeyboardButton[]> matrix = new List<KeyboardButton[]>();
                List<KeyboardButton> rows = new List<KeyboardButton>();
                foreach(string baseKey in baseKeys)
                {
                    rows.Add(new KeyboardButton(baseKey));
                    if(rows.Count == width){
                        matrix.Add(rows.ToArray());
                        rows = new List<KeyboardButton>();
                    }
                }
                matrix.Add(rows.ToArray());
                return matrix.ToArray();
            }
        }

        public void SendMessage(Message message, long chatId)
        {

        }
    }
}
