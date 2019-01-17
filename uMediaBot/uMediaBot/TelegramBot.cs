using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace uMediaBot.Bot
{
    public class TelegramBot
    {
        private readonly string _PKEY;
        private ITelegramBotClient _bot;
        private AspNetAPI AspNetAPI;
        private Renderer renderer;

        List<Client> activeClients = new List<Client>();

        public TelegramBot(string PKEY)
        {
            _PKEY = PKEY;
        }

        public void Start()
        {
            AspNetAPI = new AspNetAPI();
            _bot = new TelegramBotClient(_PKEY);
            renderer = new Renderer(_bot);
            
            Console.WriteLine("Starting bot...");
            _bot.OnMessage += _botMessageHandler;
            _bot.OnCallbackQuery += _botCallbackHandler;
            _bot.StartReceiving();
        }

        private void _botMessageHandler(object sender, MessageEventArgs e)
        {
            if (!IsUsersClintActive(e.Message.Chat.Id))
                activeClients.Add(new Client(e.Message.Chat.Id, AspNetAPI, renderer));
            else
                SendMessageToUsersClient(e.Message.Chat.Id, e.Message.Text);


            bool IsUsersClintActive(long id)
            {
                foreach(Client client in activeClients)
                    if(client.ChatId == id)
                        return true;
                return false;
            }
            void SendMessageToUsersClient(long id, string message)
            {
                foreach(Client client in activeClients)
                    if(client.ChatId == id)
                        client.HandleMessage(message);
            }
        }

        private void _botCallbackHandler(object sender, CallbackQueryEventArgs e)
        {
            if (!IsUsersClintActive(e.CallbackQuery.Message.Chat.Id))
                activeClients.Add(new Client(e.CallbackQuery.Message.Chat.Id, AspNetAPI, renderer));
            else
                SendMessageToUsersClient(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.Text);


            bool IsUsersClintActive(long id)
            {
                foreach(Client client in activeClients)
                    if(client.ChatId == id)
                        return true;
                return false;
            }
            void SendMessageToUsersClient(long id, string message)
            {
                foreach(Client client in activeClients)
                    if(client.ChatId == id)
                        client.HandleMessage(message);
            }
        }
    }
}
