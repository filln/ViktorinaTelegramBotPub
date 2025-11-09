// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Список команд. Родительский класс.
 */

namespace Viktorina.Bot
{
	abstract public class CommandsListParent
	{

		public abstract string Help { get; set; } //Список и описание команд.
		public abstract string Start { get; set; } //Запустить игру. 
		public abstract string Stop { get; set; } //Остановить игру.
		public abstract string Hint1 { get; set; } //Первая подсказка.
		public abstract string Hint2 { get; set; } //Вторая подсказка.
		public abstract string Next { get; set; } //Перейти к следующему вопросу.
		public abstract string Stat { get; set; } //Статистика игрока, отправившего команду. 
		public abstract string TopPoints { get; set; } //Список лучших по очкам.
		public abstract string YesSuperGame { get; set; } //Согласие на супер-игру со ставкой 10.
		public abstract string NoSuperGame { get; set; } //Отказ от супер-игры.
		public abstract string ProfilesList { get; set; } //Список профилей со статами.
		public abstract string Description { get; set; } //Описание игры.

		//end of class
	}
}
