// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Обработчик команд.
 */

namespace Viktorina.Bot
{
	class CommandsHandler
	{
		public CommandsHandler(ViktorinaMain viktorinaMain)
		{
			this.viktorinaMain = viktorinaMain;
		}
		private readonly ViktorinaMain viktorinaMain;
		private CommandsListParent CommandsList => viktorinaMain.CommandsList;
		private string command;
		private string Command
		{
			get => command;
			set
			{
				//Отдельно определить команды, которые состоят из префиксов. Сейчас это, например, команды хинтов ! и !!
				if 
					(
						value == (viktorinaMain.CommandsPrefix).ToString()
						|| value == (viktorinaMain.CommandsPrefix).ToString() + (viktorinaMain.CommandsPrefix).ToString()
					)
				{
					command = value;
					return;
				}
				//При определении переменной, если первый символ равен префиксу команд, то определить переменную как строку, которая после префикса команд.
				if (value.Substring(0, 1) == (viktorinaMain.CommandsPrefix).ToString())
				{
					command = value.Substring(1);
				}
			}
		}

		public void HandleCommand(string inputText, string username)
		{
			//Использовать команду стат без изменения регистра, чтобы не менять юзернейм в команде !стат Юзернейм. 
			HandleStat(inputText, username);

			Command = inputText.ToLower();

			if (Command == CommandsList.Help)
			{
				ExecuteHelp();
			}
			if (Command == "хелп")
			{
				ExecuteHelp();
			}
			else if (Command == CommandsList.Stop)
			{
				ExecuteStop(username);
			}
			else if (Command == CommandsList.Hint1)
			{
				ExecuteHint1(username);
			}
			else if (Command == CommandsList.Hint2)
			{
				ExecuteHint2(username);
			}

			else if (Command == CommandsList.Next)
			{
				ExecuteNext(username);
			}
			else if (Command == "хз")
			{
				ExecuteNext(username);
			}

			else if (Command == CommandsList.ProfilesList)
			{
				ExecuteProfilesList(username);
			}
			else if (Command == CommandsList.TopPoints)
			{
				ExecuteTopPoints();
			}
			else if (Command == "close")
			{
				ExecuteClose(username);
			}
			else if (Command == CommandsList.Description)
			{
				ExecuteDescription();
			}
			HandleStart(username);
			HandleSuperGame(username);

			//OutputBotTextMain(Command);
		}

		private void HandleStart(string username)
        {
			if (Command == CommandsList.Start)
			{
				ExecuteStart(username, 0);
				return;
			}
			//Если команда состоит не только из !старт
			//Индекс пробела в команде вида: старт 50
			int spacePos = Command.IndexOf(' ');
			if (spacePos < 0)
			{
				return;
			}
			//Найдем строку до пробела, т.е. например: старт
			string firstPart = Command.Substring(0, spacePos);
			//Если строка до пробела равна команде старта, то найдем количество вопросов (строка после пробела).
			if (firstPart == CommandsList.Start)
			{
				string secondPart = Command.Substring(spacePos + 1);
				if (Int32.TryParse(secondPart, out int count))
				{
					if(count <= 0)
                    {
						count = 0;
                    }
					if (count > 1000)
                    {
						count = 1000;
                    }
					ExecuteStart(username, count);
					return;
				}
			}
		}

		private void HandleStat(string inputText, string username)
        {
			string command = inputText.Substring(1);			
			if (command.ToLower() == CommandsList.Stat)
			{
				ExecuteStat(username);
				return;
			}

			//Если команда состоит не только из !стат
			//Индекс пробела в команде вида: стат Ulv
			int spacePos = command.IndexOf(' ');
			if (spacePos < 0)
			{
				return;
			}
			//Найдем строку до пробела, т.е. например: стат
			string firstPart = command.Substring(0, spacePos);
			//Если строка до пробела равна команде стат, то найдем username.
			if (firstPart == CommandsList.Stat)
			{
				string secondPart = command.Substring(spacePos + 1);
				ExecuteStat(secondPart);
			}
		}

		private void HandleSuperGame(string username)
		{
			if (Command == CommandsList.NoSuperGame)
			{
				ExecuteNoSuperGame(username);
				return;
			}
			if (Command == CommandsList.YesSuperGame)
			{
				ExecuteYesSuperGame(username, viktorinaMain.MinPointsSuperGame);
				return;
			}
			//Если команда состоит не только из !да или !нет
			//Индекс пробела в команде вида: да 50
			int spacePos = Command.IndexOf(' ');
			if (spacePos < 0)
			{
				return;
			}
			//Найдем строку до пробела, т.е. например: да
			string firstPart = Command.Substring(0, spacePos);
			//Если строка до пробела равна команде согласия на суперигру, то найдем ставку (строка после пробела).
			if (firstPart == CommandsList.YesSuperGame)
			{
				string secondPart = Command.Substring(spacePos + 1);
				if (Int32.TryParse(secondPart, out int points))
				{
					ExecuteYesSuperGame(username, points);
					return;
				}
			}
		}

		private void ExecuteHelp()
		{
			viktorinaMain.ExecuteHelp();
		}
		private void ExecuteStart(string username, int count)
		{
			viktorinaMain.ExecuteStart(username, count);
		}
		private void ExecuteStop(string username)
		{
			viktorinaMain.ExecuteStop(username);
		}
		private void ExecuteHint1(string username)
		{
			viktorinaMain.ExecuteHint1(username);
		}
		private void ExecuteHint2(string username)
		{
			viktorinaMain.ExecuteHint2(username);
		}
		private void ExecuteNext(string username)
		{
			viktorinaMain.ExecuteNext(username);
		}
		private void ExecuteStat(string username)
		{
			viktorinaMain.ExecuteStat(username);
		}
		private void ExecuteProfilesList(string username)
		{
			viktorinaMain.ExecuteProfilesList(username);
		}
		private void ExecuteTopPoints()
		{
			viktorinaMain.ExecuteTopPoints();
		}
		private void ExecuteNoSuperGame(string username)
		{
			viktorinaMain.ExecuteNoSuperGame(username);
		}
		private void ExecuteYesSuperGame(string username, int bet)
		{
			viktorinaMain.ExecuteYesSuperGame(username, bet);
		}

		private void ExecuteDescription()
		{
			viktorinaMain.ExecuteDescription();
		}

		private void ExecuteClose(string username)
		{
			viktorinaMain.ExecuteClose(username);
		}

		//end of class
	}
}
