using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Pokedex_GUI
{
    public partial class Form1 : Form
    {
        public Rectangle rect;
        public Search_Button button1, button2;
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
            
            button1 = new Search_Button(30, 55, "run");
            this.Controls.Add(button1.button);
            button1.button.Click += new EventHandler(button1_Click);

            button2 = new Search_Button(150, 55, "Enable Gameplay Mode");
            this.Controls.Add(button2.button);
            button2.button.Click += new EventHandler(button2_Click);

            pokemon_input = new Creature_Input();
            this.Controls.Add(pokemon_input.textBox);

            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(E_KeyPress);
        }


        private void E_KeyPress(object sender, KeyEventArgs e)
        {
            //find the coordinates of the rectangle which we'll be performing OCR on
            if (button1.button.Text == "Initializing...")
            {

                if (Poke_Img.counter == 0)
                {
                    if (e.KeyCode == Keys.E)
                    {
                        Poke_Img.top_left = new Point(Cursor.Position.X, Cursor.Position.Y);
                        Poke_Img.counter++;
                    }
                }

                else if (Poke_Img.counter == 1)
                {
                    if (e.KeyCode == Keys.E)
                    {
                        button1.button.Text = "Set viewing area";
                        MessageBox.Show("Viewing area initialized.");

                        Poke_Img.bottom_right = new Point(Cursor.Position.X, Cursor.Position.Y);
                        Poke_Img.Snapshot = new Rectangle(Poke_Img.top_left.X, Poke_Img.top_left.Y, Math.Abs(Poke_Img.bottom_right.X - Poke_Img.top_left.X), Math.Abs(Poke_Img.bottom_right.Y - Poke_Img.top_left.Y));
                        Poke_Img.counter = 0;
                    }
                }
            }

            //run search query
            else
            {
                if (button2.button.Text == "Enable Dictionary Mode")
                    button1.Execute_OCR_Search(pokemon_input,sql_connection);
            }
        }

        // button2's text can serve as an indicator of which "mode" our program is on
        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.button.Text == "Enable Gameplay Mode")
                button1.Execute_Text_Search(pokemon_input, sql_connection);
            else
            {
                button1.button.Text = "Initializing...";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.button.Text == "Enable Gameplay Mode")
            {
                this.Opacity = .75;
                Poke_Img.Clear_Images();
                button1.button.Text = "Set viewing area";
                button2.button.Text = "Enable Dictionary Mode";
            }
            else
            {
                this.Opacity = 1;
                Poke_Img.Clear_Images();
                button1.button.Text = "Run";
                button2.button.Text = "Enable Gameplay Mode";
            }
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
