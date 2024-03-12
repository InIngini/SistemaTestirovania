using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Система_тестирования
{
	public partial class П4 : Form
	{
		public П4()
		{
			InitializeComponent();
		}
		string номер_варианта;

		public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Тест = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
		//        номер            вопрос         тип ответа        правильный      номер  ответ
		public П4(П1 f,string номер_варианта)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

			this.номер_варианта = номер_варианта;

			Десериализация();
			Список_студентов();
		}
		public П4(П5 f, string номер_варианта)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

			this.номер_варианта = номер_варианта;

			Десериализация();
			Список_студентов();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			П1 newForm = new П1(this);
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}
		private void Десериализация()
		{
			//this.Text = $"Тест {номер_варианта}";
			string path;
			FileStream fil;

			path = $"Варианты\\{номер_варианта}.dat";
			using (fil = new FileStream(path, FileMode.OpenOrCreate))
			{
				BinaryFormatter formatter = new BinaryFormatter();

				fil.Position = 0;
				fil.Seek(0, SeekOrigin.Begin);
				Тест = formatter.Deserialize(fil) as Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>;
			}

			label2.Text += $"{номер_варианта}";
			label1.Text = "";
			string text = "";
			foreach (var dic1 in Тест)
			{
				foreach (var t1 in dic1.Value)//вопрос
				{
					text += Environment.NewLine;
					text += $"{dic1.Key}. Вопрос: {t1.Key}" + Environment.NewLine;
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
			}
			text += Environment.NewLine+ Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
			label1.Text += text;
		}
		private void Список_студентов()
		{
			Directory.CreateDirectory($"Результаты\\{номер_варианта}");
            DirectoryInfo dir1 = new DirectoryInfo($"Результаты\\{номер_варианта}");
			FileInfo[] files1 = dir1.GetFiles("*.dat");
			string name = "";
			foreach (var item in files1)
			{
				name = item.Name.Remove(0, 10);
				name = name.Remove(name.Length - 4, 4);
				listBox1.Items.Add(name);
			}
			listBox1.SelectedIndexChanged += (s, e) =>
			{
				if (listBox1.Text != "")
				{
					П5 newForm = new П5(this, номер_варианта, listBox1.Text);
					this.Hide();//прячет форму
					newForm.Show();//открывает новую
				}
			};
		}	
	}
}
