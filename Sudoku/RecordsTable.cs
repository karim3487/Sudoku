using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class RecordsTable : Form
    {
        private const int ROW = 11;
        private const int COL = 6;
        public RecordsTable()
        {
            InitializeComponent();

            createCells();

            printAllRecords();

        }

        Notes[,] cells = new Notes[COL, ROW];

        Records records = new Records();

        private void createCells()
        {
            var firstColor = Color.FromArgb(195, 232, 139);
            var offsetV = 0;
            var offsetH = 0;
            for (int i = 0; i < COL; i++)
            {
                offsetV += 1;
                offsetV = i % 2 == 0 ? offsetV + 3 : offsetV;
                offsetH = 0;
                for (int j = 0; j < ROW; j++)
                {
                    offsetH = j == 0 || j == 11 ? offsetH + 4 : offsetH + 1;
                    cells[i, j] = new Notes();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(120, 30);
                    cells[i, j].Location = new Point(i * 120 + offsetV, j * 30 + offsetH);
                    cells[i, j].BorderStyle = BorderStyle.None;
                    cells[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    cells[i, j].BackColor = ((i / 2) + (j / 1)) % 2 == 0 ? firstColor : Color.WhiteSmoke;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].Font = new Font("Rubik", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));

                    panel1.Controls.Add(cells[i, j]);
                }
            }
            cells[0, 0].Text = cells[2, 0].Text = cells[4, 0].Text = "Имя";
            cells[1, 0].Text = cells[3, 0].Text = cells[5, 0].Text = "Время";

            cells[0, 0].Font = cells[2, 0].Font = cells[4, 0].Font = new Font("Rubik", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 200);
            cells[1, 0].Font = cells[3, 0].Font = cells[5, 0].Font = new Font("Rubik", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 200);
        }

        private void printAllRecords()
        {
            var beginnerRecords = records.getRecords("beginnerR.txt");
            var advancedRecords = records.getRecords("advancedR.txt");
            var professionalRecords = records.getRecords("professionalR.txt");

            printRecords(beginnerRecords, 0);
            printRecords(advancedRecords, 2);
            printRecords(professionalRecords, 4);
        }

        private void printRecords(Dictionary<string, string> records, int coll)
        {
            int row = 1;
            if(records != null)
            {
                foreach (var record in records)
                {
                    if (row < 11)
                    {
                        cells[coll, row].Text = record.Value;
                        cells[coll + 1, row].Text = record.Key;
                    }
                    row++;
                }
            }
            else
            {
                cells[coll, row].Text = "";
                cells[coll + 1, row].Text = "";
            }
            
        }

        void label1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label1.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

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

        private void clearRecords_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            records.clearFiles();
            this.Close();
            MessageBox.Show("Рекорды успешно очищены!");
        }

        private void playSimpleSound(string filename)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\" + filename);
            simpleSound.Play();
        }
    }
}
