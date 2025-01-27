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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace hangman
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int height, width;

        int wrongGuesses = 0;
        PictureBox hangmanPictureBox = new PictureBox();
        

        public Form1()
        {
            InitializeComponent();
            height = 1000; 
            width = 1000;
            Size = new Size(width, height);
            
            hangmanPictureBox.Size = new Size(300, 300); 
            hangmanPictureBox.Location = new Point((width - hangmanPictureBox.Width) / 2, 700); 
            hangmanPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(hangmanPictureBox);

            UpdateHangmanImage();
        }

        private void UpdateHangmanImage()
        {
            string imagePath = $"{wrongGuesses}.png"; 

            if (File.Exists(imagePath))
            {
                hangmanPictureBox.Image = Image.FromFile(imagePath); 
            }
            else
            {
                hangmanPictureBox.Image = null; 
            }
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
                //MessageBox.Show(chosen);
                word_to_be_guessed(chosen);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textFile = "autok.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string chosen = lines[rnd.Next(0, lines.Length)];
                char[] letters = chosen.ToUpper().ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
                word_to_be_guessed(chosen);
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
                char[] letters = chosen.ToUpper().ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
                word_to_be_guessed(chosen);
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
                char[] letters = chosen.ToUpper().ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
                word_to_be_guessed(chosen);
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
                char[] letters = chosen.ToUpper().ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
                word_to_be_guessed(chosen);
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
                char[] letters = chosen.ToUpper().ToCharArray();
                game(letters);
                //MessageBox.Show(chosen);
                word_to_be_guessed(chosen);
            }
        }

        List<Label> labels = new List<Label>();

        private void word_to_be_guessed(string chosen)
        {
            char[] letters = chosen.ToUpper().ToCharArray();
            int startX = 300; 
            int startY = 200; 
            int spacing = 50; 

            
            foreach (var label in labels)
            {
                this.Controls.Remove(label);
            }
            labels.Clear();

            
            for (int i = 0; i < letters.Length; i++)
            {
                Label label = new Label();
                label.Text = "_"; 
                label.Tag = letters[i]; 
                label.Size = new Size(40, 50);
                label.Location = new Point(startX + i * spacing, startY);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Arial", 16, FontStyle.Bold);
                this.Controls.Add(label);
                labels.Add(label);
            }
        }

        public int tips = 0;
        public int correct_guesses = 0;

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
                    char guessedLetter = char.Parse(letter);

                    
                    if (letters.Contains(guessedLetter))
                    {
                        correct_guesses++;
                        tips++;
                        MessageBox.Show("Talált!");

                        
                        for (int i = 0; i < letters.Length; i++)
                        {
                            if (letters[i] == guessedLetter)
                            {
                                labels[i].Text = guessedLetter.ToString(); 
                            }
                        }
                        this.Controls.Remove(button);
                        if (letters.Length == correct_guesses)
                        {
                            MessageBox.Show($"Kitaláltad! Próbálkozások: {tips}");
                            Application.Restart();
                        }
                    }
                    else
                    {
                        wrongGuesses++;
                        UpdateHangmanImage(); 
                        tips++;
                        MessageBox.Show("Nem talált!");
                        if (wrongGuesses == 8)
                        {
                            MessageBox.Show($"Vesztettél!");
                            Application.Restart();
                            
                        }
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

