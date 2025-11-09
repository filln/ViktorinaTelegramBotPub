// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Управляет титулами игрока. Английский язык. Титулы зависят от количества очков и динамически вычисляются из количества очков.
 */

namespace Viktorina.Bot.Stats
{
	public class TitlesControlEnglish : TitlesControlParent
	{
		public TitlesControlEnglish()
		{
			title0 = "negative balance";
			title1 = "rare guest";
			title2 = "guest";
			title3 = "newbie";
			title4 = "beginner";
			title5 = "apprentice";
			title6 = "rookie";
			title7 = "nerd";
			title8 = "student";
			title9 = "fresh brain";
			title10 = "promising";
			title11 = "savvy";
			title12 = "proficient";
			title13 = "prodigy";
			title14 = "bachelor";
			title15 = "proficient";
			title16 = "doctor";
			title17 = "all-knowing";
			title18 = "professor";
			title19 = "master";
			title20 = "master";
			title21 = "sage";
			title22 = "guru";
			title23 = "regular";
			title24 = "just look at it";
			title25 = "the old-timer";
			title26 = "what the hell";
			title27 = "successful";
			title28 = "growing on yourself";
			title29 = "smart guy";
			title30 = "cyber-brain";
			title31 = "wordy";
			title32 = "letter collector";
			title33 = "loud name";
			title34 = "the man with the skills";
			title35 = "a fine expert";
			title36 = "rare doc";
			title37 = "in the prime of his life";
			title38 = "ace of keyboarding";
			title39 = "fighter against entropy";
			title40 = "more is more";
			title41 = "there are such men";
			title42 = "professional";
			title43 = "gambling polyvalent";
			title44 = "memory-aware";
			title45 = "wonders without a sieve";
			title46 = "chat room prisoner";
			title47 = "billion word stock";
			title48 = "receptive";
			title49 = "lexical zombie";
			title50 = "a dexterous keyboard player";
			title51 = "both reaper and seamstress";
			title52 = "amoeba Pavlik";
			title53 = "chained to a chair";
			title54 = "and we have no peac";
			title55 = "multarmed miracle";
			title56 = "bot tormentor";
			title57 = "UFO";
			title58 = "the crown of post-evolution";
			title59 = "halfway there";
			title60 = "empathetic mind";
			title61 = "reactive unicum";
			title62 = "serious authority";
			title63 = "linguotalent";
			title64 = "head on your shoulders";
			title65 = "common pride";
			title66 = "skilled wordsmith";
			title67 = "non-stop player";
			title68 = "rabid bothead";
			title69 = "no-talent fingers";
			title70 = "the 24-hour typist";
			title71 = "lord of dictionaries";
			title72 = "one-word master";
			title73 = "true monster";
			title74 = "impeccable thinker";
			title75 = "absorber of knowledge";
			title76 = "agent of the noosphere";
			title77 = "incurable gambler";
			title78 = "verbal gourmand";
			title79 = "elephant memory scanner";
			title80 = "analytical repository";
			title81 = "reality hacker";
			title82 = "extraterrestrial intelligence";
			title83 = "matrix agent";
			title84 = "encyclopedist";
			title85 = "associative biochip";
			title86 = "philological mnemonic";
			title87 = "child of the infomercial";
			title88 = "petabytehead";
			title89 = "tyrant of neurons";
			title90 = "photon processor";
			title91 = "secret engineering";
			title92 = "lightning keyboardboy";
			title93 = "quizzical angel";
			title94 = "great spirit of knowledge";
			title95 = "universal consciousness";
			title96 = "mysterious thinking substance";
			title97 = "combinator of meanings";
			title98 = "the ultimate talent";
			title99 = "over-the-top intellect";
			title100 = "IQ bomb";
			title101 = "Einstein clone";
			title102 = "supreme standard of intellect";
			title103 = "unique phenomenon";
			title104 = "incredible brainiac";
			title105 = "inexplicable phenomenon";
			title106 = "the classic of quizzicalism";
			title107 = "heroic polymath";
			title108 = "quiz heritage";
			title109 = "genius of the game";

		}

		private static TitlesControlParent current;
		public static TitlesControlParent GetCurrent()
		{
			if (current == null)
			{
				current = new TitlesControlEnglish();
			}
			return current;
		}


		//end of class
	}
}

/*
 * 110
отрицательный баланс
редкий гость
гость
новичок
начинающий
ученик
салага
ботан
студент
свежая голова
перспективный
смекалистый
знаток
вундеркинд
бакалавр
наловчившийся
доктор
всезнающий
профессор
магистр
мастер
мудрец
гуру
завсегдатай
только посмотрите
бывалый
во даешь!
успешный
расту над собой
умник-разумник
кибермозг
словодержимый
коллекционер букв
громкое имя
ишь как насобачился
тонкий специалист
редкий дока
в самом расцвете сил
ас клавишного рукоделия
борец с энтропией
дальше - больше
бывают же такие
профессионал
азартный многовед
вспоминатель-пониматель
чудеса без решета
узник чата
запас в миллиард слов
восприимчивый
лексический зомби
сноровистый клавишник
и жнец и швец
амёба Павлик
прикованный к стулу
и нет нам покоя
многорукое чудо
мучитель бота
НЛО
венец постэволюции
на полпути
чуткий ум
реактивный уникум
серьезный авторитет
лингвоталант
голова на плечах
общая гордость
искусный словесник
игрок нон-стоп
бешеный ботоед
безустальные пальцы
печатающий круглосуточно
владыка словарей
одно слово - мастак
настоящий монстр
безупречный мыслитель
поглотитель знаний
агент ноосферы
неизлечимый игроман
вербальный гурман
сканер с памятью слона
аналитическое хранилище
взломщик реальности
внеземной разум
агент матрицы
энциклопедоед
ассоциативный биочип
филологический мнемоник
дитя инфоэры
петабайтоголовый
тиран нейронов
фотонный процессор
секретная разработка
молниеносный клавобой
ангел викторины
великий дух познания
вселенское сознание
загадочная мыслящая субстанция
комбинатор смыслов
запредельный талантище
зашкаливший интеллект
IQ-бомба
клон Эйнштейна
высший эталон разума
уникальное явление
невероятный мозголом
необъяснимый феномен
классик викторинизма
героический эрудит
достояние викторины
гений игры


 */
