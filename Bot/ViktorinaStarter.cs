// Copyright 2022 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.
//	<EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>

//Создает ViktorinaMain, который управляет игровым процессом. Определяет папку сохранения данных игроков, объект сериализации.
//Посредник между телеграм-классами и классами викторины в плане ввода/вывода текста, закрытии программы.
//Определяет язык викторины.
//Тут объявляются переменные, объекты которых имеют перевод на разные языки. Объекты создаются в localizationManager.SelectLanguage()


using System.Runtime.Serialization.Formatters.Binary;
//using ExtendedXmlSerializer;
//using ExtendedXmlSerializer.Configuration;
//using System.Xml.Serialization;
using Viktorina.Bot.Stats;
using Viktorina.Localization;
//using ViktorinaTelegramBot;
using ViktorinaTelegramBot.Telegram;


namespace Viktorina.Bot
{
    public class ViktorinaStarter
    {
        ViktorinaStarter()
        {
            //Определить папку для сохранения данных профилей.
            UserDataFolderName = AppContext.BaseDirectory + "/UserData";
            if (Directory.Exists(UserDataFolderName) == false)
            {
                Directory.CreateDirectory(UserDataFolderName);
            }

            //Создать объект-сериализатор для считывания и записи данных профилей.
            Formatter = new BinaryFormatter();
            //Formatter = new XmlSerializer(typeof(Dictionary<string, SerializableStatsItem>));
            //Formatter = new ConfigurationContainer().Create();

            localizationManager = new LocalizationManager(this);
            localizationManager.SelectLanguage(LanguagesList.russian);
            viktorinaMain = new ViktorinaMain(this);
            SendViktorinaMainToOutputTextManager();
            
        }

        private static ViktorinaStarter? current;
        public static ViktorinaStarter GetCurrent()
        {
            if (current == null)
            {
                current = new ViktorinaStarter();
            }
            return current;
        }

        /**
        * Variables
        */
        public string UserDataFolderName { get; private set; }
        public BinaryFormatter Formatter { get; private set; }
        //public XmlSerializer Formatter { get; private set; }
        //public IExtendedXmlSerializer Formatter { get; private set; }
        public string CurrentLanguage => localizationManager.CurrentLanguage;

        //Тут объявляются переменные, объекты которых имеют перевод на разные языки.
        //Объекты создаются в localizationManager.SelectLanguage()
        ///
        public OutputTextManagerParent? OutputTextManager { get; set; }
        public CommandsListParent? CommandsList { get; set; }
        public TitlesControlParent? TitlesControl { get; set; }
        ///

        public ViktorinaMain viktorinaMain;
        private LocalizationManager localizationManager;

        /**
         * Methods
         */

        public void TakeInputText(string inputText, string username)
        {
            viktorinaMain.TakeInputText(inputText, username);
        }

        public void OutputText(string outputText, bool isFormatedText = true)
        {
            //Console.WriteLine(outputText);
            TelegramConnect.GetCurrent().OutputText(outputText, isFormatedText);
        }

        public void OutputDebugMessage(string outputText)
        {
            viktorinaMain.OutputDebugMessage(outputText);
        }

        //Закрыть программу.
        public void ExecuteClose()
        {
            Console.WriteLine("close");
            System.Environment.Exit(0);
        }

        public void CurrentDomain_ProcessExit()
        {
            viktorinaMain.CurrentDomain_ProcessExit();
            Console.WriteLine("Viktorina Starter CurrentDomain_ProcessExit()");
        }

        public void SendViktorinaMainToOutputTextManager()
        {
            //При смене языка в процессе игры нужно передать ссылку на viktorinaMain.
            if (viktorinaMain != null && OutputTextManager.viktorinaMain == null)
            {
                OutputTextManager.viktorinaMain = viktorinaMain;
            }
        }

        //end of class
    }
}
