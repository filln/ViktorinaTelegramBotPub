// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Таймер сохранения статов игрока (профиля) из класса StatsBaseManager в базу.
 */

using Viktorina.Bot.Stats;

namespace Viktorina.Bot.Timers
{
	class WriteProfileBaseTimerHandler
	{
		public WriteProfileBaseTimerHandler(StatsBaseManager statsBaseManager)
		{
			this.statsBaseManager = statsBaseManager;
			writeProfileBasePeriod = 60; //минут

			timerCallback = new TimerCallback(State);
			timer = new Timer(timerCallback);
			period = writeProfileBasePeriod * 60 * 1000;
			StartTimer();
		}

		/*
		 * Variables
		*/
		private readonly StatsBaseManager statsBaseManager;
		//минуты
		private readonly int writeProfileBasePeriod; 
		//Таймер сохранения статов в базу.
		private readonly Timer timer;
		private readonly TimerCallback timerCallback;
		private readonly int period;
		/**
		 * Methods
		 */

		public void StartTimer()
		{
			timer.Change(period, period);
		}
		public void StopTimer()
		{
			timer.Change(Timeout.Infinite, Timeout.Infinite);
		}

		private void State(Object sender)
		{
			statsBaseManager.TryWriteData();
		}



		//end of class
	}
}
