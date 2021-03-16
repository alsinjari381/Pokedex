using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pokedex_GUI
{
    public static class Poke_Img
    {
        // we use this to reference which types are returned by our SQL query
        private static readonly string[] Poke_Names = new string[] { "Normal", 
        "Fire", "Water", "Electric", "Grass", "Ice", "Fighting",
        "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock",
        "Ghost", "Dragon", "Dark", "Steel", "Fairy"};

        public static PictureBox[] pictureBoxes = new PictureBox[36];

        /* what we're doing here is preloading a bunch of pictureboxes with no images inside - once we get the types necessary to return,
         * we will insert the images one by one into each picturebox. this way, we retain a side-by-side order even if the types aren't 
         * necessarily next to each other naturally
         */
        public static void Initialize_Box_Position()
        {
            // weaknesses
            for (int i = 0, x = 50, y = 130; i < 18; i++)
            {
                pictureBoxes[i] = new PictureBox()
                {
                    Size = new Size(50, 19),
                    Location = new Point(x, y),
                    Image = null
                };

                x += 75;

                // the reason we start at 1, so our i input is valid for this equation (if i = 0, 3rd pos would be [2], not [3]
                if ((i + 1) % 3 == 0) // once we've put in 3 icons
                {
                    x = 50;   // return to starting x position
                    y += 30; // and go down one row
                }

            }

            // resistances 
            for (int i = 18, x = 50, y = 340; i < 36 ; i++)
            {
                pictureBoxes[i] = new PictureBox()
                {
                    Size = new Size(50, 19),
                    Location = new Point(x, y),
                    Image = null
                };

                x += 75;

                if ((i + 1) % 3 == 0) 
                {
                    x = 50;  
                    y += 30; 
                }
            }
            
        }

        public static void Upload_Images(string data, string type) // displays images according to what types returned
        {
            for (int i = 0, currentBox = 0; i < Poke_Names.Length; i++)
            {
                if (data.ToUpper().Contains(Poke_Names[i].ToUpper())) {
                    if (type == "weaknesses")
                        pictureBoxes[currentBox].Image = Image.FromFile($".\\types\\Type_{Poke_Names[i]}.png");
                    else // if resistances
                        pictureBoxes[currentBox + 18].Image = Image.FromFile($".\\types\\Type_{Poke_Names[i]}.png");
                    currentBox++;
                }
            }
        }

        public static void Clear_Images()
        {
            for (int i = 0; i < pictureBoxes.Length; i++)
                pictureBoxes[i].Image = null;
        }
    }
}
