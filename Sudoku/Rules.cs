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
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();

            setRules();
        }

        private void setRules()
        {
            label1.Text = "Игровое поле представляет собой квадрат размером 9×9, разделённый на меньшие квадраты со стороной в 3 клетки. " +
                "Таким образом, всё игровое поле состоит из 81 клетки. В них уже в начале игры стоят некоторые числа (от 1 до 9), называемые " +
                "подсказками. От игрока требуется заполнить свободные клетки цифрами от 1 до 9 так, чтобы в каждой строке, в каждом столбце" +
                " и в каждом малом квадрате 3×3 каждая цифра встречалась бы только один раз.\n\n" +
                "Сложность судоку зависит от количества изначально заполненных клеток и от методов, которые нужно применять для её решения. " +
                "Самые простые решаются дедуктивно: всегда есть хотя бы одна клетка, куда подходит только одно число. Некоторые головоломки " +
                "можно решить за несколько минут, на другие можно потратить часы.\n\n" +
                "Правильно составленная головоломка имеет только одно решение. Тем не менее, на некоторых сайтах в интернете под видом " +
                "усложнённых головоломок пользователю предлагаются варианты судоку с несколькими вариантами решения, а также с ветвлениями " +
                "самого хода решения.";
            label1.TextAlign = ContentAlignment.TopCenter;
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
            closeButton.ForeColor = Color.FromArgb(167, 0, 0);
        }

        private void playSimpleSound(string filename)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\" + filename);
            simpleSound.Play();
        }

        private void rules_button_Click(object sender, EventArgs e)
        {
            playSimpleSound("Windows Navigation Start.wav");

            this.Close();
        }
    }
}
