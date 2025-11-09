// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Содержит общую статистику текущей игры.
 */

namespace Viktorina.Bot.Stats
{
	class GlobalStatsBaseManager
	{
		public GlobalStatsBaseManager()
		{
			CountOfQuestionsInRound = 0;
			CountOfAnswersInRound = 0;
			CountOfLoseAnswersInRound = 0;
		}

		/**
		 * Variables
		 */
		public int CountOfQuestionsInRound { get; private set; }
		public int MaxCountOfQuestionsInRound { get; private set; }
		public int CountOfAnswersInRound { get; private set; }

		public int CountOfLoseAnswersInRound { get; private set; }

		public DateTime LastQuestionTime { get; set; }
		/**
		 * Methods
		 */
		public void IncreaseCountOfQuestionsInRound()
		{
			CountOfQuestionsInRound++;
		}

		public void SetMaxCountOfQuestionsInRound(int count)
        {
			MaxCountOfQuestionsInRound = count;
		}

		public void IncreaseCountOfAnswersInRound()
		{
			CountOfAnswersInRound++;
		}

		public void ResetCountOfQuestionsAndAnswersInRound()
		{
			CountOfQuestionsInRound = 0;
			CountOfAnswersInRound = 0;
			CountOfLoseAnswersInRound = 0;
		}

		public void IncreaseCountOfLoseAnswersInRound()
		{
			CountOfLoseAnswersInRound++;
		}



		//end of class
	}
}
