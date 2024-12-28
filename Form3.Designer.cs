namespace WinFormsGame
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            label5 = new Label();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(326, 147);
            label5.Name = "label5";
            label5.Size = new Size(139, 25);
            label5.TabIndex = 23;
            label5.Text = "Введіть дані:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(466, 276);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Size = new Size(23, 23);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(294, 367);
            button2.Name = "button2";
            button2.Size = new Size(235, 55);
            button2.TabIndex = 20;
            button2.Text = "Зареєструватися";
            button2.Cursor = Cursors.Hand;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(328, 227);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(132, 23);
            textBox3.TabIndex = 19;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(328, 276);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(132, 23);
            textBox4.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(245, 276);
            label7.Name = "label7";
            label7.Size = new Size(69, 19);
            label7.TabIndex = 17;
            label7.Text = "Пароль:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(245, 229);
            label8.Name = "label8";
            label8.Size = new Size(55, 19);
            label8.TabIndex = 16;
            label8.Text = "Логін:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(466, 276);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 23);
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(371, 326);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(351, 326);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 26;
            label3.Cursor = Cursors.Hand;
            label3.Text = "<-- Назад";
            label3.Click += label3_Click;
            // 
            // Form3
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(784, 500);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(label7);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form3";
            Text = "Форма реєстрації";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private PictureBox pictureBox2;
        private Button button2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label3;
    }
}