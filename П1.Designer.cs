using System.Text.RegularExpressions;

namespace Система_тестирования
{
	partial class П1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(П1));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Сост_случ_вар_кнопка = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.Сост_вар_кнопка = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.Посм_вар_кнопка = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "СОСТАВЛЕНИЕ ВАРИАНТА";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(23, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(195, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Случайный вариант:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(23, 165);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "Составить вариант:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(258, 120);
			this.textBox1.MaxLength = 2;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(76, 23);
			this.textBox1.TabIndex = 3;
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(23, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(229, 21);
			this.label4.TabIndex = 4;
			this.label4.Text = "Введите количество вопросов:";
			// 
			// Сост_случ_вар_кнопка
			// 
			this.Сост_случ_вар_кнопка.Location = new System.Drawing.Point(354, 120);
			this.Сост_случ_вар_кнопка.Name = "Сост_случ_вар_кнопка";
			this.Сост_случ_вар_кнопка.Size = new System.Drawing.Size(123, 23);
			this.Сост_случ_вар_кнопка.TabIndex = 5;
			this.Сост_случ_вар_кнопка.Text = "Составить вариант";
			this.Сост_случ_вар_кнопка.UseVisualStyleBackColor = true;
			this.Сост_случ_вар_кнопка.Click += new System.EventHandler(this.Составление_случайного_варианта_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label5.Location = new System.Drawing.Point(23, 211);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(259, 21);
			this.label5.TabIndex = 6;
			this.label5.Text = "Будет открыт редактор вариантов:";
			// 
			// Сост_вар_кнопка
			// 
			this.Сост_вар_кнопка.Location = new System.Drawing.Point(288, 212);
			this.Сост_вар_кнопка.Name = "Сост_вар_кнопка";
			this.Сост_вар_кнопка.Size = new System.Drawing.Size(123, 23);
			this.Сост_вар_кнопка.TabIndex = 7;
			this.Сост_вар_кнопка.Text = "Составить вариант";
			this.Сост_вар_кнопка.UseVisualStyleBackColor = true;
			this.Сост_вар_кнопка.Click += new System.EventHandler(this.Составление_варианта_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label6.Location = new System.Drawing.Point(12, 268);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(519, 37);
			this.label6.TabIndex = 8;
			this.label6.Text = "ПОСМОТРЕТЬ ВАРИАНТ И РЕЗУЛЬТАТЫ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label7.Location = new System.Drawing.Point(23, 330);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(191, 21);
			this.label7.TabIndex = 9;
			this.label7.Text = "Введите номер варианта:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(220, 332);
			this.textBox2.MaxLength = 4;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(76, 23);
			this.textBox2.TabIndex = 10;
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// Посм_вар_кнопка
			// 
			this.Посм_вар_кнопка.Location = new System.Drawing.Point(320, 332);
			this.Посм_вар_кнопка.Name = "Посм_вар_кнопка";
			this.Посм_вар_кнопка.Size = new System.Drawing.Size(130, 23);
			this.Посм_вар_кнопка.TabIndex = 11;
			this.Посм_вар_кнопка.Text = "Посмотреть вариант";
			this.Посм_вар_кнопка.UseVisualStyleBackColor = true;
			this.Посм_вар_кнопка.Click += new System.EventHandler(this.Посм_вар_кнопка_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(23, 1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(71, 29);
			this.button1.TabIndex = 12;
			this.button1.Text = "Назад";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Назад_Click);
			// 
			// П1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(637, 416);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Посм_вар_кнопка);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.Сост_вар_кнопка);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Сост_случ_вар_кнопка);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "П1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Система тестирования";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox textBox1;
		private Label label4;
		private Button Сост_случ_вар_кнопка;
		private Label label5;
		private Button Сост_вар_кнопка;
		private Label label6;
		private Label label7;
		private TextBox textBox2;
		private Button Посм_вар_кнопка;
		private Button button1;
	}
}