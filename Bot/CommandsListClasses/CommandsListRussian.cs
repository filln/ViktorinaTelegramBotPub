// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Список команд. Русский язык.
 */

namespace Viktorina.Bot
{
	class CommandsListRussian : CommandsListParent
	{
		private CommandsListRussian()
		{
			Help = "помощь";
			Start = "старт";
			Stop = "стоп";
			Hint1 = "!";
			Hint2 = "!!";
			Next = "д";
			Stat = "стат";
			TopPoints = "топ";
			YesSuperGame = "да";
			NoSuperGame = "нет";
			ProfilesList = "список";
			Description = "описание";
		}

		private static CommandsListParent current;
		public static CommandsListParent GetCurrent()
		{
			if (current == null)
			{
				current = new CommandsListRussian();
			}
			return current;
		}

		public override string Help { get; set; } //Список и описание команд.
		public override string Start { get; set; } //Запустить игру. 
		public override string Stop { get; set; } //Остановить игру.
		public override string Hint1 { get; set; } //Первая подсказка.
		public override string Hint2 { get; set; } //Вторая подсказка.
		public override string Next { get; set; } //Перейти к следующему вопросу.
		public override string Stat { get; set; } //Статистика игрока, отправившего команду. 
		public override string TopPoints { get; set; } //Список лучших по очкам.
		public override string YesSuperGame { get; set; } //Согласие на супер-игру со ставкой 10.
		public override string NoSuperGame { get; set; } //Отказ от супер-игры.
		public override string ProfilesList { get; set; } //Список профилей со статами.
		public override string Description { get; set; } //Описание игры.

	}
}
