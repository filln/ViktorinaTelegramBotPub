// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Настройки, связанные с игровым процессом.
 */

namespace Viktorina.Bot
{
	class Configuration
	{
		public Configuration()
		{
			//OwnerID = 5244963513;
			//channel id -722117411 or -1001680312705
			OwnerName = "Ulv_filln";
			BotName = "Vik42_bot";
			CommandsPrefix = '!';
			//HintSymbol = System.Convert.ToChar(149); //'•' https://yorktown.cbe.wwu.edu/sandvig/shared/asciicodes.aspx
			//HintSymbol = '*';
			HintSymbol = '•';

			//Пауза между новым вопросом и авто ответом. Т.е. время, выделенное игроку на ответ.
			AllocatedToAnswerTime = 60; //секунд

			//Пауза между ответом и новым вопросом.
			PauseBetweenAnswerAndNewQuestion = 3; //секунд

			//Очки за ответ.
			PointsForAnswer = 5;
			PointsForAnswerHint1 = 2;
			PointsForAnswerHint2 = 1;

			//Кол. правильных ответов для начала суперигры.
			RightAnswersCountInARowForSuperGame = 10;
			//Ставки на суперигру.
			MinPointsSuperGame = 40;
			MaxPointsSuperGame = 80;
			//Ожидание согласия на супер-игру, сек.
			WaitingAgreementPlaySuperGameInterval = 10;

			//После RightAnswersCountInARowForCongrat правильных ответов каждый последующий правильный ответ выводится поздравление типа "Ulv отвечает на 4 вопроса подряд!"
			//и начисляются бонусные очки в размере statsBaseManager.CurrentRightAnswersCountInARowForCongrat (через viktorinaMain)
			RightAnswersCountInARowForCongrat = 4;

			//Максимальное количество неотвеченных вопросов в раунде. При достижении останавливается игра.
			MaxCountOfLoseAnswersInRound = 100;
		}
		
		public string OwnerName { get; private set; }
		public string BotName { get; private set; }
		public char CommandsPrefix { get; private set; }
		public char HintSymbol { get; private set; }

		//Выводит количество символов в подсказке case 2: return 1; значит, что в слове из 2 букв выведется 1 символ подсказки.
		public int Hint1VisibleSymbolsCount(int answerLength)
		{
			if(answerLength < 2)
			{
				return 0;
			}
			if (answerLength > 32)
			{
				return 15;
			}
			switch (answerLength)
			{
				case 2: return 1;
				case 3: return 2;
				case 4: return 1;
				case 5: return 2;
				case 6: return 2;
				case 7: return 3;
				case 8: return 3;
				case 9: return 4;
				case 10: return 4;
				case 11: return 5;
				case 12: return 5;
				case 13: return 6;
				case 14: return 6;
				case 15: return 7;
				case 16: return 7;
				case 17: return 8;
				case 18: return 8;
				case 19: return 9;
				case 20: return 9;
				case 21: return 10;
				case 22: return 10;
				case 23: return 11;
				case 24: return 11;
				case 25: return 12;
				case 26: return 12;
				case 27: return 13;
				case 28: return 13;
				case 29: return 14;
				case 30: return 14;
				case 31: return 15;
				case 32: return 15;

				default: break;
			}
			return 0;
		}
		//Выводит количество символов в подсказке case 2: return 1; значит, что в слове из 2 букв выведется 1 символ подсказки.
		public int Hint2VisibleSymbolsCount(int answerLength)
		{
			if (answerLength < 4)
			{
				return 0;
			}
			if (answerLength > 32)
			{
				return 16;
			}
			switch (answerLength)
			{
				case 4: return 1;
				case 5: return 1;
				case 6: return 2;
				case 7: return 2;
				case 8: return 3;
				case 9: return 3;
				case 10: return 4;
				case 11: return 4;
				case 12: return 5;
				case 13: return 5;
				case 14: return 6;
				case 15: return 6;
				case 16: return 7;
				case 17: return 7;
				case 18: return 8;
				case 19: return 8;
				case 20: return 9;
				case 21: return 9;
				case 22: return 10;
				case 23: return 10;
				case 24: return 11;
				case 25: return 11;
				case 26: return 12;
				case 27: return 12;
				case 28: return 13;
				case 29: return 13;
				case 30: return 14;
				case 31: return 14;
				case 32: return 15;

				default: break;
			}
			return 0;
		}

		public int AllocatedToAnswerTime { get; private set; }
		public int PauseBetweenAnswerAndNewQuestion { get; private set; }

		public int PointsForAnswer { get; private set; }
		public int PointsForAnswerHint1 { get; private set; }
		public int PointsForAnswerHint2 { get; private set; }

		public int RightAnswersCountInARowForCongrat { get; set; }

		//SuperGame
		public int RightAnswersCountInARowForSuperGame { get; private set; }
		public int MinPointsSuperGame { get; private set; }
		public int MaxPointsSuperGame { get; private set; }
		public int WaitingAgreementPlaySuperGameInterval { get; private set; }

		//Максимальное количество неотвеченных вопросов в раунде. При достижении останавливается игра.
		public int MaxCountOfLoseAnswersInRound { get; private set; }


		//end of class
	}
}
/**
 * старый вариант
 * 			if(answerLength < 3)
			{
				return 0;
			}
			if (answerLength >= 3 && answerLength < 7)
			{
				return 2;
			}
			if (answerLength >= 7 && answerLength < 12)
			{
				return 3;
			}
			if (answerLength >= 12 && answerLength < 16)
			{
				return 4;
			}
			if (answerLength >= 16 && answerLength < 20)
			{
				return 5;
			}
			if (answerLength >= 20 && answerLength < 24)
			{
				return 6;
			}
			if (answerLength >= 24 && answerLength < 28)
			{
				return 7;
			}
			if (answerLength >= 28 && answerLength < 32)
			{
				return 8;
			}
			if (answerLength >= 32)
			{
				return 9;
			}
===================================================================
			if (answerLength < 5)
			{
				return 0;
			}
			if (answerLength >= 5 && answerLength < 8)
			{
				return 1;
			}
			if (answerLength >= 8 && answerLength < 12)
			{
				return 2;
			}
			if (answerLength >= 12 && answerLength < 16)
			{
				return 3;
			}
			if (answerLength >= 16 && answerLength < 20)
			{
				return 4;
			}
			if (answerLength >= 20 && answerLength < 24)
			{
				return 5;
			}
			if (answerLength >= 24 && answerLength < 28)
			{
				return 6;
			}
			if (answerLength >= 28 && answerLength < 32)
			{
				return 7;
			}
			if (answerLength >= 32)
			{
				return 8;
			}
 */