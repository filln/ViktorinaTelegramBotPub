// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Элемент словаря Dictionary<string, SerializableStatsItem> stats. Список статов текущего профиля.
 */

namespace Viktorina.Bot.Stats
{
	[Serializable]
	public class SerializableStatsItem : ICloneable, IComparable
	{
		//Имя профиля.
		public string username;
		//Очки.
		public int points;
		//Количество правильных ответов.
		public int answersCount;
		//Очки за раунд.
		public int pointsRound;
		//Количество правильных ответов за раунд.
		public int answersCountRound;
		//Очки за месяц.
		public int pointsMonth;
		//Колич. правильных ответов за месяц.
		public int answersCountMonth;
		//Очки за сутки.
		public int pointsDay;
		//Колич. правильных ответов за сутки.
		public int answersCountDay;
		//Очки, полученные за супер-игры.
		public int superGamePoints;
		//Очки, утерянные в супер-играх.
		public int superGameLosePoints;
		//Количество выигранных супер-игр (т.е. правильные ответы за супер-игры).
		public int superGameAnswersCount;
		//Количество проигранных суперигр.
		public int superGameLoseCount;
		//Самый быстрый ответ.
		public double minAnswerTimeInterval;
		//Макс. колич. правильных ответов подряд.
		public int maxAnswersCountInARow;
		//Массив оригинальных ответов (вопросы из базы повторяются, а этот параметр учитывает по одному ответу на каждый вопрос).
		public bool[] answersFlagsArray;
		//Если true, то даны ответы на все вопросы базы, т.е. statsBaseManager.CountOfQuestions <= lastOriginalAnswers
		public bool allQuestionsAnswered;
		//Сохранение количества оригинальных ответов.
		public int lastOriginalAnswers;
		//Титул игрока.
		public string title;
		//Дата и время начала игры
		public DateTime beginGameDateTime; 
		//Дата и время последней игры
		public DateTime lastGameDateTime;

		public object Clone()
		{
			SerializableStatsItem returnItem = new SerializableStatsItem
			{
				username = string.Copy(this.username),
				points = this.points,
				answersCount = this.answersCount,
				pointsRound = this.pointsRound,
				answersCountRound = this.answersCountRound,
				pointsMonth = this.pointsMonth,
				answersCountMonth = this.answersCountMonth,
				pointsDay = this.pointsDay,
				answersCountDay = this.answersCountDay,
				superGamePoints = this.superGamePoints,
				superGameLosePoints = this.superGameLosePoints,
				superGameAnswersCount = this.superGameAnswersCount,
				superGameLoseCount = this.superGameLoseCount,
				minAnswerTimeInterval = this.minAnswerTimeInterval,
				maxAnswersCountInARow = this.maxAnswersCountInARow,
				allQuestionsAnswered = this.allQuestionsAnswered,
				lastOriginalAnswers = this.lastOriginalAnswers,
				title = string.Copy(this.title),
				beginGameDateTime = this.beginGameDateTime,
				lastGameDateTime = this.lastGameDateTime
			};

			returnItem.answersFlagsArray = new bool[this.answersFlagsArray.Length];
			this.answersFlagsArray.CopyTo(returnItem.answersFlagsArray, 0);

			return returnItem;
		}

		public int CompareTo(object? obj)
		{
			if (obj != null)
			{
				SerializableStatsItem otherItem = (SerializableStatsItem)obj;
				if (otherItem != null)
				{
					//По возрастанию.
					//return this.points.CompareTo(otherItem.points);

					//По убыванию.
					return otherItem.points.CompareTo(this.points);
				}
			}
			return 1;
		}

		public int CompareToByRoundPoints(object? obj)
		{
			if (obj != null)
			{
				SerializableStatsItem otherItem = (SerializableStatsItem)obj;
				if (otherItem != null)
				{
					//По возрастанию.
					//return this.points.CompareTo(otherItem.points);

					//По убыванию.
					return otherItem.pointsRound.CompareTo(this.pointsRound);
				}
			}
			return 1;
		}


		//end of class.
	}
}
