namespace WinFormsGame
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(265, 216);
            label1.Name = "label1";
            label1.Size = new Size(55, 19);
            label1.TabIndex = 0;
            label1.Text = "Логін:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(251, 263);
            label2.Name = "label2";
            label2.Size = new Size(69, 19);
            label2.TabIndex = 1;
            label2.Text = "Пароль:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(326, 212);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(132, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(326, 263);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(132, 23);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(320, 368);
            button1.Name = "button1";
            button1.Size = new Size(138, 57);
            button1.TabIndex = 4;
            button1.Text = "Увійти";
            button1.Cursor = Cursors.Hand;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(225, 321);
            label3.Name = "label3";
            label3.Size = new Size(333, 19);
            label3.TabIndex = 6;
            label3.Cursor = Cursors.Hand;
            label3.Text = "Ще не зарееєстровані? Зареєструватися -->";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(326, 145);
            label4.Name = "label4";
            label4.Size = new Size(139, 25);
            label4.TabIndex = 7;
            label4.Text = "Введіть дані:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(464, 263);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Size = new Size(18, 18);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.Location = new Point(464, 263);
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(18, 18);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(784, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form2";
            Text = "Форма входу";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}