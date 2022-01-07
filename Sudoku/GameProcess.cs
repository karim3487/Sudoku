using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GameProcess : Form
    {
        private bool isActive = false, error_prevention = false, notes_mode = false;
        private int s, m, h, ms;
        private string playerName, mode;
        private int flagForNameFile;
        private const int cellSize = 51;
        private const int noteSize = cellSize / 3;
        private int currentFrame = 0;
        Image sprite;


        public GameProcess(string playerName, int hintsCount, string mode)
        {
            InitializeComponent();

            this.playerName = playerName;
            this.mode = mode;

            flagForNameFile = hintsCount;

            createCells();

            playSoundtrack(1);

            startNewGame(hintsCount);

            animation();
        }

        NewGameForm startingTheGame = new NewGameForm();

        SudokuCell[,] cells = new SudokuCell[9, 9];

        Notes[,] notes = new Notes[3, 3];

        Records records = new Records();

        private void createCells()
        {
            var offsetV = 0;
            var offsetH = 0;
            for (int i = 0; i < 9; i++)
            {
                offsetV = i == 3 || i == 6 ? offsetV + 2 : offsetV;
                offsetH = 0;
                for (int j = 0; j < 9; j++)
                {
                    offsetH = j == 3 || j == 6 ? offsetH + 2 : offsetH;
                    // Создаем 81 ячейку со стилями и местоположениями на основе индекса
                    Point location = new Point(i * cellSize + offsetV, j * cellSize + offsetH);
                    cells[i, j] = new SudokuCell(cellSize, location);
                    if (mode == "classic")
                        cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? Color.LightGreen : Color.White;
                    else
                        cells[i, j].BackColor = Color.White;
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
                        cell.IsFilled = true;
                        cell.ForeColor = Color.FromArgb(136, 47, 175);
                        for (int index = 0; index < 9; index++)
                            listLabel[index].Text = "";
                    }
                }
                else
                {
                    if (notes_mode)
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
                            cell.IsFilled = true;
                            for (int index = 0; index < 9; index++)
                                listLabel[index].Text = "";
                        }
                        cell.ForeColor = Color.FromArgb(90, 90, 90);
                    }
                }
            }
        }

        private void startNewGame(int hintsCount)
        {
            loadValues();

            isActive = true; // запускаем таймер

            showRandomValuesHints(hintsCount);

            if (mode == "even_odd")
                even_odd_mode();

            pictureBox1.Hide();
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
        }

        private void add_notes(SudokuCell cell)
        {
            // В цикле пробегаемся по каждой ячейке поля, если она !IsLocked загружаем в нее 9 лейблов для заметок
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {

                    notes[k, l] = new Notes();
                    notes[k, l].Font = new System.Drawing.Font("Rubik", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    notes[k, l].Size = new Size(noteSize, noteSize);
                    notes[k, l].Location = new Point(l * noteSize, k * noteSize);
                    notes[k, l].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    notes[k, l].Enabled = false;
                    notes[k, l].BackColor = Color.Transparent;
                    cell.Controls.Add(notes[k, l]);
                }
            }

            /*int ias = 0;
            foreach (Label l in cells[0, 0].Controls.OfType<Label>())
            {
                ias++;
            }
            MessageBox.Show(ias.ToString());*/

        }

        private void loadValues()
        {
            // Очистить значения в каждой ячейке
            foreach (var cell in cells)
            {
                cell.Value = 0;
                cell.Clear();
                if (!cell.IsLocked)
                    add_notes(cell);
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
                playSimpleSound("Windows Background.wav");
                MessageBox.Show("Неправильно!!!");
                /*// --------------для теста-----------
                playSoundtrack(3);
                playSimpleSound("tada.wav");
                //MessageBox.Show($"{playerName}, Вы победили!\nВаше время: {txtTimer.Text}");
                setRecord();
                animation_timer.Stop();
                // --------------для теста-----------*/
            }
            else
            {
                playSoundtrack(3);
                playSimpleSound("tada.wav");
                setRecord();
                this.Hide();
                startingTheGame.Show();
                MessageBox.Show($"{playerName}, Вы победили!\nВаше время: {txtTimer.Text}");
                resetTimer();

            }
        }

        private void even_odd_mode()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (isValidNumber(cells[i, j].Value, i, j) && cells[i, j].Value % 2 == 0)
                    {
                        cells[i, j].BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void resetTimer()
        {
            animation_timer.Stop();
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
            playSoundtrack(3);
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
                notes_mode = true;
                checkBox1.BackColor = Color.GreenYellow;
            }
            else
            {
                notes_mode = false;
                checkBox1.BackColor = SystemColors.ButtonFace;
            }
        }

        private void resume_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i, j].IsLocked)
                    {
                        cells[i, j].Text = cells[i, j].Value.ToString();
                        cells[i, j].ForeColor = Color.Black;
                    }
                    else if (cells[i, j].IsFilled)
                    {
                        cells[i, j].Text = cells[i, j].Value.ToString();
                    }
                    else
                    {
                        cells[i, j].Text = "";
                    }
                    cells[i, j].Enabled = true;
                    if (!cells[i, j].IsLocked)
                        foreach (Label l in cells[i, j].Controls.OfType<Label>())
                            l.Show();
                }
            }
            timer.Start();
            playSoundtrack(4);
            checkButton.Enabled = true;
            clearButton.Enabled = true;
            pause_button.Visible = true;
            resume_button.Visible = false;

            pictureBox1.Hide();
            animation_timer.Stop();
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j].Text = "X";
                    cells[i, j].Enabled = false;
                    if (!cells[i, j].IsLocked)
                        foreach (Label l in cells[i, j].Controls.OfType<Label>())
                            l.Hide();
                }
            }

            timer.Stop();
            playSoundtrack(2);
            checkButton.Enabled = false;
            clearButton.Enabled = false;
            pause_button.Visible = false;
            resume_button.Visible = true;

            pictureBox1.Show();
            animation_timer.Start();
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
            playSoundtrack(3);

            resetTimer();
            Application.DoEvents();
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.FromArgb(167, 0, 0);
        }

        private void playSimpleSound(string filename)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\" + filename);
            simpleSound.Play();
        }


        private void playSoundtrack(int flag)
        {

            if (flag == 1)
            {
                soundtrack.URL = "soundtrack.mp3";
                soundtrack.settings.setMode("loop", true);
                soundtrack.settings.volume = 100;
                soundtrack.Ctlcontrols.play();
            }
            else if (flag == 2)
                soundtrack.Ctlcontrols.pause();
            else if (flag == 3)
                soundtrack.Ctlcontrols.stop();
            else if (flag == 4)
                soundtrack.Ctlcontrols.play();

        }

        private void animation()
        {
            sprite = new Bitmap("sprites/sprite1.png");
            pictureBox1.BackColor = Color.Transparent;
            animation_timer.Tick += new EventHandler(updateAnimation);
            animation_timer.Interval = 100;

        }

        private void updateAnimation(object sender, EventArgs e)
        {
            playAnimation();
            if (currentFrame >= 7)
                currentFrame = 0;
            currentFrame++;
        }

        private void playAnimation()
        {
            Image part = new Bitmap(212, 174);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(sprite, 0, 0, new Rectangle(new Point(215 * currentFrame, 0), new Size(214, 174)), GraphicsUnit.Pixel);
            pictureBox1.Image = part;
            pictureBox1.Size = new Size(212, 174);
        }
    }
}