Телеграм-бот групповой викторины. 

Бот дает вопросы по таймеру и реагирует на правильный ответ или какую-либо команду (посказки, старт, стоп и т.д.) на канале. 
Работает по логике викторины IRC-сети прошлых лет. Все причастные имена будут даны ниже. 

Таким образом игроки соревнуются в том, кто быстрее даст ответ на вопрос бота или кто больше наберет очков (ответов).

Соединение бота работает на пулинге (потому что так было проще).

Для запуска и работы минимально нужно отредактировать 2 файла: 

-Telegram/TelegramConnect.cs:

---var token = Environment.GetEnvironmentVariable("TOKEN") ?? "YourToken"; - вместо YourToken вставьте токен вашего бота.
  
-Bot/Configuration.cs:

---OwnerName = "Ulv_filln"; - вместо Ulv_filln вставьте свой юзернейм в телеграме. Это владелец бота с доступом к специфическим командам.

---BotName = "Vik42_bot"; - вместо Vik42_bot вставьте юзернейм своего бота. Хотя сейчас он не используется, но это может поменяться.

Разрешено делать форки этого репозитория, но в форках должны быть сохранены мои копирайты и все причастные к боту имена из метода OutputDescription() файла Bot\OutputTextManagerClasses\OutputTextManagerRussian.cs (English, Belorussian).

По вопросам запуска бота и изменения каких-то функций в вашем форке можете найти меня в телеграме @Ulv_filln или на канале https://t.me/viktorinaIRC или в группе https://vk.com/viktorina_place

Причастные имена:

			  Copyright 2025 Anatoli Kucharau https://vk.com/viktorina_place. All Rights Reserved.
			  Автор программы - Анатолий Кучеров. (Ulv, Ulv_filln)
			  
			  Based on eggdrop scripts (IRC) of Viktorina
			1.6 addons by MOSSs 
			+ modification by Ulv 
			+ some from mrissa.tcl (Based on 3hauka.tcl 2.0.3 by hex and Drakon_) v1.36 (bugsfix) by Maxe_Erte_the_Mad 
			+ 3hauka.tcl 2.0.4-stable+php-stat-mod by hex and Drakon_ 
			+ quiz_q.tcl v1.19 by Kreon (Based on 3hauka.tcl 2.0.4 by hex and Drakon_)
			+ Questions base by Sclex & others.
