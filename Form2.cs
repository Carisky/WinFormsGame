using Microsoft.VisualBasic.Logging;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsGame
{
    public partial class Form2 : Form
    {
        private bool showPassword = false;

        public Form2()
        {
            InitializeComponent();
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            label3.MouseEnter += label3_MouseEnter;
            label3.MouseLeave += label3_MouseLeave;
            this.StartPosition = FormStartPosition.CenterScreen;

            textBox2.UseSystemPasswordChar = true;

            pictureBox1.Click += pictureBox1_Click;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Highlight;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = SystemColors.Highlight;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Будь ласка, введіть логін і пароль.");
                    return; 
                }

                string filePath = Directory.GetCurrentDirectory() + "\\user\\user info.txt";
                string filePath2 = Directory.GetCurrentDirectory() + "\\admin\\admin info.txt";

                string[] existingLines = File.ReadAllLines(filePath);

                if (Array.Exists(existingLines, line => line.StartsWith($"{login} {password}")))
                {
                    MessageBox.Show("Вхід успішний. Приємної гри! ^_^");
                    Form1 form1 = new Form1();
                    form1.FormClosed += restart;
                    this.Hide();
                    form1.Show();
                    return;
                }

                string[] existingLines2 = File.ReadAllLines(filePath2);

                if (Array.Exists(existingLines2, line => line.StartsWith($"{login} {password}")))
                {
                    MessageBox.Show("Вхід успішний.");
                    GlobalVariables.levels = ("1");
                    Form1 form1 = new Form1();
                    form1.FormClosed += restart;
                    this.Hide();
                    form1.Show();
                    return;
                }

                MessageBox.Show("Такого логіну/пароля не існує. Спробуйте ще раз або зареєструйтесь.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }

        private void restart(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.FormClosed += restart;
            form1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }
    }
    public static class GlobalVariables
    {
        public static string levels = ("0");
    }

}
