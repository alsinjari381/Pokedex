import re, requests, bs4
import sqlite3, os
from sqlite3 import Error

def main():
    #if a database already exists, clear it
    if(os.path.isfile('.\\pokedex.db')):
        os.remove('.\\pokedex.db')
   
    con = connection()
    create_table = ''' CREATE TABLE pokedex(
    pokemon TEXT,
    weaknesses TEXT,
    resistances TEXT
);
'''
        
    execute(con, create_table)
    #starting_url = 'https://pokemondb.net/pokedex/calyrex'
    starting_url = 'https://pokemondb.net/pokedex/bulbasaur'
    

    scrape_and_update_db(starting_url, con)

     
def connection(path='.\\pokedex.db'):
    try:
        connection = sqlite3.connect(path)
        return connection
    except Error as e:
        print("Error!", e)

def execute(connection, query):
    try:
        cursor = connection.cursor()
        cursor.execute(query)
        connection.commit()
    except Error as e:
        print("Error!", e)

def scrape_and_update_db(url, connection):
    #we create a dict of key ints and value strings - the key is the position in which the Type shows up in data
    #while the value is name of the type (i.e. Normal type shows up first, so key is 0 and value is Normal)
    #we use this in our for loop later. while an enum seems logical, it's better to use a dictionary to be able to assign the appropiate string later on in the code
    
    typeDictionary = {0  : "Normal",
                      1  : "Fire",
                      2  : "Water",
                      3  : "Electric",
                      4  : "Grass",
                      5  : "Ice",
                      6  : "Fighting",
                      7  : "Poison",
                      8  : "Ground",
                      9  : "Flying",
                      10 : "Psychic",
                      11 : "Bug",
                      12 : "Rock",
                      13 : "Ghost",
                      14 : "Dragon",
                      15 : "Dark",
                      16 : "Steel",
                      17 : "Fairy"}
    while True:
        print("Downloading from...", url)
        res = requests.get(url)
        res.raise_for_status()
        soup = bs4.BeautifulSoup(res.text, features = "lxml")

        rawData = soup.find("div", {"class" : "resp-scroll text-center"})

        #now we've sanitized our data into a list, with each value corresponding to a Pokemon type
        typeData = rawData.find_all("td")

        pokeName = re.sub("https://pokemondb.net/pokedex/", "", url)
        super_effective = ""
        not_effective = ""
     
        #sort effectiveness into two strings
        for i in typeDictionary:
            if re.search("super-effective", str(typeData[i])): #returns true if string contains super-effective
                super_effective += typeDictionary[i] + " "
            elif re.search("not very effective", str(typeData[i])):
                not_effective += typeDictionary[i] + " "


        insert_values = '''
            INSERT INTO
            pokedex(pokemon, weaknesses, resistances)
            VALUES
            ('%s', '%s', '%s')''' %(pokeName, super_effective, not_effective)
        execute(connection, insert_values)
        
        try:
            nextLink = soup.select('a[rel="next"]')[0]
            url = 'https://pokemondb.net' + nextLink.get('href')
        except IndexError: #nextLink will throw an IndexError if we reached the last Pokemon (no next)
            print("Finished.")
            break;


main()

#INSERT INTO pokedex(pokemon, id, weaknesses, resistances)
#VALUES
