using System;
using System.Windows.Forms;
using System.Drawing;

namespace Pokedex_GUI
{
    public class Creature_Input
    {
        public TextBox textBox { get; set; }

        public Creature_Input()
        {
            this.textBox = new TextBox();
            this.textBox.Location = new Point(68, 25);
            this.textBox.Height = 40;
            this.textBox.Width = 150;
            this.textBox.BackColor = Color.White;
            this.textBox.ForeColor = Color.Black;
            this.textBox.Text = "Snivy";
            this.textBox.Name = "Textbox";
            this.textBox.Font = new Font("Times New Roman", 12);
        }

        public void ChangeText(string name) { this.textBox.Text = name; }
        
    }
}
