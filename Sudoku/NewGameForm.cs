using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class NewGameForm : Form
    {
        public Bitmap Logo = Resource1.SUDOKU;


        public NewGameForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            this.Close();
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            var hintsCount = 0;
            var mode = "";
            if (this.classic_mode.Checked)
                mode = "classic";
            else if (this.even_odd_mode.Checked)
                mode = "even_odd";
            if (this.beginnerLevel.Checked)
                hintsCount = 45;
            else if (this.IntermediateLevel.Checked)
                hintsCount = 30;
            else if (this.AdvancedLevel.Checked)
                hintsCount = 15;
            if (hintsCount != 0 && inputName.Text != "")
            {
                GameProcess game = new GameProcess(inputName.Text, hintsCount, mode);
                this.Hide();
                game.Show();
            }
            else
            {
                playSimpleSound("Windows Background.wav");
                MessageBox.Show("Выберите уровень сложности и/или введите имя!");
            }
        }

        private void recordsButton_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            RecordsTable records = new RecordsTable();
            records.Show();
        }

        private void rules_button_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            Rules rules = new Rules();
            rules.Show();
        }

        private void NewGameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(Logo, new Rectangle(Width / 2 - 160, 28, 320, 72));
        }

        private void playSimpleSound(string filename)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\" + filename);
            simpleSound.Play();
        }

        
    }
}
