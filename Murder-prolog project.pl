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

:- use_rendering(table,[header(occupant('Person', 'Gender', 'Role', 'Age'))]).
person(theman). 
person(thewoman). 
person(femaleStudent).
person(maleStudent).

gender(male).
gender(female).

age(1).
age(2).
age(3).
age(4).

role(witness).
role(killerAssisant).
role(killer).
role(victim).
обитат(_Person, _Gender, _Role, _Age).
unique([]):-!.
unique([Head|Tail]):- member(Head, Tail), !, fail; unique(Tail).
buildingOccupants(Occ):- 
    Occ = [occupant(Person1, Gender1, Role1, Age1), 
          occupant(Person2, Gender2,  Role2, Age2),
          occupant(Person3, Gender3,  Role3, Age3), 
          occupant(Person4, Gender4,  Role4, Age4)],
	person(Person1), person(Person2), person(Person3), person(Person4),
		unique([Person1,Person2,Person3,Person4]),
	gender(Gender1), gender(Gender2), gender(Gender3), gender(Gender4),
	role(Role1), role(Role2), role(Role3), role(Role4),
		unique([Role1,Role2,Role3,Role4]),	
	age(Age1), age(Age2), age(Age3), age(Age4),
		unique([Age1,Age2,Age3,Age4]),
    
    
    % genders of occupants
  member(occupant(theman,male,_,_),Occ),member(occupant(maleStudent,male,_,_),Occ),
  member(occupant(thewoman,female,_,_),Occ),member(occupant(femaleStudent,female,_,_),Occ),
  %The youngest was not the killer.The youngest was also not the victim
    not(member(occupant(_,_,killer,1),Occ)),
    not(member(occupant(_,_,victim,1),Occ)),
    % The man was older than the woman.
(member(occupant(theman,male,_,4),Occ),member(occupant(thewoman,female,_,3),Occ)), 
    % The witness and the killer assistant are not the same gender.
((member(occupant(_,male,witness,_),Occ),member(occupant(_,female,killerAssisant,_),Occ));
 (member(occupant(_,male,killerAssisant,_),Occ),member(occupant(_,female,witness,_),Occ))),
 % The oldest man and the witness are not the same gender
 (member(occupant(thewoman,female,witness,_),Occ);
  member(occupant(femaleStudent,female,witness,_),Occ)),
      
% The killer assistant was older than the victim.So if 1 is not the victim the age of the 
% killer assistant must be either 3 or 4    
 (member(occupant(theman,male,killerAssisant,4),Occ);
  member(occupant(_,_,killerAssisant,3),Occ)),
% The youngest and the victim are not the same gender
((member(occupant(_,male,_,1),Occ),member(occupant(_,female,victim,_),Occ));
 (member(occupant(_,male,victim,_),Occ),member(occupant(_,female,_,1),Occ))),
   
 
Occ = [occupant(_,_,killer,_),occupant(_,_,killerAssisant,_),occupant(_,_,witness,_),occupant(_,_,victim,_)].    

% ?-buildingOccupants(Occ). to call the table

