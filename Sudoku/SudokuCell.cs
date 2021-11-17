using System.Windows.Forms;

namespace Sudoku
{
    class SudokuCell : Button
    {
        public int Value { get; set; }
        public bool IsLocked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Clear()
        {
            this.Text = string.Empty;
            this.IsLocked = false;
        }
    }

    class ValuesLabel : Label
    {
        public int Value { get; set; }
        public bool IsLocked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int[,] array = { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };

        public void Clear()
        {
            this.Text = string.Empty;
            this.IsLocked = false;
        }
    }

}