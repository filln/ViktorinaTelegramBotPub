// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Содержит статистику профиля, хранит ее на время запуска программы.
 */
//https://github.com/ExtendedXmlSerializer/home/wiki/The-Basics

using System.Runtime.Serialization.Formatters.Binary;
//using ExtendedXmlSerializer;
//using System.Xml;
//using System.Xml.Serialization;

namespace Viktorina.Bot.Stats
{
    public class StatsBaseManager
    {
        public StatsBaseManager(ViktorinaMain viktorinaMain)
        {
            this.viktorinaMain = viktorinaMain;
            answersFlags = new AnswersFlags(this);
            statsHandler = new StatsHandler(this);
            statsDataFilePath = UserDataFolderName + "/stats.dat";
            //statsDataFilePath = UserDataFolderName + "/stats.xml";

        }

        /**
		 * Variables
		 */
        private readonly ViktorinaMain viktorinaMain;
        public StatsHandler statsHandler;
        private OutputTextManagerParent OutputTextManager => viktorinaMain.OutputTextManager;
        private BinaryFormatter Formatter => viktorinaMain.Formatter;
        //private XmlSerializer Formatter => viktorinaMain.Formatter;
        //private IExtendedXmlSerializer Formatter => viktorinaMain.Formatter;
        public readonly AnswersFlags answersFlags;
        public TitlesControlParent TitlesControl => viktorinaMain.TitlesControl;

        private readonly string statsDataFilePath;
        private string UserDataFolderName => viktorinaMain.UserDataFolderName;

        public DateTime LastQuestionTime => viktorinaMain.LastQuestionTime;
        public int CountOfQuestions => viktorinaMain.CountOfQuestions;

        /**
		 * Methods  
		 */

        public void TryReadData()
        {
            bool userDataFolderExist = CheckAndCreateUserDataFolder();
            if (!userDataFolderExist)
            {
                OutputDebugMessage("TryReadData() !userDataFolderExist");
                return;
            }
            if (!CheckStatsDataFile())
            {
                //Создадим новый файл статов.
                CreateStatsDataFile();
                return;
            }
            ReadData();
        }

        public void TryWriteData()
        {
            bool userDataFolderExist = CheckAndCreateUserDataFolder();
            if (!userDataFolderExist)
            {
                OutputDebugMessage("TryWriteData() !userDataFolderExist");
                return;
            }
            if (!CheckStatsDataFile())
            {
                //Создадим новый файл статов.
                CreateStatsDataFile();
                return;
            }
            WriteData();
        }

        public void IncreasePoints(string username, int add)
        {
            statsHandler.AddPoints(username, add);
            statsHandler.AddPointsRound(username, add);
            statsHandler.SetLastGameDateTime(username, DateTime.Now);
            statsHandler.AddPointsMonth(username, add);
            statsHandler.AddPointsDay(username, add);
        }

        public void IncreaseAnswersCount(string username)
        {
            statsHandler.IncrAnswersCount(username);
            statsHandler.IncrAnswersCountMonth(username);
            statsHandler.IncrAnswersCountDay(username);
            statsHandler.IncrAnswersCountRound(username);
        }

        public void IncreaseSuperGameWins(string username, int addPoints)
        {
            statsHandler.IncrSuperGameAnswersCount(username);
            statsHandler.AddSuperGamePoints(username, addPoints);
        }

        public void IncreaseSuperGameLoss(string username, int addLosePoints)
        {
            statsHandler.IncrSuperGameLoseCount(username);
            statsHandler.AddSuperGameLosePoints(username, addLosePoints);
        }

        public (string, bool) GetLastAnswerTimeInterval(DateTime Now, string username)
        {
            //Интервал между последним вопросом и первым ответом.
            string intervalStr;
            //Достигнут ли рекорд минимального времени ответа.
            bool minIntervalReached = false;

            double intervalTmp = (Now - LastQuestionTime).TotalSeconds;

            //Убрать лишние дробные части, оставив их в количестве 3.
            //int multiplier = Convert.ToInt32(Math.Pow(10, countFractionalDigit));
            double interval = Math.Truncate(intervalTmp * 1000) / 1000;
            intervalStr = interval.ToString();

            if (interval < statsHandler.GetMinAnswerTimeInterval(username))
            {
                statsHandler.SetMinAnswerTimeInterval(username, interval);
                minIntervalReached = true;
            }

            return (intervalStr, minIntervalReached);
        }

        //Проверить, может побили рекорд на макс. ответов подряд.
        public void CheckAnswersInARow(string username, int count)
        {
            if (count > statsHandler.GetMaxAnswersCountInARow(username))
            {
                statsHandler.IncrMaxAnswersCountInARow(username);
            }
        }

        //Срабатывает при команде !список
        public void ExecuteProfilesList()
        {
            if (statsHandler.stats.Count == 0)
            {
                return;
            }

            List<KeyValuePair<string, SerializableStatsItem>> stats = statsHandler.stats.ToList();
            stats.Sort
            (
                (firstPair, secondPair) => firstPair.Value.CompareTo(secondPair.Value)
            );
            foreach (var stat in stats)
            {
                OutputTextManager.OutputUsernameAndTitle
                    (
                        stat.Key,
                        stat.Value.title,
                        stat.Value.allQuestionsAnswered
                    );
            }
        }

        public void ExecuteTopPoints()
        {
            if (statsHandler.stats.Count == 0)
            {
                return;
            }

            List<KeyValuePair<string, SerializableStatsItem>> stats = statsHandler.stats.ToList();
            stats.Sort
            (
                (firstPair, secondPair) => firstPair.Value.CompareTo(secondPair.Value)
            );
            string topStr = OutputTextManager.CreateBeginTopPointsStr();
            int place = 0;
            foreach (var stat in stats)
            {
                place++;
                string topStrApp = OutputTextManager.CreateProfileInTopPointsStr
                    (
                        place,
                        stat.Key,
                        stat.Value.allQuestionsAnswered,
                        stat.Value.title,
                        stat.Value.points
                    );
                topStr += topStrApp;
                if (place == 5)
                {
                    break;
                }
            }
            OutputTextManager.OutputText(topStr, true);
        }

        public void OutputTopRoundPoints()
        {
            List<KeyValuePair<string, SerializableStatsItem>> stats = statsHandler.stats.ToList();
            stats.Sort
            (
                (firstPair, secondPair) => firstPair.Value.CompareToByRoundPoints(secondPair.Value)
            );
            string topStr = OutputTextManager.CreateBeginTopRoundPointsStr();
            bool topIsFill = false;
            int place = 0;
            foreach (var stat in stats)
            {
                place++;
                if (stat.Value.pointsRound == 0)
                {
                    break;
                }
                string topStrApp = OutputTextManager.CreateProfileInTopPointsStr
                    (
                        place,
                        stat.Key,
                        stat.Value.allQuestionsAnswered,
                        stat.Value.title,
                        stat.Value.pointsRound
                    );
                topStr += topStrApp;
                topIsFill = true;
                if (place == 5)
                {
                    break;
                }
            }
            if (topIsFill)
            {
                OutputTextManager.OutputText(topStr, true);
            }            
        }

        public void ExecuteStat(string username)
        {
            if (!statsHandler.CheckExistsUsername(username))
            {
                OutputTextManager.OutputNotFindUsername(username);
                return;
            }

            statsHandler.CheckLastMonthAndDayOfGame();

            OutputTextManager.OutputStat
                (
                    username,
                    statsHandler.GetPoints(username),
                    statsHandler.GetAnswersCount(username),
                    statsHandler.GetPointsMonth(username),
                    statsHandler.GetAnswersCountMonth(username),
                    statsHandler.GetPointsDay(username),
                    statsHandler.GetAnswersCountDay(username),
                    statsHandler.GetSuperGamePoints(username),
                    statsHandler.GetSuperGameLosePoints(username),
                    statsHandler.GetSuperGameAnswersCount(username),
                    statsHandler.GetSuperGameLoseCount(username),
                    statsHandler.GetMinAnswerTimeInterval(username),
                    statsHandler.GetMaxAnswersCountInARow(username),
                    statsHandler.GetLastOriginalAnswers(username),
                    statsHandler.GetAllQuestionsAnswered(username),
                    statsHandler.GetBeginGameDateTime(username),
                    statsHandler.GetLastGameDateTime(username),
                    statsHandler.GetTitle(username)
                );
        }

        public void OutputCongratOnAllQuestionsAnswered(string username)
        {
            viktorinaMain.OutputCongratOnAllQuestionsAnswered(username);
        }

        private bool CheckAndCreateUserDataFolder()
        {
            if (Directory.Exists(UserDataFolderName) == false)
            {
                Directory.CreateDirectory(UserDataFolderName);
                if (Directory.Exists(UserDataFolderName) == false)
                {
                    OutputDebugMessage("CheckAndCreateFolderAndFile() : Directory.Exists(UserDataFolderName) == false");
                    return false;
                }
            }
            return true;
        }

        private bool CheckStatsDataFile()
        {
            return File.Exists(statsDataFilePath);
        }
        private void CreateStatsDataFile()
        {
            FileStream fileStream;
            fileStream = new FileStream(statsDataFilePath, FileMode.CreateNew);
            Formatter.Serialize(fileStream, statsHandler.stats);
            fileStream.Close();
            if (!CheckStatsDataFile())
            {
                OutputDebugMessage("CreateStatsDataFile() !CheckStatsDataFile()");
            }
        }

        private bool ReadData()
        {
            FileStream fileStream;
            statsHandler.stats.Clear();
            //Прочитать файл.
            fileStream = new FileStream(statsDataFilePath, FileMode.Open, FileAccess.Read);
            //XmlReader reader = XmlReader.Create(fileStream);
            statsHandler.stats = (Dictionary<string, SerializableStatsItem>)Formatter.Deserialize(fileStream);
            //statsHandler.stats = (Dictionary<string, SerializableStatsItem>)Formatter.Deserialize(reader);
            fileStream.Close();
            statsHandler.CheckLastMonthAndDayOfGame();

            return true;
        }

        private bool WriteData()
        {
            statsHandler.CheckLastMonthAndDayOfGame();
            FileStream fileStream;
            fileStream = new FileStream(statsDataFilePath, FileMode.Truncate);
            Formatter.Serialize(fileStream, statsHandler.stats);
            fileStream.Close();
            Console.WriteLine("WriteData");
            return true;
        }

        public void OutputDebugMessage(string outputText)
        {
            OutputTextManager.OutputDebugMessage(outputText);
        }

        //end of class
    }
}
