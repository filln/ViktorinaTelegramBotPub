//Принимает и проверяет данные от телеграма, отправляет данные на телеграм.
//Хранит ИД чата.

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ViktorinaTelegramBot;

public class HandleUpdateService
{
    private readonly ITelegramBotClient _botClient;
    //private readonly ILogger<HandleUpdateService> _logger;
    private long chatId = 0;

    public HandleUpdateService(ITelegramBotClient botClient)
    {
        _botClient = botClient;
        Program.handleUpdateService = this;
    }

    public async Task EchoAsync(Update update)
    {
        if(chatId == 0)
        {
            chatId = update.Message.Chat.Id;
        }

        string username = "username";
        /**
         * Использовать юзернейм, если он есть.
         * Если юзернейма нет, то использовать имя и фамилию(или что есть из них)
         * Если нет имени и фамилии, то использовать ИД.
         */
        if (String.IsNullOrEmpty(update.Message.From.Username))
        {
            if(!String.IsNullOrEmpty(update.Message.From.FirstName) && !String.IsNullOrEmpty(update.Message.From.LastName))
            {
                username = update.Message.From.FirstName + update.Message.From.LastName;
            }
            if (!String.IsNullOrEmpty(update.Message.From.FirstName) && String.IsNullOrEmpty(update.Message.From.LastName))
            {
                username = update.Message.From.FirstName;
            }
            if(String.IsNullOrEmpty(update.Message.From.FirstName) && !String.IsNullOrEmpty(update.Message.From.LastName))
            {
                username = update.Message.From.LastName;
            }
            if (String.IsNullOrEmpty(update.Message.From.FirstName) && String.IsNullOrEmpty(update.Message.From.LastName))
            {
                username = update.Message.From.Id.ToString();
            }
        }
        else
        {
            username = update.Message.From.Username;
        }

        Program.viktorinaStarter.TakeInputText(update.Message.Text, username);

    }

    public void SendMessage(string text, bool isFormatedText = true)
    {
        ParseMode parseMode;
        if(isFormatedText)
        {
            parseMode = ParseMode.Html;
        }
        else
        {
            parseMode = ParseMode.Markdown;
        }
        //_botClient.SendTextMessageAsync(chatId, text, parseMode);
        _botClient.SendMessage(chatId, text, parseMode);
    }

 
}
