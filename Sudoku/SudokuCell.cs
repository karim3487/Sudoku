using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    class SudokuCell : Button
    {
        public SudokuCell(int size, Point location)
        {
            this.Font = new Font(SystemFonts.DefaultFont.FontFamily, 25);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.Black;
            this.ForeColor = SystemColors.ControlDarkDark;
            this.Size = new Size(size, size);
            this.Location = location;

        }

        public int Value { get; set; }
        public bool IsLocked { get; set; }
        public bool IsFilled { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Clear()
        {
            this.Text = string.Empty;
            this.IsLocked = false;
            this.IsFilled = false;
        }
    }

    class Notes : Label
    {
        public int Value { get; set; }
        public bool IsLocked { get; set; }

    }

}