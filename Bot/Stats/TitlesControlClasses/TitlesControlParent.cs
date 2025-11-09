// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Абстрактный класс. Управляет титулами игрока. Титулы зависят от количества очков и динамически вычисляются из количества очков.
 */

namespace Viktorina.Bot.Stats
{
	public abstract class TitlesControlParent
	{
		//Сохраняет текущее звание для сравнения со званием после начисления очков, для вывода поздравления с повышением в звании.
		public string previousTitle;

		protected string title0;
		protected string title1;
		protected string title2;
		protected string title3;
		protected string title4;
		protected string title5;
		protected string title6;
		protected string title7;
		protected string title8;
		protected string title9;
		protected string title10;
		protected string title11;
		protected string title12;
		protected string title13;
		protected string title14;
		protected string title15;
		protected string title16;
		protected string title17;
		protected string title18;
		protected string title19;
		protected string title20;
		protected string title21;
		protected string title22;
		protected string title23;
		protected string title24;
		protected string title25;
		protected string title26;
		protected string title27;
		protected string title28;
		protected string title29;
		protected string title30;
		protected string title31;
		protected string title32;
		protected string title33;
		protected string title34;
		protected string title35;
		protected string title36;
		protected string title37;
		protected string title38;
		protected string title39;
		protected string title40;
		protected string title41;
		protected string title42;
		protected string title43;
		protected string title44;
		protected string title45;
		protected string title46;
		protected string title47;
		protected string title48;
		protected string title49;
		protected string title50;
		protected string title51;
		protected string title52;
		protected string title53;
		protected string title54;
		protected string title55;
		protected string title56;
		protected string title57;
		protected string title58;
		protected string title59;
		protected string title60;
		protected string title61;
		protected string title62;
		protected string title63;
		protected string title64;
		protected string title65;
		protected string title66;
		protected string title67;
		protected string title68;
		protected string title69;
		protected string title70;
		protected string title71;
		protected string title72;
		protected string title73;
		protected string title74;
		protected string title75;
		protected string title76;
		protected string title77;
		protected string title78;
		protected string title79;
		protected string title80;
		protected string title81;
		protected string title82;
		protected string title83;
		protected string title84;
		protected string title85;
		protected string title86;
		protected string title87;
		protected string title88;
		protected string title89;
		protected string title90;
		protected string title91;
		protected string title92;
		protected string title93;
		protected string title94;
		protected string title95;
		protected string title96;
		protected string title97;
		protected string title98;
		protected string title99;
		protected string title100;
		protected string title101;
		protected string title102;
		protected string title103;
		protected string title104;
		protected string title105;
		protected string title106;
		protected string title107;
		protected string title108;
		protected string title109;

		public string CalcTitle(int points)
		{
			if (points < 0)
			{
				return title0;
			}
			if (points >= 0 && points < 100)
			{
				return title1;
			}
			if (points >= 100 && points < 200)
			{
				return title2;
			}
			if (points >= 200 && points < 300)
			{
				return title3;
			}
			if (points >= 300 && points < 400)
			{
				return title4;
			}
			if (points >= 400 && points < 500)
			{
				return title5;
			}
			if (points >= 500 && points < 600)
			{
				return title6;
			}
			if (points >= 600 && points < 700)
			{
				return title7;
			}
			if (points >= 700 && points < 800)
			{
				return title8;
			}
			if (points >= 800 && points < 900)
			{
				return title9;
			}
			if (points >= 900 && points < 1000)
			{
				return title10;
			}
			if (points >= 1000 && points < 1500)
			{
				return title11;
			}
			if (points >= 1500 && points < 2000)
			{
				return title12;
			}
			if (points >= 2000 && points < 2500)
			{
				return title13;
			}
			if (points >= 2500 && points < 3000)
			{
				return title14;
			}
			if (points >= 3000 && points < 5000)
			{
				return title15;
			}
			if (points >= 5000 && points < 7000)
			{
				return title16;
			}
			if (points >= 7000 && points < 10000)
			{
				return title17;
			}
			if (points >= 10000 && points < 15000)
			{
				return title18;
			}
			if (points >= 15000 && points < 20000)
			{
				return title19;
			}
			if (points >= 20000 && points < 30000)
			{
				return title20;
			}
			if (points >= 30000 && points < 40000)
			{
				return title21;
			}
			if (points >= 40000 && points < 50000)
			{
				return title22;
			}
			if (points >= 50000 && points < 60000)
			{
				return title23;
			}
			if (points >= 60000 && points < 70000)
			{
				return title24;
			}
			if (points >= 70000 && points < 80000)
			{
				return title25;
			}
			if (points >= 80000 && points < 90000)
			{
				return title26;
			}
			if (points >= 90000 && points < 100000)
			{
				return title27;
			}
			if (points >= 100000 && points < 110000)
			{
				return title28;
			}
			if (points >= 110000 && points < 120000)
			{
				return title29;
			}
			if (points >= 120000 && points < 130000)
			{
				return title30;
			}
			if (points >= 130000 && points < 140000)
			{
				return title31;
			}
			if (points >= 140000 && points < 150000)
			{
				return title32;
			}
			if (points >= 150000 && points < 160000)
			{
				return title33;
			}
			if (points >= 160000 && points < 170000)
			{
				return title34;
			}
			if (points >= 170000 && points < 180000)
			{
				return title35;
			}
			if (points >= 180000 && points < 190000)
			{
				return title36;
			}
			if (points >= 190000 && points < 200000)
			{
				return title37;
			}
			if (points >= 200000 && points < 210000)
			{
				return title38;
			}
			if (points >= 210000 && points < 220000)
			{
				return title39;
			}
			if (points >= 220000 && points < 230000)
			{
				return title40;
			}
			if (points >= 230000 && points < 240000)
			{
				return title41;
			}
			if (points >= 240000 && points < 250000)
			{
				return title42;
			}
			if (points >= 250000 && points < 260000)
			{
				return title43;
			}
			if (points >= 260000 && points < 270000)
			{
				return title44;
			}
			if (points >= 270000 && points < 280000)
			{
				return title45;
			}
			if (points >= 280000 && points < 290000)
			{
				return title46;
			}
			if (points >= 290000 && points < 300000)
			{
				return title47;
			}
			if (points >= 300000 && points < 310000)
			{
				return title48;
			}
			if (points >= 310000 && points < 320000)
			{
				return title49;
			}
			if (points >= 320000 && points < 330000)
			{
				return title50;
			}
			if (points >= 330000 && points < 340000)
			{
				return title51;
			}
			if (points >= 340000 && points < 350000)
			{
				return title52;
			}
			if (points >= 350000 && points < 360000)
			{
				return title53;
			}
			if (points >= 360000 && points < 370000)
			{
				return title54;
			}
			if (points >= 370000 && points < 380000)
			{
				return title55;
			}
			if (points >= 380000 && points < 390000)
			{
				return title56;
			}
			if (points >= 390000 && points < 400000)
			{
				return title57;
			}
			if (points >= 400000 && points < 410000)
			{
				return title58;
			}
			if (points >= 410000 && points < 420000)
			{
				return title59;
			}
			if (points >= 420000 && points < 430000)
			{
				return title60;
			}
			if (points >= 430000 && points < 440000)
			{
				return title61;
			}
			if (points >= 440000 && points < 450000)
			{
				return title62;
			}
			if (points >= 450000 && points < 460000)
			{
				return title63;
			}
			if (points >= 460000 && points < 470000)
			{
				return title64;
			}
			if (points >= 470000 && points < 480000)
			{
				return title65;
			}
			if (points >= 480000 && points < 490000)
			{
				return title66;
			}
			if (points >= 490000 && points < 500000)
			{
				return title67;
			}
			if (points >= 500000 && points < 510000)
			{
				return title68;
			}
			if (points >= 510000 && points < 520000)
			{
				return title69;
			}
			if (points >= 520000 && points < 530000)
			{
				return title70;
			}
			if (points >= 530000 && points < 540000)
			{
				return title71;
			}
			if (points >= 540000 && points < 550000)
			{
				return title72;
			}
			if (points >= 550000 && points < 560000)
			{
				return title73;
			}
			if (points >= 560000 && points < 570000)
			{
				return title74;
			}
			if (points >= 570000 && points < 580000)
			{
				return title75;
			}
			if (points >= 580000 && points < 590000)
			{
				return title76;
			}
			if (points >= 590000 && points < 600000)
			{
				return title77;
			}
			if (points >= 600000 && points < 610000)
			{
				return title78;
			}
			if (points >= 610000 && points < 620000)
			{
				return title79;
			}
			if (points >= 620000 && points < 630000)
			{
				return title80;
			}
			if (points >= 630000 && points < 640000)
			{
				return title81;
			}
			if (points >= 640000 && points < 650000)
			{
				return title82;
			}
			if (points >= 650000 && points < 660000)
			{
				return title83;
			}
			if (points >= 660000 && points < 670000)
			{
				return title84;
			}
			if (points >= 670000 && points < 680000)
			{
				return title85;
			}
			if (points >= 680000 && points < 690000)
			{
				return title86;
			}
			if (points >= 690000 && points < 700000)
			{
				return title87;
			}
			if (points >= 700000 && points < 710000)
			{
				return title88;
			}
			if (points >= 710000 && points < 720000)
			{
				return title89;
			}
			if (points >= 720000 && points < 730000)
			{
				return title90;
			}
			if (points >= 730000 && points < 740000)
			{
				return title91;
			}
			if (points >= 740000 && points < 750000)
			{
				return title92;
			}
			if (points >= 750000 && points < 760000)
			{
				return title93;
			}
			if (points >= 760000 && points < 770000)
			{
				return title94;
			}
			if (points >= 770000 && points < 780000)
			{
				return title95;
			}
			if (points >= 780000 && points < 790000)
			{
				return title96;
			}
			if (points >= 790000 && points < 800000)
			{
				return title97;
			}
			if (points >= 800000 && points < 810000)
			{
				return title98;
			}
			if (points >= 810000 && points < 820000)
			{
				return title99;
			}
			if (points >= 820000 && points < 830000)
			{
				return title100;
			}
			if (points >= 830000 && points < 840000)
			{
				return title101;
			}
			if (points >= 840000 && points < 850000)
			{
				return title102;
			}
			if (points >= 850000 && points < 860000)
			{
				return title103;
			}
			if (points >= 860000 && points < 870000)
			{
				return title104;
			}
			if (points >= 870000 && points < 880000)
			{
				return title105;
			}
			if (points >= 880000 && points < 890000)
			{
				return title106;
			}
			if (points >= 890000 && points < 900000)
			{
				return title107;
			}
			if (points >= 900000 && points < 1000000)
			{
				return title108;
			}
			if (points >= 1000000)
			{
				return title109;
			}
			return "звание";
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