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
        private const int COL = 2;
        public RecordsTable()
        {
            InitializeComponent();

            createCells();
        }

        SudokuCell[,] cells = new SudokuCell[COL, ROW];

        private void createCells()
        {
            for (int i = 0; i < COL; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    // Create 81 cells for with styles and locations based on the index
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(400, 40);
                    //cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 400, j * 40);
                    cells[i, j].BackColor = ((i / 2) + (j / 1)) % 2 == 0 ? Color.Khaki : Color.SandyBrown;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    //cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    //cells[i, j].X = i;
                    //cells[i, j].Y = j;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
            cells[0, 0].Text = "Имя";
            cells[1, 0].Text = "Время";
            cells[1, 0].Font = cells[0, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
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
    }
}
