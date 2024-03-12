using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_тестирования
{
	public partial class П5 : Form
	{
		public П5()
		{
			InitializeComponent();
		}
		public П5(П4 f, string номер_варианта, string имя_студента)//конструктор копирования
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

			this.Size = f.Size;//копирет размер
			this.Location = f.Location; //копирует положение на экране
			this.Text = f.Text;//копирует название
			this.Icon = f.Icon;//копирует иконку
			this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

			this.номер_варианта = номер_варианта;
			this.имя_студента = имя_студента;

			Десериализация();
			
		}
		string номер_варианта;
		string имя_студента;

		public Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>> Тест = new Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>();
		//        номер            вопрос         тип ответа        правильный      номер  ответ
		private void button1_Click(object sender, EventArgs e)
		{
			П4 newForm = new П4(this,номер_варианта);
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}
		private void Десериализация()
		{
			//this.Text = $"Тест {номер_варианта}";
			string path;
			FileStream fil;

			path = $"Результаты\\{номер_варианта}\\Результат {имя_студента}.dat";
			if (path != "Результаты\\43\\Результат .dat")
			{
				using (fil = new FileStream(path, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();

					fil.Position = 0;
					fil.Seek(0, SeekOrigin.Begin);
					Тест = formatter.Deserialize(fil) as Dictionary<byte, Dictionary<string, Dictionary<byte, Dictionary<string, Dictionary<byte, string>>>>>;
				}

				label2.Text += $"{номер_варианта}";
				label3.Text += $"{имя_студента}";
				label1.Text = "";
				string text = "";
				double количество_вопросов = Тест.Keys.Count;
				double количество_правильных = 0;
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
								string правильный_ответ = "";
								string ответ_студента = "";
								for (int i = 0; i < t3.Key.Length; i++)
								{
									if (t3.Key[i] - 124 != 0)//124 - |
									{
										правильный_ответ += t3.Key[i];
									}
									else
									{
										ответ_студента += t3.Key.Remove(0, i + 1);
										i = t3.Key.Length;//чтоб закончить
									}
								}
								if (правильный_ответ.Trim(' ').Equals(ответ_студента.Trim(' '), StringComparison.OrdinalIgnoreCase)
									|| правильный_ответ == "")//(правильный_ответ == ответ_студента)
									количество_правильных++;


								if (t2.Key != 3)
								{
									text += $"    Правильный ответ: {правильный_ответ}" + Environment.NewLine;
									text += $"    Ответ студента: {ответ_студента}" + Environment.NewLine;
									text += $"    Ответы:" + Environment.NewLine;
									var dic4 = t3.Value;
									foreach (var t4 in dic4)//номер  ответ
									{
										text += $"    {t4.Key}. {t4.Value}" + Environment.NewLine;
									}
								}
								else
								{
									text += $"    Правильный ответ: {правильный_ответ}" + Environment.NewLine;
									text += $"    Ответ студента: {ответ_студента}" + Environment.NewLine;
								}
							}
						}
					}
				}
				text += Environment.NewLine;
				label1.Text += text;
				int проценты = Convert.ToInt32(((количество_правильных / количество_вопросов) * 100) / 0.1) / 10;
				label4.Text += $"{проценты}%";
			}
		}
	}
}
