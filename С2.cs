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
    public partial class С2 : Form
    {
        public С2()
        {
            InitializeComponent();
        }
        string ФИ;
        private void Автозаполнение()
        {
           
            int[] Варианты = new int[100];
            int i = 0;
            string str;

            DirectoryInfo dir1 = new DirectoryInfo("Варианты\\");
            FileInfo[] files1 = dir1.GetFiles("*.dat"); 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            foreach (var item in files1)
            {
                string result;
                str = item.Name;
                result = str.Remove(str.Length-4,4);
                //Варианты[i] = Convert.ToInt32(result.Remove(0, 2));
                source.Add(result);
                i++;
            }

            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public С2(С1 f,string ФИ)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location
            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
            Автозаполнение();
            this.ФИ = ФИ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//это добавляем в соответствующую названию штуку в свойствах
        {
            char k = e.KeyChar;
            if ((k < '0' || k > '9') && (k != '\b'))//разрешает вводить только цифры; 8 это удаление, а то так не разрешает;
            {
                e.Handled = true;
            }
           
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            DirectoryInfo dir1 = new DirectoryInfo("Варианты\\");
            FileInfo[] files1 = dir1.GetFiles("*.dat");
            foreach (var item in files1)
            {
                if(item.Name == $"{textBox1.Text}.dat")
                    flag = true;
            }

            if (flag)
            {
                MessageBox.Show($"Ваш вариант {textBox1.Text} \nОн будет виден в левом углу экрана");
                С3 newForm = new С3(this, textBox1.Text, ФИ);
                this.Hide();//прячет форму
                newForm.Show();//открывает новую
            }
            else
                MessageBox.Show("Такого варианта нет");
        }
        //цивильно и роскошно
        private void Назад_Click(object sender, EventArgs e)
        {
            С1 newForm = new С1(this);
            this.Hide();//прячет форму
            newForm.Show();//открывает новую
        }
    }
}
