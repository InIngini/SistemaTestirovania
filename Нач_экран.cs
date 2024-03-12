using System.Drawing;

namespace Система_тестирования
{
	public partial class Нач_экран : Form
	{
        public Нач_экран(П1 f)//конструктор копирования
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;//Положение формы определяется свойством Location

            this.Size = f.Size;//копирет размер
            this.Location = f.Location; //копирует положение на экране
            this.Text = f.Text;//копирует название
            this.Icon = f.Icon;//копирует иконку
            this.FormBorderStyle = f.FormBorderStyle;//запрещает масштабировать
        }
        public Нач_экран()
		{
			InitializeComponent();
		}
		private void Студент_Click(object sender, EventArgs e)
		{
			С1 newForm = new С1(this);
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}
		private void Преподаватель_Click(object sender, EventArgs e)
		{
			П1 newForm = new П1(this);
			this.Hide();//прячет форму
			newForm.Show();//открывает новую
		}

        private void Нач_экран_Load(object sender, EventArgs e)
        {

        }
    }
}