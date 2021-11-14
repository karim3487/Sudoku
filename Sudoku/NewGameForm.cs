using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class NewGameForm : Form
    {
        public NewGameForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
            Form1 game = new Form1();
            var hintsCount = 0;

            // Assign the hints count based on the 
            // level player chosen
            if (this.beginnerLevel.Checked)
                hintsCount = 45;
            else if (this.IntermediateLevel.Checked)
                hintsCount = 30;
            else if (this.AdvancedLevel.Checked)
                hintsCount = 15;
            if (hintsCount != 0 && inputName.Text != "")
            {
                this.Hide();
                game.Show();
                game.startNewGame(hintsCount);
            }
            else
                MessageBox.Show("Выберите уровень сложности и/или введите имя!");
        }

        private void recordsButton_Click(object sender, EventArgs e)
        {
            RecordsTable records = new RecordsTable();
            records.Show();
        }
    }
}
