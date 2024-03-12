using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_тестирования
{
    public partial class С1 : Form
    {
        public С1(С2 f)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
        }
        public С1(Нач_экран f)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location
            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
        }

        private void Тест_преподавателя_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                С2 newForm = new С2(this,textBox1.Text);
                this.Hide();//прячет форму
                newForm.Show();//открывает новую
            }
            else
                MessageBox.Show("Введите ФИ");

            }
        private void Случайный_тест_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Random rnd = new Random();
                int Номер = 0;
                int[] Варианты = new int[100];
                int i = 0;
                string str;

                DirectoryInfo dir1 = new DirectoryInfo("Варианты\\");
                FileInfo[] files1 = dir1.GetFiles("*.dat");
                foreach (var item in files1)
                {
                    string result;
                    str = item.ToString();
                    result = Regex.Replace(str, @"[^\d]", "");
                    Варианты[i] = Convert.ToInt32(result.Remove(0, 2));
                    i++;
                }
                Номер = rnd.Next(0, i);
				MessageBox.Show($"Ваш вариант {Варианты[Номер]} \nОн будет виден в левом углу экрана");
				С3 newForm = new С3(this, $"{Варианты[Номер]}", textBox1.Text);
                this.Hide();//прячет форму
                newForm.Show();//открывает новую
            }
            else
                MessageBox.Show("Введите ФИ");
        }
        //цивильно и роскошно
        private void Назад_Click(object sender, EventArgs e)
        {
            Нач_экран newForm = new Нач_экран();
            this.Hide();//прячет форму
            newForm.Show();//открывает новую
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char k = e.KeyChar;
            if ((k < 'А' || k > 'я') && (k != '\b') && (k != 32))
            {
                e.Handled = true;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
