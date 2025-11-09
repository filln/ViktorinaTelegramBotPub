// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Обрабатывает и передает на отображение текст. Белорусский язык.
 */

namespace Viktorina.Bot
{
	class OutputTextManagerBelorussian : OutputTextManagerParent
	{
		public OutputTextManagerBelorussian(ViktorinaStarter viktorinaStarter) : base(viktorinaStarter) { }

		private static OutputTextManagerParent current;
		public static OutputTextManagerParent GetCurrent(ViktorinaStarter viktorinaStarter)
		{
			if (current == null)
			{
				current = new OutputTextManagerBelorussian(viktorinaStarter);
			}
			return current;
		}

		public override void ExecuteHelp()
		{
			OutputText(CreateFormatedText("Дапамога па камандах:"));
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.Help)
				+ " - спіс і апісанне камандаў."
			);
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.Start)
				+ " - запусціць гульню."
			);
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.Stop)
				+ " - спыніць гульню."
			);
			OutputText
			(
				CreateFormatedText(CommandsList.Hint1)
				+ " - першая падказка."
			);
			OutputText
			(
				CreateFormatedText(CommandsList.Hint2)
				+ " - другая падказка."
			);
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.Next)
				+ " - перайсці да наступнага пытання."
			);
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.Stat)
				+ " - статыстыка гульца, які адправіў каманду."
			);
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.TopPoints)
				+ " - спіс лепшых па ачках."
			);
			//OutputText
			//(
			//	CreateFormatedText(OutputCommandsPrefix() + CommandsList.ProfilesList)
			//	+ " - спіс гульцоў са статыстыкай."
			//);
			OutputText
			(
				CreateFormatedText(OutputCommandsPrefix() + CommandsList.Description)
				+ " - апісанне гульні. "
			);
		}
		public override void ExecuteStart(int countOfQuestions)
		{
			//Добро пожаловать на нашу викторину! Начинаем игру. В базе данных countOfQuestions вопросов.
			OutputText
			(
				CreateFormatedText
				(
					"Сардэчна запрашаем на нашу віктарыну! Пачынаем гульню. У базе дадзеных "
					+ countOfQuestions.ToString()
					+ " пытанняў."
				)
			);
		}

		public override void OutputEventOnStartWithLimitQuestions(int maxCountOfQuestionsInRound)
		{
			//Будет дано 5 вопросов.
			OutputText
			(
				"Будзе дадзена "
				+ CreateFormatedText(maxCountOfQuestionsInRound.ToString())
				+ " пытанняў."
			);
		}

		public override void OutputEventOnStopWithLimitLoseAnswers()
		{
			//Достигнут предел неотвеченных вопросов подряд.
			OutputText("Дасягнуты ліміт неадказаных пытанняў запар.", false);
		}

		public override void ExecuteStop
			(
				string startCommand,
				int countOfQuestions,
				int countOfAnswers,
				TimeSpan duration
			)
		{
			//Викторина остановлена. Для запуска напиши startCommand. Всего прозвучало countOfQuestions вопросов.
			//Было дано countOfAnswers правильных ответов. Игра длилась duration.
			//
			OutputText
			(
				"Віктарына спынена. Для запуску напішы "
				+ CreateFormatedText(startCommand)
				+ ". Усяго прагучала "
				+ CreateFormatedText(countOfQuestions.ToString())
				+ " пытанняў. Было дадзена "
				+ CreateFormatedText(countOfAnswers.ToString())
				+ " правільных адказаў. Гульня доўжылася "
				+ CreateFormatedText(duration.ToString("%h"))
				+ " гадзін, "
				+ CreateFormatedText(duration.ToString("%m"))
				+ " хвілін, "
				+ CreateFormatedText(duration.ToString("%s"))
				+ " секундаў."
			);
		}

		protected override string OutputQuestionInternal(string outputText, int answerLength)
		{
			//outputText (answerLength букв)
			return
				CreateFormatedText(outputText)
				+ " ("
				+ CreateFormatedText(answerLength.ToString())
				+ " літар).";
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
				"Ніхто не адказаў на пытанне, слушны адказ быў "
				+ CreateFormatedText(answer)
				+ "."
			);
		}

		public override void ExecuteHint(string hint)
		{
			//Подсказка: hint
			OutputText
			(
				"Падказка: "
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
				+ " не знойдзен."
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
			//Угаданных чисел: 2 (2000 очков)			
			 */

			if (allQuestionsAnswered)
			{
				username = "[[" + username + "]]";
			}
			OutputText
			(
				CreateFormatedText(username)
				+ OutputTitle(title)
				+ ": "
			);

			OutputText
			(
				CreateFormatedText(rightAnswersCount.ToString())
				+ " адказаў ("
				+ CreateFormatedText(points.ToString())
				+ " ачкоў)"
			);

			OutputText
			(
				CreateFormatedText(originalRightAnswersCount.ToString())
				+ " арыгінальных адказаў"
			);

			if (allQuestionsAnswered)
			{
				OutputText
				(
					"]]]]]] "
					+ "Віншуем "
					+ CreateFormatedText(username)
					+ " !!! "
					+ CreateFormatedText(username)
					+ " адказаў на "
					+ CreateFormatedText("ЎСЕ")
					+ " пытанні базы!!!"
					+ " [[[[[["
				);
			}

			OutputText
			(
				CreateFormatedText(rightAnswersCountMonth.ToString())
				+ " адказаў ("
				+ CreateFormatedText(pointsMonth.ToString())
				+ " ачкоў) за месяц"
			);
			OutputText
			(
				CreateFormatedText(rightAnswersCountDay.ToString())
				+ " адказаў ("
				+ CreateFormatedText(pointsDay.ToString())
				+ " ачкоў) за суткі"
			);
			OutputText
			(
				CreateFormatedText(maxRightAnswersCountInARow.ToString())
				+ " адказаў агулам"
			);
			OutputText
			(
				"Самы хуткі адказ - за "
				+ CreateFormatedText(minRightAnswerTimeInterval.ToString())
				+ " секундаў"
			);
			OutputText
			(
				CreateFormatedText(superGameRightAnswersCount.ToString())
				+ " выйграных супергульняў (выйграна "
				+ CreateFormatedText(superGamePoints.ToString())
				+ " ачкоў)"
			);
			OutputText
			(
				CreateFormatedText(superGameLoseCount.ToString())
				+ " прайграных супергульняў (аддадзена "
				+ CreateFormatedText(superGameLosePoints.ToString())
				+ " ачкоў)"
			);
			string begin = beginGameDateTime.ToString("G");
			string last = lastGameDateTime.ToString("G");
			OutputText
			(
				"Пачаў гуляць: "
				+ CreateFormatedText(begin)
			);
			OutputText
			(
				"Апошні раз гуляў: "
				+ CreateFormatedText(last)
			);
		}

		public override void OutputBeginTopPoints()
		{
			//Топ игроков по очкам (внутренняя база вопросов):
			OutputText
			(
				CreateFormatedText("Топ 5 гульцоў па ачках :")
			);
		}

		public override void OutputBeginTopRoundPoints()
		{
			//Топ игроков по очкам за раунд:
			OutputText
			(
				CreateFormatedText("Топ 5 гульцоў па ачках за раўнд :")
			);
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
				+ " ачкоў."
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
					"Малайчына, "
					+ CreateFormatedText(username)
					+ "! Правильный ответ [[ "
					+ CreateFormatedText(answer)
					+ " ]] быў дадзены за "
					+ CreateFormatedText(lastAnswerTimeInterval)
					+ " секундаў і прынёс табе "
					+ CreateFormatedText(pointsIncrease.ToString())
					+ " ачкоў. "
				);
			}
			else
			{
				OutputText
				(
					"Малайчына, "
					+ CreateFormatedText(username)
					+ "! Правильный ответ [[ "
					+ CreateFormatedText(answer)
					+ " ]] быў дадзены за "
					+ CreateFormatedText(lastAnswerTimeInterval)
					+ " секундаў і прынёс табе "
					+ CreateFormatedText(pointsIncrease.ToString())
					+ " ("
					+ CreateFormatedText("+" + bonus.ToString())
					+ ")"
					+ " ачкоў. "
				);
			}
			OutputCongratOnCorrectAnswerBase
				(
					username,
					points,
					answersCount,
					pointsRound,
					answersCountRound,
					originalRightAnswersCount,
					allQuestionsAnswered,
					title
				);
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
				+ " набірае "
				+ CreateFormatedText(points.ToString())
				+ " ачкоў ("
				+ CreateFormatedText(answersCount.ToString())
				+ " адказаў) | "
				+ CreateFormatedText(pointsRound.ToString())
				+ " ачкоў ("
				+ CreateFormatedText(answersCountRound.ToString())
				+ " адказаў) за раўнд | "
				+ CreateFormatedText(originalRightAnswersCount.ToString())
				+ " арыгінальных адказаў."
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
				+ " атрымвае новае званне "
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
				+ " зніжаецца ў званні да "
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
				"І гэта твой самы хуткі адказ, "
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
				+ " адказвае на "
				+ CreateFormatedText(count.ToString())
				+ " пытанняў агулам!"
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
				+ " атрымвае права на "
				+ CreateFormatedText("супергульню")
				+ "! Увядзіце "
				+ CreateFormatedText(commandsPrefix.ToString() + yesCommand)
				+ " стаўка"
				+ ", каб гуляць ці "
				+ CreateFormatedText(commandsPrefix.ToString() + noCommand)
				+ ", каб адмовіцца. Стаўка ад "
				+ CreateFormatedText(minBet.ToString())
				+ " да "
				+ CreateFormatedText(maxBet.ToString())
				+ " ачкоў (па змаўчанні "
				+ CreateFormatedText(minBet.ToString())
				+ "). Калі вы не адкажаце правільна, то страціце ачкі стаўкі. У вас "
				+ CreateFormatedText(intervalForWaitYes.ToString())
				+ " секунд на выбар."
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
				+ " адмаўляецца ад супергульні."
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
				"Супергульня "
				+ "для "
				+ CreateFormatedText(username)
				+ " пачынаецца. Стаўка: "
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
				"Малайчына, "
				+ CreateFormatedText(username)
				+ "! Ты выйграў "
				+ "супергульню"
				+ "! Правільны адказ [[ "
				+ CreateFormatedText(answer)
				+ " ]] быў дадзены за "
				+ CreateFormatedText(lastAnswerTimeInterval.ToString())
				+ " секунд і дазволіў табе выйграць стаўку ў "
				+ CreateFormatedText(pointsIncrease.ToString())
				+ " ачкоў!"
			);

			OutputCongratOnCorrectAnswerBase
				(
					username,
					points,
					answersCount,
					pointsRound,
					answersCountRound,
					originalRightAnswersCount,
					allQuestionsAnswered,
					title
				);
		}

		public override void OutputQuestionSuperGame(string outputText, int answerLength)
		{
			//Вопрос суперигры:
			OutputText
			(
				"Пытанне супергульні: "
			);
			OutputText
			(
				OutputQuestionInternal(outputText, answerLength)
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
					+ " не адказаў на пытанне "
					+ "супергульні"
					+ ", правільны адказ быў "
					+ CreateFormatedText(answer)
					+ ". "
					+ CreateFormatedText(username)
					+ " губляе стаўку "
					+ CreateFormatedText(bet.ToString())
					+ " ачкоў."
				);
			}
			//У Ulv теперь 44731 очков.
			OutputText
			(
				"У "
				+ CreateFormatedText(username)
				+ " зараз "
				+ CreateFormatedText(points.ToString())
				+ " ачкоў."
			);
		}

		public override void OutputDescription()
		{
			/**Viktorina online v.1.
			  Copyright 2022 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.
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

			OutputText("Viktorina online v.1");
			OutputText
			(
				"Copyright 2021 Anatoli Kucharau "
				+ "https://vk.com/ulvprog"
				+ " All Rights Reserved."
			);
			OutputText("Автор программы - Анатолий Кучеров (Ulv).");
			OutputText("Based on eggdrop scripts (IRC) of Viktorina");
			OutputText("1.6 addons by MOSSs");

			OutputText("+ modification by Ulv");
			OutputText("+ some from mrissa.tcl (Based on 3hauka.tcl 2.0.3 by hex and Drakon_) v1.36 (bugsfix) by Maxe_Erte_the_Mad");
			OutputText("+ 3hauka.tcl 2.0.4-stable+php-stat-mod by hex and Drakon_");
			OutputText("+ quiz_q.tcl v1.19 by Kreon (Based on 3hauka.tcl 2.0.4 by hex and Drakon_)");
			OutputText("+ Questions base v.2.7 by Sclex & others.");
			OutputText("Гульня ўяўляе сабою тэкставую віктарыну. Бот задае пытанні, а вы адказваеце на іх.");
			OutputText("Карані гульні растуць з eggdrop (windrop) скрыпту віктарыны, якая працавала на IRC-канале #viktorina_bsatu сеткі " +
				"https://irc.bynets.org"
				);
			OutputText("Канал існаваў прыкладна з 2009 па 2014 год (+/- пары гадоў). Гісторыю канала можна часткова прасачыць на форуме " +
				"https://porovik.forum24.ru");
			OutputText("Уласнікам канала быў аўтар дадзенай праграмы Анатоль Кучараў (пад нікам Ulv), які з'яднаў некалькі падобных скрыптоў віктарыны ў адзін скрыпт, які працаваў тады на тым канале.");
			OutputText("Аўтары скрыптоў і крыніца базы пытанняў дадзены вышэй.");
			OutputText("У дадзеную праграму дададзена некалькі дадатковых магчымасцяў, якія не былі тады рэалізаваны на канале #viktorina_bsatu.");
			OutputText("Паспрабуйце афлайн віктарыну https://filln.itch.io/viktorina-offline");
			OutputText("Наведайце пляцоўку гульні https://vk.com/viktorina_place");
			OutputText("Перакладзена на беларускую мову з дапамогай перакладніка Белазар -[[[ " +
				"http://belazar.info");
			OutputText("Прыемнай гульні!");
		}

		public override void OutputCongratOnAllQuestionsAnswered(string username, bool allQuestionsAnswered)
		{
			// ]]] Поздравляем Ulv!!! Ulv отвечает на ВСЕ вопросы базы questionsBasePath!!! [[[
			// ]]] Поздравляем Ulv!!! Ulv отвечает на ВСЕ вопросы внутренней базы!!! [[[
			if (allQuestionsAnswered)
			{
				username = "[[" + username + "]]";
			}
			OutputText
			(
				"]]]]]] "
				+ "Віншуем "
				+ CreateFormatedText(username)
				+ " !!! "
				+ CreateFormatedText(username)
				+ " адказвае на "
				+ "ЎСЕ"
				+ " пытанні базы!!!"
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
			//OutputText("Для пачатку гульні ўвядзіце !старт у тэкставай падлозе ўводу знізу акна і націсніце Enter.");
			//OutputText("Тамсама ўводзьце адказы на пытанні і іншыя каманды (!, !! - падказкі, !д - наступнае пытанне, !стоп - спыніць гульню і інш.).");
			//OutputText("Увядзіце !дапамога для апісання наяўных камандаў.");
			//OutputText("Увядзіце !апісанне для інфармацыі пра гульню.");
			//OutputText("Прыемнай гульні!");
			OutputText("Віктарына прачнулася!");
		}

		//end of class
	}

}
