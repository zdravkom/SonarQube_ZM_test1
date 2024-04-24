# ConsoleApp1_Zadatak_20221124

Zadatak - Valamar (12. mj. 2022 g.)

U nastavku je riješenje za N LogN
-------------------------
Da bude malo plastičnije ti nacrtam jedan od mogućih smjerova razmišljanja
Podatke stavimo u tablicu – dobijemo ovako nešto
Recimo da tražimo da je suma 15, odnosno najbliže kombinacije

U toj tablici onda označimo brojeve koji su oko broja 15 i onda idemo tražiti algoritam kako da njih izvučemo vani

Prvi korak bi recimo mogao biti da izbacimo sve kolone i stupce di je vrijedno u array veca od 15, tako da smanjimo kvadrat
Drugi korak bi onda mogao biti da vidimo koja je vrijednost na centralnoj čeliji i da eliminiramo dio tablice i onda idemo na ostale djelove tablice

![Tablica_rijesavanja_zadatka_Valamar_202212](https://user-images.githubusercontent.com/1702535/206447362-5fb57a0a-9d0d-47ab-b245-1e4afc1a64dd.jpg)


Najprije pogledamo element koji je na sredini tablice
akt_X=max_x/2
akt_y=max_y/2

vrijednost elementa tablica[akt_x, akt_y] je 13.
to znači da sve x<akt_x ne trebamo gledati jer su sigurno manji.
to znači da sve y<akt_y ne trebamo gledati jer su sigurno manji.

I tako onda obrađujemo dalje

LP,

FR,

Valamar Riviera d.d.
