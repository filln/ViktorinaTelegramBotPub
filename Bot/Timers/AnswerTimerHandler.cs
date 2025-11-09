// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * //Отсчитывает время (AllocatedToAnswerTime) от вопроса до автоответа(если никто не отвечат ранее).
 */

namespace Viktorina.Bot.Timers
{
	class AnswerTimerHandler
	{
		public AnswerTimerHandler(ViktorinaMain viktorinaMain, TimersManager timersManager)
		{
			this.viktorinaMain = viktorinaMain;
			this.timersManager = timersManager;

			timerCallback = new TimerCallback(State);
			timer = new Timer(timerCallback);
			dueTime = viktorinaMain.AllocatedToAnswerTime * 1000;
		}

		/*
		* Variables
		*/
		private readonly ViktorinaMain viktorinaMain;
		private readonly TimersManager timersManager;
		//Отсчитывает время до вопроса.
		private readonly Timer timer;
		private readonly TimerCallback timerCallback;
		private readonly int dueTime;


		/**
		 * Methods
		 */

		public void StartTimer()
		{
			timer.Change(dueTime, Timeout.Infinite);
		}
		public void StopTimer()
		{
			timer.Change(Timeout.Infinite, Timeout.Infinite);
		}

		private void State(Object sender)
		{
			viktorinaMain.OutputAnswer();
			StopTimer();
			timersManager.StartQuestionTimer();
		}




		//end of class
	}
}
