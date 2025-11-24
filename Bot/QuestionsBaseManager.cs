// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Управляет файлом базы вопросов, текстом базы.
 */

using System.Reflection;

namespace Viktorina.Bot
{
	class QuestionsBaseManager
	{
		public QuestionsBaseManager(ViktorinaMain viktorinaMain)
		{
			this.viktorinaMain = viktorinaMain;
			basesEncoding = System.Text.Encoding.UTF8;
			assembly = Assembly.GetExecutingAssembly();
			//InternalQuestionsBasePath = "Viktorina.Bot.questions.txt";
			//ResourceName = @"d:\\Viktorina\bin\Release\q.txt";
			CountOfQuestions = 0;
			LineNumber = 0;
			delimiter = '|';
		}

		/**
		 * Variables
		 */
		private readonly ViktorinaMain viktorinaMain;
		private StreamReader strReader;
		private Stream str;
		private Assembly assembly;
		private readonly char delimiter;
		private string? hint1;
		private string CurrentLanguage => viktorinaMain.CurrentLanguage;
		public string InternalQuestionsBasePath
		{ 
			get
			{
				if (CurrentLanguage == LanguagesList.russian)
                {
					return "ViktorinaTelegramBot.Bot.questions.txt";
                    //return "ViktorinaTelegramBot.Bot.questionsTest.txt";
                }
				if (CurrentLanguage == LanguagesList.belorussian)
				{
					return "ViktorinaTelegramBot.Bot.questionsBY.txt";
				}
				return "ViktorinaTelegramBot.Bot.questions.txt";
			}
		}

		//Количество вопросов в базе вопросов.
		public int CountOfQuestions { get; private set; }
		public string? Question { get; private set; }
		public string? Answer { get; private set; }
		
		//Номер строки текущего вопроса.
		public int LineNumber { get; private set; }

		private System.Text.Encoding basesEncoding;

		/**
		 * Methods
		 */
		public bool ExecuteStart()
		{
			if (strReader == null)
			{
				OutputDebugMessage("ExecuteStart(): streamReader == null");
				return false;
			}
			return true;
		}

		public void ExecuteStop()
		{
			if (strReader == null)
			{
				OutputDebugMessage("ExecuteStop(): streamReader == null");
			}
			//if (str == null)
			//{
			//	OutputDebugMessage("ExecuteStop(): str == null");
			//}
		}

		public void GetRandomQuestion()
		{
			SetPositionToBegin();
			string questionWithAnswer = null;
			Answer = null;
			Question = null;
			Random rnd = new Random(DateTime.Now.Millisecond);
			LineNumber = rnd.Next(1, CountOfQuestions + 1);
			//LineNumber = 6;
			//OutputDebugMessage(lineNumber.ToString());
			for (int currentLine = 1; currentLine <= LineNumber; currentLine++)
			{
				questionWithAnswer = strReader.ReadLine();
			}
			if (questionWithAnswer == null)
			{
				OutputDebugMessage(LineNumber.ToString());
				return;
			}

			//разделим вопрос и ответ.
			bool rightSection = true;
			foreach(char symbol in questionWithAnswer)
			{
				if (rightSection)
				{
					if (symbol != delimiter)
					{
						Question += symbol;
					}
					else
					{
						rightSection = false;
						continue;
					}
				}
				else
				{
					Answer += symbol;
				}
			}

			if (Answer == null || rightSection == true)
			{
				OutputDebugMessage("Не найден разделитель вопроса и ответа " + delimiter);
			}
		}

		public string ExecuteHint1(int hint1VisibleSymbolsCount, char hintSymbol)
		{
			char[] hint1AsChars = Answer.ToCharArray();
			for(int index = hint1VisibleSymbolsCount; index < Answer.Length; index++)
			{
				if (hint1AsChars[index] != ' ' && hint1AsChars[index] != '-')
				{
					hint1AsChars[index] = hintSymbol;
				}				
			}
			hint1 = new string(hint1AsChars);
			return hint1;
		}
		public string ExecuteHint2(int hint2VisibleSymbolsCount)
		{
			char[] hint2AsChars = hint1.ToCharArray();
			//01234  ***34
			for (int index = (Answer.Length - 1); index > (Answer.Length - 1 - hint2VisibleSymbolsCount); index--)
			{
				hint2AsChars[index] = Answer[index];
			}

			string hint2 = new string(hint2AsChars);
			return hint2;
		}

		public void ResetAnswer()
		{
			Answer = null;
		}

		private void OutputDebugMessage(string outputText)
		{
			viktorinaMain.OutputDebugMessage(outputText);
		}

		private void SetPositionToBegin()
		{
			if (strReader != null)
			{
				strReader.DiscardBufferedData();
				if (strReader.BaseStream != null)
				{
					strReader.BaseStream.Position = 0;
				}
				else
				{
					OutputDebugMessage("SetPositionToBegin(): strReader.BaseStream == null");
				}
			}
			else
			{
				OutputDebugMessage("SetPositionToBegin(): strReader == null");
			}
		}


		public void SetInternalQuestionsBase()
		{
			viktorinaMain.ExecuteStop(viktorinaMain.OwnerName);
			assembly = Assembly.GetExecutingAssembly();
			str = assembly?.GetManifestResourceStream(InternalQuestionsBasePath);
			if (str != null)
			{
				strReader = new StreamReader(str, basesEncoding);
				if (strReader != null)
				{
					CalcCountOfQuestionsInCurrentBase();
				}
				else
				{
					OutputDebugMessage("SetInternalQuestionsBase(): strReader == null");
					return;
				}
			}
			else
			{
				OutputDebugMessage("SetInternalQuestionsBase(): str == null");
				return;
			}
			
		}

		private void CalcCountOfQuestionsInCurrentBase()
		{
			CountOfQuestions = 0;
			while (strReader.ReadLine() != null)
			{
				CountOfQuestions++;
			}
			SetPositionToBegin();
		}

		public int CalcCountOfQuestionsInInputBase(string questionsBasePath)
		{
			int countOfQuestions = 0;
			StreamReader tmpStrReader = null;
			if (questionsBasePath == InternalQuestionsBasePath)
			{
				Assembly tmpAssembly = Assembly.GetExecutingAssembly();
				Stream tmpStr = tmpAssembly?.GetManifestResourceStream(questionsBasePath);
				if (tmpStr != null)
				{
					tmpStrReader = new StreamReader(tmpStr, basesEncoding);
				}
			}
			else
			{
				tmpStrReader = new StreamReader(questionsBasePath, basesEncoding);
			}

			if (tmpStrReader != null)
			{
				while (tmpStrReader.ReadLine() != null)
				{
					countOfQuestions++;
				}
				tmpStrReader.Close();
			}
			else
			{
				OutputDebugMessage("CalcCountOfQuestionsInInputBase(): strReader == null");
			}
			return countOfQuestions;
		}

		//end of class
	}
}
