using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pokedex_GUI
{
    public class Labels
    {
        public Labels()
        {
            printed_labels[0] = new Label()
            {
                Text = "Pokedex Search",
                Location = new Point(110, 0),
                Font = new Font("Times New Roman", 12)
            };

            printed_labels[1] = new Label()
            {
                Text = "Weaknesses",
                Location = new Point(110, 100),
                Font = new Font("Times New Roman", 12)
            };

            printed_labels[2] = new Label()
            {
                Text = "Resistances",
                Location = new Point(110, 310),
                Font = new Font("Times New Roman", 12)
            };
        }
        //these need to be public to add to controls
        public Label[] printed_labels = new Label[3];
    }
}
