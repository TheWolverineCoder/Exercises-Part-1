str_kont('Egypt','Africa').
str_kont('Russia','Europe').
str_kont('Russia','Asia').
str_kont('France','Europe').
str_kont('Japan','Asia').
str_kont('MagicLand','Europe').
str_kont('Bulgaria','Europe').
stolica_str('Berlin','Germany').
stolica_str('Sofia','Bulgaria').
stolica_str('Talin','Estonia').
stolica_str('Moscow','Russia').
stolica_str('Paris','France').
stolica_str('Tokyo','Japan').
stolica_str('Abra Kadabra','MagicLand').
stolica_str('Cairo','Egypt').
gr_nasel('Sofia',1850000).
gr_nasel('Tokyo',7500500).
gr_nasel('Moscow',21000300).
gr_nasel('Paris',6600500).
gr_nasel('Berlin',9000888).
gr_nasel('Plovdiv',550000).
gr_nasel('Silistra',95000).
gr_nasel('Karnobat',95000).
gr_nasel('Abra Kadabra',33333333).
malko_nasel_grad(X):- gr_nasel(X,Y), \+ (gr_nasel(_,H),Y>H),!.
grad_s_po_malko_naselenie_ot(X,Y):-gr_nasel(X,C), \+ (gr_nasel(Y,B),B<C,X\=Y).

 /*1.България в европа ли е?
str_kont('Bulgaria','Europe'),nl,fail

2.В кой континент е България?
str_kont('Bulgaria',X),write(X),nl,fail

3.Кои са страните в Европа?
str_kont(X,'Europe'),write(X),nl,fail

4.Кои са европейските столици?
str_kont(X,'Europe'),stolica_str(Y,X),write(Y),nl,fail

5.Кои градове са с население над 3 млн.?
gr_nasel(X,Y),Y>3000000,write(X),nl,fail

6.Кои са столиците с население над 7 млн.?
stolica_str(X,_),gr_nasel(X,Y),Y>7000000,write(X),nl,fail

7.Има ли два града с еднакъв брой жители?
gr_nasel(X,Y),gr_nasel(J,Y),X@<J,write(X),write(' и '),write(J),nl,fail

8.Кои са континентите, в които има страни със столица с над 4 млн. жители?
str_kont(A,B),stolica_str(C,A),gr_nasel(C,Y),Y>4000000,write(B),nl,fail
п.п така и не успях да махна дублирането

9.Кои са градовете,които не са столици на някоя страна?
gr_nasel(X,_),not(stolica_str(X,Y)),write(X),nl,fail

10.Кои са градовете, чието население е по-малко от населението на друг град?
grad_s_po_malko_naselenie_ot(X,'Sofia'),write(X),nl,fail
п.п тук вместо София можем да пишем всеки друг град

11.Кой град е с най-малко население?
malko_nasel_grad(X),write(X),nl,fail

12.Кои са страните в Азия или Европа?
str_kont(X,Y),(Y ='Europe';Y ='Asia'),write(X),nl,fail
*/
