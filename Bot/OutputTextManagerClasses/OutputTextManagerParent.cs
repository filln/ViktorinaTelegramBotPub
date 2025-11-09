// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Абстрактный родительский класс менеджеров вывода текста.
 */

namespace Viktorina.Bot
{
    abstract public class OutputTextManagerParent
    {
        protected OutputTextManagerParent(ViktorinaStarter viktorinaStarter)
        {
            this.viktorinaStarter = viktorinaStarter;
        }
        protected readonly ViktorinaStarter viktorinaStarter;
        public ViktorinaMain viktorinaMain;
        protected CommandsListParent CommandsList => viktorinaStarter.CommandsList;

        protected string OutputArrow()
        {
            return "==> ";
        }
        protected string OutputCommandsPrefix()
        {
            return viktorinaMain.CommandsPrefix.ToString();
        }

        public abstract void ExecuteHelp();
        public abstract void ExecuteStart(int countOfQuestionsInBase);

        public abstract void OutputEventOnStartWithLimitQuestions(int maxCountOfQuestionsInRound);

        public abstract void OutputEventOnStopWithLimitLoseAnswers();

        public abstract void ExecuteStop
            (
                string startCommand,
                int countOfQuestions,
                int countOfAnswers,
                TimeSpan duration
            );

        public void OutputQuestion(string outputText, int answerLength, int numberOfQuestion)
        {
            //numberOfQuestion: question.
            OutputText
            (
                "#"
                + numberOfQuestion.ToString()
                + ": "
                + OutputQuestionInternal(outputText, answerLength)
            );
        }
        protected abstract string OutputQuestionInternal(string outputText, int answerLength);
        public abstract void OutputAnswer(string answer);

        public abstract void ExecuteHint(string hint);

        public abstract void OutputUsernameAndTitle(string username, string title, bool allQuestionsAnswered);

        public abstract void OutputNotFindUsername(string username);

        public abstract void OutputStat
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
            );

        public abstract void OutputBeginTopPoints();

        public abstract void OutputBeginTopRoundPoints();

        public abstract void OutputProfileInTopPoints
            (
                int place,
                string username,
                bool allQuestionsAnswered,
                string title,
                int points
            );

        public abstract void OutputCongratOnCorrectAnswer
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
            );

        protected abstract void OutputCongratOnCorrectAnswerBase
            (
            string username,
            int points,
            int answersCount,
            int pointsRound,
            int answersCountRound,
            int originalRightAnswersCount,
            bool allQuestionsAnswered,
            string title
            );

        protected string OutputTitle(string title)
        {
            return " [" + title + "] ";
        }

        public abstract void OutputCongratOnNewTitle(string username, string title, bool allQuestionsAnswered);
        public abstract void OutputAlertOnDemotionTitle(string username, string title, bool allQuestionsAnswered);
        public abstract void OutputCongratOnMinLastAnswerTimeIntervalReached(string username, bool allQuestionsAnswered);

        public abstract void OutputCongratOnRightAnswersInARow(string username, int count, bool allQuestionsAnswered);

        public abstract void OutputOfferSuperGame
            (
            string username,
            char commandsPrefix,
            string yesCommand,
            string noCommand,
            int minBet,
            int maxBet,
            int intervalForWaitYes,
            bool allQuestionsAnswered
            );

        public abstract void ExecuteNoSuperGame(string username, bool allQuestionsAnswered);
        public abstract void ExecuteYesSuperGame(string username, int bet, bool allQuestionsAnswered);

        public abstract void OutputCongratOnCorrectAnswerSuperGame
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
        );

        public abstract void OutputQuestionSuperGame(string outputText, int answerLength);

        public abstract void OutputAnswerSuperGame(string answer, string username, int bet, int points, bool allQuestionsAnswered);

        public abstract void OutputDescription();

        public void OutputDebugMessage(string outputText)
        {
            OutputText(CreateFormatedText("DebugMessage: ") + outputText, false);
        }

        public abstract void OutputCongratOnAllQuestionsAnswered(string username, bool allQuestionsAnswered);

        public void OutputText(string outputText, bool isFormatedText = true)
        {
            viktorinaStarter.OutputText(outputText, isFormatedText);
        }

        public abstract void OutputHelpAfterLaunch();

        protected string CreateFormatedText(string text)
        {
            return "<b><i>" + text + "</i></b>";
        }

        //end of class
    }
}
