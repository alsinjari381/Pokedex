# Pokedex
A simple GUI that looks up a Pokemon's type weaknesses and resistances. Originally I was going to include an OCR engine to analyze your screen and automatically figure out what Pokemon there was, but it turned out to be not so useful due to the often low-font of Pokemon battles and the background always changing inbetween seperate battles. The feature still stays, and works well if you're playing with a larger font with a clear background(for some reason).

![image](https://user-images.githubusercontent.com/76085879/111940932-2cb4cb80-8a8d-11eb-9e4e-ee464433c438.png)

The program searches an SQLite database and recovers the weaknesses & resistances of a Pokemon. If you press "Enable Gameplay"...

![image](https://user-images.githubusercontent.com/76085879/111940981-48b86d00-8a8d-11eb-886c-38bed465e643.png)

The program will become clearer so you can easily put it over a game window. If you press the "Set Viewing Area" button, a prompt will show up, and you can press E in two places - one which would be the designated top-left corner, and the other the bottom-right corner. This will form the snapshot area, for the OCR to take a screenshot and process said image. Afterwords, you can press the E key for the program to take a picture and analyze.
