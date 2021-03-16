using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Pokedex_GUI
{
    public partial class Form1 : Form
    {
        public Search_Button button1;
        public Creature_Input pokemon_input;
        public SQLiteConnection sql_connection;
        public Labels labels;

        private void InitComponents()
        {
            Text = "PokeDex";
            //temporary, replace data source
            sql_connection = new SQLiteConnection("Data Source=C:\\pokedexproj\\pokedex.db");
            Size = new Size(300, 600);

            labels = new Labels();
            for (int i = 0; i < labels.printed_labels.Length; i++)
                this.Controls.Add(labels.printed_labels[i]);

            Poke_Img.Initialize_Box_Position();
            for (int i = 0; i < Poke_Img.pictureBoxes.Length; i++)
                this.Controls.Add(Poke_Img.pictureBoxes[i]);

            button1 = new Search_Button();
            this.Controls.Add(button1.button);
            button1.button.Click += new EventHandler(button1_Click);

            pokemon_input = new Creature_Input();
            this.Controls.Add(pokemon_input.textBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Execute_Text_Search(pokemon_input, sql_connection);
        }
        public Form1()
        {
            //Microsoft's initializer 
            InitializeComponent();
            //Our own Winforms initializer
            InitComponents();
        }

    }
}
