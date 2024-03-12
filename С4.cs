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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Система_тестирования
{
    public partial class С4 : Form
    {
        Label label2;
        public С4()
        {
            InitializeComponent();
        }
        public С4(С3 f, float Количестов_вопросов, float Количество_баллов)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location
            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать

            Label label2 = new Label();
            label2.Location = new Point(141, 122);//положение отсчитывается относительно формы, в которой находится
            label2.Size = new Size(430, 140);
            label2.Font = new Font("Segoe UI Semibold", 28);
            label2.Text = $"Вы на {((int)((Количество_баллов/Количестов_вопросов)*100)/0.1)/10}% хлебушек";
			label2.BackColor = System.Drawing.Color.Transparent;
			Controls.Add(label2);

            
        }
        //цивильно и роскошно
        private void Вернуться_в_начало_Click(object sender, EventArgs e)
        {
            Нач_экран newForm = new Нач_экран();
            this.Hide();//прячет форму
            newForm.Show();//открывает новую
        }
    }
}
