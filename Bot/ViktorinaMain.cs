// Copyright 2022 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Главный класс для управления викториной. Создает объекты пространства имен Bot для игрового процесса.
 */

using System.Runtime.Serialization.Formatters.Binary;
using Viktorina.Bot.Timers;
using Viktorina.Bot.Stats;

namespace Viktorina.Bot
{
    public class ViktorinaMain
    {
        public ViktorinaMain(ViktorinaStarter viktorinaStarter)
        {
            this.viktorinaStarter = viktorinaStarter;
            GameOn = false;
            QuestionExists = false;
            hint1 = false;
            hint2 = false;

            //Определить конфигурацию процесса игры.
            configuration = new Configuration();

            //Создать менеджер базы вопросов. В конструкторе определяется необходимый ниже путь для внутренней базы.
            questionsBaseManager = new QuestionsBaseManager(this);

            //Загрузить базу вопросов.
            questionsBaseManager.SetInternalQuestionsBase();

            //Создать объект менеджера статов профиля. В конструкторе создаются объекты для сериализации, заполняются дефолтными значениями.
            //Определяется путь к файлу базы статов. Создается объект управления массивом оригинальных ответов на вопросы данной базы.
            statsBaseManager = new StatsBaseManager(this);

            //Теперь можно запустить все таймеры (там же таймер автозаписи статов на диск).
            timersManager = new TimersManager(this, statsBaseManager, viktorinaStarter);

            commandsHandler = new CommandsHandler(this);
            globalStatsBaseManager = new GlobalStatsBaseManager();
            superGame = new SuperGame(this, timersManager, configuration, statsBaseManager);
            answersInARow = new RightAnswersCountInARow();
            answersInARowForSupergame = new RightAnswersCountInARow();

            statsBaseManager.TryReadData();

            
        }

        /**
		 * Variables
		 */
        private readonly ViktorinaStarter viktorinaStarter;

        private readonly Configuration configuration;
        private readonly QuestionsBaseManager questionsBaseManager;
        private readonly StatsBaseManager statsBaseManager;
        private readonly CommandsHandler commandsHandler;
        private readonly TimersManager timersManager;
        private readonly GlobalStatsBaseManager globalStatsBaseManager;
        private readonly SuperGame superGame;
        private readonly RightAnswersCountInARow answersInARow;
        private readonly RightAnswersCountInARow answersInARowForSupergame;
        public OutputTextManagerParent OutputTextManager => viktorinaStarter.OutputTextManager;
        public CommandsListParent CommandsList => viktorinaStarter.CommandsList;
        public TitlesControlParent TitlesControl => viktorinaStarter.TitlesControl;

        //Время старта игры.
        private DateTime StartTime;
        //Время остановки игры.
        private DateTime StopTime;

        //Маркер выданных подсказок.
        private bool hint1;
        private bool hint2;

        //Маркер запуска игры.
        public bool GameOn { get; private set; }
        //Маркер существования вопроса.
        public bool QuestionExists { get; private set; }

        //Игрок, который запустил игру.
        public string GameStarter { get; private set; }
        /**
		 * ViktorinaStarter variables
		*/
        public string UserDataFolderName => viktorinaStarter.UserDataFolderName;
        public BinaryFormatter Formatter => viktorinaStarter.Formatter;
        public string CurrentLanguage => viktorinaStarter.CurrentLanguage;
        /**
		 * Configuration variables
		 */
        public string OwnerName => configuration.OwnerName;
        public string BotName => configuration.BotName;
        public char CommandsPrefix => configuration.CommandsPrefix;
        public char HintSymbol => configuration.HintSymbol;
        public int AllocatedToAnswerTime => configuration.AllocatedToAnswerTime;
        public int PauseBetweenAnswerAndNewQuestion => configuration.PauseBetweenAnswerAndNewQuestion;
        public int PointsForAnswer => configuration.PointsForAnswer;
        public int PointsForAnswerHint1 => configuration.PointsForAnswerHint1;
        public int PointsForAnswerHint2 => configuration.PointsForAnswerHint2;
        public int RightAnswersCountInARowForSuperGame => configuration.RightAnswersCountInARowForSuperGame;
        public int RightAnswersCountInARowForCongrat { get { return configuration.RightAnswersCountInARowForCongrat; } set { configuration.RightAnswersCountInARowForCongrat = value; } }
        public int MinPointsSuperGame => configuration.MinPointsSuperGame;
        public int WaitingAgreementPlaySuperGameInterval => configuration.WaitingAgreementPlaySuperGameInterval;

        /**
		 * QuestionsBaseManager variables
		 */

        public int CountOfQuestions => questionsBaseManager.CountOfQuestions;
        public string Question => questionsBaseManager.Question;
        public string Answer => questionsBaseManager.Answer;
        public int LineNumber => questionsBaseManager.LineNumber;
        public string InternalQuestionsBasePath => questionsBaseManager.InternalQuestionsBasePath;

        /**
		 * StatsBaseManager variables
		 */
        //

        /**
		 * GlobalStatsBaseManager
		 */

        public int CountOfQuestionsInRound => globalStatsBaseManager.CountOfQuestionsInRound;
        public int CountOfAnswersInRound => globalStatsBaseManager.CountOfAnswersInRound;
        public DateTime LastQuestionTime { get { return globalStatsBaseManager.LastQuestionTime; } set { globalStatsBaseManager.LastQuestionTime = value; } }

        /**
		 * SuperGame
		 */

        //Маркер запуска супер-игры.
        public bool SuperGameOn { get { return superGame.SuperGameOn; } set { superGame.SuperGameOn = value; } }
        public bool WaitSuperGame => superGame.WaitSuperGame;

        /**
		 * Methods
		 */

        public void TakeInputText(string inputText, string username)
        {
            //Если игрок ввел команду.
            if (inputText[0] == CommandsPrefix)
            {
                commandsHandler.HandleCommand(inputText, username);
                return;
            }

            if (GameOn == false)
            {
                return;
            }
            if (!QuestionExists)
            {
                return;
            }
            if (Answer == null)
            {
                return;
            }

            //Если игрок ввел правильный ответ.			
            if (inputText.ToLower() == Answer.ToLower())
            {
                HandleRightAnswer(username);
            }
        }

        //Вызывается, когда игрок правильно ответил на вопрос.
        private void HandleRightAnswer(string username)
        {
            QuestionExists = false;
            
            //Создать игрока в базе, если его нет.
            if(!statsBaseManager.statsHandler.CheckExistsUsername(username))
            {
                statsBaseManager.statsHandler.CreateUser(username);
            }

            globalStatsBaseManager.IncreaseCountOfAnswersInRound();

            //Увеличить количество ответов подряд для суперигры.
            answersInARowForSupergame.IncrCurrentAnswersInARow(username);

            answersInARow.IncrCurrentAnswersInARow(username);
            statsBaseManager.CheckAnswersInARow(username, answersInARow.GetCurrentAnswersInARow());

            statsBaseManager.IncreaseAnswersCount(username);
            //Установить флаг правильного ответа в массиве оригинальных ответов.
            statsBaseManager.statsHandler.AddOriginalAnswer(username, LineNumber);

            int pointsForAnswer;
            bool minIntervalReached;
            string interval;
            (interval, minIntervalReached) = statsBaseManager.GetLastAnswerTimeInterval(DateTime.Now, username);
            string title = statsBaseManager.statsHandler.GetTitle(username);
            //Если суперигры нет.
            if (!SuperGameOn)
            {
                pointsForAnswer = PointsForAnswer;

                //Определить очки за ответ при наличии подсказок.
                if (hint1)
                {
                    pointsForAnswer = PointsForAnswerHint1;
                }
                if (hint2)
                {
                    pointsForAnswer = PointsForAnswerHint2;
                }

                //Определить очки за ответ при наличии бонуса за ответы подряд. Вывести поздравление.
                if ((answersInARow.GetCurrentAnswersInARow() >= RightAnswersCountInARowForCongrat) && !hint2)
                {
                    statsBaseManager.IncreasePoints(username, pointsForAnswer + answersInARow.GetCurrentAnswersInARow());
                    OutputTextManager.OutputCongratOnCorrectAnswer
                        (
                            username,
                            Answer,
                            interval,
                            pointsForAnswer,
                            answersInARow.GetCurrentAnswersInARow(),
                            statsBaseManager.statsHandler.GetPoints(username),
                            statsBaseManager.statsHandler.GetAnswersCount(username),
                            statsBaseManager.statsHandler.GetPointsRound(username),
                            statsBaseManager.statsHandler.GetAnswersCountRound(username),
                            statsBaseManager.statsHandler.GetAllQuestionsAnswered(username),
                            statsBaseManager.statsHandler.GetLastOriginalAnswers(username),
                            title
                        );
                }
                else
                {
                    statsBaseManager.IncreasePoints(username, pointsForAnswer);
                    OutputTextManager.OutputCongratOnCorrectAnswer
                        (
                            username,
                            Answer,
                            interval,
                            pointsForAnswer,
                            0,
                            statsBaseManager.statsHandler.GetPoints(username),
                            statsBaseManager.statsHandler.GetAnswersCount(username),
                            statsBaseManager.statsHandler.GetPointsRound(username),
                            statsBaseManager.statsHandler.GetAnswersCountRound(username),
                            statsBaseManager.statsHandler.GetAllQuestionsAnswered(username),
                            statsBaseManager.statsHandler.GetLastOriginalAnswers(username),
                            title
                        );
                }
            }
            //Если суперигра есть.
            else
            {
                pointsForAnswer = superGame.Bet;
                statsBaseManager.IncreaseSuperGameWins(username, pointsForAnswer);
                statsBaseManager.IncreasePoints(username, pointsForAnswer);
                OutputTextManager.OutputCongratOnCorrectAnswerSuperGame
                    (
                        username,
                        Answer,
                        interval,
                        pointsForAnswer,
                        statsBaseManager.statsHandler.GetPoints(username),
                        statsBaseManager.statsHandler.GetAnswersCount(username),
                        statsBaseManager.statsHandler.GetPointsRound(username),
                        statsBaseManager.statsHandler.GetAnswersCountRound(username),
                        statsBaseManager.statsHandler.GetLastOriginalAnswers(username),
                        statsBaseManager.statsHandler.GetAllQuestionsAnswered(username),
                        title
                    );
            }
            ResetAnswer();
            hint1 = false;
            hint2 = false;

            //Проверить на самый быстрый ответ.
            if (minIntervalReached)
            {
                OutputTextManager.OutputCongratOnMinLastAnswerTimeIntervalReached(username, statsBaseManager.statsHandler.GetAllQuestionsAnswered(username));
            }

            if (answersInARow.GetCurrentAnswersInARow() >= RightAnswersCountInARowForCongrat)
            {
                OutputTextManager.OutputCongratOnRightAnswersInARow(username, answersInARow.GetCurrentAnswersInARow(), statsBaseManager.statsHandler.GetAllQuestionsAnswered(username));
            }
            string newTitle = statsBaseManager.statsHandler.CalcTitle(username);
            if (title != newTitle)
            {
                OutputTextManager.OutputCongratOnNewTitle
                (
                    username, 
                    newTitle, 
                    statsBaseManager.statsHandler.GetAllQuestionsAnswered(username)
                );
                statsBaseManager.statsHandler.SetTitle(username, newTitle);
            }

            //Проверить на возможность последующей суперигры.
            if (!SuperGameOn)
            {
                if (answersInARowForSupergame.GetCurrentAnswersInARow() >= RightAnswersCountInARowForSuperGame)
                {
                    answersInARowForSupergame.ResetCurrentAnswersInARow();
                    superGame.StartSuperGame(username);
                    return;
                }
            }

            SuperGameOn = false;
            timersManager.StopAnswerTimer();
            timersManager.StartQuestionTimer();
        }

        public void OutputQuestion()
        {
            //Остановить игру, если достигнуто количество заданных вопросов.
            if (!SuperGameOn && globalStatsBaseManager.MaxCountOfQuestionsInRound > 0)
            {
                if(globalStatsBaseManager.CountOfQuestionsInRound >= globalStatsBaseManager.MaxCountOfQuestionsInRound)
                {
                    GameOn = false;
                    StopGame(OwnerName);
                    return;
                }
            }
            questionsBaseManager.GetRandomQuestion();
            if (Question == null)
            {
                OutputDebugMessage("ViktrinaBot.OutputQuestion() null");
                return;
            }
            if (Answer == null)
            {
                OutputDebugMessage("ViktorinaBot.OutputQuestion() null");
                return;
            }

            QuestionExists = true;
            LastQuestionTime = DateTime.Now;
            globalStatsBaseManager.IncreaseCountOfQuestionsInRound();
            if (!SuperGameOn)
            {
                OutputTextManager.OutputQuestion(Question, Answer.Length, CountOfQuestionsInRound);
            }
            else
            {
                OutputTextManager.OutputQuestionSuperGame(Question, Answer.Length);
            }

        }

        //Вызывается вывод правильного ответа, когда игрок не дал его.
        public void OutputAnswer()
        {
            if (!SuperGameOn)
            {
                OutputTextManager.OutputAnswer(Answer);
                globalStatsBaseManager.IncreaseCountOfLoseAnswersInRound();
                //Остановить игру, если достигнуто количество неотвеченных вопросов.
                if
                (
                    GameOn
                    && globalStatsBaseManager.CountOfLoseAnswersInRound >= configuration.MaxCountOfLoseAnswersInRound
                )
                {
                    GameOn = false;
                    OutputTextManager.OutputEventOnStopWithLimitLoseAnswers();
                    StopGame(OwnerName);
                }
            }
            else
            {
                superGame.OutputAnswer(Answer);
                string title = statsBaseManager.statsHandler.GetTitle(superGame.Username);
                string newTitle = statsBaseManager.statsHandler.CalcTitle(superGame.Username);
                if (title != newTitle)
                {
                    OutputTextManager.OutputAlertOnDemotionTitle
                        (
                            superGame.Username,
                            newTitle,
                            statsBaseManager.statsHandler.GetAllQuestionsAnswered(superGame.Username)
                        );
                    statsBaseManager.statsHandler.SetTitle(superGame.Username, newTitle);
                }
                SuperGameOn = false;
            }
            ResetAnswer();
            QuestionExists = false;
            hint1 = false;
            hint2 = false;
            answersInARowForSupergame.ResetCurrentAnswersInARow();
            answersInARow.ResetCurrentAnswersInARow();

        }

        public void ExecuteStart(string username, int count)
        {
            if (GameOn)
            {
                return;
            }
            if (questionsBaseManager.ExecuteStart() == false)
            {
                return;
            }
            GameOn = true;
            GameStarter = username;
            globalStatsBaseManager.ResetCountOfQuestionsAndAnswersInRound();
            globalStatsBaseManager.SetMaxCountOfQuestionsInRound(count);
            statsBaseManager.statsHandler.ResetPointsAndAnswersRound();
            timersManager.StartWriteProfileBaseTimer();
            OutputTextManager.ExecuteStart(CountOfQuestions);
            if(count > 0)
            {
                OutputTextManager.OutputEventOnStartWithLimitQuestions(count);
            }
            StartTime = DateTime.Now;
            timersManager.StartQuestionTimer();
        }

        public void ExecuteStop(string username)
        {
            if (!GameOn)
            {
                return;
            }
            if(SuperGameOn)
            {
                return;
            }
            if(username != GameStarter && username != OwnerName)
            {
                return;
            }

            GameOn = false;
            OutputAnswer();
            StopGame(username);
        }
        private void StopGame(string username)
        {
            StopTime = DateTime.Now;
            if (!SuperGameOn)
            {
                OutputTextManager.ExecuteStop(CommandsPrefix + CommandsList.Start, CountOfQuestionsInRound, CountOfAnswersInRound, StopTime - StartTime);
            }
            else
            {
                superGame.ExecuteStop(username, CommandsPrefix + CommandsList.Start, CountOfQuestionsInRound, CountOfAnswersInRound, StopTime - StartTime);
            }
        
            timersManager.StopWriteProfileBaseTimer();
            statsBaseManager.TryWriteData();

            questionsBaseManager.ExecuteStop();
            timersManager.StopWaitingAgreementPlaySuperGameTimer();
            timersManager.StopAnswerTimer();
            timersManager.StopQuestionTimer();
            if(globalStatsBaseManager.CountOfAnswersInRound > 0)
            {
                statsBaseManager.OutputTopRoundPoints();
            }
        }
        public void ExecuteNext(string username)
        {
            if (!GameOn)
            {
                return;
            }
            if (Answer == null)
            {
                return;
            }
            if(!SuperGameOn)
            {
                if (username != GameStarter && username != OwnerName)
                {
                    return;
                }
            }
            else
            {
                if(username != superGame.Username)
                {
                    return;
                }
            }
            OutputAnswer();
            timersManager.StopAnswerTimer();
            timersManager.StartQuestionTimer();
        }

        public void ExecuteHint1(string username)
        {
            if (!GameOn)
            {
                return;
            }
            if (!QuestionExists)
            {
                return;
            }
            if (Answer == null)
            {
                return;
            }
            if (hint1)
            {
                return;
            }
            if (SuperGameOn)
            {
                if (username != superGame.Username)
                {
                    return;
                }
            }

            int hint1VisibleSymbolsCount = configuration.Hint1VisibleSymbolsCount(Answer.Length);
            if (hint1VisibleSymbolsCount != 0)
            {
                string hint1 = questionsBaseManager.ExecuteHint1(hint1VisibleSymbolsCount, HintSymbol);
                OutputTextManager.ExecuteHint(hint1);
            }

            hint1 = true;
        }

        public void ExecuteHint2(string username)
        {
            if (!GameOn)
            {
                return;
            }
            if (!QuestionExists)
            {
                return;
            }
            if (Answer == null)
            {
                return;
            }
            if (!hint1 || hint2)
            {
                return;
            }
            if (SuperGameOn)
            {
                if (username != superGame.Username)
                {
                    return;
                }
            }

            int hint2VisibleSymbolsCount = configuration.Hint2VisibleSymbolsCount(Answer.Length);
            if (hint2VisibleSymbolsCount != 0)
            {
                string hint2 = questionsBaseManager.ExecuteHint2(hint2VisibleSymbolsCount);
                OutputTextManager.ExecuteHint(hint2);
            }

            hint2 = true;
        }

        public void ExecuteProfilesList(string username)
        {
            if (GameOn)
            {
                return;
            }
            if (username != OwnerName)
            {
                return;
            }
            statsBaseManager.ExecuteProfilesList();
        }

        public void ExecuteTopPoints()
        {
            statsBaseManager.ExecuteTopPoints();
        }
        /**
		 * SuperGame
		 */

        public void ExecuteNoSuperGame(string username)
        {
            if (!GameOn || !WaitSuperGame)
            {
                return;
            }
            superGame.ExecuteNoSuperGame(username);
        }
        public void ExecuteYesSuperGame(string username, int bet)
        {
            if (!GameOn || !WaitSuperGame)
            {
                return;
            }
            superGame.ExecuteYesSuperGame(username, bet);
        }

        /**
		 * QuestionsBaseManager
		 */

        private void ResetAnswer()
        {
            questionsBaseManager.ResetAnswer();
        }


        /*
		 * OutputTextManager
		 */

        public void ExecuteHelp()
        {
            OutputTextManager.ExecuteHelp();
        }

        public void OutputHelpAfterLaunch()
        {
            OutputTextManager.OutputHelpAfterLaunch();
            Console.WriteLine("Viktorina launched");
        }

        public void OutputDebugMessage(string outputText)
        {
            OutputTextManager.OutputDebugMessage(outputText);
        }

        public void ExecuteDescription()
        {
            if(GameOn)
            {
                return;
            }
            OutputTextManager.OutputDescription();
        }

        public void ExecuteStat(string username)
        {
            statsBaseManager.ExecuteStat(username);
        }

        public void OutputCongratOnAllQuestionsAnswered(string username)
        {
            OutputTextManager.OutputCongratOnAllQuestionsAnswered(username, statsBaseManager.statsHandler.GetAllQuestionsAnswered(username));
        }

        public void ExecuteClose(string username)
        {
            Console.WriteLine("try close " + username);
            if (username != OwnerName)
            {
                return;
            }
            //OutputTextManager.OutputText("Викторина закрывается.");
            //timersManager.StopWriteProfileBaseTimer();
            //statsBaseManager.TryWriteData();
            //viktorinaStarter.ExecuteClose();
            //Console.WriteLine("close " + username);
        }

        public void CurrentDomain_ProcessExit()
        {
            timersManager.StopWriteProfileBaseTimer();
            statsBaseManager.TryWriteData();
            Console.WriteLine("CurrentDomain_ProcessExit()");
        }

        //end of class
    }
}
