// Copyright 2022 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.


using Microsoft.AspNetCore.Mvc.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Viktorina.Bot;

namespace ViktorinaTelegramBot.Telegram
{
    public class TelegramConnect
    {
        public TelegramConnect() 
        {
            // replace YOUR_BOT_TOKEN below, or set your TOKEN in Project Properties > Debug > Launch profiles UI > Environment variables
            var token = Environment.GetEnvironmentVariable("TOKEN") ?? "YourToken";

            cts = new CancellationTokenSource();
            bot = new TelegramBotClient(token, cancellationToken: cts.Token);

            bot.DeleteWebhook();          // you may comment this line if you find it unnecessary
            bot.DropPendingUpdates();     // you may comment this line if you find it unnecessary

            bot.OnError += OnError;
            bot.OnMessage += OnMessage;
            //Внутри конструктора ChatId() ввести ИД канала (начинается с минуса)
            //bot.SendMessage(new ChatId(Id), "Викторина запустилась", ParseMode.Markdown);
        }

        /**
        * Variables
        */
        public CancellationTokenSource cts;
        TelegramBotClient bot;
        private long chatId = 0;
        private ChatId chatIdObj;

        public static TelegramConnect? current;
        public static TelegramConnect GetCurrent()
        {
            if (current == null)
            {
                current = new TelegramConnect();
            }
            return current;
        }


        /**
        * Methods
        */
        public void OutputText(string outputText, bool isFormatedText = true)
        {
            ParseMode parseMode;
            if (isFormatedText)
            {
                parseMode = ParseMode.Html;
            }
            else
            {
                parseMode = ParseMode.Markdown;
            }
            if (chatIdObj == null)
            {
                Console.WriteLine("chatIdObj == null");
                return;
            }
            bot.SendMessage(chatIdObj, outputText, parseMode);
        }

        async Task OnError(Exception exception, HandleErrorSource source)
        {
            Console.WriteLine(exception);
            await Task.Delay(2000, cts.Token);
        }

        async Task OnMessage(Message msg, UpdateType type)
        {
            //Console.WriteLine(msg.Text + " from " + msg.From.Username + " in " + msg.Chat.Type.ToString() + " " + msg.Chat.Username + " " + msg.Chat.Id);
            if (msg == null)
            {
                return;
            }
            if (msg.Text == null)
            {
                return;
            }
            if (msg.Chat == null)
            {
                return;
            }
            if (msg.From == null)
            {
                return;
            }
            //Private chats forbid.
            if (msg.Chat.Type != ChatType.Supergroup)
            {
                return;
            }
            if (msg.From.IsBot)
            {
                return;
            }

            if (msg.Type != MessageType.Text)
            {
                return;
            }

            if (msg.Text[0] == ' ')
            {
                return;
            }
            bool emptySymbolsPresentEverywhere = true;
            foreach (char symbol in msg.Text)
            {
                if
                    (
                        symbol != '\n'
                        && symbol != '\t'
                    )
                {
                    emptySymbolsPresentEverywhere = false;
                }
                else
                {
                    emptySymbolsPresentEverywhere = true;
                    break;
                }
            }
            if (emptySymbolsPresentEverywhere)
            {
                return;
            }

            if (chatId == 0)
            {
                chatId = msg.Chat.Id;
                chatIdObj = new ChatId(chatId);
                //Console.WriteLine("chatId = " + chatId.ToString());
            }

            string username = "username";
            /**
             * Использовать юзернейм, если он есть.
             * Если юзернейма нет, то использовать имя и фамилию(или что есть из них)
             * Если нет имени и фамилии, то использовать ИД.
             */
            if (String.IsNullOrEmpty(msg.From.Username))
            {
                if (!String.IsNullOrEmpty(msg.From.FirstName) && !String.IsNullOrEmpty(msg.From.LastName))
                {
                    username = msg.From.FirstName + msg.From.LastName;
                }
                if (!String.IsNullOrEmpty(msg.From.FirstName) && String.IsNullOrEmpty(msg.From.LastName))
                {
                    username = msg.From.FirstName;
                }
                if (String.IsNullOrEmpty(msg.From.FirstName) && !String.IsNullOrEmpty(msg.From.LastName))
                {
                    username = msg.From.LastName;
                }
                if (String.IsNullOrEmpty(msg.From.FirstName) && String.IsNullOrEmpty(msg.From.LastName))
                {
                    username = msg.From.Id.ToString();
                }
            }
            else
            {
                username = msg.From.Username;
            }
            ViktorinaStarter.GetCurrent().TakeInputText(msg.Text, username);

        }

 


        //end of class
    }
}
