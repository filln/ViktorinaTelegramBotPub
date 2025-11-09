// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Отсчитывает время согласия на суперигру. По истечению времени продолжается обычная игра.
 */

namespace Viktorina.Bot.Timers
{
	class WaitingAgreementPlaySuperGameTimerHandler
	{
		public WaitingAgreementPlaySuperGameTimerHandler(ViktorinaMain viktorinaMain, TimersManager timersManager)
		{
			this.viktorinaMain = viktorinaMain;
			this.timersManager = timersManager;

			timerCallback = new TimerCallback(State);
			timer = new Timer(timerCallback);
			dueTime = viktorinaMain.WaitingAgreementPlaySuperGameInterval * 1000;
		}

		/*
		* Variables
		*/
		private readonly ViktorinaMain viktorinaMain;
		private readonly TimersManager timersManager;

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
			StopTimer();
			viktorinaMain.SuperGameOn = false;
			timersManager.StartQuestionTimer();
		}


		//end of class
	}
}
