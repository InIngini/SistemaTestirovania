namespace Система_тестирования
{
	partial class П2
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
			System.Windows.Forms.RadioButton radioButton1;
			System.Windows.Forms.RadioButton radioButton2;
			System.Windows.Forms.RadioButton radioButton3;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(П2));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBoxy = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.Назад = new System.Windows.Forms.Button();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBoxy.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			radioButton1.Location = new System.Drawing.Point(6, 6);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(62, 23);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "Один";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton2
			// 
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			radioButton2.Location = new System.Drawing.Point(79, 6);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(94, 23);
			radioButton2.TabIndex = 1;
			radioButton2.TabStop = true;
			radioButton2.Text = "Несколько";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton3
			// 
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			radioButton3.Location = new System.Drawing.Point(189, 6);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(93, 23);
			radioButton3.TabIndex = 2;
			radioButton3.TabStop = true;
			radioButton3.Text = "Открытый";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.groupBoxy);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(23, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(509, 155);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(6, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 21);
			this.label3.TabIndex = 4;
			this.label3.Text = "Ответы: ";
			// 
			// groupBoxy
			// 
			this.groupBoxy.Controls.Add(radioButton3);
			this.groupBoxy.Controls.Add(radioButton2);
			this.groupBoxy.Controls.Add(radioButton1);
			this.groupBoxy.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBoxy.Location = new System.Drawing.Point(106, 62);
			this.groupBoxy.Name = "groupBoxy";
			this.groupBoxy.Size = new System.Drawing.Size(390, 37);
			this.groupBoxy.TabIndex = 3;
			this.groupBoxy.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(6, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "Тип ответа: ";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox1.Location = new System.Drawing.Point(71, 27);
			this.textBox1.MaxLength = 90;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(425, 25);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(6, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Вопрос: ";
			// 
			// button6
			// 
			this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button6.BackColor = System.Drawing.Color.Transparent;
			this.button6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button6.Location = new System.Drawing.Point(479, 366);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(146, 38);
			this.button6.TabIndex = 2;
			this.button6.Text = "Сохранить тест";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.Сохранить_Click);
			// 
			// Назад
			// 
			this.Назад.Location = new System.Drawing.Point(23, 1);
			this.Назад.Name = "Назад";
			this.Назад.Size = new System.Drawing.Size(71, 29);
			this.Назад.TabIndex = 13;
			this.Назад.Text = "Назад";
			this.Назад.UseVisualStyleBackColor = true;
			this.Назад.Click += new System.EventHandler(this.Назад_Click);
			// 
			// П2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(637, 416);
			this.Controls.Add(this.Назад);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "П2";
			this.Text = "Система тестирование";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBoxy.ResumeLayout(false);
			this.groupBoxy.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private GroupBox groupBox1;
		private Label label1;
		private Label label2;
		private GroupBox groupBoxy;
		private Label label3;
		private Button button6;
		public TextBox textBox1;
	}
}