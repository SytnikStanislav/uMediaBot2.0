using System;
using uMediaBot.Bot;

namespace uMediaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new TelegramBot("711230373:AAF5J1HmvQ8zkf6vXY8-b6J9OMBZYr0xw6Q");
            bot.Start();
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
