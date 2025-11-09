// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Управления массивом флагов для обозначения оригинальных ответов на вопросы базы.
 */

namespace Viktorina.Bot.Stats
{
	public class AnswersFlags
	{
		public AnswersFlags(StatsBaseManager statsBaseManager)
		{
			this.statsBaseManager = statsBaseManager;
			ArrayLength = 1000000;
		}

		/**
		 * Variables
		 */
		private readonly StatsBaseManager statsBaseManager;
		public int ArrayLength { get; private set; }

		/**
		 * Methods
		 */

		public bool[] CreateAnswersFlagsArray()
		{
			bool[] answersFlagsArray = new bool[ArrayLength];
			for (int index = 0; index < ArrayLength; index++)
			{
				answersFlagsArray[index] = false;
			}
			return answersFlagsArray;
		}

		//Записать ответ. Если ответ не был ранее отвечен(массив хранил false), то вернуть результат true.
		public bool AddOriginalAnswer(string username, int lineNumber)
		{
			if (lineNumber > ArrayLength)
			{
				return false;
			}
			if (lineNumber < 1)
			{
				return false;
			}
			if (!statsBaseManager.statsHandler.stats[username].answersFlagsArray[lineNumber - 1])
            {
				statsBaseManager.statsHandler.stats[username].answersFlagsArray[lineNumber - 1] = true;
				return true;
			}
			return false;
		}


		//Посчитать количество оригинальных ответов игрока.
		//Не используется.
		private int CalcOriginalAnswers(string username)
		{
			int countOfQuestions = statsBaseManager.CountOfQuestions;
			int answersFlagsArrayLength = statsBaseManager.statsHandler.stats[username].answersFlagsArray.Length;
			if (countOfQuestions > answersFlagsArrayLength)
			{
				return -1;
			}
			int originalRightAnswersCount = 0;
			for (int index = 0; index < countOfQuestions; index++)
			{
				if (statsBaseManager.statsHandler.stats[username].answersFlagsArray[index] == true)
				{
					originalRightAnswersCount++;
				}
			}
			return originalRightAnswersCount;
		}


		//end of class
	}
}
