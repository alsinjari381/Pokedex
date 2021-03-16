using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SQLite;

namespace Pokedex_GUI
{
	public class Search_Button
	{
		public Button button { get; set; }

		public Search_Button()
		{
			this.button = new Button();
			this.button.Size = new Size(40, 40);
			this.button.Location = new Point(30, 55);
			this.button.Text = "Run";
		}

		public void Execute_Text_Search(Creature_Input data, SQLiteConnection con)
        {
			string weakness_query = $"SELECT weaknesses FROM pokedex WHERE pokemon = \"{data.textBox.Text.ToLower()}\"";
			string resistance_query = $"SELECT resistances FROM pokedex WHERE pokemon = \"{data.textBox.Text.ToLower()}\"";
			string weaknesses = "";
			string resistances = "";

			using (var cmd = new SQLiteCommand(weakness_query, con))
            {
				con.Open();
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read()) // while reading
                    {
						weaknesses = reader.GetString(0);
                    }
                }
				con.Close();
			}

			//yes, you could probably make a function to "never repeat yourself", but i'm repeating myself here for the sake of legibility
			using (var cmd = new SQLiteCommand(resistance_query, con))
            {
				con.Open();
				using (var reader = cmd.ExecuteReader())
                {
					while (reader.Read())
                    {
						resistances = reader.GetString(0);
                    }
                }
				con.Close();
            }

			// if look-up returned any existing pokemon
			if (!(weaknesses == "" && resistances == ""))
			{ 
				Poke_Img.Clear_Images();
				Poke_Img.Upload_Images(weaknesses, "weaknesses");
				Poke_Img.Upload_Images(resistances, "resistances");
			}
		}
	}
}
