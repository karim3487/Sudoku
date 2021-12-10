using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private bool isActive = false, error_prevention = false, notes = false;
        private int s, m, h, ms;
        private string playerName;
        private int flagForNameFile;
        public Form1(string playerName, int hintsCount)
        {
            InitializeComponent();

            createCells();

            playSoundtrack(true);

            startNewGame(hintsCount);

            this.playerName = playerName;

            flagForNameFile = hintsCount;
        }

        NewGameForm startingTheGame = new NewGameForm();

        SudokuCell[,] cells = new SudokuCell[9, 9];

        ValuesLabel[,] values = new ValuesLabel[3, 3];

        Records records = new Records();

        private void createCells()
        {
            var firstColor = Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(187)))));
            var secondColor = Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(255)))), ((int)(((byte)(99)))));
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Создаем 81 ячейку со стилями и местоположениями на основе индекса
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 25);
                    cells[i, j].Size = new Size(51, 51);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 51, j * 51);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? firstColor : Color.White;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;
                    // Назначаем событие нажатия клавиши для каждой ячейки
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            // Ничего не делать, если ячейка заблокирована
            if (cell.IsLocked)
                return;

            int value;
            bool checkValidInput = int.TryParse(e.KeyChar.ToString(), out value);
            int i = 0;
            Label[] listLabel = new Label[9];
            foreach (Label l in cell.Controls.OfType<Label>())
            {
                listLabel[i] = l;
                l.MouseEnter += new System.EventHandler(cells_MouseEnter); ;
                i++;
            }

            // Добавляем в ячейку значение нажатой клавиши, только если это число
            if (checkValidInput)
            {
                // Очищаем ячейку если нажат 0
                if (error_prevention)
                {
                    if (value == 0)
                        cell.Clear();
                    else if (string.Equals(cell.Value.ToString(), value.ToString()))
                    {
                        cell.Text = value.ToString();
                        cell.ForeColor = Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(47)))), ((int)(((byte)(175)))));
                        for (int notes = 0; notes < 9; notes++)
                            listLabel[notes].Text = "";
                        
                    }
                }
                else
                {
                    if (notes)
                    {
                        if (cell.Text == "")
                        {
                            if (listLabel[value - 1].Text == "")
                                listLabel[value - 1].Text = value.ToString();
                            else
                                listLabel[value - 1].Text = "";
                        }
                    }
                    else
                    {
                        if (value == 0)
                            cell.Clear();
                        else
                        {
                            cell.Text = value.ToString();
                            for (int notes = 0; notes < 9; notes++)
                                listLabel[notes].Text = "";
                        }
                        cell.ForeColor = Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
                    }
                }
            }
        }

        private void startNewGame(int hintsCount)
        {
            loadValues();

            isActive = true; // запускаем таймер

            showRandomValuesHints(hintsCount);
        }

        private void showRandomValuesHints(int hintsCount)
        {
            // Показываем цифры в случайных ячейках
            // Количество показанных цифр зависит от уровня, выбранного игроком.
            for (int i = 0; i < hintsCount; i++)
            {
                var rX = random.Next(9);
                var rY = random.Next(9);

                // По-другому задаем стиль ячеек подсказки и
                // блокируем ячейку, чтобы игрок не мог редактировать значение.
                cells[rX, rY].Text = cells[rX, rY].Value.ToString();
                cells[rX, rY].ForeColor = Color.Black;
                cells[rX, rY].IsLocked = true;
            }
            initNotes(); // загружаем заметки для ячеек, которые !IsLocked
        }

        private void initNotes()
        {
            // В цикле пробегаемся по каждой ячейке поля, если она !IsLocked загружаем в нее 9 лейблов для заметок
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (!cells[i, j].IsLocked)
                            {
                                values[k, l] = new ValuesLabel();
                                values[k, l].Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                values[k, l].Size = new Size(17, 17);
                                values[k, l].Location = new Point(k * 17, l * 17);
                                values[k, l].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                values[k, l].Enabled = false;
                                values[k, l].ForeColor = System.Drawing.SystemColors.ControlText;
                                values[k, l].BackColor = Color.Transparent;
                                cells[i, j].Controls.Add(values[l, k]);
                            }
                        }
                    }
                }
            }
        }

        private void loadValues()
        {
            // Очистить значения в каждой ячейке
            foreach (var cell in cells)
            {
                cell.Value = 0;
                cell.Clear();
            }

            // Этот метод будет вызываться рекурсивно,
            // пока не найдет подходящие значения для каждой ячейки.
            findValueForNextCell(0, -1);
        }

        Random random = new Random();

        private bool findValueForNextCell(int i, int j)
        {
            // Увеличеваем значения i и j, чтобы перейти к следующей ячейке,
            // и если столбец заканчивается, переходим к следующей строке
            if (++j > 8)
            {
                j = 0;

                // Выходим если строки заканчиваются
                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Находим случайное допустимое число для ячейки, переходим к
            // следующей ячейке и проверяем, может ли она быть назначена другим случайным допустимым числом
            do
            {
                // Если в списке не осталось номеров для следующей попытки,
                // возвращаемся к предыдущей ячейке и присвоеваем ей другое число
                if (numsLeft.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return false;
                }

                // Берем случайное число из числа оставшихся в списке
                value = numsLeft[random.Next(0, numsLeft.Count)];
                cells[i, j].Value = value;

                // Удалить выделенное значение из списка
                numsLeft.Remove(value);
            }
            while (!isValidNumber(value, i, j) || !findValueForNextCell(i, j));

            return true;
        }

        private bool isValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                // Проверяем все ячейки по вертикали
                if (i != y && cells[x, i].Value == value)
                    return false;

                // Проверяем все ячейки по горизонтали
                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            // Проверяем все ячейки в конкретном блоке
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            var wrongCells = new List<SudokuCell>();

            // Ищем все неправильные числа, которые ввел пользователь
            foreach (var cell in cells)
            {
                if (!string.Equals(cell.Value.ToString(), cell.Text))
                {
                    wrongCells.Add(cell);
                }
            }

            // Проверяем, есть ли ошибки
            if (wrongCells.Any())
            {
                // Выделяем неправильные цифры
                wrongCells.ForEach(x => x.ForeColor = Color.Red);
                //MessageBox.Show("Неправильно!!!");
                //playSimpleSound("Windows Background.wav");
                // --------------для теста-----------
                //playSoundtrack(false);
                playSimpleSound("tada.wav");
                MessageBox.Show($"{playerName}, Вы победили!\nВаше время: {txtTimer.Text}");
                setRecord();
                // --------------для теста-----------
            }
            else
            {
                playSoundtrack(false);
                this.Hide();
                startingTheGame.Show();
                resetTimer();
                MessageBox.Show($"{playerName}, Вы победили!\nВаше время: {txtTimer.Text}"); ///////////////////
                setRecord();////////////////////////////
            }
        }

        private void resetTimer()
        {
            isActive = false;
            txtTimer.Text = "00:00:00.00";
            s = m = h = ms = 0;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");
            foreach (var cell in cells)
            {
                // Очищаем ячейку, только если она не заблокирована
                if (cell.IsLocked == false)
                {
                    cell.Clear();
                    foreach (Label l in cell.Controls.OfType<Label>())
                    {
                        l.Text = "";
                    }
                }
            }
        }

        private void setRecord()
        {
            if (flagForNameFile == 45)
                records.pushToFile(txtTimer.Text, playerName, "beginnerR.txt");
            else if (flagForNameFile == 30)
                records.pushToFile(txtTimer.Text, playerName, "advancedR.txt");
            else
                records.pushToFile(txtTimer.Text, playerName, "professionalR.txt");
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            playSoundtrack(false);
            playSimpleSound("Windows Navigation Start.wav");

            this.Hide();
            startingTheGame.Show();
            resetTimer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                ms++;
                if (ms >= 100)
                {
                    s++;
                    ms = 0;
                }
                if (s >= 60)
                {
                    m++;
                    s = 0;
                }
                if (m >= 60)
                {
                    h++;
                    m = 0;
                }
            }
            txtTimer.Text = String.Format("{0}:{1}:{2}.{3}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'), ms.ToString().PadLeft(2, '0'));
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            if (checkBox1.Checked)
            {
                notes = true;
                checkBox1.BackColor = Color.GreenYellow;
            }
            else
            {
                notes = false;
                checkBox1.BackColor = SystemColors.ButtonFace;
            }
        }

        private void errorPreventionMode_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            if (errorPreventionMode.Checked)
            {
                error_prevention = true;
                errorPreventionMode.BackColor = Color.GreenYellow;
            }
            else
            {
                error_prevention = false;
                errorPreventionMode.BackColor = SystemColors.ButtonFace;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");
            playSoundtrack(false);

            resetTimer();
            Application.DoEvents();
            Application.Exit();
        }

        private void cells_MouseEnter(object sender, EventArgs e)
        {
            foreach (Label l in cells[1, 1].Controls.OfType<Label>())
            {
                l.BackColor = Color.Black;
            }
            values[1, 1].BackColor = Color.Red;
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }

        private void playSimpleSound(string filename)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\" + filename);
            simpleSound.Play();
        }

        private void playSoundtrack(bool flag)
        {
            if (flag)
            {
                soundtrack.URL = "soundtrack.mp3";
                soundtrack.settings.setMode("loop", true);
                soundtrack.settings.volume = 2;
                soundtrack.Ctlcontrols.play();
            }
            else
            {
                soundtrack.Ctlcontrols.stop();
            }
        }
    }
}