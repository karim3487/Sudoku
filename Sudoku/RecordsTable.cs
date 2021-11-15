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

        SudokuCell[,] cells = new SudokuCell[COL, ROW];

        Records records = new Records();

        private void createCells()
        {
            for (int i = 0; i < COL; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(200, 40);
                    cells[i, j].Location = new Point(i * 200, j * 40);
                    cells[i, j].BackColor = ((i / 2) + (j / 1)) % 2 == 0 ? Color.Khaki : Color.SandyBrown;
                    cells[i, j].FlatStyle = FlatStyle.Flat;

                    cells[i, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    panel1.Controls.Add(cells[i, j]);
                }
            }
            cells[0, 0].Text = cells[2, 0].Text = cells[4, 0].Text = "Имя";
            cells[1, 0].Text = cells[3, 0].Text = cells[5, 0].Text = "Время";            
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
                    cells[coll, row].Text = record.Value;
                    cells[coll + 1, row].Text = record.Key;
                    row++;
                }
            }
            else
            {
                cells[coll, row].Text = "";
                cells[coll + 1, row].Text = "";
            }
            
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

        private void clearRecords_Click(object sender, EventArgs e)
        {
            records.clearFiles();
            this.Close();
            MessageBox.Show("Рекорды успешно очищены!");
        }
    }
}
