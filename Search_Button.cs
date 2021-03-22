using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SQLite;

namespace Pokedex_GUI
{
	public class Search_Button
	{
		public Button button { get; set; }
		
		public Search_Button(int x, int y, string text)
		{
			this.button = new Button();
			this.button.Size = new Size(80, 40);
			this.button.Location = new Point(x, y);
			this.button.Text = text;
		}


		public void Execute_Text_Search(Creature_Input data, SQLiteConnection con)
		{
			string weakness_query = $"SELECT weaknesses FROM pokedex WHERE pokemon = \"{data.textBox.Text.ToLower().Trim()}\"";
			string resistance_query = $"SELECT resistances FROM pokedex WHERE pokemon = \"{data.textBox.Text.ToLower().Trim()}\"";
			Continue_Search(weakness_query, resistance_query, con);
		}

		public void Execute_OCR_Search(Creature_Input data, SQLiteConnection con)
		{
			string pokemon = Poke_Img.Analyze_Screenshot(data);
			string weakness_query = $"SELECT weaknesses FROM pokedex WHERE pokemon = \"{pokemon.ToLower().Trim()}\"";
			//MessageBox.Show(weakness_query);
			string resistance_query = $"SELECT resistances FROM pokedex WHERE pokemon = \"{pokemon.ToLower().Trim()}\"";
			Continue_Search(weakness_query, resistance_query, con);
		}


		private void Continue_Search(string weakness_query, string resistance_query, SQLiteConnection con)
        {
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
			Poke_Img.Clear_Images();
			
			// if look-up returned any existing pokemon
			if (!(weaknesses == "" && resistances == ""))
			{ 
				Poke_Img.Upload_Images(weaknesses, "weaknesses");
				Poke_Img.Upload_Images(resistances, "resistances");
			}
		}
	}
}
