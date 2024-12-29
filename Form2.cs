using Microsoft.VisualBasic.Logging;
using System;
using System.Windows.Forms;
using WinFormsGame.db.services;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsGame
{
    public partial class Form2 : Form
    {
        private bool showPassword = false;
        private readonly UserService _userService;
        public Form2(UserService userService)
        {
            _userService = userService;
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

        private async void button1_Click(object sender, EventArgs e)
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

                var user = await _userService.AuthenticateUserAsync(login, password);

                if (user != null)
                {
                    MessageBox.Show("Вхід успішний. Приємної гри! ^_^");
                    Form1 form1 = new Form1(_userService);
                    Program.CurrentUser = user;
                    form1.FormClosed += restart;
                    this.Hide();
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("Такого логіну/пароля не існує. Спробуйте ще раз або зареєструйтесь.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }


        private void restart(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1(_userService);
            form1.FormClosed += restart;
            form1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(_userService);
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
