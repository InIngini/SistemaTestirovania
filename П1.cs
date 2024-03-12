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
using static System.Windows.Forms.DataFormats;

namespace Система_тестирования
{
	public partial class П1 : Form
	{
		public П1()
		{
			InitializeComponent();
		}
		public П1(Нач_экран f)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
			Автозаполнение();
		}
		public П1(П4 f)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
            Автозаполнение();
        }
		public П1(П2 f)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
            Автозаполнение();
        }
		public П1(П3 f)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
            Автозаполнение();
        }
		private void Составление_случайного_варианта_Click(object sender, EventArgs e)
		{
			DirectoryInfo dir1 = new DirectoryInfo("Вопросы\\");
			FileInfo[] files1 = dir1.GetFiles("*.dat");
			if (textBox1.Text != "")
			{
				if (Convert.ToInt32(textBox1.Text) <= files1.Length)
				{
					П3 newForm = new П3(this, textBox1.Text);
					this.Hide();//прячет форму
					newForm.Show();//открывает новую
				}
				else
					MessageBox.Show("Доступно только " + files1.Length + " вопросов.");
			}
		}
		private void Составление_варианта_Click(object sender, EventArgs e)
		{
			П2 newForm = new П2(this);
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}
		private byte textBox1_знаки = 1;
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//это добавляем в соответствующую названию штуку в свойствах
		{
			 if ((e.KeyChar < '0' || e.KeyChar> '9') && (e.KeyChar != '\b'))//разрешает вводить только цифры
             {
                e.Handled = true;
             }
			
		}
		private byte textBox2_знаки = 1;
		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)//это добавляем в соответствующую названию штуку в свойствах
		{
			if ((((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar == 8) && (textBox1_знаки < 4 || e.KeyChar == 8))//разрешает вводить только цифры; 8 это удаление, а то так не разрешает;
			{
				if (e.KeyChar == 8)
					textBox2_знаки--; //уменьшаем, когда удаляем
				else
					textBox2_знаки++; //количество знаков меньше десяти, а то не обработает

				return;
			}
			e.Handled = true;
		}
		//цивильно и роскошно
        private void Назад_Click(object sender, EventArgs e)
        {
            Нач_экран newForm = new Нач_экран(this);
            this.Hide();//прячет форму
            newForm.Show();//открывает новую
        }
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
                result = str.Remove(str.Length - 4, 4);
                //Варианты[i] = Convert.ToInt32(result.Remove(0, 2));
                source.Add(result);
                i++;
            }

            textBox2.AutoCompleteCustomSource = source;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void Посм_вар_кнопка_Click(object sender, EventArgs e)
		{
			bool flag = false;
			DirectoryInfo dir1 = new DirectoryInfo("Варианты\\");
			FileInfo[] files1 = dir1.GetFiles("*.dat");
			foreach (var item in files1)
			{
				if (item.Name == $"{textBox2.Text}.dat")
					flag = true;
			}

			if (flag)
			{
				П4 newForm = new П4(this,textBox2.Text);
				this.Hide();//прячет форму
				newForm.Show();//открывает новую
			}
			else
				MessageBox.Show("Такого варианта нет.");
		}
	}
}
