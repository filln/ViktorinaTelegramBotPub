// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Суперигра.
 */

using Viktorina.Bot.Timers;
using Viktorina.Bot.Stats;

namespace Viktorina.Bot
{
    class SuperGame
    {
        public SuperGame(ViktorinaMain viktorinaMain, TimersManager timersManager, Configuration configuration, StatsBaseManager statsBaseManager)
        {
            this.viktorinaMain = viktorinaMain;
            this.configuration = configuration;
            this.statsBaseManager = statsBaseManager;
            this.timersManager = timersManager;

            Bet = 0;
            SuperGameOn = false;
            WaitSuperGame = false;
        }

        /**
		 * Variables
		 */
        private readonly ViktorinaMain viktorinaMain;
        private readonly TimersManager timersManager;
        private OutputTextManagerParent OutputTextManager => viktorinaMain.OutputTextManager;
        private readonly Configuration configuration;
        private readonly StatsBaseManager statsBaseManager;

        public int Bet { get; private set; }
        public bool SuperGameOn { get; set; }
        public bool WaitSuperGame { get; private set; }
        //Текущий игрок в суперигру.
        public string Username { get; set; }

        /**
		 * Methods 
		 */

        public void StartSuperGame(string username)
        {
            Username = username;
            timersManager.StopAnswerTimer();
            timersManager.StopQuestionTimer();
            OutputTextManager.OutputOfferSuperGame
                (
                    Username,
                    viktorinaMain.CommandsPrefix,
                    viktorinaMain.CommandsList.YesSuperGame,
                    viktorinaMain.CommandsList.NoSuperGame,
                    configuration.MinPointsSuperGame,
                    configuration.MaxPointsSuperGame,
                    configuration.WaitingAgreementPlaySuperGameInterval,
                    statsBaseManager.statsHandler.GetAllQuestionsAnswered(Username)
                );

            timersManager.StartWaitingAgreementPlaySuperGameTimer();
            WaitSuperGame = true;

        }
        public void ExecuteNoSuperGame(string username)
        {
            if (username != Username)
            {
                return;
            }
            timersManager.StopWaitingAgreementPlaySuperGameTimer();
            OutputTextManager.ExecuteNoSuperGame(Username, statsBaseManager.statsHandler.GetAllQuestionsAnswered(Username));
            SuperGameOn = false;
            WaitSuperGame = false;
            timersManager.StartQuestionTimer();
        }

        public void ExecuteYesSuperGame(string username, int bet)
        {
            if (username != Username)
            {
                return;
            }

            timersManager.StopWaitingAgreementPlaySuperGameTimer();

            if (bet < configuration.MinPointsSuperGame)
            {
                bet = configuration.MinPointsSuperGame;
            }
            if (bet > configuration.MaxPointsSuperGame)
            {
                bet = configuration.MaxPointsSuperGame;
            }
            Bet = bet;
            OutputTextManager.ExecuteYesSuperGame(Username, bet, statsBaseManager.statsHandler.GetAllQuestionsAnswered(Username));
            SuperGameOn = true;
            WaitSuperGame = false;
            timersManager.StartQuestionTimer();
        }

        public void ExecuteStop(string username, string startCommand, int countOfQuestions, int countOfAnswers, TimeSpan duration)
        {
            if (username != Username)
            {
                return;
            }
            statsBaseManager.IncreasePoints(Username, -Bet);
            statsBaseManager.IncreaseSuperGameLoss(Username, Bet);
            OutputTextManager.ExecuteStop(startCommand, countOfQuestions, countOfAnswers, duration);
        }

        public void OutputAnswer(string answer)
        {
            statsBaseManager.IncreasePoints(Username, -Bet);
            statsBaseManager.IncreaseSuperGameLoss(Username, Bet);
            OutputTextManager.OutputAnswerSuperGame
            (
                answer, 
                Username, 
                Bet, 
                statsBaseManager.statsHandler.GetPoints(Username),
                statsBaseManager.statsHandler.GetAllQuestionsAnswered(Username)
            );
        }

        //end of class
    }
}
