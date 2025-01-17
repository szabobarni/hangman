using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int height, width;
        public Form1()
        {
            InitializeComponent();
            height = 500;
            width = 800;
            Size = new Size(width, height);
        }
        private void game(char[] letters)
        {
            label1.Text = "TALÁLJA KI!";
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Location = new Point(150, 10);
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(button3);
            this.Controls.Remove(button4);
            this.Controls.Remove(button5);
            this.Controls.Remove(button6);
            abc(letters);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textFile = "allatok.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0,lines.Length)];
                int length = chosen.Length;
                char[] letters = chosen.ToUpper().ToCharArray();
                game(letters);
                MessageBox.Show(chosen);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textFile = "autok.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0, lines.Length)];
                char[] letters = chosen.ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string textFile = "edessegek.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0, lines.Length)];
                int length = chosen.Length;
                char[] letters = chosen.ToCharArray();
                game(letters);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string textFile = "markak.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0, lines.Length)];
                int length = chosen.Length;
                char[] letters = chosen.ToCharArray();
                game(letters);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string textFile = "orszagok.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0, lines.Length)];
                int length = chosen.Length;
                char[] letters = chosen.ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string textFile = "varosok.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0, lines.Length)];
                int length = chosen.Length;
                char[] letters = chosen.ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
            }
        }
        private void abc(char[] letters)
        {
            string[] abc = {
            "A", "Á", "B", "C", "D", "E", "É", "F", "G",  "H", "I", "Í",
            "J", "K", "L", "M", "N",  "O", "Ó", "Ö", "Ő", "P", "Q", "R", "S",  "T",
            "U", "Ú", "Ü", "Ű", "V", "W", "X", "Y", "Z", 
        };

            int buttonWidth = 60;
            int buttonHeight = 40;
            int margin = 10;
            int x = margin;
            int y = margin;

            foreach (string letter in abc)
            {
                Button button = new Button();
                button.Text = letter;
                button.Size = new Size(buttonWidth, buttonHeight);
                button.Location = new Point(x, 250+y);
                button.Click += (sender, e) =>
                {
                    char a = char.Parse(letter);
                    if (letters.Contains(a))
                    {
                        MessageBox.Show("jo");
                        this.Controls.Remove(button);
                    }
                    else
                    {
                        MessageBox.Show("rossz");
                        this.Controls.Remove(button);
                    }
                };

                this.Controls.Add(button);

                x += buttonWidth + margin;

                if (x + buttonWidth + margin > this.ClientSize.Width)
                {
                    x = margin;
                    y += buttonHeight + margin;
                }
            }
        }
    }
}
