import sqlite3, os, re
from sqlite3 import Error

def main():
    con = connection()
    while True:
        entry = input()
        if (entry.lower() == "exit"):
            break

        weakness_command = execute_read(con, 'SELECT weaknesses FROM pokedex WHERE pokemon = "%s"' % (entry))
        resistance_command = execute_read(con, 'SELECT resistances FROM pokedex WHERE pokemon = "%s"' % (entry))
        #regex removes '[](), to make output more user friendlyu
        resistance_command = re.sub(r"['(),\[\]]", "", str(resistance_command))
        weakness_command = re.sub(r"['(),\[\]]", "", str(weakness_command))
        print("Weaknesses:", weakness_command)
        print("Resistances:", resistance_command)
        
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

def execute_read(connection, query):
    cursor = connection.cursor()
    result = None
    try:
        cursor.execute(query)
        result = cursor.fetchall()
        return result
    except Error as e:
        print("Error!", e)

main()
