using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Система_тестирования
{
	[Serializable]
	public partial class П2 : Form
	{
		public П2()
		{
			InitializeComponent();
		}
		public П2(П1 f)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

			groupBox1.Height = groupBox1.Height;//увеличиваем форму вопроса
			Начальная_длина_формы = groupBox1.Height;

			Вопросы = new List<GroupBox>() { groupBox1 };

			groupBox_ПоУмолчанию = new GroupBox();
			groupBox_ПоУмолчанию = groupBox1;



		}
		GroupBox groupBox_ПоУмолчанию;
		GroupBox groupBox;
		int Тип_Ответа = 0;
		int Начальная_длина_формы;

		public Dictionary<byte,Dictionary<string,Dictionary<byte,Dictionary<string,Dictionary<byte,string>>>>> Тест = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
		//        номер            вопрос         тип ответа        правильный      номер  ответ
		List<GroupBox> Вопросы;
		List<RadioButton> Ответы_Один;
		List<CheckBox> Ответы_Несколько;
		List<TextBox> Текст_Ответа;
		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			// приводим отправителя к элементу типа RadioButton
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				if(radioButton.Text=="Один")
				{
					Тип_Ответа = 1;
					Количество_ответов = 1;
					кол_отв_о = 1;

					groupBox1.Controls.Remove(groupBox);//удаление на случай, если там уже что-то было
					this.Controls.Remove(button3);
					this.Controls.Remove(button4);

					Ответы_Один = new List<RadioButton>();//обнуляем
					Ответы_Несколько = new List<CheckBox>();
					Текст_Ответа = new List<TextBox>();

					groupBox1.Height = Начальная_длина_формы;//уменьшаем форму вопроса

					groupBox = new GroupBox();//создаем новый бокс для записи ответов
					Ответы_LocationControls(groupBox1, groupBox);//относительно общего бокса вопроса
					groupBox.Width = 370;
					groupBox1.Controls.Add(groupBox);//добавляем, чтобы можно было видеть

					Создание_ответов_один();
				}
				if (radioButton.Text == "Несколько")
				{
					Тип_Ответа = 2;
					Количество_ответов = 1;
					кол_отв_о = 1;

					groupBox1.Controls.Remove(groupBox);//удаление на случай, если там уже что-то было. Но не работает пока
					this.Controls.Remove(button3);
					this.Controls.Remove(button4);

					Ответы_Один = new List<RadioButton>();//обнуляем
					Ответы_Несколько = new List<CheckBox>();
					Текст_Ответа = new List<TextBox>();

					groupBox1.Height = Начальная_длина_формы;//уменьшаем форму вопроса

					groupBox = new GroupBox();//создаем новый бокс для записи ответов
					Ответы_LocationControls(groupBox1, groupBox);//относительно общего бокса вопроса
					groupBox.Width = 370;
					groupBox1.Controls.Add(groupBox);//добавляем, чтобы можно было видеть

					Создание_ответов_несколько();
				}
				if (radioButton.Text == "Открытый")
				{
					Тип_Ответа = 3;
					Количество_ответов = 1;

					groupBox1.Controls.Remove(groupBox);//удаление на случай, если там уже что-то было. Но не работает пока
					this.Controls.Remove(button3);
					this.Controls.Remove(button4);

					Ответы_Один = new List<RadioButton>();//обнуляем
					Ответы_Несколько = new List<CheckBox>();
					Текст_Ответа = new List<TextBox>();

					groupBox1.Height = Начальная_длина_формы;//уменьшаем форму вопроса

					groupBox = new GroupBox();//создаем новый бокс для записи ответов
					Ответы_LocationControls(groupBox1, groupBox);//относительно общего бокса вопроса
					groupBox.Width = 370;
					groupBox1.Controls.Add(groupBox);//добавляем, чтобы можно было видеть

					Создание_ответа_открытый();
				}
			}
		}
		Button Назад;//добавить ответ
		Button button2;//удалить ответ
		Button button3;//добавить вопрос
		Button button4;//добавить вопрос из базы
		int Количество_ответов = 1;
		private void Создание_ответов_один()
		{
			groupBox1.Height = groupBox1.Height + 50;//увеличиваем форму вопроса

			RadioButton radioButton1 = new RadioButton();//добавляем первый ответ
			radioButton1.Location = new Point(13, 18);//положение отсчитывается относительно формы, в которой находится
			radioButton1.Size = new Size(330, 25);
			radioButton1.Font = new Font("Segoe UI", 10);
			groupBox.Controls.Add((RadioButton)radioButton1);//добавляем, чтобы видеть
			Ответы_Один.Add(radioButton1);//добавляем кнопочку

			TextBox textBox_Answer = new TextBox();
			Ответы3_LocationControls(radioButton1, textBox_Answer);
			textBox_Answer.Font = new Font("Segoe UI", 10);
			textBox_Answer.Size = new Size(300, 25);
			textBox_Answer.MaxLength = 50;
			radioButton1.Controls.Add(textBox_Answer);
			Текст_Ответа.Add(textBox_Answer);//добавляем текст 

			Назад = new Button();
			Назад.Location = new Point(220, 56);
			Назад.Size = new Size(120, 30);
			Назад.Font = new Font("Segoe UI", 10);
			Назад.Text = "Добавить ответ";
			Назад.Click += Добавление_Click;//это добавление метода, я серьезно
			groupBox.Controls.Add(Назад);

			button4 = new Button();
			Добавить_вопрос_из_базы_LocationControls(button4);
			button4.Size = new Size(200, 38);
			button4.Font = new Font("Segoe UI", 10);
			button4.Text = "Добавить вопрос из базы";
			button4.Click += Добавление_вопроса_из_базы_Click;//это добавление метода, я серьезно
			this.Controls.Add(button4);
		}
        private void Добавление_ответов_один()
		{
				groupBox.Controls.Remove(Назад);//удаляем кнопку
				groupBox.Controls.Remove(button2);//удаляем кнопку
				this.Controls.Remove(button3);
				this.Controls.Remove(button4);
				groupBox1.Height = groupBox1.Height + 30;//увеличиваем форму вопроса
				groupBox.Height = groupBox.Height + 30;

				RadioButton radioButton1 = new RadioButton();//добавляем второй ответ
				Ответы4_LocationControls(radioButton1);//положение отсчитывается относительно формы, в которой находится
				radioButton1.Size = new Size(330, 25);
				radioButton1.Font = new Font("Segoe UI", 10);
				groupBox.Controls.Add((RadioButton)radioButton1);//добавляем, чтобы видеть
				Ответы_Один.Add(radioButton1);//добавляем кнопочку

				TextBox textBox_Answer = new TextBox();
				Ответы3_LocationControls(radioButton1, textBox_Answer);
				textBox_Answer.Font = new Font("Segoe UI", 10);
				textBox_Answer.Size = new Size(300, 25);
            textBox_Answer.MaxLength = 50;
            radioButton1.Controls.Add(textBox_Answer);
				Текст_Ответа.Add(textBox_Answer);//добавляем текст 

				Назад = new Button();
				Добавить_LocationControls(Назад);
				Назад.Size = new Size(120, 30);
				Назад.Font = new Font("Segoe UI", 10);
				Назад.Text = "Добавить ответ";
				Назад.Click += Добавление_Click;//это добавление метода, я серьезно
				groupBox.Controls.Add(Назад);

				button2 = new Button();
				Удаление_LocationControls(button2);
				button2.Size = new Size(120, 30);
				button2.Font = new Font("Segoe UI", 10);
				button2.Text = "Удалить ответ";
				button2.Click += Удаление_Click;//это добавление метода, я серьезно
				groupBox.Controls.Add(button2);

				button3 = new Button();
				Добавить_вопрос_LocationControls(button3);
				button3.Size = new Size(146, 38);
				button3.Font = new Font("Segoe UI", 10);
				button3.Text = "Добавить вопрос";
				button3.Click += Добавление_вопроса_Click;//это добавление метода, я серьезно
				this.Controls.Add(button3);

				button4 = new Button();
				Добавить_вопрос_из_базы_LocationControls(button4);
				button4.Size = new Size(200, 38);
				button4.Font = new Font("Segoe UI", 10);
				button4.Text = "Добавить вопрос из базы";
				button4.Click += Добавление_вопроса_из_базы_Click;//это добавление метода, я серьезно
				this.Controls.Add(button4);

		}
		private void Создание_ответов_несколько()
		{
			groupBox1.Height = groupBox1.Height + 50;//увеличиваем форму вопроса

			CheckBox chekBox1 = new CheckBox();//добавляем первый ответ
			chekBox1.Location = new Point(13, 18);//положение отсчитывается относительно формы, в которой находится
			chekBox1.Size = new Size(330, 25);
			chekBox1.Font = new Font("Segoe UI", 10);
			groupBox.Controls.Add((CheckBox)chekBox1);//добавляем, чтобы видеть
			Ответы_Несколько.Add(chekBox1);//добавляем кнопочку

			TextBox textBox_Answer = new TextBox();
			Ответы3_LocationControls(chekBox1, textBox_Answer);
			textBox_Answer.Font = new Font("Segoe UI", 10);
			textBox_Answer.Size = new Size(300, 25);
            textBox_Answer.MaxLength = 50;
            chekBox1.Controls.Add(textBox_Answer);
			Текст_Ответа.Add(textBox_Answer);//добавляем текст 

			Назад = new Button();
			Назад.Location = new Point(220, 56);
			Назад.Size = new Size(120, 30);
			Назад.Font = new Font("Segoe UI", 10);
			Назад.Text = "Добавить ответ";
			Назад.Click += Добавление_Click;//это добавление метода, я серьезно
			groupBox.Controls.Add(Назад);

			button4 = new Button();
			Добавить_вопрос_из_базы_LocationControls(button4);
			button4.Size = new Size(200, 38);
			button4.Font = new Font("Segoe UI", 10);
			button4.Text = "Добавить вопрос из базы";
			button4.Click += Добавление_вопроса_из_базы_Click;//это добавление метода, я серьезно
			this.Controls.Add(button4);
		}
		private void Добавление_ответов_несколько()
		{
				groupBox.Controls.Remove(Назад);//удаляем кнопку
				groupBox.Controls.Remove(button2);//удаляем кнопку
				this.Controls.Remove(button3);
				this.Controls.Remove(button4);
				groupBox1.Height = groupBox1.Height + 30;//увеличиваем форму вопроса
				groupBox.Height = groupBox.Height + 30;

				CheckBox chekBox1 = new CheckBox();//добавляем второй ответ
				Ответы4_LocationControls(chekBox1);//положение отсчитывается относительно формы, в которой находится
				chekBox1.Size = new Size(330, 25);
				chekBox1.Font = new Font("Segoe UI", 10);
				groupBox.Controls.Add((CheckBox)chekBox1);//добавляем, чтобы видеть
				Ответы_Несколько.Add(chekBox1);//добавляем кнопочку

				TextBox textBox_Answer = new TextBox();
				Ответы3_LocationControls(chekBox1, textBox_Answer);
				textBox_Answer.Font = new Font("Segoe UI", 10);
				textBox_Answer.Size = new Size(300, 25);
            textBox_Answer.MaxLength = 50;
            chekBox1.Controls.Add(textBox_Answer);
				Текст_Ответа.Add(textBox_Answer);//добавляем текст 

				Назад = new Button();
				Добавить_LocationControls(Назад);
				Назад.Size = new Size(120, 30);
				Назад.Font = new Font("Segoe UI", 10);
				Назад.Text = "Добавить ответ";
				Назад.Click += Добавление_Click;//это добавление метода, я серьезно
				groupBox.Controls.Add(Назад);

				button2 = new Button();
				Удаление_LocationControls(button2);
				button2.Size = new Size(120, 30);
				button2.Font = new Font("Segoe UI", 10);
				button2.Text = "Удалить ответ";
				button2.Click += Удаление_Click;//это добавление метода, я серьезно
				groupBox.Controls.Add(button2);

				button3 = new Button();
				Добавить_вопрос_LocationControls(button3);
				button3.Size = new Size(146, 38);
				button3.Font = new Font("Segoe UI", 10);
				button3.Text = "Добавить вопрос";
				button3.Click += Добавление_вопроса_Click;//это добавление метода, я серьезно
				this.Controls.Add(button3);

				button4 = new Button();
				Добавить_вопрос_из_базы_LocationControls(button4);
				button4.Size = new Size(200, 38);
				button4.Font = new Font("Segoe UI", 10);
				button4.Text = "Добавить вопрос из базы";
				button4.Click += Добавление_вопроса_из_базы_Click;//это добавление метода, я серьезно
				this.Controls.Add(button4);
			
        }
		TextBox textBox_Answer_Открытый;
		private void Создание_ответа_открытый()
		{
			groupBox1.Height = groupBox1.Height + 50;//увеличиваем форму вопроса

			textBox_Answer_Открытый = new TextBox();
			textBox_Answer_Открытый.Location = new Point(13, 18);
			textBox_Answer_Открытый.Font = new Font("Segoe UI", 10);
			textBox_Answer_Открытый.Size = new Size(350, 25);
			textBox_Answer_Открытый.MaxLength = 40;

            groupBox.Controls.Add(textBox_Answer_Открытый);
			Текст_Ответа.Add(textBox_Answer_Открытый);//добавляем текст 

			button3 = new Button();
			Добавить_вопрос_LocationControls(button3);
			button3.Size = new Size(146, 38);
			button3.Font = new Font("Segoe UI", 10);
			button3.Text = "Добавить вопрос";
			button3.Click += Добавление_вопроса_Click;//это добавление метода, я серьезно
			this.Controls.Add(button3);

			button4 = new Button();
			Добавить_вопрос_из_базы_LocationControls(button4);
			button4.Size = new Size(200, 38);
			button4.Font = new Font("Segoe UI", 10);
			button4.Text = "Добавить вопрос из базы";
			button4.Click += Добавление_вопроса_из_базы_Click;//это добавление метода, я серьезно
			this.Controls.Add(button4);
		}
        int кол_отв_о = 1;// переменная для подсчета количества ответов 
        private void Добавление_Click(object sender, EventArgs e)
		{
			if (Тип_Ответа == 1)//перед тем как добавить еще один ответ, смотрит их количество и если их уже 4 то выводим ошибку
			{
                if (кол_отв_о != 4)
                {
					кол_отв_о++;
                    Добавление_ответов_один();
                }
                else
                {
                    MessageBox.Show("Превышено максимально количество ответов");
                }
            }
			else
			{
				
				if (кол_отв_о != 4)//перед тем как добавить еще один ответ, смотрит их количество и если их уже 4 то выводим ошибку
                {
					кол_отв_о++;
					Добавление_ответов_несколько();
				}
				else
				{
					MessageBox.Show("Превышено максимально количество ответов");
				}
			}
		}
		private void Удаление_Click(object sender, EventArgs e)
		{
			groupBox1.Height = groupBox1.Height - 30;
			groupBox.Height = groupBox.Height - 30;

			Количество_ответов--;
			groupBox.Controls.Remove(button2);//удаление кнопки удаление
			this.Controls.Remove(button3);//удаление кнопки добавить вопрос

			if (Тип_Ответа == 1)
			{
				groupBox.Controls.Remove(Ответы_Один.Last());
				Ответы_Один.Remove(Ответы_Один.Last());
				Текст_Ответа.Remove(Текст_Ответа.Last());
				кол_отв_о--;
			}
			else
			{
				кол_отв_о--;
				groupBox.Controls.Remove(Ответы_Несколько.Last());
				Ответы_Несколько.Remove(Ответы_Несколько.Last());
				Текст_Ответа.Remove(Текст_Ответа.Last());
			}

			if (Количество_ответов != 1)
			{
				button2 = new Button();
				Удаление_LocationControls(button2);
				button2.Size = new Size(120, 30);
				button2.Font = new Font("Segoe UI", 10);
				button2.Text = "Удалить ответ";
				button2.Click += Удаление_Click;//это добавление метода, я серьезно
				groupBox.Controls.Add(button2);

				button3 = new Button();
				Добавить_вопрос_LocationControls(button3);
				button3.Size = new Size(146, 38);
				button3.Font = new Font("Segoe UI", 10);
				button3.Text = "Добавить вопрос";
				button3.Click += Добавление_вопроса_Click;//это добавление метода, я серьезно
				this.Controls.Add(button3);
			}

			groupBox.Controls.Remove(Назад);

			Назад = new Button();
			Добавить_LocationControls(Назад);
			Назад.Size = new Size(120, 30);
			Назад.Font = new Font("Segoe UI", 10);
			Назад.Text = "Добавить ответ";
			Назад.Click += Добавление_Click;//это добавление метода, я серьезно
			groupBox.Controls.Add(Назад);

			this.Controls.Remove(button4);

			button4 = new Button();
			Добавить_вопрос_из_базы_LocationControls(button4);
			button4.Size = new Size(200, 38);
			button4.Font = new Font("Segoe UI", 10);
			button4.Text = "Добавить вопрос из базы";
			button4.Click += Добавление_вопроса_из_базы_Click;//это добавление метода, я серьезно
			this.Controls.Add(button4);
		}
		int Количество_вопросов = 1;
		List<int> СписокВопросовИзБазы=new List<int>();
		private void Добавление_вопроса_Click(object sender, EventArgs e)
		{
			Тест.Remove((byte)Количество_вопросов);//если предыдущая попытка не удалась(что-то не заполнено), то удаляем

			Dictionary<byte, string> DОтветы = new Dictionary<byte, string>();

			bool Ответы_не_пустые = true;
			byte t = 1;
			foreach (var i in Текст_Ответа)
			{
				DОтветы.Add(t, i.Text);
				if (i.Text == "")
					Ответы_не_пустые = false;
				t++;
			}

			bool Правильный_ответ_есть = true;
			string Правильный = "";//использую строку, так как если открытый тип, то тут будет ответ, а для нескольких перечисление
			if (Тип_Ответа == 1)
			{
				byte k = 1;
				foreach (var i in Ответы_Один)
				{
					if (i.Checked)
					{
						Правильный = $"{k}";
					}
					k++;
				}
			}
			if (Тип_Ответа == 2)
			{
				byte k = 1;
				foreach (var i in Ответы_Несколько)
				{
					if (i.Checked)
					{
						Правильный += $"{k}.";
					}
					k++;
				}
			}
			if (Тип_Ответа == 3)
			{
				foreach (var k in Текст_Ответа)
				{
					Правильный = k.Text;
				}
			}
			if (Правильный == "")
				Правильный_ответ_есть = false;

			var DПравильный = new Dictionary<string, Dictionary<byte, string>>();
			DПравильный.Add(Правильный, DОтветы);
			var DТип = new Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>();
			DТип.Add((byte)Тип_Ответа, DПравильный);
			var DВопрос = new Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>();
			DВопрос.Add(textBox1.Text, DТип);

			bool Вопрос_есть = true;
			if(textBox1.Text=="")
				Вопрос_есть=false;

			Тест.Add((byte)Количество_вопросов, DВопрос);

			if (Ответы_не_пустые && Правильный_ответ_есть && Вопрос_есть)
			{
				this.Controls.Remove(groupBox1);
				groupBox1 = groupBox_ПоУмолчанию;
				this.Controls.Add(groupBox1);

				Ответы_Один = new List<RadioButton>();//обнуляем
				Ответы_Несколько = new List<CheckBox>();
				Текст_Ответа = new List<TextBox>();
				groupBox1.Controls.Remove(groupBox);
				textBox1.Clear();

				Вопросы.Add(groupBox1);
				Количество_ответов = 1;
				Количество_вопросов++;
				groupBox1.Text = Convert.ToString(Количество_вопросов);

				foreach (RadioButton radio in groupBoxy.Controls.OfType<RadioButton>().ToList())
				{
					if (radio.Checked == true)
					{
						radio.Checked = false;
						break;
					}
				}

				groupBox1.Height = Начальная_длина_формы;
				this.Controls.Remove(button3);
				this.Controls.Remove(button4);
			}
			else
			{
				if (Тип_Ответа == 1 || Тип_Ответа == 2)
				{
					MessageBox.Show("Заполните все поля." + "\n\n1. Поле вопроса должно содержать вопрос;" +
					"\n2. Все поля ответов должны содержать ответ;" + "\n3. Вы должны выбрать правильный ответ (нажмите на кружок/квадрат рядом с ним).");
				}
				else
				{
					MessageBox.Show("Заполните все поля." + "\n\n1. Поле вопроса должно содержать вопрос;" +
					"\n2. Поле ответов должно содержать ответ.");
				}
			}
		}
		private void Добавление_вопроса_из_базы_Click(object sender, EventArgs e)
		{

            Тип_Ответа = 1;
            Количество_ответов = 1;
            кол_отв_о = 1;

            groupBox1.Controls.Remove(groupBox);//удаление на случай, если там уже что-то было
            this.Controls.Remove(button3);
            this.Controls.Remove(button4);

            Ответы_Один = new List<RadioButton>();//обнуляем
            Ответы_Несколько = new List<CheckBox>();
            Текст_Ответа = new List<TextBox>();

            groupBox1.Height = Начальная_длина_формы;//уменьшаем форму вопроса

            groupBox = new GroupBox();//создаем новый бокс для записи ответов
            Ответы_LocationControls(groupBox1, groupBox);//относительно общего бокса вопроса
            groupBox.Width = 370;
            groupBox1.Controls.Add(groupBox);//добавляем, чтобы можно было видеть

            //Создание_ответов_несколько();

            П2_база_данных_ newForm = new П2_база_данных_(this);
			newForm.Show();//открывает новую
		}
		private void Сохранить_Click(object sender, EventArgs e)
		{
			//сначала добавляем последний вопрос
			Тест.Remove((byte)Количество_вопросов);//если предыдущая попатка не удалась(что-то не заполнено), то удаляем

			Dictionary<byte, string> DОтветы = new Dictionary<byte, string>();

			bool Ответы_не_пустые = true;
			byte t = 1;
			foreach (var i in Текст_Ответа)
			{
				DОтветы.Add(t, i.Text);
				if (i.Text == "")
					Ответы_не_пустые = false;
				t++;
			}

			bool Правильный_ответ_есть = true;
			string Правильный = "";//использую строку, так как если открытый тип, то тут будет ответ, а для нескольких перечисление
			if (Тип_Ответа == 1)
			{
				byte k = 1;
				foreach (var i in Ответы_Один)
				{
					if (i.Checked)
					{
						Правильный = $"{k}";
					}
					k++;
				}
			}
			if (Тип_Ответа == 2)
			{
				byte k = 1;
				foreach (var i in Ответы_Несколько)
				{
					if (i.Checked)
					{
						Правильный += $"{k}.";
					}
					k++;
				}
			}
			if(Тип_Ответа== 3)
			{
				foreach (var k in Текст_Ответа)
				{
					Правильный = k.Text;
				}
			}	
			if (Правильный == "")
				Правильный_ответ_есть = false;

			var DПравильный = new Dictionary<string, Dictionary<byte, string>>();
			DПравильный.Add(Правильный, DОтветы);
			var DТип = new Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>();
			DТип.Add((byte)Тип_Ответа, DПравильный);
			var DВопрос = new Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>();
			DВопрос.Add(textBox1.Text, DТип);

			bool Вопрос_есть = true;
			if (textBox1.Text == "")
				Вопрос_есть = false;

			Тест.Add((byte)Количество_вопросов, DВопрос);

			if (Ответы_не_пустые && Правильный_ответ_есть && Вопрос_есть)
			{
				Сохранить();
			}
			else
			{
				if (Тип_Ответа == 1 || Тип_Ответа == 2)
				{
					MessageBox.Show("Заполните все поля." + "\n\n1. Поле вопроса должно содержать вопрос;" +
					"\n2. Все поля ответов должны содержать ответ;" + "\n3. Вы должны выбрать правильный ответ (нажмите на кружок/квадрат рядом с ним).");
				}
				else
				{
					MessageBox.Show("Заполните все поля." + "\n\n1. Поле вопроса должно содержать вопрос;" +
					"\n2. Поле ответов должно содержать ответ.");
				}
			}
		}
		private void Сохранить()
		{
			var formatter = new BinaryFormatter();

			//Cериализируем весь тест
			Random rnd = new Random();
			int Номер_варианта=0;
			bool flag = true;
			while(flag)//проверяем, нет ли случайно уже такого файла
			{
				flag = false;
				Номер_варианта = rnd.Next(1, 1000);
				DirectoryInfo dir1 = new DirectoryInfo("Варианты\\");
				FileInfo[] files1 = dir1.GetFiles("*.dat");
				foreach (var item in files1)
				{
					if($"{item}" == $"{Номер_варианта}")
					{
						flag = true;
					}
				}
			}
			string path = $"Варианты\\{Номер_варианта}.dat";
			FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
			formatter.Serialize(f, Тест);
			f.Close();

			//Сериализируем вопросы в базу
			var dir2 = new DirectoryInfo("Вопросы\\");
			FileInfo[] files = dir2.GetFiles("*.dat");
			int k = files.Length+1;
			int счетчик_вопросов = 1;
			foreach (var item in Тест)
			{
				if (!СписокВопросовИзБазы.Contains(счетчик_вопросов))//Если этот вопрос мы взяли не из базы
				{
					path = $"Вопросы\\{k}.dat";
					f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
					formatter.Serialize(f, item.Value);
					k++;
					f.Close();
				}
				счетчик_вопросов++;
			}
			string сообщение = "Вариант успешно создан!\n\n" +
							"Запишипе номер и сообщите студентам:\n" +
							Номер_варианта +
							"\n\nНажмите ОК для возвращения в главное меню.";
			MessageBox.Show(сообщение);

			Нач_экран newForm = new Нач_экран();
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}
		private void Ответы_LocationControls(Control source, Control target)
		{
			var x = source.Location.X + 70;//мои потрясающие подсчеты
			var y = source.Location.Y + 70;
			target.Location = new Point(x, y);
		}
		private void Ответы2_LocationControls(Control source, Control target)
		{
			var x = source.Location.X + 7;//мои потрясающие подсчеты
			var y = source.Location.Y + 7;
			target.Location = new Point(x, y);
		}
		private void Ответы3_LocationControls(Control source, Control target)
		{
			var x = 27;//мои потрясающие подсчеты
			var y = 0;
			target.Location = new Point(x, y);
		}
		private void Ответы4_LocationControls(Control target)
		{
			int t = 0;
			if (Количество_ответов == 1)
				t = 15;
			else
				t = 13;

			var x = 13;//мои потрясающие подсчеты
			var y = t+Количество_ответов*30;
			Количество_ответов++;
			target.Location = new Point(x, y);
		}
		private void Добавить_LocationControls(Control target)
		{
			var x = 220;//мои потрясающие подсчеты
			var y = 26 + Количество_ответов * 30;
			target.Location = new Point(x, y);
		}
		private void Удаление_LocationControls(Control target)
		{
			var x = 90;//мои потрясающие подсчеты
			var y = 26 + Количество_ответов * 30;
			target.Location = new Point(x, y);
		}
		private void Добавить_вопрос_LocationControls(Control target)
		{
			var x = 386;//мои потрясающие подсчеты
			var y = 238 + (Количество_ответов-1) * 30;
			target.Location = new Point(x, y);
		}
		private void Добавить_вопрос_из_базы_LocationControls(Control target)
		{
			var x = 150;//мои потрясающие подсчеты
			var y = 238 + (Количество_ответов - 1) * 30;
			target.Location = new Point(x, y);
		}
        //цивильно и роскошно
        private void Назад_Click(object sender, EventArgs e)
        {
            П1 newForm = new П1(this);
            this.Hide();//прячет форму
            newForm.Show();//открывает новую
        }
		public void Добавление_из_базы(object sender, EventArgs e,string воп,Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Вопрос)
		{

            П2_база_данных_ п2_База_ = new П2_база_данных_();

			int номер = Convert.ToInt32(groupBox1.Text);
			СписокВопросовИзБазы.Add(номер);

			foreach (var t in Вопрос) //номер
			{
				var dic1 = t.Value;
				foreach (var t1 in dic1)//вопрос
				{
					if (t1.Key == воп)//сравнили
					{
						string ts = t1.Key;
						textBox1.Text = ts;//записали

						var dic2 = t1.Value;
						foreach (var t2 in dic2)//тип ответа
						{

							Тип_Ответа = t2.Key;
							string Тип_Ответа_текст = "";
							if (t2.Key == 1)
							{
								Тип_Ответа_текст = "Один";
								Создание_ответов_один();
							}
							if (t2.Key == 2)
							{
								Тип_Ответа_текст = "Несколько";
								Создание_ответов_несколько();
							}
							if (t2.Key == 3)
							{
								Тип_Ответа_текст = "Открытый";
								Создание_ответа_открытый();
							}

							foreach (RadioButton radio in groupBoxy.Controls.OfType<RadioButton>().ToList())
							{
								if (radio.Text == Тип_Ответа_текст)
								{
									radio.Checked = true;
									break;
								}
								else
									radio.Checked = false;
							}

							var dic3 = t2.Value;
							foreach (var t3 in dic3)//правильный
							{
								if (t2.Key != 3)
								{
									var dic4 = t3.Value;

									int количество = t3.Value.Count;
									foreach (var t4 in dic4)//номер  ответ
									{

										Текст_Ответа.Last().Text = t4.Value.ToString();
										if (Тип_Ответа == 1 && t4.Key!=количество)//перед тем как добавить еще один ответ, смотрит их количество и если их уже 4 то выводим ошибку
										{
											Добавление_ответов_один();

										}
										if (Тип_Ответа == 2 && t4.Key != количество)
										{
											Добавление_ответов_несколько();
										}

									}

									if (Тип_Ответа == 1)
									{
										int k = 1;
										foreach (RadioButton radio in Ответы_Один)
										{
											if (k.ToString() == t3.Key)
											{
												radio.Checked = true;
												break;
											}
											k++;
										}

									}
									if (Тип_Ответа == 2)
									{
										string[] отв = t3.Key.Split('.');
										int i = 0;
										int k = 1;
										foreach (CheckBox check in Ответы_Несколько)
										{
											if (k.ToString() == отв[i])
											{
												check.Checked = true;
												i++;
											}
											k++;
										}
									}
								}
								else
								{
									foreach (var k in Текст_Ответа)
									{
										k.Text = t3.Key;
									}
								}
							}
						}

						break;
					}
				}
			};
		}
    }
}
