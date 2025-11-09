// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Управляет таймерами игры, создает их, дает интерфейс доступа к ним.
 */

using Viktorina.Bot.Stats;

namespace Viktorina.Bot.Timers
{
	class TimersManager
	{
		public TimersManager(ViktorinaMain viktorinaMain, StatsBaseManager statsBaseManager, ViktorinaStarter viktorinaStarter)
		{
			this.viktorinaMain = viktorinaMain;
			questionTimerHandler = new QuestionTimerHandler(viktorinaMain, this);
			answerTimerHandler = new AnswerTimerHandler(viktorinaMain, this);
			waitingAgreementPlaySuperGameTimerHandler = new WaitingAgreementPlaySuperGameTimerHandler(viktorinaMain, this);
			writeProfileBaseTimerHandler = new WriteProfileBaseTimerHandler(statsBaseManager);

		}


		/**
		 * Variables
		 */

		private readonly QuestionTimerHandler questionTimerHandler;
		private readonly ViktorinaMain viktorinaMain;
		private readonly AnswerTimerHandler answerTimerHandler;
		private readonly WaitingAgreementPlaySuperGameTimerHandler waitingAgreementPlaySuperGameTimerHandler;
		private readonly WriteProfileBaseTimerHandler writeProfileBaseTimerHandler;


		/**
		 * Methods
		 */

		public void StartQuestionTimer()
		{
            if (!viktorinaMain.GameOn)
            {
                return;
            }
            questionTimerHandler.StartTimer();
		}
		public void StopQuestionTimer()
		{
			questionTimerHandler.StopTimer();
		}
		public void StartAnswerTimer()
		{
			if (!viktorinaMain.GameOn)
			{
				return;
			}
			answerTimerHandler.StartTimer();
		}
		public void StopAnswerTimer()
		{
			answerTimerHandler.StopTimer();
		}
		public void StartWaitingAgreementPlaySuperGameTimer()
		{
			if (!viktorinaMain.GameOn)
			{
				return;
			}
			waitingAgreementPlaySuperGameTimerHandler.StartTimer();
		}
		public void StopWaitingAgreementPlaySuperGameTimer()
		{
			waitingAgreementPlaySuperGameTimerHandler.StopTimer();
		}

		public void StartWriteProfileBaseTimer()
		{
			writeProfileBaseTimerHandler.StartTimer();
		}
		public void StopWriteProfileBaseTimer()
		{
			writeProfileBaseTimerHandler.StopTimer();
		}



		//end of class
	}
}
