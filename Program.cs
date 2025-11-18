// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

//Создает объекты для соединения с телеграмом, управляет созданием и доступом к ViktorinaStarter

using Viktorina.Bot;
using ViktorinaTelegramBot.Telegram;

namespace ViktorinaTelegramBot
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ViktorinaStarter.GetCurrent();
            TelegramConnect.GetCurrent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Console.WriteLine("bot is running... Press Escape to terminate");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
            TelegramConnect.GetCurrent().cts.Cancel(); // stop the bot
        }


        /**
         * Variables
         */

        /**
         * Methods
         */

        private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            ViktorinaStarter.GetCurrent().CurrentDomain_ProcessExit();
            Console.WriteLine("CurrentDomain_ProcessExit()");
        }


    }
}
