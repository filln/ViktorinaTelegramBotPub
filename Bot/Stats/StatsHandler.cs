// Copyright 2022 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Содержит словарь статов и методы управления и доступа к словарю.
 */

namespace Viktorina.Bot.Stats
{
    public class StatsHandler
    {
        public StatsHandler(StatsBaseManager statsBaseManager)
        {
            stats = new Dictionary<string, SerializableStatsItem>();
            this.statsBaseManager = statsBaseManager;
        }

        public Dictionary<string, SerializableStatsItem> stats;
        StatsBaseManager statsBaseManager;

        /**
        * Methods  
        */

        //Проверить наличие игрока в базе.
        public bool CheckExistsUsername(string username)
        {
            return stats.ContainsKey(username);
        }

        //Создать игрока в базе.
        public void CreateUser(string username)
        {
            SerializableStatsItem statsItem = new SerializableStatsItem();
            DefineInitialStatsItem(ref statsItem, username);
            stats.Add(username, statsItem);
        }

        ///////////////////////////////////////////////////
        ///
        /**
		 * Статы для сохранения в базу.
		 */

        //points
        public int GetPoints(string username)
        {
            return stats[username].points;
        }
        public void AddPoints(string username, int add)
        {
            stats[username].points += add;
        }

        //answersCount
        public int GetAnswersCount(string username)
        {
            return stats[username].answersCount;
        }
        public void IncrAnswersCount(string username)
        {
            stats[username].answersCount++;
        }

        //pointsRound
        public int GetPointsRound(string username)
        {
            return stats[username].pointsRound;
        }
        public void AddPointsRound(string username, int add)
        {
            stats[username].pointsRound += add;
        }
        public void ResetPointsAndAnswersRound()
        {
            if (stats.Count == 0)
            {
                return;
            }
            var keys = stats.Keys;
            foreach (var key in keys)
            {
                stats[key].pointsRound = 0;
                stats[key].answersCountRound = 0;
            }
        }

        //answersCountRound
        public int GetAnswersCountRound(string username)
        {
            return stats[username].answersCountRound;
        }
        public void IncrAnswersCountRound(string username)
        {
            
            stats[username].answersCountRound++;
        }

        //pointsMonth
        public int GetPointsMonth(string username)
        {
            
            return stats[username].pointsMonth;
        }
        public void AddPointsMonth(string username, int add)
        {
            
            stats[username].pointsMonth += add;
        }

        //answersCountMonth
        public int GetAnswersCountMonth(string username)
        {
            
            return stats[username].answersCountMonth;
        }
        public void IncrAnswersCountMonth(string username)
        {
            
            stats[username].answersCountMonth++;
        }

        //pointsDay
        public int GetPointsDay(string username)
        {
            
            return stats[username].pointsDay;
        }
        public void AddPointsDay(string username, int add)
        {
            
            stats[username].pointsDay += add;
        }

        //answersCountDay
        public int GetAnswersCountDay(string username)
        {
            
            return stats[username].answersCountDay;
        }
        public void IncrAnswersCountDay(string username)
        {
            
            stats[username].answersCountDay++;
        }

        //superGamePoints
        public int GetSuperGamePoints(string username)
        {
            
            return stats[username].superGamePoints;
        }
        public void AddSuperGamePoints(string username, int add)
        {
            
            stats[username].superGamePoints += add;
        }

        //superGameLosePoints
        public int GetSuperGameLosePoints(string username)
        {
            
            return stats[username].superGameLosePoints;
        }
        public void AddSuperGameLosePoints(string username, int add)
        {
            
            stats[username].superGameLosePoints += add;
        }

        //superGameAnswersCount
        public int GetSuperGameAnswersCount(string username)
        {
            
            return stats[username].superGameAnswersCount;
        }
        public void IncrSuperGameAnswersCount(string username)
        {
            
            stats[username].superGameAnswersCount++;
        }

        //superGameLoseCount
        public int GetSuperGameLoseCount(string username)
        {
            
            return stats[username].superGameLoseCount;
        }
        public void IncrSuperGameLoseCount(string username)
        {
            
            stats[username].superGameLoseCount++;
        }

        //minAnswerTimeInterval
        public double GetMinAnswerTimeInterval(string username)
        {
            
            return stats[username].minAnswerTimeInterval;
        }
        public void SetMinAnswerTimeInterval(string username, double value)
        {
            
            stats[username].minAnswerTimeInterval = value;
        }

        //maxAnswersCountInARow
        public int GetMaxAnswersCountInARow(string username)
        {
            
            return stats[username].maxAnswersCountInARow;
        }
        public void IncrMaxAnswersCountInARow(string username)
        {
            
            stats[username].maxAnswersCountInARow++;
        }

        //allQuestionsAnswered
        public bool GetAllQuestionsAnswered(string username)
        {
            
            return stats[username].allQuestionsAnswered;
        }

        //lastOriginalAnswers
        public int GetLastOriginalAnswers(string username)
        {
            
            return stats[username].lastOriginalAnswers;
        }
        public void AddOriginalAnswer(string username, int lineNumber)
        {
            
            if(stats[username].allQuestionsAnswered)
            {
                return;
            }
            bool result = statsBaseManager.answersFlags.AddOriginalAnswer(username, lineNumber);
            if (result)
            {
                stats[username].lastOriginalAnswers++;
            }
            if (stats[username].lastOriginalAnswers >= statsBaseManager.CountOfQuestions)
            {
                stats[username].allQuestionsAnswered = true;
                statsBaseManager.OutputCongratOnAllQuestionsAnswered(username);
            }
        }

        //title
        public string GetTitle(string username)
        {
            
            return stats[username].title;
        }
        //Сохраняет текущее звание для сравнения со званием после начисления очков, для вывода поздравления с повышением в звании.
        public void SetTitle(string username, string title)
        {
            
            stats[username].title = title;
        }
        //Звание, вычисляется из очков.
        public string CalcTitle(string username)
        {
            
            return statsBaseManager.TitlesControl.CalcTitle(GetPoints(username));
        }

        //beginGameDateTime
        public DateTime GetBeginGameDateTime(string username)
        {
            
            return stats[username].beginGameDateTime;
        }
        public void SetBeginGameDateTime(string username, DateTime dateTime)
        {
            
            stats[username].beginGameDateTime = dateTime;
        }

        //lastGameDateTime
        public DateTime GetLastGameDateTime(string username)
        {
            
            return stats[username].lastGameDateTime;
        }
        public void SetLastGameDateTime(string username, DateTime dateTime)
        {
            
            stats[username].lastGameDateTime = dateTime;
        }


        //////////////////////////////////////////////////
        ///

        //Определить объект начальных статов для нового игрока.
        public void DefineInitialStatsItem(ref SerializableStatsItem item, string username)
        {
            item.username = username;

            item.points = 0;
            item.answersCount = 0;

            item.pointsRound = 0;
            item.answersCountRound = 0;

            item.pointsMonth = 0;
            item.answersCountMonth = 0;

            item.pointsDay = 0;
            item.answersCountDay = 0;

            item.superGamePoints = 0;
            item.superGameLosePoints = 0;
            item.superGameAnswersCount = 0;
            item.superGameLoseCount = 0;

            item.minAnswerTimeInterval = double.PositiveInfinity;
            item.maxAnswersCountInARow = 0;

            item.answersFlagsArray = statsBaseManager.answersFlags.CreateAnswersFlagsArray();
            item.allQuestionsAnswered = false;
            item.lastOriginalAnswers = 0;
            item.title = statsBaseManager.TitlesControl.CalcTitle(0);

            item.beginGameDateTime = DateTime.Now;
            item.lastGameDateTime = DateTime.Now;
        }

        private void CheckLastMonthAndDayOfGame(string username, DateTime now)
        {
            if
                (
                    (stats[username].lastGameDateTime.DayOfWeek != now.DayOfWeek)
                    || ((stats[username].lastGameDateTime.DayOfWeek == now.DayOfWeek) && (stats[username].lastGameDateTime.DayOfYear != now.DayOfYear))
                )
            {
                stats[username].answersCountDay = 0;
                stats[username].pointsDay = 0;
            }
            if
                (
                    (stats[username].lastGameDateTime.Month != now.Month)
                    || ((stats[username].lastGameDateTime.Month == now.Month) && (stats[username].lastGameDateTime.Year < now.Year))
                )
            {
                stats[username].answersCountMonth = 0;
                stats[username].pointsMonth = 0;
            }
        }
        public void CheckLastMonthAndDayOfGame()
        {
            DateTime now = DateTime.Now;
            if (stats.Count == 0)
            {
                return;
            }
            var keys = stats.Keys;
            foreach (var key in keys)
            {
                CheckLastMonthAndDayOfGame(key, now);
            }
        }


        //end of class
    }
}
