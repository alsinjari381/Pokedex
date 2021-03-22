# Pokedex
A simple GUI that looks up a Pokemon's type weaknesses and resistances. Originally I was going to include an OCR engine to analyze your screen and automatically figure out what Pokemon there was, but it turned out to be not so useful due to the often low-font of Pokemon battles and the background always changing inbetween seperate battles. The feature still stays, and works well in certain scenarios.

![image](https://user-images.githubusercontent.com/76085879/111940932-2cb4cb80-8a8d-11eb-9e4e-ee464433c438.png)

The program searches an SQLite database and recovers the weaknesses & resistances of a Pokemon. The database is constructed by running the Database Constructor Python script, which scrapes pokemondb.net and creates a database from the subsequent information. If you press "Enable Gameplay"...

![image](https://user-images.githubusercontent.com/76085879/111940981-48b86d00-8a8d-11eb-886c-38bed465e643.png)

The program will become clearer so you can easily put it over a game window. If you press the "Set Viewing Area" button, a prompt will show up, and you can press E in two places - one which would be the designated top-left corner, and the other the bottom-right corner. This will form the snapshot area, for the OCR to take a screenshot and process said image. Afterwords, you can press the E key for the program to take a picture and analyze.

![image](https://user-images.githubusercontent.com/76085879/111941201-bd8ba700-8a8d-11eb-9b3d-0642d02964c1.png)

![image](https://user-images.githubusercontent.com/76085879/111941219-c67c7880-8a8d-11eb-8a64-028817f4bb44.png)

This way, while battling, if you wonder the information of a certain Pokemon, rather than painstakingly Googling it and scrolling down to find the answer, you could either type it real quick or simply press the E key and let the computer do the work for you.
