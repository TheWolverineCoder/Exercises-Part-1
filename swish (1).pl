работа('Иван Петров', 'Трета поликлиника', 23).
работа('Стоян Драганов', 'Пълмед', 8).
работа('Стоян Иванов', 'Пълмед', 10).
работа('Петър Кръстев', 'ВМА', 5).
работа('Тихомир Стефанов', 'Пирогов', 11).
работа('Стефан Чочев', 'Иван Рилски', 2).
работа('Ивана Петкова', 'Пълмед', 6).
работа('Стоян Драганов', 'Пълмед', 8).
работа('Михаела Тодорова', 'Първа поликлиника', 14).
работа('Стефан Тихомиров', 'Първа поликлиника', 4).
работа('Александра Димитрова', 'Иван Рилски', 8).
работа('Светла Георгиева', 'ВМА', 10).
работа('Петър Каменов', 'Първа поликлиника', 11).
работа('Симеон Драгоев', 'Пълмед', 7).
работа('Йордан Ростиславов', 'Трета поликлиника', 3).
лекува('Михаела Тодорова', пациент('Иван Иванов', 34)).
лекува('Стоян Драганов', пациент('Нели Томова', 53)).
лекува('Иван Петров',пациент('Христо Ангелов', 76)).
лекува('Иван Петров',пациент('Камен Димов', 23)).
лекува('Йордан Ростиславов',пациент('Камен Димов', 23)).
лекува('Йордан Ростиславов',пациент('Владимир Тенев', 37)).
лекува('Петър Кръстев',пациент('Иван Стоянов', 33)).
лекува('Стоян Иванов',пациент('Георги Стаменов', 35)).
лекува('Ивана Петкова',пациент('Стефан Виденов', 22)).
лекува('Александра Димитрова',пациент('Димо Динев', 56)).
лекува('Стоян Драганов',пациент('Стефан Виденов', 22)).
лекува('Стефан Чочев',пациент('Симеон Тилев', 46)).
пациентна(A,B) :- лекува(B,пациент(A,C)).
/*А) Дефинирайте предикат, който определя лекарите с трудов стаж над10 години.
?-работа(X,Y,Z),Z>10,write(X),write(" "),write(Z)
Б) Напишете цел, която извежда като резултати пациенти на възраст 34 г., лекувани от д-р Михаела Тодорова.
?-лекува(X,пациент(Y,Z)),X='Михаела Тодорова',Z=34,write(Y)
В) Дефинирайте предикат, определящ имената на пациентите, които се лекуват при лекар работещ в Трета поликлиника и има стаж под 15 години.
?-лекува(A,пациент(B,C)),работа(A,F,G),F='Трета поликлиника',G<15,write(B)
Г) Напишете цел, която извежда двама различни пациенти, които се лекуват при един и същи лекар
?-лекува(A,пациент(B,C)),лекува(D,пациент(F,S)),A=D,B\=F,write(B),write(" и "),write(F)
Д) Дефинирайте предикат, който определя пациентите, които не се лекуват в Първа поликлиника.
?-лекува(A,пациент(B,C)),работа(A,F,G),F\='Първа поликлиника',write(B)
Е) Напишете цел, която извежда пациентите, които се лекуват само при един лекар.
?-
*/