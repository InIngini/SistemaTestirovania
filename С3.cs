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
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace Система_тестирования
{
    public partial class С3 : Form
    {
        public С3()
        {
            InitializeComponent();
        }
        string ФИ = "Ноунейм";
        string Номер_варианта;
        public С3(С2 f, string вариант,string ФИ)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location
            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
            this.ФИ = ФИ;
            Номер_варианта = вариант;
            Десериализация(вариант);

            Вопросы = new List<GroupBox>() { groupBox1 };


		}
        public С3(С1 f, string вариант, string ФИ)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location
            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
            this.ФИ = ФИ;
            Номер_варианта = вариант;
            Десериализация(вариант);
        }
        public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Тест = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
        //        номер            вопрос         тип ответа        правильный      номер  ответ
        public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Тест2 = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
        //        номер            вопрос         тип ответа        правильный      номер  ответ
        List<GroupBox> Вопросы;
        List<RadioButton> Ответы_Один;
        List<CheckBox> Ответы_Несколько;
        List<TextBox> Текст_Ответа;
        TextBox textBox_Answer_Открытый;
        int s=0;
        int m=90;
		void timer1_Tick(object sender, EventArgs e)
		{
            label2.Text = $"Осталось {m} мин {s} секунд";
			s = s - 1;
			if (s == -1)
			{
				m = m - 1;
				s = 59;
			}
			if (m == 0 && s == 0)
            {
                timer1.Stop();
                MessageBox.Show("Время вышло!");
                Заверешение_теста();
            }
		}
		private void Десериализация(String вариант)
        {
			timer1.Interval = 1000; // полтора часа
			timer1.Enabled = true;
			timer1.Tick += timer1_Tick;



			this.Text = $"Тест {вариант}";
            string path;
            FileStream fil;

            path = $"Варианты\\{вариант}.dat";
            using (fil = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                fil.Position = 0;
                fil.Seek(0, SeekOrigin.Begin);
                Тест = formatter.Deserialize(fil) as Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>;
                Рассортировка();
                Создание_вопроса();
            }
        }
        int n = 0;//Номер текущего вопроса
        int n1 = 0;
        int[] Номер_вопроса = new int[30];
        string[,] Вопрос_ответы = new string[30, 6];
        int[] Тип_отв = new int[30];
        string[] Правильный_ответ = new string[30];
        string[] Данный_ответ = new string[30];
        int Количество_вопросов = 0;
        int Количество_ответов = 1;
        private void Рассортировка()
        {

            for (int k = 0; k < 30; k++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Вопрос_ответы[k, j] = "";
                    Данный_ответ[k] = "";
                }
            }

            int i = 0;
            var dic = Тест;
            foreach (var t in dic) //номер
            {
                Номер_вопроса[i] = t.Key;
                Количество_вопросов = t.Key;
                var dic1 = t.Value;
                foreach (var t1 in dic1)//вопрос
                {
                    Вопрос_ответы[i, 0] = t1.Key;
                    var dic2 = t1.Value;
                    foreach (var t2 in dic2)//тип ответа
                    {
                        Тип_отв[i] = t2.Key;
                        var dic3 = t2.Value;
                        foreach (var t3 in dic3)// правильный
                        {
                            Правильный_ответ[i] = t3.Key;
                            var dic4 = t3.Value;
                            int j = 1;
                            foreach (var t4 in dic4)
                            {
                                Вопрос_ответы[i, j] = $"{t4.Key}) {t4.Value}";
                                j++;
                            }
                        }
                    }
                }
                i++;
            }
            groupBox2.Text = $"{1}|{Количество_вопросов}";
        }

        private void Создание_вопроса()
        {


            groupBox2.Controls.Add(label4);
            label4.Text = Вопрос_ответы[n, 0];

            Количество_ответов = 1;

            Ответы_Один = new List<RadioButton>();//обнуляем
            Ответы_Несколько = new List<CheckBox>();
            Текст_Ответа = new List<TextBox>();
            n1 = 1;
            if (Тип_отв[n] == 1)
            {
                Создание_ответов_один();
                n1++;
                while (Вопрос_ответы[n, n1] != "")
                {
                    Добавление_ответов_один();
                    n1++;
                }
            }
            else
                if (Тип_отв[n] == 2)
            {
                Создание_ответов_несколько();
                n1++;
                while (Вопрос_ответы[n, n1] != "")
                {
                    Добавление_ответов_несколько();
                    n1++;
                }
            }
            else
                Создание_ответа_открытый();
        }

        private void Создание_ответов_один()
        {

            RadioButton radioButton1 = new RadioButton();//добавляем первый ответ
            radioButton1.Location = new Point(49, 68);//положение отсчитывается относительно формы, в которой находится
            radioButton1.Size = new Size(830, 30);
            radioButton1.Font = new Font("Segoe UI", 14);
            radioButton1.Text = Вопрос_ответы[n, 1];
            groupBox2.Controls.Add(radioButton1);
            Ответы_Один.Add(radioButton1);//добавляем кнопочку
        }
        private void Добавление_ответов_один()
        {

            RadioButton radioButton1 = new RadioButton();//добавляем второй ответ
            Ответы4_LocationControls(radioButton1);//положение отсчитывается относительно формы, в которой находится
            radioButton1.Size = new Size(830, 30);
            radioButton1.Font = new Font("Segoe UI", 14);
            radioButton1.Text = Вопрос_ответы[n, n1];
            Ответы_Один.Add(radioButton1);//добавляем кнопочку
            groupBox2.Controls.Add((RadioButton)radioButton1);
        }
        private void Создание_ответов_несколько()
        {

            CheckBox chekBox1 = new CheckBox();//добавляем первый ответ
            chekBox1.Location = new Point(49, 68);//положение отсчитывается относительно формы, в которой находится
            chekBox1.Size = new Size(830, 30);
            chekBox1.Font = new Font("Segoe UI", 14);
            chekBox1.Text = Вопрос_ответы[n, 1];
            Ответы_Несколько.Add(chekBox1);//добавляем кнопочку
            groupBox2.Controls.Add(chekBox1);
        }
        private void Добавление_ответов_несколько()
        {

            CheckBox chekBox1 = new CheckBox();//добавляем второй ответ
            Ответы4_LocationControls(chekBox1);//положение отсчитывается относительно формы, в которой находится
            chekBox1.Size = new Size(830, 30);
            chekBox1.Font = new Font("Segoe UI", 14);
            chekBox1.Text = Вопрос_ответы[n, n1];
            groupBox2.Controls.Add((CheckBox)chekBox1);//добавляем, чтобы видеть
            Ответы_Несколько.Add(chekBox1);//добавляем кнопочку
        }
        private void Создание_ответа_открытый()
        {

            textBox_Answer_Открытый = new TextBox();
            textBox_Answer_Открытый.Location = new Point(49, 68);
            textBox_Answer_Открытый.Font = new Font("Segoe UI", 14);
            textBox_Answer_Открытый.Size = new Size(350, 30);
            textBox_Answer_Открытый.MaxLength = 40;
            groupBox2.Controls.Add(textBox_Answer_Открытый);
            Текст_Ответа.Add(textBox_Answer_Открытый);//добавляем текст 
        }
        private void Ответы4_LocationControls(Control target)
        {
            Количество_ответов++;

            var x = 49;//мои потрясающие подсчеты
            var y = 68 + (Количество_ответов - 1) * 33;

            target.Location = new Point(x, y);
        }
        private void Следующий_вопрос_Click(object sender, EventArgs e)
        {
            if (Тип_отв[n] == 1)
            {
                byte k = 1;
                foreach (var i in Ответы_Один)
                {
                    if (i.Checked)
                    {
                        Данный_ответ[n] = $"{k}";
                    }
                    k++;
                }
            }
            if (Тип_отв[n] == 2)
            {
                byte k = 1;
                foreach (var i in Ответы_Несколько)
                {
                    if (i.Checked)
                    {
                        Данный_ответ[n] += $"{k}.";
                    }
                    k++;
                }
            }
            if (Тип_отв[n] == 3)
                Данный_ответ[n] = textBox_Answer_Открытый.Text;



            if (n == Количество_вопросов - 2)
                button1.Text = "ЗАВЕРШИТЬ ТЕСТ";
            if (n != Количество_вопросов - 1)
            {
                groupBox2.Controls.Clear();
                n++;
                groupBox2.Text = $"{n + 1}|{Количество_вопросов}";
                Создание_вопроса();
                if (Данный_ответ[n] != "")
                {
                    if (Тип_отв[n] == 1)
                    {
                        int k = 1;
                        foreach (RadioButton radio in Ответы_Один)
                        {
                            if (k.ToString() == Данный_ответ[n])
                            {
                                radio.Checked = true;
                                break;
                            }
                            k++;
                        }

                    }
                    if (Тип_отв[n] == 2)
                    {
                        string[] отв = Данный_ответ[n].Split('.');
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
                    if (Тип_отв[n] == 3)
                    {
                        textBox_Answer_Открытый.Text = Данный_ответ[n];
                    }
                }
            }
            else
                Заверешение_теста();

        }
        private void Предыдущий_вопрос_Click(object sender, EventArgs e)
        {
            if (n >= 1)
            {

                if (Тип_отв[n] == 1)
                {
                    byte k = 1;
                    foreach (var i in Ответы_Один)
                    {
                        if (i.Checked)
                        {
                            Данный_ответ[n] = $"{k}";
                        }
                        k++;
                    }
                }
                if (Тип_отв[n] == 2)
                {
                    byte k = 1;
                    foreach (var i in Ответы_Несколько)
                    {
                        if (i.Checked)
                        {
                            Данный_ответ[n] += $"{k}.";
                        }
                        k++;
                    }
                }
                if (Тип_отв[n] == 3)
                    Данный_ответ[n] = textBox_Answer_Открытый.Text;

                button1.Text = "СЛЕДУЮЩИЙ ВОПРОС";
                groupBox2.Controls.Clear();
                n--;
                groupBox2.Text = $"{n + 1}|{Количество_вопросов}";
                Создание_вопроса();
                if (Данный_ответ[n] != "")
                {
                    if (Тип_отв[n] == 1)
                    {
                        int k = 1;
                        foreach (RadioButton radio in Ответы_Один)
                        {
                            if (k.ToString() == Данный_ответ[n])
                            {
                                radio.Checked = true;
                                break;
                            }
                            k++;
                        }

                    }
                    if (Тип_отв[n] == 2)
                    {
                        string[] отв = Данный_ответ[n].Split('.');
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
                    if (Тип_отв[n] == 3)
                    {
                        textBox_Answer_Открытый.Text = Данный_ответ[n];
                    }
                }
            }
        }
        int Количество_баллов = 0;
        private void Заверешение_теста()
        {
            for(int j = 0; j<Количество_вопросов;j++)
            {
                if (Правильный_ответ[j].Trim(' ').Equals(Данный_ответ[j].Trim(' '), StringComparison.OrdinalIgnoreCase))
					Количество_баллов++;
            }
            for (int q = 0; q < Количество_вопросов; q++)
            {
                Dictionary<byte, string> DОтв = new Dictionary<byte, string>();
                int j = 1;
                while (Вопрос_ответы[q, j] != "")
                {
                    string str = Вопрос_ответы[q,j];
                    if (str.Length >= 2)
                    {
                        if (str[1] == ')')
                            str = str.Remove(0, 3);
                        else
                        if (str[2] == ')')
                            str = str.Remove(0, 4);
                    }
                    DОтв.Add((byte)(j), str);
                    j++;   
                }
                var DПравильный = new Dictionary<string, Dictionary<byte, string>>();
                DПравильный.Add($"{Правильный_ответ[q]}|{Данный_ответ[q]}", DОтв);

                var DТип = new Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>();
                DТип.Add((byte)Тип_отв[q], DПравильный);
                var DВопрос = new Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>();
                DВопрос.Add(Вопрос_ответы[q,0], DТип);
                Тест2.Add((byte)(q+1), DВопрос);
            }
            var formatter = new BinaryFormatter();
            
            Directory.CreateDirectory($"Результаты\\{Номер_варианта}\\");

            DirectoryInfo dir1 = new DirectoryInfo($"Результаты\\{Номер_варианта}\\");
			FileInfo[] files1 = dir1.GetFiles("*.dat");
            string name = $"Результат {ФИ}.dat";
            bool flag = true;
            int попытка = 2;
            while (flag)
            { 
                flag = false;
                foreach (var item in files1)
                {
                    if (item.Name == name)
                    { 
                        flag = true;
                        name = $"Результат {ФИ} попытка {попытка}.dat";
                        попытка++;
					}
                } 
            }

			string path = $"Результаты\\{Номер_варианта}\\{name}";
			FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            formatter.Serialize(f, Тест2);
            f.Close();

            С4 newForm = new С4(this, Количество_вопросов, Количество_баллов);
            this.Hide();//прячет форму
            newForm.Show();//открывает новую
        }
    }
}
