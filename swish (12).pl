% всеки жител на сградата в списъка съдържа данни за:
	% buildingOccupants('Person', 'Gender', 'Age','Role')
    % колкото по-възрастен е човекът,толкова по-голямо е числото при 'Age' - 
    %съответно най-възрастният е с числото 4,а най-младият с 1
person('The man'). 
person('The woman'). 
person('Male student').
person('Female student').
gender('male').
gender('female').
age(1).
age(2).
age(3).
age(4).
role('Killer').
role('Killer Assistant').
role('The witness'). 
role('Victim').
unique([]):-!.
unique([Head|Tail]):- member(Head, Tail), !, fail; unique(Tail).
:- use_rendering(table,[header(buildingOccupants('Person', 'Gender', 'Age','Role'))]).
occupants(Occ) :-
Occ = [buildingOccupants('Person1', 'Gender1', 'Age1','Role1'), buildingOccupants('Person2', 'Gender2', 'Age2','Role2'),
           buildingOccupants('Person3', 'Gender3', 'Age3','Role3'), buildingOccupants('Person4', 'Gender4', 'Age4','Role4')],
			person(Person1), person(Person2), person(Person3), person(Person4),
			unique([Person1,Person2,Person3,Person4]),
			gender(Gender1), gender(Gender2), gender(Gender3), gender(Gender4),
			unique([Gender1,Gender2,Gender3,Gender4]),
			age(Age1), age(Age2), age(Age3), age(Age4),
			unique([Age1,Age2,Age3,Age4]),
            role(Role1), role(Role2), role(Role3), role(Role4),
			unique([Role1,Role2,Role3,Role4]),
	length(Occ, 4), 
    member(buildingOccupants('The man','male',_,'Killer Assistant'), Occ), 
    member(buildingOccupants('The woman','female',_,'Killer'), Occ), 
    member(buildingOccupants('The man','male',4,_), Occ), 
    member(buildingOccupants('The woman','female',3,_), Occ),
    member(buildingOccupants('Male student','male',_,_), Occ),	
    member(buildingOccupants('Male student','male',2,'Victim'), Occ),	
    member(buildingOccupants('Female student','female',_,_), Occ), 
    not(member(buildingOccupants(_,'male',_,'The witness'),Occ)),
	not(member(buildingOccupants(_,'female',_,'Killer Assistant'),Occ)),
	not(member(buildingOccupants(_,_,1,'Killer'),Occ)),  
    not(member(buildingOccupants(_,_,1,'Victim'),Occ)),  
    member(buildingOccupants(_,'male',4,'Killer Assistant'), Occ).
     /*member(buildingOccupants(_,'male',4,'Killer Assistant'), Occ)).*/
	[buildingOccupants(_, _, _,'Killer'),buildingOccupants(_, _, _,'Killer Assistant'), 
    buildingOccupants(_, _, _,'The witness'),buildingOccupants(_, _, _,'Victim')].
	
