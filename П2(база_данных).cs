using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Система_тестирования
{
	public partial class П2_база_данных_ : Form
	{
		public П2_база_данных_()
		{
			InitializeComponent();
		}
		public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Вопрос = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
		//                вопрос         тип ответа        правильный            номер  ответ
		Button button1;
		П2 f;
		public П2_база_данных_(П2 f)//конструктор копирования
		{
			this.f = f;
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

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

			foreach (var t in dic) //получить все значения из словаря//номер
			{
				var dic1 = t.Value;
				foreach (var t1 in dic1)//вопрос
				{
					listBox1.Items.Add(t1.Key);
				}
			};
			listBox1.SelectedIndexChanged += (s, e) =>
			{
				string text = "";
				foreach (var t in dic) //номер
				{
					var dic1 = t.Value;
					foreach (var t1 in dic1)//вопрос
					{
						if (listBox1.Text == t1.Key)
						{
							воп = t1.Key;
							text = $"Вопрос: {t1.Key}" + Environment.NewLine + Environment.NewLine;
							var dic2 = t1.Value;
							foreach (var t2 in dic2)//тип ответа
							{
								var dic3 = t2.Value;
								foreach (var t3 in dic3)//правильный
								{
									if (t2.Key != 3)
									{
										text += $"Правильный ответ: {t3.Key}" + Environment.NewLine + Environment.NewLine;
										text += $"Ответы:" + Environment.NewLine;
										var dic4 = t3.Value;
										foreach (var t4 in dic4)//номер  ответ
										{
											text += $"{t4.Key}. {t4.Value}" + Environment.NewLine;
										}
									}
									else
									{
										text += $"Правильный ответ: {t3.Key}";
									}
								}
							}
						}
					}
				};
				textBox1.Text = text;

				button1 = new Button();
				button1.Location = new Point(210, 266);
				button1.Size = new Size(222, 33);
				button1.Font = new Font("Segoe UI", 12);
				button1.Text = "Добавить вопрос";
				button1.Click += Добавление_Click;//это добавление метода, я серьезно
				this.Controls.Add(button1);
			};
		}
		string воп;
		private void Добавление_Click(object sender, EventArgs e)
		{
			//var воп1 = Вопрос;
			this.Hide();//прячет форму
			f.Focus();
			f.Добавление_из_базы(sender,e,воп,Вопрос);
			
			//this.Hide();//прячет форму
		}
	}
}
