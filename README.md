# 👮‍♂️ Police Mobile Data Terminal 👮‍♂️ #

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)

## 🔐 Login 🔐 ##
> - #### Využito základní Identity, které je v ASP.NET Core
> - #### Přidány uživateli další property
> - #### Každý uživatel si může přizpůsobovat svůj účet
> - #### Role pro admina

## 🖥 Technologie 🖥 ##
> - #### ASP.NET Core MVC frontend
> - #### ASP.NET API backend
> - #### Knihovna pro endpointy, modely
> - #### Mapster pro mapování databázových objektů na aplikační

## 🛠 Funkcionalita 🛠 ##
> - #### Slouží jakožto policejní databáze (Můžeme si to představit jako terminál ve vozidle)
> - #### Příslušník Law Enforcementu zde vidí všechny občany
> - #### Po rozkliknutí občana policista může vidět detail osoby, kde vidí jednotlivé záznamy, pokuty a vozidla, která osoba vlastní
> - #### Taktéž zde může vidět vydané zatykače na danou osobu
> - #### Pokud je zde platný zatykač na osobu, zbarví se okno červeně

## 📅 Databáze 📅 ##
> - #### Citizens, Cars, Records, Fines, Warrants, Stations
> - #### Každá tabulka kromě Citizens má v sobě občana, ke kterému určitý záznam je připojen
> - #### SQLite