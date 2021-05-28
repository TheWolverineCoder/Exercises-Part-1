% всеки жител на сградата в списъка съдържа данни за:
	% buildingOccupants('Person', 'Gender', 'Age','Role')
    % колкото по-възрастен е човекът,толкова по-голямо е числото при 'Age' - 
    %съответно най-възрастният е с числото 4,а най-младият с 1
/*person(TheMan). 
person(TheWoman). 
person(MaleStudent).
person(FemaleStudent).
gender(male).
gender(female).
age(1).
age(2).
age(3).
age(4).
role(Killer).
role(KillerAssistant).
role(TheWitness). 
role(Victim).
buildingOccupants(_Person,_Gender,_Age,_Role).
unique([]):-!.
unique([Head|Tail]):- member(Head, Tail), !, fail; unique(Tail).

:- use_rendering(table,[header(buildingOccupants('Person', 'Gender', 'Age','Role'))]).
occupants(Occ) :-
Occ = [buildingOccupants(Person1, Gender1, Age1,Role1), buildingOccupants(Person2, Gender2, Age2,Role2),
           buildingOccupants(Person3, Gender3, Age3,Role3), buildingOccupants(Person4, Gender4, Age4,Role4)],
			person(Person1), person(Person2), person(Person3), person(Person4),
			unique([Person1,Person2,Person3,Person4]),
			gender(Gender1), gender(Gender2), gender(Gender3), gender(Gender4),
			age(Age1), age(Age2), age(Age3), age(Age4),
			unique([Age1,Age2,Age3,Age4]),
            role(Role1), role(Role2), role(Role3), role(Role4),
			unique([Role1,Role2,Role3,Role4]),
    member(buildingOccupants(TheMan,man,_,_),Occ),member(buildingOccupants(TheWoman,woman,_,_),Occ),
    member(buildingOccupants(MaleStudent,woman,_,_),Occ),member(buildingOccupants(FemaleStudent,woman,_,_),Occ),
    member(buildingOccupants(TheMan,male,_,KillerAssistant), Occ), 
    member(buildingOccupants(TheWoman,female,_,Killer), Occ), 
    member(buildingOccupants(TheMan,male,4,_), Occ), 
    member(buildingOccupants(TheWoman,female,3,_), Occ),
    member(buildingOccupants(MaleStudent,male,_,_), Occ),	
    member(buildingOccupants(MaleStudent,male,2,Victim), Occ),	
    member(buildingOccupants(FemaleStudent,female,_,_), Occ), 
    not(member(buildingOccupants(_,male,_,TheWitness),Occ)),
	not(member(buildingOccupants(_,female,_,KillerAssistant),Occ)),
	not(member(buildingOccupants(_,_,1,Killer),Occ)),  
    not(member(buildingOccupants(_,_,1,Victim),Occ)),  
    member(buildingOccupants(_,male,4,KillerAssistant), Occ).
    
	[buildingOccupants(_, _, _,Killer),buildingOccupants(_, _, _,KillerAssistant), 
    buildingOccupants(_, _, _,TheWitness),buildingOccupants(_, _, _,Victim)].
*/	

:- use_rendering(table,[header(buildingOccupant('Person', 'Gender', 'Role', 'Age'))]).
person(TheMan). 
person(TheWoman). 
person(MaleStudent).
person(FemaleStudent).

gender(male).
gender(female).

role(killer).
role(killerAssistant).
role(witness).
role(victim).

age(1).
age(2).
age(3).
age(4).


buildingOccupant(_Person, _Gender, _Role, _Age).
unique([]):-!.
unique([Head|Tail]):- member(Head, Tail), !, fail; unique(Tail).
buildingOccupants(Occ):- 
    Occ = [buildingOccupant(Person1, Gender1, Role1, Age1), 
          buildingOccupant(Person2, Gender2, Role2, Age2),
          buildingOccupant(Person3, Gender3, Role3, Age3), 
          buildingOccupant(Person4, Gender4, Role4, Age4)],
	person(Person1), person(Person2), person(Person3), person(Person4),
		unique([Person1,Person2,Person3,Person4]),
	gender(Gender1), gender(Gender2), gender(Gender3), gender(Gender4),
	role(Role1), role(Role2), role(Role3), role(Role4),
		unique([Role1,Role2,Role3,Role4]),	
	age(Age1), age(Age2), age(Age3), age(Age4),
		unique([Age1,Age2,Age3,Age4]),   
    % genders of occupants
  member(buildingOccupant(TheMan,male,_,_),Occ),member(buildingOccupant(TheWoman,female,_,_),Occ),
  member(buildingOccupant(MaleStudent,male,_,_),Occ),member(buildingOccupant(FemaleStudent,female,_,_),Occ),
    %The man is older than the woman so he is 4-the oldest and she is 3-the second oldest
    member(buildingOccupant(TheMan,male,_,4),Occ),member(buildingOccupant(TheWoman,female,3,_),Occ), 
    %1. The witness and the killer assistant are not the same gender
((member(buildingOccupant(_,male,witness,_),Occ),member(buildingOccupant(_,female,killerAssistant,_),Occ));
 (member(buildingOccupant(_,male,killerAssistant,_),Occ),member(buildingOccupant(_,female,witness,_),Occ))),
 	%The killer/the victim is not the youngest one
 	not(member(buildingOccupant(_,_,killer,1),Occ)),
    not(member(buildingOccupant(_,_,victim,1),Occ)),
%2. The oldest one and the witness are not the same gender-so we conclude that the witness is a female
 (member(buildingOccupant(TheWoman,female,witness,_),Occ);
  member(buildingOccupant(FemaleStudent,female,witness,_),Occ)),
%3. The youngest and the victim are not the same gender.
((member(buildingOccupant(_,male,_,1),Occ),member(buildingOccupant(_,female,victim,_),Occ));
 (member(buildingOccupant(_,male,victim,_),Occ),member(buildingOccupant(_,female,_,1),Occ))),
%4. the Killer Assistant is older than the victim so he is either 3 or 4
 (member(buildingOccupant(TheMan,male,killerAssistant,4),Occ);
  member(buildingOccupant(_,_,killerAssistant,_),Occ)),   
Occ = [buildingOccupant(_,_,killer,_),buildingOccupant(_,_,killerAssistant,_),buildingOccupant(_,_,witness,_),buildingOccupant(_,_,victim,_)].    
  % ?-buildingOccupants(Occ).




/*
 VI. Убийство
В един блок живеят мъж, жена и двама студенти - момче и момиче. Една вечер един от
четиримата убил друг от тях. Един от останалите станал свидетел на убийството.
Последният помогнал за убийството.
Дадена ви е следната информация:
1. Свидетелят и този, който е помогнал на убиеца, не са от един и същи пол.
2. Най-старият човек и свидетелят не са от един и същи пол.
3. Най-младият човек и жертвата не са от един и същи пол.
4. Този, който е помогнал за убийството, е бил по-възрастен от жертвата.
5. Мъжът е бил по-стар от жената.
6. Убиецът не е бил най-младият.
Кой е бил убиецът? */
/*
:- use_rendering(table,[header(обитат('Човек', 'Пол', 'Години', 'Роли'))]).
човек(мъжът). 
човек(жената). 
човек(студентка).
човек(студент).

пол(мъж).
пол(жена).

години(1).
години(2).
години(3).
години(4).

роли(свидетел).
роли(помощник).
роли(убиец).
роли(жертва).
обитат(_Човек, _Пол, _Години, _Роли).
unique([]):-!.
unique([Head|Tail]):- member(Head, Tail), !, fail; unique(Tail).
обитатели(Об):- 
    Об = [обитат(Човек1, Пол1, Години1, Роли1), 
          обитат(Човек2, Пол2, Години2, Роли2),
          обитат(Човек3, Пол3, Години3, Роли3), 
          обитат(Човек4, Пол4, Години4, Роли4)],
	човек(Човек1), човек(Човек2), човек(Човек3), човек(Човек4),
		unique([Човек1,Човек2,Човек3,Човек4]),
	пол(Пол1), пол(Пол2), пол(Пол3), пол(Пол4),
		
	години(Години1), години(Години2), години(Години3), години(Години4),
		unique([Години1,Години2,Години3,Години4]),
    роли(Роли1), роли(Роли2), роли(Роли3), роли(Роли4),
		unique([Роли1,Роли2,Роли3,Роли4]),
    
    % участниците по пол
  member(обитат(мъжът,мъж,_,_),Об),member(обитат(студент,мъж,_,_),Об),
  member(обитат(жената,жена,_,_),Об),member(обитат(студентка,жена,_,_),Об),
	
    %1. Свидетелят и този, който е помогнал на убиеца, не са от един и същи пол.
((member(обитат(_,мъж,_,свидетел),Об),member(обитат(_,жена,_,помощник),Об));
 (member(обитат(_,мъж,_,помощник),Об),member(обитат(_,жена,_,свидетел),Об))),
%5. Мъжът е бил по-стар от жената.
(member(обитат(мъжът,мъж,4,_),Об),member(обитат(жената,жена,3,_),Об)),  

%2. Най-старият човек и свидетелят не са от един и същи пол.
 (member(обитат(жената,жена,_,свидетел),Об);
  member(обитат(студентка,жена,_,свидетел),Об)),
%3. Най-младият човек и жертвата не са от един и същи пол.
((member(обитат(_,мъж,1,_),Об),member(обитат(_,жена,_,жертва),Об));
 (member(обитат(_,мъж,_,жертва),Об),member(обитат(_,жена,1,_),Об))),
  not(member(обитат(_,_,1,жертва),Об)),
%4. Този, който е помогнал за убийството, е бил по-възрастен от жертвата, 
 %следователно е най-стария(4) или стария (3)
 (member(обитат(мъжът,мъж,4,помощник),Об);
  member(обитат(_,_,3,помощник),Об)),   
%6. Убиецът не е бил най-младият.
 not(member(обитат(_,_,1,убиец),Об)),
Об = [обитат(_,_,_,убиец),обитат(_,_,_,помощник),обитат(_,_,_,свидетел),обитат(_,_,_,жертва)].    
  % ?-обитатели(Об).
*/
   
