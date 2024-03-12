using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_тестирования
{
	public partial class П3 : Form
	{
		public П3()
		{
			InitializeComponent();
		}
		int колво_заданий;
		public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Вопрос = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
		//				номер				вопрос         тип ответа        правильный            номер  ответ
		public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Вариант = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
		//				номер				вопрос         тип ответа        правильный            номер  ответ
		public П3(П1 f,string колво_заданий)//конструктор копирования
		{
			InitializeComponent();

			this.колво_заданий = Convert.ToInt32(колво_заданий);

			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

			Дисериализация();
		}
		List<int> список_вопросов = new List<int>();
		public void Дисериализация()
		{
			string path;
			DirectoryInfo dir1 = new DirectoryInfo("Вопросы\\");
			FileInfo[] files1 = dir1.GetFiles("*.dat");
			FileStream fil;
			byte i = 1;
			foreach (var item in files1)
			{
				path = $"Вопросы\\{item.Name}";
				using (fil = new FileStream(path, FileMode.OpenOrCreate))
				{
					BinaryFormatter formatter = new BinaryFormatter();

					fil.Position = 0;
					fil.Seek(0, SeekOrigin.Begin);

					Вопрос[i] = formatter.Deserialize(fil) as Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>;
				}
				i++;
			}

			var dic = Вопрос;//.Values;
			label1.Text = "";
			Random rnd = new Random();	
			string вопрос = "";
			bool незанято = true;
			for (int номер_вопроса = 1; номер_вопроса <= колво_заданий; номер_вопроса++) //получить все значения из словаря//номер
			{
				незанято = true;
				вопрос = "";
				while (незанято)
				{
					int q = rnd.Next(1, dic.Count+1);

					if (!список_вопросов.Contains(q))
					{
						незанято = false;

						список_вопросов.Add(q);//добавляем в список вопросов, чтобы там проверять

						var dic1 = dic[(byte)q];

						вопрос += $"{номер_вопроса}. ";

						string text = "";

						Вариант.Add((byte)номер_вопроса, dic1);//добавляем в вариант

						foreach (var t1 in dic1)//вопрос
						{
							text = $"Вопрос: {t1.Key}" + Environment.NewLine;
							var dic2 = t1.Value;
							foreach (var t2 in dic2)//тип ответа
							{
								var dic3 = t2.Value;
								foreach (var t3 in dic3)//правильный
								{
									if (t2.Key != 3)
									{
										text += $"    Правильный ответ: {t3.Key}" + Environment.NewLine;
										text += $"    Ответы:" + Environment.NewLine;
										var dic4 = t3.Value;
										foreach (var t4 in dic4)//номер  ответ
										{
											text += $"    {t4.Key}. {t4.Value}" + Environment.NewLine;
										}
									}
									else
									{
										text += $"    Правильный ответ: {t3.Key}" + Environment.NewLine;
									}
								}
							}
						}
						text += Environment.NewLine;
						вопрос += text;
						label1.Text += вопрос;
					}
				}
			};
			label1.Text += Environment.NewLine + Environment.NewLine + Environment.NewLine;
			Сериализация_Варианта();
		}
		private void Сериализация_Варианта()
		{
			var formatter = new BinaryFormatter();
			//Cериализируем весь тест
			Random rnd = new Random();
			int Номер_варианта = 0;
			bool flag = true;
			while (flag)//проверяем, нет ли случайно уже такого файла
			{
				flag = false;
				Номер_варианта = rnd.Next(1, 1000);
				DirectoryInfo dir = new DirectoryInfo("Варианты\\");
				FileInfo[] files = dir.GetFiles("*.dat");
				foreach (var item in files)
				{
					if ($"{item}" == $"{Номер_варианта}")
					{
						flag = true;
					}
				}
			}
			label3.Text += $" {Номер_варианта}";//добавляем в лейбл номер варианта
			string path = $"Варианты\\{Номер_варианта}.dat";
			FileStream fi = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
			formatter.Serialize(fi, Вариант);
			fi.Close();
		}
		private void Назад_Click(object sender, EventArgs e)
		{
			П1 newForm = new П1(this);
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Нач_экран newForm = new Нач_экран();
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}
	}
}
