using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WinFormsGame
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button2.MouseEnter += button1_MouseEnter;
            button2.MouseLeave += button1_MouseLeave;
            label3.MouseEnter += label3_MouseEnter;
            label3.MouseLeave += label3_MouseLeave;
            this.StartPosition = FormStartPosition.CenterScreen;
            textBox4.UseSystemPasswordChar = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Highlight;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Control;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = SystemColors.Highlight;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = SystemColors.ControlText;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string login = textBox3.Text;
            string password = textBox4.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Будь ласка, введіть логін і пароль перед збереженням.");
                return;
            }

            try
            {
                string filePath = Directory.GetCurrentDirectory() + "\\user\\user info.txt";

                string line = $"{login} {password}";

                if (File.Exists(filePath) && !File.ReadAllText(filePath).EndsWith(Environment.NewLine))
                {
                    File.AppendAllText(filePath, Environment.NewLine);
                }

                File.AppendAllText(filePath, line + Environment.NewLine);

                MessageBox.Show("Дані збережено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }
    }
}