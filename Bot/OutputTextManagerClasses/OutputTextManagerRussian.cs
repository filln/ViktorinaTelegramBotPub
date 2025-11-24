// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.



using System.Runtime.InteropServices;
using System.Text;

/**
 * Обрабатывает и передает на отображение текст. Русский язык.
 */
namespace Viktorina.Bot
{
    class OutputTextManagerRussian : OutputTextManagerParent
    {
        public OutputTextManagerRussian(ViktorinaStarter viktorinaStarter) : base(viktorinaStarter) { }

        private static OutputTextManagerParent current;
        public static OutputTextManagerParent GetCurrent(ViktorinaStarter viktorinaStarter)
        {
            if (current == null)
            {
                current = new OutputTextManagerRussian(viktorinaStarter);
            }
            return current;
        }

        public override void ExecuteHelp()
        {
            OutputText(
                CreateFormatedText("Помощь по командам:")
                + "\n"
                +CreateFormatedText(OutputCommandsPrefix() + CommandsList.Help)
                + " (1помощь)"
                + " - список и описание команд."
                + "\n"
                + CreateFormatedText(OutputCommandsPrefix() + CommandsList.Start)
                + " (1старт)"
                + " - запустить игру."
                + "\n"
                + CreateFormatedText(OutputCommandsPrefix() + CommandsList.Stop)
                + " (1стоп)"
                + " - остановить игру."
                + "\n"
                + CreateFormatedText(CommandsList.Hint1)
                + " (1х)"
                + " - первая подсказка."
                + "\n"
                + CreateFormatedText(CommandsList.Hint2)
                + " (11х)"
                + " - вторая подсказка."
                + "\n"
                + CreateFormatedText(OutputCommandsPrefix() + CommandsList.Next)
                + " (1д)"
                + " - перейти к следующему вопросу."
                + "\n"
                + CreateFormatedText(OutputCommandsPrefix() + CommandsList.Stat)
                + " (1стат)"
                + " - статистика игрока, отправившего команду."
                + "\n"
                + CreateFormatedText(OutputCommandsPrefix() + CommandsList.TopPoints)
                + " (1топ)"
                + " - список лучших по очкам."
                + "\n"
                + CreateFormatedText(OutputCommandsPrefix() + CommandsList.Description)
                + " (1описание)"
                + " - описание игры. "
            );

        }
        public override void ExecuteStart(int countOfQuestions)
        {
            //Добро пожаловать на нашу викторину! Начинаем игру. В базе данных countOfQuestions вопросов.
            OutputText
            (
                CreateFormatedText
                (
                    "Добро пожаловать на нашу викторину! Начинаем игру. В базе данных "
                    + countOfQuestions.ToString()
                    + " вопросов."
                )         
            );
        }

        public override void OutputEventOnStartWithLimitQuestions(int maxCountOfQuestionsInRound)
        {
            //Будет дано 5 вопросов.
            OutputText
            (
                "Будет дано "
                + CreateFormatedText(maxCountOfQuestionsInRound.ToString())
                + " вопросов."
            );
        }

        public override void OutputEventOnStopWithLimitLoseAnswers()
        {
            //Достигнут предел неотвеченных вопросов подряд.
            OutputText("Достигнут предел неотвеченных вопросов подряд.", false);
        }
        private string CreateStopStr
            (
                string startCommand,
                int countOfQuestions,
                int countOfAnswers,
                TimeSpan duration
            )
        {
            string stopStr =
                "Викторина остановлена. Для запуска напиши "
                + CreateFormatedText(startCommand)
                + " (1старт)"
                + ". Всего прозвучало "
                + CreateFormatedText(countOfQuestions.ToString())
                + " вопросов. Было дано "
                + CreateFormatedText(countOfAnswers.ToString())
                + " правильных ответов. Игра длилась "
                + CreateFormatedText(duration.ToString("%h"))
                + " часов, "
                + CreateFormatedText(duration.ToString("%m"))
                + " минут, "
                + CreateFormatedText(duration.ToString("%s"))
                + " секунд.";
            return stopStr;
        }
        private string CreateAnswerStr(string answer)
        {
            string outStr =
                "Никто не ответил на вопрос, правильный ответ был "
                + CreateFormatedText(answer)
                + ".";
            return outStr;
        }
        public override void ExecuteStop
            (
                string startCommand,
                int countOfQuestions,
                int countOfAnswers,
                TimeSpan duration,
                string answer
            )
        {
            //Викторина остановлена. Для запуска напиши startCommand. Всего прозвучало countOfQuestions вопросов.
            //Было дано countOfAnswers правильных ответов. Игра длилась duration.
            //
            string stopStr = CreateStopStr
                (
                    startCommand,
                    countOfQuestions,
                    countOfAnswers,
                    duration
                );
            if (answer == null)
            {
                OutputText(stopStr);
            }
            else
            {
                string answerStr = CreateAnswerStr(answer);
                OutputText(answerStr + "\n" + stopStr);
            } 
        }

        protected override string OutputQuestionInternal(string outputText, int answerLength)
        {
            //outputText (answerLength букв)
            return
                CreateFormatedText(outputText)
                + " ("
                + CreateFormatedText(answerLength.ToString())
                + " букв).";
        }
        public override void OutputAnswer(string answer)
        {
            if (answer == null)
            {
                return;
            }
            //Никто не ответил на вопрос, правильный ответ был answer.
            OutputText
            (
                "Никто не ответил на вопрос, правильный ответ был "
                + CreateFormatedText(answer)
                + "."
            );
        }

        public override void ExecuteHint(string hint)
        {
            //Подсказка: hint
            OutputText
            (
                "Подсказка: "
                + CreateFormatedText(hint)
            );
        }

        public override void OutputUsernameAndTitle(string username, string title, bool allQuestionsAnswered)
        {
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                CreateFormatedText(username)
                + OutputTitle(title)
            );
        }

        public override void OutputNotFindUsername(string username)
        {
            OutputText
            (
                CreateFormatedText(username)
                + " не найден."
            );
        }

        public override void OutputStat
            (
                string username,
                int points,
                int rightAnswersCount,
                int pointsMonth,
                int rightAnswersCountMonth,
                int pointsDay,
                int rightAnswersCountDay,
                int superGamePoints,
                int superGameLosePoints,
                int superGameRightAnswersCount,
                int superGameLoseCount,
                double minRightAnswerTimeInterval,
                int maxRightAnswersCountInARow,
                int originalRightAnswersCount,
                bool allQuestionsAnswered,
                DateTime beginGameDateTime,
                DateTime lastGameDateTime,
                string title
            )
        {
            /**
			 * Ulv[title] (база вопросов questionsBasePath):
			 * На счету Ulv уже 12283 ответа (44740 очков)
			 * 10000 оригинальных ответов (из countOfQuestions вопросов)
			 * ( ]]] Поздравляем Ulv!!! Ulv ответил на ВСЕ вопросы базы!!! [[[ )
			 * 17 ответов (76 очков) за месяц
			 * 17 ответов (76 очков) за сутки
			 * 16 ответов подряд 
			 * Самый быстрый ответ - за 1.131 сек.
				478 выигранных суперигр (выиграно 23220 очков)
				258 проигранных суперигр (отдано 12660 очков)
			Начал играть: 6 января 2009 г. (вторник) в 00:53:40. 
			Последний раз играл: 7 декабря 2021 г. (вторник) в 19:54:48.
			 */
            string begin = beginGameDateTime.ToString("G");
            string last = lastGameDateTime.ToString("G");
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                CreateFormatedText(username)
                + OutputTitle(title)
                + ": "
                + "\n"
                + CreateFormatedText(rightAnswersCount.ToString())
                + " ответов ("
                + CreateFormatedText(points.ToString())
                + " очков)"
                + "\n"
                + CreateFormatedText(originalRightAnswersCount.ToString())
                + " оригинальных ответов"
                + "\n"
                + CreateFormatedText(rightAnswersCountMonth.ToString())
                + " ответов ("
                + CreateFormatedText(pointsMonth.ToString())
                + " очков) за месяц"
                + "\n"
                + CreateFormatedText(rightAnswersCountDay.ToString())
                + " ответов ("
                + CreateFormatedText(pointsDay.ToString())
                + " очков) за сутки"
                + "\n"
                + CreateFormatedText(maxRightAnswersCountInARow.ToString())
                + " ответов подряд"
                + "\n"
                + "Самый быстрый ответ - за "
                + CreateFormatedText(minRightAnswerTimeInterval.ToString())
                + " секунд"
                + "\n"
                + CreateFormatedText(superGameRightAnswersCount.ToString())
                + " выигранных суперигр (выиграно "
                + CreateFormatedText(superGamePoints.ToString())
                + " очков), "
                + CreateFormatedText(superGameLoseCount.ToString())
                + " проигранных суперигр (отдано "
                + CreateFormatedText(superGameLosePoints.ToString())
                + " очков)"
                + "\n"
                + "Начал играть: "
                + CreateFormatedText(begin)
                + "\n"
                + "Последний раз играл: "
                + CreateFormatedText(last)

            );
            if (allQuestionsAnswered)
            {
                OutputText
                (
                    "]]]]]] "
                    + "Поздравляем "
                    + CreateFormatedText(username)
                    + " !!! "
                    + CreateFormatedText(username)
                    + " ответил на "
                    + CreateFormatedText("ВСЕ")
                    + " вопросы базы!!!"
                    + " [[[[[["
                );
            }
        }
        public override string CreateBeginTopPointsStr()
        {
            return "Топ 5 игроков:";
        }
        public override void OutputBeginTopPoints()
        {
            //Топ игроков по очкам (внутренняя база вопросов):
            OutputText
            (
                CreateFormatedText("Топ 5 игроков:")
            );
        }
        public override string CreateBeginTopRoundPointsStr()
        {
            return "Топ 5 игроков за раунд:";
        }
        public override void OutputBeginTopRoundPoints()
        {
            //Топ игроков по очкам за раунд:
            OutputText
            (
                CreateFormatedText("Топ 5 игроков за раунд :")
            );
        }
        public override string CreateProfileInTopPointsStr
            (
                int place,
                string username,
                bool allQuestionsAnswered,
                string title,
                int points
            )
        {
            //#1: Ulv звание -[[[ 50 очков.
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            string str =
                "\n"
                + "#"
                + place.ToString()
                + ": "
                + CreateFormatedText(username)
                + OutputTitle(title)
                + " - "
                + CreateFormatedText(points.ToString())
                + " очков.";
            return str;
        }
        public override void OutputProfileInTopPoints
            (
                int place,
                string username,
                bool allQuestionsAnswered,
                string title,
                int points
            )
        {
            //#1: Ulv звание -[[[ 50 очков.
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                "#"
                + place.ToString()
                + ": "
                + CreateFormatedText(username)
                + OutputTitle(title)
                + " - "
                + CreateFormatedText(points.ToString())
                + " очков."
            );
        }

        public override void OutputCongratOnCorrectAnswer
            (
                string username,
                string answer,
                string lastAnswerTimeInterval,
                int pointsIncrease,
                int bonus,
                int points,
                int answersCount,
                int pointsRound,
                int answersCountRound,
                bool allQuestionsAnswered,
                int originalRightAnswersCount,
                string title
            )
        {
            /*
			 * Молодец, Ulv! Правильный ответ [[ вискас ]] был дан за 35.229 секунд и принёс тебе 2 (+12) очков. 
			 * 
			 */
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            if (bonus <= 0)
            {
                OutputText
                (
                    "Молодец, "
                    + CreateFormatedText(username)
                    + "! Правильный ответ [[ "
                    + CreateFormatedText(answer)
                    + " ]] был дан за "
                    + CreateFormatedText(lastAnswerTimeInterval)
                    + " секунд и принёс тебе "
                    + CreateFormatedText(pointsIncrease.ToString())
                    + " очков. "
                    + CreateCorrectAnswerBaseStr
                        (
                            username,
                            points,
                            answersCount,
                            pointsRound,
                            answersCountRound,
                            originalRightAnswersCount,
                            allQuestionsAnswered,
                            title
                        )
                );
            }
            else
            {
                //Console.WriteLine("OutputCongratOnCorrectAnswer3.1");
                OutputText
                (
                    "Молодец, "
                    + CreateFormatedText(username)
                    + "! Правильный ответ [[ "
                    + CreateFormatedText(answer)
                    + " ]] был дан за "
                    + CreateFormatedText(lastAnswerTimeInterval)
                    + " секунд и принёс тебе "
                    + CreateFormatedText(pointsIncrease.ToString())
                    + " ("
                    + CreateFormatedText("+" + bonus.ToString())
                    + ")"
                    + " очков. "
                    + CreateCorrectAnswerBaseStr
                        (
                            username,
                            points,
                            answersCount,
                            pointsRound,
                            answersCountRound,
                            originalRightAnswersCount,
                            allQuestionsAnswered,
                            title
                        )
                );
            }

        }
        private string CreateCorrectAnswerBaseStr
            (
                string username,
                int points,
                int answersCount,
                int pointsRound,
                int answersCountRound,
                int originalRightAnswersCount,
                bool allQuestionsAnswered,
                string title
            )
        {
            string correctAnswerBaseStr =
                "\n"
                + CreateFormatedText(username)
                + OutputTitle(title)
                + " набирает "
                + CreateFormatedText(points.ToString())
                + " очков ("
                + CreateFormatedText(answersCount.ToString())
                + " ответов) | "
                + CreateFormatedText(pointsRound.ToString())
                + " очков ("
                + CreateFormatedText(answersCountRound.ToString())
                + " ответов) за раунд | "
                + CreateFormatedText(originalRightAnswersCount.ToString())
                + " оригинальных ответов.";

            return correctAnswerBaseStr;
        }

        protected override void OutputCongratOnCorrectAnswerBase
            (
            string username,
            int points,
            int answersCount,
            int pointsRound,
            int answersCountRound,
            int originalRightAnswersCount,
            bool allQuestionsAnswered,
            string title
            )
        {
            /*
			* 
			* Ulv[title] набирает 44667 очков (12267 ответов) | 2 очков (1 ответов) за раунд | 10000 оригинальных ответов. 
			*/

            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                CreateFormatedText(username)
                + OutputTitle(title)
                + " набирает "
                + CreateFormatedText(points.ToString())
                + " очков ("
                + CreateFormatedText(answersCount.ToString())
                + " ответов) | "
                + CreateFormatedText(pointsRound.ToString())
                + " очков ("
                + CreateFormatedText(answersCountRound.ToString())
                + " ответов) за раунд | "
                + CreateFormatedText(originalRightAnswersCount.ToString())
                + " оригинальных ответов."
            );
        }

        public override void OutputCongratOnNewTitle(string username, string title, bool allQuestionsAnswered)
        {
            //Ulv получает новое звание title!
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }

            OutputText
            (
                CreateFormatedText(username)
                + " получает новое звание "
                + OutputTitle(title)
                + "!"
            );
        }
        public override void OutputAlertOnDemotionTitle(string username, string title, bool allQuestionsAnswered)
        {
            //Ulv понижается в звании до title!
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                CreateFormatedText(username)
                + " понижается в звании до "
                + OutputTitle(title)
                + "!"
            );
        }
        public override void OutputCongratOnMinLastAnswerTimeIntervalReached(string username, bool allQuestionsAnswered)
        {
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                "И это твой самый быстрый ответ, "
                + CreateFormatedText(username)
                + "!"
            );
        }

        public override void OutputCongratOnRightAnswersInARow(string username, int count, bool allQuestionsAnswered)
        {
            //Ulv отвечает на 4 вопроса подряд!
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                CreateFormatedText(username)
                + " отвечает на "
                + CreateFormatedText(count.ToString())
                + " вопросов подряд!"
            );
        }

        public override void OutputOfferSuperGame
            (
            string username,
            char commandsPrefix,
            string yesCommand,
            string noCommand,
            int minBet,
            int maxBet,
            int intervalForWaitYes,
            bool allQuestionsAnswered
            )
        {
            //Ulv получает право на суперигру! Введите !да ставка, чтобы играть или !нет, чтобы отказаться.
            //Ставка от 10 до 50 очков (по умолчанию 10). Если вы не ответите правильно, то потеряете очки ставки.
            //У вас 25 секунд на выбор.

            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }

            OutputText
            (
                CreateFormatedText(username)
                + " получает право на "
                + CreateFormatedText("суперигру")
                + "! Введите "
                + CreateFormatedText(commandsPrefix.ToString() + yesCommand)
                + " ставка"
                + ", чтобы играть или "
                + CreateFormatedText(commandsPrefix.ToString() + noCommand)
                + ", чтобы отказаться. Ставка от "
                + CreateFormatedText(minBet.ToString())
                + " до "
                + CreateFormatedText(maxBet.ToString())
                + " очков (по умолчанию "
                + CreateFormatedText(minBet.ToString())
                + "). Если вы не ответите правильно, то потеряете очки ставки. У вас "
                + CreateFormatedText(intervalForWaitYes.ToString())
                + " секунд на выбор."
            );
        }

        public override void ExecuteNoSuperGame(string username, bool allQuestionsAnswered)
        {
            //Ulv отказывается от суперигры.
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                CreateFormatedText(username)
                + " отказывается от суперигры."
            );
        }
        public override void ExecuteYesSuperGame(string username, int bet, bool allQuestionsAnswered)
        {
            //Суперигра для Ulv начинается. Ставка: 10
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                "Суперигра "
                + "для "
                + CreateFormatedText(username)
                + " начинается. Ставка: "
                + CreateFormatedText(bet.ToString())
                + "."
            );
        }

        public override void OutputCongratOnCorrectAnswerSuperGame
        (
            string username,
            string answer,
            string lastAnswerTimeInterval,
            int pointsIncrease,
            int points,
            int answersCount,
            int pointsRound,
            int answersCountRound,
            int originalRightAnswersCount,
            bool allQuestionsAnswered,
            string title
        )
        {
            //Молодец, Ulv! Ты выиграл суперигру! Правильный ответ [[ экзот ]] был дан за 5 секунд и позволил тебе выиграть ставку в 48 очков!

            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                "Молодец, "
                + CreateFormatedText(username)
                + "! Ты выиграл "
                + "суперигру"
                + "! Правильный ответ [[ "
                + CreateFormatedText(answer)
                + " ]] был дан за "
                + CreateFormatedText(lastAnswerTimeInterval.ToString())
                + " секунд и позволил тебе выиграть ставку в "
                + CreateFormatedText(pointsIncrease.ToString())
                + " очков!"
                + CreateCorrectAnswerBaseStr
                    (
                        username,
                        points,
                        answersCount,
                        pointsRound,
                        answersCountRound,
                        originalRightAnswersCount,
                        allQuestionsAnswered,
                        title
                    )
            );
        }

        public override void OutputQuestionSuperGame(string outputText, int answerLength)
        {
            //Вопрос суперигры:
            OutputText
            (
                "Вопрос суперигры: "
                + "\n"
                + OutputQuestionInternal(outputText, answerLength)
            );            
        }

        public override void OutputAnswerSuperGame(string answer, string username, int bet, int points, bool allQuestionsAnswered)
        {
            //Ulv не ответил на вопрос суперигры, правильный ответ был ялапа. Ulv теряет ставку 10 очков.
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            if (answer != null)
            {
                OutputText
                (
                    CreateFormatedText(username)
                    + " не ответил на вопрос "
                    + "суперигры"
                    + ", правильный ответ был "
                    + CreateFormatedText(answer)
                    + ". "
                    + CreateFormatedText(username)
                    + " теряет ставку "
                    + CreateFormatedText(bet.ToString())
                    + " очков."
                );
            }

            //У Ulv теперь 44731 очков.
            OutputText
            (
                "У "
                + CreateFormatedText(username)
                + " теперь "
                + CreateFormatedText(points.ToString())
                + " очков."
            );
        }

        public override void OutputDescription()
        {
            /**Viktorina online v.1.
			  Copyright 2022 Anatoli Kucharau https://vk.com/viktorina_place. All Rights Reserved.
			  Автор программы - Анатолий Кучеров.
			  
			  Based on eggdrop scripts (IRC) of Viktorina
			1.6 addons by MOSSs 
			+ modification by Ulv 
			+ some from mrissa.tcl (Based on 3hauka.tcl 2.0.3 by hex and Drakon_) v1.36 (bugsfix) by Maxe_Erte_the_Mad 
			+ 3hauka.tcl 2.0.4-stable+php-stat-mod by hex and Drakon_ 
			+ quiz_q.tcl v1.19 by Kreon (Based on 3hauka.tcl 2.0.4 by hex and Drakon_)
			+ Questions base by Sclex & others.

			  Игра представляет собой текстовую викторину. Бот задает вопросы, а вы отвечаете на них.
			  Корни игры растут из eggdrop (windrop) скрипта викторины, которая работала на IRC-канале #viktorina_bsatu сети https://irc.bynets.org  
			  Канал существовал примерно с 2009 по 2014 год (+/- пару лет). Историю канала можно частично проследить на форуме https://porovik.forum24.ru
			  Владельцем канала был автор данной программы Анатолий Кучеров (под ником Ulv), который объединил несколько похожих скриптов викторины в один скрипт, который работал тогда 
			  на том канале. 
			  Авторы скриптов и источник базы вопросов даны выше.
			  В данную программу добавлено несколько дополнительных возможностей, которые не были тогда реализованы на канале #viktorina_bsatu.
              Попробуйте оффлайн викторину https://filln.itch.io/viktorina-offline
              Посетите площадку игры https://vk.com/viktorina_place
			  Приятной игры!
			 */

            OutputText
            (
                "Viktorina online v.1"
                + "\n"
                + "Copyright 2021 Anatoli Kucharau "
                + "https://vk.com/viktorina_place"
                + " All Rights Reserved."
                + "\n"
                + "Автор программы - Анатолий Кучеров (Ulv)."
                + "\n"
                + "Based on eggdrop scripts (IRC) of Viktorina 1.6 addons by MOSSs"
                + "\n"
                + "+ modification by Ulv"
                + "\n"
                + "+ some from mrissa.tcl (Based on 3hauka.tcl 2.0.3 by hex and Drakon_) v1.36 (bugsfix) by Maxe_Erte_the_Mad"
                + "\n"
                + "+ 3hauka.tcl 2.0.4-stable+php-stat-mod by hex and Drakon_"
                + "\n"
                + "+ quiz_q.tcl v1.19 by Kreon (Based on 3hauka.tcl 2.0.4 by hex and Drakon_)"
                + "\n"
                + "+ база вопросов v.2.7 от Sclex и других."
                + "\n"
                + "Игра представляет собой текстовую викторину. Бот задает вопросы, а вы отвечаете на них."
                + "\n"
                + "Корни игры растут из eggdrop (windrop) скрипта викторины, которая работала на IRC-канале #viktorina_bsatu сети https://irc.bynets.org"
                + "\n"
                + "Канал существовал примерно с 2009 по 2014 год (+/- пару лет). Историю канала можно частично проследить на форуме https://porovik.forum24.ru"
                + "\n"
                + "Владельцем канала был автор данной программы Анатолий Кучеров (под ником Ulv), который объединил несколько похожих скриптов викторины в один скрипт, который работал тогда на том канале."
                + "\n"
                + "Авторы скриптов и источник базы вопросов даны выше."
                + "\n"
                + "В данную программу добавлено несколько дополнительных возможностей, которые не были тогда реализованы на канале #viktorina_bsatu."
                + "\n"
                + "Попробуйте оффлайн викторину filln.itch.io/viktorina-offline для Windows и rustore.ru/catalog/app/com.ID3964234.viktorina для Android"
                + "\n"
                + "Посетите площадку игры vk.com/viktorina_place"
                + "\n" 
                + "Приятной игры!"
                , true
            );
        }

        public override void OutputCongratOnAllQuestionsAnswered(string username, bool allQuestionsAnswered)
        {
            // ]]] Поздравляем Ulv!!! Ulv отвечает на ВСЕ вопросы базы!!! [[[
            if (allQuestionsAnswered)
            {
                username = "[[" + username + "]]";
            }
            OutputText
            (
                "]]]]]] "
                + "Поздравляем "
                + CreateFormatedText(username)
                + " !!! "
                + CreateFormatedText(username)
                + " отвечает на "
                + "ВСЕ"
                + " вопросы базы!!!"
                + " [[[[[["
            );
        }
 
        public override void OutputHelpAfterLaunch()
        {
            /**
			 * Viktorina offline v.1.1.
			 * Для начала игры введите !старт в текстовом поле ввода снизу окна и нажмите Enter. 
			 * Там же вводите ответы на вопросы и другие команды (!, !! - подсказки, !д - следующий вопрос, !стоп - остановить игру и др.). 
			 * Введите !помощь для описания имеющихся команд. 
			 * Загляните в раздел "Описание".
			 * Приятной игры!
			 */
            //OutputText("Viktorina online v.1.");
            //OutputText("Для начала игры введите !старт в текстовом поле ввода снизу окна и нажмите Enter.");
            //OutputText("Там же вводите ответы на вопросы и другие команды (!, !! - подсказки, !д - следующий вопрос, !стоп - остановить игру и др.).");
            //OutputText("Введите !помощь для описания имеющихся команд.");
            //OutputText("Введите !описание для информации об игре.");
            //OutputText("Приятной игры!");
            OutputText("Викторина запустилась!");
        }




        //end of class
    }

}
