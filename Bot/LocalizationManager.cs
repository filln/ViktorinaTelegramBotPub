// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Класс для выбора языка программы.
 */

using Viktorina.Bot;
using Viktorina.Bot.Stats;

struct LanguagesList
{
	public const string english = "English";
	public const string russian = "Русский";
	public const string belorussian = "Беларуская";
}

namespace Viktorina.Localization
{
	public class LocalizationManager
	{
		public LocalizationManager(ViktorinaStarter viktorinaStarter)
		{
			this.viktorinaStarter = viktorinaStarter;
		}

		/**
		 * Variables
		 */
		private readonly ViktorinaStarter viktorinaStarter;
		public string CurrentLanguage { get; private set; }


		/**
		 * Methods
		 */

		//Выбрать язык классов, отображающих текст в поле ввывода текста.
		public void SelectLanguage(string selectedLanguage, bool doWriteData = true)
		{
			CurrentLanguage = selectedLanguage;

			if (selectedLanguage == LanguagesList.english)
			{
				//viktorinaStarter.OutputTextManager = OutputTextManagerEnglish.GetCurrent(viktorinaStarter);
				//viktorinaStarter.CommandsList = CommandsListEnglish.GetCurrent();
				//viktorinaStarter.TitlesControl = TitlesControlEnglish.GetCurrent();
			}
			else if (selectedLanguage == LanguagesList.russian)
			{
				viktorinaStarter.OutputTextManager = OutputTextManagerRussian.GetCurrent(viktorinaStarter);
				viktorinaStarter.CommandsList = CommandsListRussian.GetCurrent();
				viktorinaStarter.TitlesControl = TitlesControlRussian.GetCurrent();
			}
			else if (selectedLanguage == LanguagesList.belorussian)
			{
				viktorinaStarter.OutputTextManager = OutputTextManagerBelorussian.GetCurrent(viktorinaStarter);
				viktorinaStarter.CommandsList = CommandsListBelorussian.GetCurrent();
				viktorinaStarter.TitlesControl = TitlesControlBelorussian.GetCurrent();
			}

		}


		//end of class
	}
}
