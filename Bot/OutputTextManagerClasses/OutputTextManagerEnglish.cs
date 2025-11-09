// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Обрабатывает и передает на отображение текст. Английский язык.
 */

namespace Viktorina.Bot
{
	class OutputTextManagerEnglish //: OutputTextManagerParent
	{
		//public OutputTextManagerEnglish(ViktorinaStarter viktorinaStarter) : base(viktorinaStarter) { }

		//private static OutputTextManagerParent current;
		//public static OutputTextManagerParent GetCurrent(ViktorinaStarter viktorinaStarter)
		//{
		//	if (current == null)
		//	{
		//		current = new OutputTextManagerEnglish(viktorinaStarter);
		//	}
		//	return current;
		//}

		//public override void ExecuteHelp()
		//{
		//	OutputText(CreateFormatedText("Help by commands:"));
		//	OutputText
		//	(
		//		CreateFormatedText(OutputCommandsPrefix() + CommandsList.Help)
		//		+ " - list and description of commands."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(OutputCommandsPrefix() + CommandsList.Start)
		//		+ " - start the game."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(OutputCommandsPrefix() + CommandsList.Stop)
		//		+ " - stop the game."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(CommandsList.Hint1)
		//		+ " - first hint."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(CommandsList.Hint2)
		//		+ " - second hint."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(OutputCommandsPrefix() + CommandsList.Next)
		//		+ " - go to the next question."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(OutputCommandsPrefix() + CommandsList.Stat)
		//		+ " - statistics of the player who sent the command."
		//	);
		//	OutputText
		//	(
		//		CreateFormatedText(OutputCommandsPrefix() + CommandsList.TopPoints)
		//		+ " - the top points list."
		//	);
		////	OutputText
		////	(
		////		CreateFormatedText(OutputCommandsPrefix() + CommandsList.ProfilesList)
		////		+ " - list of players with statistics."
		////	);
		//}
		//public override void ExecuteStart(int countOfQuestions)
		//{
		//	//Добро пожаловать на нашу викторину! Начинаем игру. В базе данных countOfQuestions вопросов.
		//	OutputText
		//	(
		//		CreateFormatedText
		//		(
		//			"Welcome to our quiz! Let's start the game. In the database "
		//			+ countOfQuestions.ToString()
		//			+ " questions."
		//		)
		//	);
		//}

		//public override void OutputEventOnStartWithLimitQuestions(int maxCountOfQuestionsInRound)
		//{
		//	//Будет дано 5 вопросов.
		//	OutputText
		//	(
		//		"Будет дано "
		//		+ CreateFormatedText(maxCountOfQuestionsInRound.ToString())
		//		+ " вопросов."
		//	);
		//}

		//public override void OutputEventOnStopWithLimitLoseAnswers()
		//{
		//	//Достигнут предел неотвеченных вопросов подряд.
		//	OutputText("Дасягнуты ліміт неадказаных пытанняў запар.", false);
		//}

		//public override void ExecuteStop
		//	(
		//		string startCommand,
		//		int countOfQuestions,
		//		int countOfAnswers,
		//		TimeSpan duration
		//	)
		//{
		//	//Викторина остановлена. Для запуска напиши startCommand. Всего прозвучало countOfQuestions вопросов.
		//	//Было дано countOfAnswers правильных ответов. Игра длилась duration.
		//	//

		//	OutputTimeAndBotName();
		//	OutputText("The quiz is stopped. To start it, write ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(startCommand, Brushes.Green, FontWeights.Bold);
		//	OutputText(". Total sounded ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(countOfQuestions.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" questions. was given ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(countOfAnswers.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" correct answers. The game duration ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(duration.ToString("%h"), Brushes.Green, FontWeights.Bold);
		//	OutputText(" hours, ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(duration.ToString("%m"), Brushes.Green, FontWeights.Bold);
		//	OutputText(" minutes, ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(duration.ToString("%s"), Brushes.Green, FontWeights.Bold);
		//	OutputText(" seconds.", Brushes.SteelBlue, FontWeights.Normal);

		//}

		//protected override void OutputQuestionInternal(string outputText, int answerLength)
		//{
		//	//outputText (answerLength букв)
		//	OutputText(outputText, Brushes.Orange, FontWeights.Normal);
		//	OutputText(" (", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(answerLength.ToString(), Brushes.DarkOrange, FontWeights.Normal);
		//	OutputText(" letters).", Brushes.SteelBlue, FontWeights.Normal);
		//}
		//public override void OutputAnswer(string answer)
		//{
		//	if (answer == null)
		//	{
		//		return;
		//	}
		//	//Никто не ответил на вопрос, правильный ответ был answer.
		//	OutputTimeAndBotName();
		//	OutputText("No one answered the question, the correct answer was ", Brushes.Green, FontWeights.Normal);
		//	OutputText(answer, Brushes.Red, FontWeights.Bold);
		//	OutputText(".", Brushes.Green, FontWeights.Normal);
		//}

		//public override void ExecuteHint(string hint)
		//{
		//	//Подсказка: hint
		//	OutputTimeAndBotName();
		//	OutputText("Hint: ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(hint, Brushes.Red, FontWeights.Normal);
		//}

		//public override void OutputUsernameAndTitle(string username, string title, bool allQuestionsAnswered)
		//{
		//	if (allQuestionsAnswered)
		//	{
		//		username = "[[" + username + "]]";
		//	}
		//	OutputText
		//	(
		//		CreateFormatedText(username)
		//		+ OutputTitle(title)
		//	);
		//}

		//public override void OutputNotFindUsername(string username)
		//{
		//	OutputText
		//	(
		//		CreateFormatedText(username)
		//		+ " не знойдзен."
		//	);
		//}

		//public override void OutputStat
		//	(
		//		string profileName,
		//		string questionsBasePath,
		//		int points,
		//		int rightAnswersCount,
		//		int pointsMonth,
		//		int rightAnswersCountMonth,
		//		int pointsDay,
		//		int rightAnswersCountDay,
		//		int superGamePoints,
		//		int superGameLosePoints,
		//		int superGameRightAnswersCount,
		//		int superGameLoseCount,
		//		double minRightAnswerTimeInterval,
		//		int maxRightAnswersCountInARow,
		//		int originalRightAnswersCount,
		//		int countOfQuestions,
		//		DateTime beginGameDateTime,
		//		DateTime lastGameDateTime,
		//		string internalQuestionsBasePath,
		//		string title
		//	)
		//{
		//	/**
		//	 * Ulv[title] (база вопросов questionsBasePath):
		//	 * На счету Ulv уже 12283 ответа (44740 очков)
		//	 * 10000 оригинальных ответов (из countOfQuestions вопросов)
		//	 * ( <<< Поздравляем Ulv!!! Ulv ответил на ВСЕ вопросы базы!!! >>> )
		//	 * 17 ответов (76 очков) за месяц
		//	 * 17 ответов (76 очков) за сутки
		//	 * 16 ответов подряд 
		//	 * Самый быстрый ответ - за 1.131 сек.
		//		478 выигранных суперигр (выиграно 23220 очков)
		//		258 проигранных суперигр (отдано 12660 очков)
		//	Начал играть: 6 января 2009 г. (вторник) в 00:53:40. 
		//	Последний раз играл: 7 декабря 2021 г. (вторник) в 19:54:48.
		//	//Угаданных чисел: 2 (2000 очков)			
		//	 */
		//	bool allQuestionsAnswered = originalRightAnswersCount == countOfQuestions;
		//	OutputTimeAndBotName();
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Bold);
		//	OutputTitle(title);
		//	OutputQuestionsBase(questionsBasePath, internalQuestionsBasePath);
		//	OutputText(": ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText("On account ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Bold);
		//	OutputText(" already ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(rightAnswersCount.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" answers (", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(points.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText("points)", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText(originalRightAnswersCount.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" original answers (from ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(countOfQuestions.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" questions)", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	if (allQuestionsAnswered)
		//	{
		//		OutputText("<]<]<] ", Brushes.OrangeRed, FontWeights.ExtraBold);
		//		OutputText("Congratulations", Brushes.DodgerBlue, FontWeights.Bold);
		//		OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.UltraBold);
		//		OutputText(" !!! ", Brushes.DodgerBlue, FontWeights.Bold);
		//		OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.UltraBold);
		//		OutputText(" answered ", Brushes.DodgerBlue, FontWeights.Bold);
		//		OutputText("ALL", Brushes.Crimson, FontWeights.UltraBold);
		//		OutputText(" questions ", Brushes.DodgerBlue, FontWeights.Bold);
		//		OutputText("bases", Brushes.DodgerBlue, FontWeights.Bold);
		//		OutputText("!!!", Brushes.DodgerBlue, FontWeights.Bold);
		//		OutputText(" [>[>[>", Brushes.OrangeRed, FontWeights.ExtraBold);
		//		OutputLineBreak();
		//	}

		//	OutputText(rightAnswersCountMonth.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" answers (", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(pointsMonth.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" points) for the month", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText(rightAnswersCountDay.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" answers (", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(pointsDay.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" points) per day", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText(maxRightAnswersCountInARow.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" answers in a row", Brushes.SteelBlue, FontWeights.Normal);

		//	OutputLineBreak();
		//	OutputText("The fastest answer is for ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(minRightAnswerTimeInterval.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" seconds", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText(superGameRightAnswersCount.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" supergames won (won ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(superGamePoints.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" points)", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText(superGameLoseCount.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" supergames losed (give away ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(superGameLosePoints.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" points)", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputLineBreak();

		//	OutputText("Started playing: ", Brushes.SteelBlue, FontWeights.Normal);
		//	string begin = beginGameDateTime.ToString("G");
		//	OutputText(begin, Brushes.Green, FontWeights.Bold);
		//	OutputLineBreak();
		//	string last = lastGameDateTime.ToString("G");
		//	OutputText("Last played: ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(last, Brushes.Green, FontWeights.Bold);

		//}

		//public override void OutputBeginTopPoints(string questionsBasePath, string internalQuestionsBasePath)
		//{
		//	//Топ 5 игроков по очкам (внутренняя база вопросов):
		//	OutputTimeAndBotName();
		//	OutputText("Best players in counting points ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputQuestionsBase(questionsBasePath, internalQuestionsBasePath);
		//	OutputText(":", Brushes.SteelBlue, FontWeights.Normal);
		//}

		//public override void OutputBeginTopRoundPoints()
		//{
		//	//Топ 5 игроков по очкам за раунд:
		//	OutputText
		//	(
		//		CreateFormatedText("Best 5 players in counting points by round :")
		//	);
		//}

		//public override void OutputProfileInTopPoints
		//	(
		//		int place,
		//		string profileName,
		//		int originalRightAnswersCount,
		//		int countOfQuestions,
		//		string title,
		//		int points
		//	)
		//{
		//	//#1: Ulv звание -->> 50 очков.
		//	OutputLineBreak();
		//	OutputText("#", Brushes.Green, FontWeights.Normal);
		//	OutputText(place.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(": ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Normal);
		//	OutputTitle(title);
		//	OutputText(" -->> ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(points.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" points.", Brushes.SteelBlue, FontWeights.Normal);
		//}

		//public override void OutputCongratOnCorrectAnswer
		//	(
		//		string profileName,
		//		string answer,
		//		string lastAnswerTimeInterval,
		//		int pointsIncrease,
		//		int bonus,
		//		int points,
		//		int answersCount,
		//		int pointsRound,
		//		int answersCountRound,
		//		int originalRightAnswersCount,
		//		int countOfQuestions,
		//		string title
		//	)
		//{
		//	/*
		//	 * Молодец, Ulv! Правильный ответ -> вискас <- был дан за 35.229 секунд и принёс тебе 2 (+12) очков. 
		//	 * 
		//	 */
		//	OutputTimeAndBotName();
		//	OutputText("Well done, ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Normal);
		//	OutputText("! Correct answer -> ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(answer, Brushes.Red, FontWeights.Bold);
		//	OutputText(" <- was given for ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(lastAnswerTimeInterval, Brushes.Green, FontWeights.Bold);
		//	OutputText(" seconds and give you ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(pointsIncrease.ToString(), Brushes.Green, FontWeights.Bold);
		//	if (bonus > 0)
		//	{
		//		OutputText(" (", Brushes.SteelBlue, FontWeights.Normal);
		//		OutputText("+", Brushes.HotPink, FontWeights.Normal);
		//		OutputText(bonus.ToString(), Brushes.HotPink, FontWeights.Bold);
		//		OutputText(")", Brushes.SteelBlue, FontWeights.Normal);
		//	}
		//	OutputText(" points. ", Brushes.SteelBlue, FontWeights.Normal);

		//	OutputCongratOnCorrectAnswerBase
		//		(
		//			profileName,
		//			points,
		//			answersCount,
		//			pointsRound,
		//			answersCountRound,
		//			originalRightAnswersCount,
		//			title,
		//			CalcProfileNameColor(countOfQuestions, originalRightAnswersCount)
		//		);

		//}

		//protected override void OutputCongratOnCorrectAnswerBase
		//	(
		//	string profileName,
		//	int points,
		//	int answersCount,
		//	int pointsRound,
		//	int answersCountRound,
		//	int originalRightAnswersCount,
		//	string title,
		//	SolidColorBrush profileBrush
		//	)
		//{
		//	/*
		//	* 
		//	* Ulv[title] набирает 44667 очков (12267 ответов) | 2 очков (1 ответов) за раунд | 10000 оригинальных ответов. 
		//	*/

		//	OutputLineBreak();
		//	OutputText(profileName, profileBrush, FontWeights.Normal);
		//	OutputTitle(title);
		//	OutputText(" scores ", Brushes.SteelBlue, FontWeights.Normal);

		//	OutputText(points.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText("points(", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(answersCount.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" answers) | ", Brushes.SteelBlue, FontWeights.Normal);

		//	OutputText(pointsRound.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText("points(", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(answersCountRound.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" answers) per round | ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(originalRightAnswersCount.ToString(), Brushes.Tomato, FontWeights.UltraBold);
		//	OutputText(" original answers.", Brushes.SteelBlue, FontWeights.Normal);
		//}

		//public override void OutputCongratOnNewTitle(string profileName, string title, int originalRightAnswersCount, int countOfQuestions)
		//{
		//	//Ulv получает новое звание title!
		//	OutputTimeAndBotName();
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Normal);
		//	OutputText(" gets a new rank ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputTitle(title);
		//	OutputText("!", Brushes.SteelBlue, FontWeights.Normal);
		//}
		//public override void OutputAlertOnDemotionTitle(string profileName, string title, int originalRightAnswersCount, int countOfQuestions)
		//{
		//	//Ulv понижается в звании до title!
		//	OutputTimeAndBotName();
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Normal);
		//	OutputText(" is demoted to the rank of ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputTitle(title);
		//	OutputText("!", Brushes.SteelBlue, FontWeights.Normal);
		//}
		//public override void OutputCongratOnMinLastAnswerTimeIntervalReached(string profileName)
		//{
		//	OutputTimeAndBotName();
		//	OutputText("And that's your fastest answer, ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(profileName, Brushes.DarkOrange, FontWeights.Normal);
		//	OutputText("!", Brushes.SteelBlue, FontWeights.Normal);
		//}

		//public override void OutputCongratOnRightAnswersInARow(string profileName, int count)
		//{
		//	//Ulv отвечает на 4 вопроса подряд!

		//	OutputTimeAndBotName();
		//	OutputText(profileName, Brushes.HotPink, FontWeights.Normal);
		//	OutputText(" answers to ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(count.ToString(), Brushes.HotPink, FontWeights.Bold);
		//	OutputText(" questions in a row!", Brushes.SteelBlue, FontWeights.Normal);
		//}

		//public override void OutputOfferSuperGame
		//	(
		//	string profileName,
		//	char commandsPrefix,
		//	string yesCommand,
		//	string noCommand,
		//	int minBet,
		//	int maxBet,
		//	int intervalForWaitYes
		//	)
		//{
		//	//Ulv получает право на суперигру! Введите !да ставка, чтобы играть или !нет, чтобы отказаться.
		//	//Ставка от 10 до 50 очков (по умолчанию 10). Если вы не ответите правильно, то потеряете очки ставки.
		//	//У вас 25 секунд на выбор.

		//	OutputTimeAndBotName();
		//	OutputText(profileName, Brushes.Magenta, FontWeights.Normal);
		//	OutputText(" gets the right to ", Brushes.Green, FontWeights.Normal);
		//	OutputText("supergame", Brushes.Magenta, FontWeights.Bold);
		//	OutputText("! Enter ", Brushes.Green, FontWeights.Normal);
		//	OutputText(commandsPrefix.ToString() + yesCommand, Brushes.Magenta, FontWeights.Normal);
		//	OutputText(" bet", Brushes.Red, FontWeights.Normal);
		//	OutputText(" to play or ", Brushes.Green, FontWeights.Normal);
		//	OutputText(commandsPrefix.ToString() + noCommand, Brushes.Magenta, FontWeights.Normal);
		//	OutputText(" to refuse. Rate from ", Brushes.Green, FontWeights.Normal);
		//	OutputText(minBet.ToString(), Brushes.Red, FontWeights.Normal);
		//	OutputText(" to ", Brushes.Green, FontWeights.Normal);
		//	OutputText(maxBet.ToString(), Brushes.Red, FontWeights.Normal);
		//	OutputText(" points (default ", Brushes.Green, FontWeights.Normal);
		//	OutputText(minBet.ToString(), Brushes.Red, FontWeights.Normal);
		//	OutputText("). If you don't answer correctly, you lose bet points. You have ", Brushes.Green, FontWeights.Normal);
		//	OutputText(intervalForWaitYes.ToString(), Brushes.Magenta, FontWeights.Normal);
		//	OutputText(" seconds to select.", Brushes.Green, FontWeights.Normal);
		//}

		//public override void ExecuteNoSuperGame(string profileName)
		//{
		//	//Ulv отказывается от суперигры.
		//	OutputTimeAndBotName();
		//	OutputText(profileName, Brushes.Green, FontWeights.Normal);
		//	OutputText(" refuses to supergame.", Brushes.SteelBlue, FontWeights.Normal);
		//}
		//public override void ExecuteYesSuperGame(string profileName, int bet)
		//{
		//	//Суперигра для Ulv начинается. Ставка: 10

		//	OutputTimeAndBotName();
		//	OutputText("Supergame ", Brushes.Magenta, FontWeights.Bold);
		//	OutputText("for ", Brushes.Green, FontWeights.Normal);
		//	OutputText(profileName, Brushes.Magenta, FontWeights.Normal);
		//	OutputText(" starts. Bet: ", Brushes.Green, FontWeights.Normal);
		//	OutputText(bet.ToString(), Brushes.Red, FontWeights.Normal);
		//	OutputText(".", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputCongratOnCorrectAnswerSuperGame
		//(
		//	string profileName,
		//	string answer,
		//	string lastAnswerTimeInterval,
		//	int pointsIncrease,
		//	int points,
		//	int answersCount,
		//	int pointsRound,
		//	int answersCountRound,
		//	int originalRightAnswersCount,
		//	int countOfQuestions,
		//	string title
		//)
		//{
		//	//Молодец, Ulv! Ты выиграл суперигру! Правильный ответ -> экзот <- был дан за 5 секунд и позволил тебе выиграть ставку в 48 очков!

		//	OutputTimeAndBotName();
		//	OutputText("Well done, ", Brushes.Green, FontWeights.Normal);
		//	OutputText(profileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Normal);
		//	OutputText("! You won ", Brushes.Green, FontWeights.Normal);
		//	OutputText("supergame", Brushes.Magenta, FontWeights.Bold);
		//	OutputText("! Correct answer -> ", Brushes.Green, FontWeights.Normal);
		//	OutputText(answer, Brushes.Red, FontWeights.Bold);
		//	OutputText(" <- was given for ", Brushes.Green, FontWeights.Normal);
		//	OutputText(lastAnswerTimeInterval.ToString(), Brushes.Green, FontWeights.Bold);
		//	OutputText(" seconds and let you win the bet in ", Brushes.Green, FontWeights.Normal);
		//	OutputText(pointsIncrease.ToString(), Brushes.Red, FontWeights.Normal);
		//	OutputText(" points!", Brushes.Green, FontWeights.Normal);

		//	OutputTimeAndBotName();
		//	OutputCongratOnCorrectAnswerBase
		//		(
		//			profileName,
		//			points,
		//			answersCount,
		//			pointsRound,
		//			answersCountRound,
		//			originalRightAnswersCount,
		//			title,
		//			CalcProfileNameColor(countOfQuestions, originalRightAnswersCount)
		//		);
		//}

		//public override void OutputQuestionSuperGame(string outputText, int answerLength)
		//{
		//	//Вопрос суперигры:
		//	OutputTimeAndBotName();
		//	OutputText("Supergame question: ", Brushes.Magenta, FontWeights.Normal);
		//	OutputQuestionInternal(outputText, answerLength);
		//}

		//public override void OutputAnswerSuperGame(string answer, string profileName, int bet, int points)
		//{
		//	//Ulv не ответил на вопрос суперигры, правильный ответ был ялапа. Ulv теряет ставку 10 очков.
		//	if (answer != null)
		//	{
		//		OutputTimeAndBotName();
		//		OutputText(profileName, Brushes.Magenta, FontWeights.Normal);
		//		OutputText(" did not answer the question ", Brushes.Green, FontWeights.Normal);
		//		OutputText("supergames", Brushes.Magenta, FontWeights.Bold);
		//		OutputText(", the correct answer was ", Brushes.Green, FontWeights.Normal);
		//		OutputText(answer, Brushes.Red, FontWeights.Bold);
		//		OutputText(". ", Brushes.Green, FontWeights.Normal);
		//		OutputText(profileName, Brushes.Magenta, FontWeights.Normal);
		//		OutputText(" loses bet ", Brushes.Green, FontWeights.Normal);
		//		OutputText(bet.ToString(), Brushes.Red, FontWeights.Normal);
		//		OutputText(" points.", Brushes.Green, FontWeights.Normal);
		//	}

		//	//У Ulv теперь 44731 очков.
		//	OutputTimeAndBotName();
		//	OutputText(profileName, Brushes.Magenta, FontWeights.Normal);
		//	OutputText(" now have ", Brushes.Green, FontWeights.Normal);
		//	OutputText(points.ToString(), Brushes.Red, FontWeights.Normal);
		//	OutputText(" points.", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputDescription()
		//{
		//	/**Viktorina offline v.1.1.
		//	  Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.
		//	  Автор программы - Анатолий Кучеров.

		//	  Based on eggdrop scripts (IRC) of Viktorina
		//	1.6 addons by MOSSs 
		//	+ modification by Ulv 
		//	+ some from mrissa.tcl (Based on 3hauka.tcl 2.0.3 by hex and Drakon_) v1.36 (bugsfix) by Maxe_Erte_the_Mad 
		//	+ 3hauka.tcl 2.0.4-stable+php-stat-mod by hex and Drakon_ 
		//	+ quiz_q.tcl v1.19 by Kreon (Based on 3hauka.tcl 2.0.4 by hex and Drakon_)
		//	+ Questions base by Sclex & others.
		//	Описание базы смотрите в папке программы Viktorina_offline/viktorina_base_by_Sclex_v2.7/comment.txt

		//	  Игра представляет собой текстовую викторину. Бот задает вопросы, а вы отвечаете на них.
		//	  Корни игры растут из eggdrop (windrop) скрипта викторины, которая работала на IRC-канале #viktorina_bsatu сети https://irc.bynets.org  
		//	  Канал существовал примерно с 2009 по 2014 год (+/- пару лет). Историю канала можно частично проследить на форуме https://porovik.forum24.ru
		//	  Владельцем канала был автор данной программы Анатолий Кучеров (под ником Ulv), который объединил несколько похожих скриптов викторины в один скрипт, который работал тогда 
		//	  на том канале. 
		//	  Авторы скриптов и источник базы вопросов даны выше.
		//	  В данную программу добавлено несколько дополнительных возможностей, которые не были тогда реализованы на канале #viktorina_bsatu.
		//	  Мотивацией к написанию этой программы стало желание играть в викторину, не запуская IRC-сервер, клиент и бота.
		//	  Основое преимущество данной программы над старой викториной в том, что ей не нужны сервер, клиент, бот для IRC.
		//            Можно просто запустить игру и играть. Однако, на данный момент играть можно только оффлайн в гордом одиночестве, не отвлекаясь на соперников.
		//	  Вашим соперником может быть только бот или игрок с другим профилем, который будет играть после вас.
		//	  Надеюсь, следующая версия игры будет многопользовательской!
		//	  Приятной игры!
		//	 */

		//	Brush foreground = Brushes.SkyBlue;

		//	OutputLineBreak();
		//	OutputText("Viktorina offline v.1.2", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Copyright 2021 Anatoli Kucharau ", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputUrl("https://vk.com/ulvprog");
		//	OutputText(". All Rights Reserved.", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Author of the program - Anatoli Kucharau (Ulv).", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputLineBreak();
		//	OutputText("Based on eggdrop scripts (IRC) of Viktorina", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("1.6 addons by ", foreground, FontWeights.Normal);
		//	OutputText("MOSSs", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("+ modification by ", foreground, FontWeights.Normal);
		//	OutputText("Ulv", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("+ some from mrissa.tcl (Based on 3hauka.tcl 2.0.3 by ", foreground, FontWeights.Normal);
		//	OutputText("hex", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputText(" and ", foreground, FontWeights.Normal);
		//	OutputText("Drakon_", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputText(") v1.36 (bugsfix) by ", foreground, FontWeights.Normal);
		//	OutputText("Maxe_Erte_the_Mad", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("+ 3hauka.tcl 2.0.4-stable+php-stat-mod by hex and Drakon_", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("+ quiz_q.tcl v1.19 by ", foreground, FontWeights.Normal);
		//	OutputText("Kreon", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputText(" (Based on 3hauka.tcl 2.0.4 by hex and Drakon_)", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("+ Questions base v.2.7 by ", foreground, FontWeights.Normal);
		//	OutputText("Sclex", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputText(" & ", foreground, FontWeights.Normal);
		//	OutputText("others.", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("See the description of the base in the program folder Viktorina_offline/QuestionsBases/viktorina_base_by_Sclex_v2.7/comment.txt", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputLineBreak();
		//	OutputText("The game is a text quiz. The bot asks questions, and you answer them.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("The roots of the game come from the eggdrop (windrop) of the quiz script that ran on the IRC channel #viktorina_bsatu network ", foreground, FontWeights.Normal);
		//	OutputUrl("https://irc.bynets.org");
		//	OutputLineBreak();
		//	OutputText("The channel existed from about 2009 to 2014 (+/- a couple of years). You can partially trace the history of the channel on the forum ", foreground, FontWeights.Normal);
		//	OutputUrl("https://porovik.forum24.ru");
		//	OutputLineBreak();
		//	OutputText("The owner of this channel was Anatoly Kucherov (under the nickname Ulv), who combined several similar quiz scripts into one script that worked on that channel at the time.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("The authors of the scripts and the source of the question base are given above.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Several additional features have been added to this program that were not then implemented on #viktorina_bsatu.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("The motivation for writing this program was the desire to play quiz without running the IRC server, client or bot.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("The main advantage of this program over the old quiz is that it doesn't need an IRC server, client, or bot. " +
		//		"You can just run the game and play. However, at the moment you can only play offline in the proudest of solitude, without distractions from your opponents. " +
		//		"Your opponent can only be a bot or a player with a different profile who will play after you.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Online game site: ", foreground, FontWeights.Normal);
		//	OutputUrl("https://vk.com/viktorina_place");
		//	OutputLineBreak();
		//	OutputText("I hope the next version of the game will be multiplayer!", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("When selecting your base in the game window, know that the base must have this format:", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Question1|Answer1", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Question2|Answer2", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Question3|Answer3", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("and have UTF-8 encoding", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Press LeftCtrl + Q to hide the program in the system tray.", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Have a nice game!", foreground, FontWeights.Normal);
		//	OutputLineBreak();
		//}

		//public override void OutputEventOnChangeQuestionsBase(string questionsBasePath, bool internalBase)
		//{
		//	//Выбрана новая база вопросов fileName
		//	OutputLineBreak();
		//	if (internalBase == false)
		//	{
		//		OutputText("Selected question base ", Brushes.Green, FontWeights.Normal);
		//		OutputText(questionsBasePath, Brushes.Goldenrod, FontWeights.Bold);
		//	}
		//	else
		//	{
		//		OutputText("Selected ", Brushes.Green, FontWeights.Normal);
		//		OutputText("inside ", Brushes.Goldenrod, FontWeights.Bold);
		//		OutputText("question base.", Brushes.Green, FontWeights.Normal);
		//	}

		//}

		//public override void OutputEventOnLoadProfile(string newProfileName, int originalRightAnswersCount, int countOfQuestions, string questionsBasePath, string internalQuestionsBasePath)
		//{
		//	OutputLineBreak();
		//	OutputText("Profile loaded ", Brushes.Green, FontWeights.Normal);
		//	OutputText(newProfileName, CalcProfileNameColor(countOfQuestions, originalRightAnswersCount), FontWeights.Bold);
		//	OutputQuestionsBase(questionsBasePath, internalQuestionsBasePath);
		//	OutputText("!", Brushes.Green, FontWeights.Normal);
		//}
		//public override void OutputEventOnDeleteProfile(string profileName, string questionsBasePath, string internalQuestionsBasePath)
		//{
		//	OutputLineBreak();
		//	OutputText("Profile ", Brushes.Green, FontWeights.Normal);
		//	OutputText(profileName, Brushes.DarkOrange, FontWeights.Bold);
		//	OutputQuestionsBase(questionsBasePath, internalQuestionsBasePath);
		//	OutputText(" deleted!", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputEventOnCreateNewProfile(string profileName)
		//{
		//	OutputLineBreak();
		//	OutputText("Profile ", Brushes.Green, FontWeights.Normal);
		//	OutputText(profileName, Brushes.DarkOrange, FontWeights.Bold);
		//	OutputText(" (", Brushes.Green, FontWeights.Normal);
		//	OutputText("inside", Brushes.Goldenrod, FontWeights.Bold);
		//	OutputText(" base", Brushes.Green, FontWeights.Normal);
		//	OutputText(")", Brushes.Green, FontWeights.Normal);
		//	OutputText(" created!", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputCongratOnAllQuestionsAnswered(string profileName, string questionsBasePath, string internalQuestionsBasePath)
		//{
		//	// <<< Поздравляем Ulv!!! Ulv отвечает на ВСЕ вопросы базы questionsBasePath!!! >>>
		//	// <<< Поздравляем Ulv!!! Ulv отвечает на ВСЕ вопросы внутренней базы!!! >>>

		//	OutputTimeAndBotName();
		//	OutputText("<]<]<] ", Brushes.OrangeRed, FontWeights.ExtraBold);
		//	OutputText("Congratulations", Brushes.DodgerBlue, FontWeights.Bold);
		//	OutputText(profileName, Brushes.Tomato, FontWeights.UltraBold);
		//	OutputText(" !!! ", Brushes.DodgerBlue, FontWeights.Bold);
		//	OutputText(profileName, Brushes.Tomato, FontWeights.UltraBold);
		//	OutputText(" answers to ", Brushes.DodgerBlue, FontWeights.Bold);
		//	OutputText("ALL", Brushes.Crimson, FontWeights.UltraBold);
		//	OutputText(" questions ", Brushes.DodgerBlue, FontWeights.Bold);
		//	OutputQuestionsBase(questionsBasePath, internalQuestionsBasePath);
		//	OutputText(" !!!", Brushes.DodgerBlue, FontWeights.Bold);
		//	OutputText(" [>[>[>", Brushes.OrangeRed, FontWeights.ExtraBold);
		//}

		//public override void OutputInfoImpossiblyDeleteDefaultProfile()
		//{
		//	OutputLineBreak();
		//	OutputText("You cannot delete the default profile.", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputWarningOnBracesInProfileName()
		//{
		//	OutputLineBreak();
		//	OutputText("No brackets ) ( allowed in the profile name.", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputWarningOnProfileNameExist(string profileName)
		//{
		//	OutputLineBreak();
		//	OutputText("Profile ", Brushes.Green, FontWeights.Normal);
		//	OutputText(profileName, Brushes.DarkOrange, FontWeights.Bold);
		//	OutputText(" already exists, select another name.", Brushes.Green, FontWeights.Normal);
		//}

		//protected override void OutputQuestionsBase(string questionsBasePath, string internalQuestionsBasePath)
		//{
		//	OutputText(" (", Brushes.Green, FontWeights.Normal);
		//	if (questionsBasePath == internalQuestionsBasePath)
		//	{
		//		OutputText("inside", Brushes.Goldenrod, FontWeights.Bold);
		//		OutputText(" question base", Brushes.SteelBlue, FontWeights.Normal);
		//	}
		//	else
		//	{
		//		OutputText("question base ", Brushes.SteelBlue, FontWeights.Normal);
		//		OutputText(questionsBasePath, Brushes.Goldenrod, FontWeights.Bold);
		//	}
		//	OutputText(") ", Brushes.Green, FontWeights.Normal);
		//}

		//public override void OutputHelpAfterLaunch()
		//{
		//	/**
		//	 * Viktorina offline v.1.1.
		//	 * Для начала игры введите !старт в текстовом поле ввода снизу окна и нажмите Enter. 
		//	 * Там же вводите ответы на вопросы и другие команды (!, !! - подсказки, !д - следующий вопрос, !стоп - остановить игру и др.). 
		//	 * Введите !помощь для описания имеющихся команд. 
		//	 * Загляните в раздел "Описание".
		//	 * Приятной игры!
		//	 */
		//	OutputLineBreak();
		//	OutputLineBreak();
		//	OutputText("Viktorina offline v.1.2.", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("To start the game, type !start in the text input field at the bottom of the window and press Enter.", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("There also enter answers to questions and other commands (!, !! - hints, !n - next question, !stop - stop the game, etc.).", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Enter !help to describe the available commands.", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputText("Check out [Description].", Brushes.Goldenrod, FontWeights.Normal);
		//	OutputLineBreak();
		//	OutputLineBreak();
		//	OutputText("Have a nice game!", Brushes.Orchid, FontWeights.Bold);
		//	OutputLineBreak();
		//	OutputLineBreak();
		//}

		//public override void OutputEventOnChangeLanguage(string language)
		//{
		//	//Теперь язык программы русский.
		//	OutputTimeAndBotName();
		//	OutputText("Now the language of the program is ", Brushes.SteelBlue, FontWeights.Normal);
		//	OutputText(language, Brushes.Green, FontWeights.Bold);
		//	OutputText(" !", Brushes.SteelBlue, FontWeights.Normal);
		//}



		//end of class
	}

}
