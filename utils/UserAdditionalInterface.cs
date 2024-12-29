using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGame.db.models;
using WinFormsGame.db.services;

namespace WinFormsGame.utils
{
    static internal class UserAdditionalInterface
    {
        public static string ShowInputDialog(string title, string promptText, string defaultValue)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = promptText };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Height = 80, Multiline = true, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 140, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            DialogResult dialogResult = prompt.ShowDialog();
            return dialogResult == DialogResult.OK ? textBox.Text : defaultValue;
        }

        public static void ChangeUserInfo(object sender, EventArgs e)
        {
            try
            {
                string filePath = Directory.GetCurrentDirectory() + "\\user\\user info.txt";

                string[] userLines = File.ReadAllLines(filePath);

                if (userLines.Length > 0)
                {
                    string userInfo = string.Join(Environment.NewLine, userLines);

                    string editedInfo = ShowInputDialog("Інформація про користувачів", "Редагування інформації:", userInfo);

                    File.WriteAllText(filePath, editedInfo);

                    MessageBox.Show("Зміни збережено.");
                }
                else
                {
                    MessageBox.Show("У файлі немає інформації про користувачів.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }

        public static void ShowUsersInfo(object sender, EventArgs e)
        {
            try
            {
                string filePath = Directory.GetCurrentDirectory() + "\\user\\user info.txt";

                string[] userLines = File.ReadAllLines(filePath);

                if (userLines.Length > 0)
                {
                    string userInfo = string.Join(Environment.NewLine, userLines);

                    MessageBox.Show($"Інформація про користувачів:{Environment.NewLine}{userInfo}", "Інформація про користувачів");
                }
                else
                {
                    MessageBox.Show("У файлі немає інформації про користувачів.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }

        public static void SetRandomBackColor(Form form)
        {
            Random random = new Random();

            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            Color randomColor = Color.FromArgb(red, green, blue);

            form.BackColor = randomColor;
        }
        public static void ChangeBackgroundColor(Form form)
        {
            SetRandomBackColor(form);
        }
        public static void ShowGameRules(object sender, EventArgs e)
        {
            MessageBox.Show("Правила 2048:\n" +
            "- Дошка: Гра відбувається на дошці розміром 4x4, на якій зазвичай розташовуються плитки з числами. Ви починаєте з двох плиток, які мають значення 2 або 4.\n" +
            "- Переміщення: Ви можете переміщати всі плитки на дошці за 4-х клавіш зі стрілками(←, ↑, →, ↓) в чотирьох можливих напрямках: вгору, вниз, вліво та вправо.\n" +
            "- Злиття: Якщо плитки з однаковими значеннями зіткнуться під час переміщення в одному напрямку, вони об'єднуються в одну плитку, зі значенням, яке дорівнює сумі значень об'єднаних плиток. Наприклад, якщо дві плитки зі значенням зіткнуться, вони об'єднаються в одну плитку зі значенням.\n" +
            "- Мета: Ваша мета - досягти плитки з числом 2048, об'єднуючи плитки та отримуючи більші числа, які після певної кількості кроків можуть стати 2048. Гра завершується, якщо ви не можете зробити новий хід або досягли плитки.\n" +
            "- Стратегія: Головна стратегія в грі 2048 полягає в униканні заблокування дошки та попередньої обробці майбутніх ходів. Зазвичай гравці стараються утримувати один кут дошки вільним для збільшення плиток з великими значеннями.\n" +
            "- Щоб змінити колір фону натисніть на однойменний пункт меню.\n" +
            "- Для того аби перезапустити гру оберіть відповідний пункт меню.\n" +
            "- Щоб вийти з програми, оберіть пункт меню 'Вийти з програми'.\n",
            "Інструкція користувача ^_^", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowLeaderTable(object sender, EventArgs e, List<User> users)
        {
            UserTablePrinter.ShowUsersTable(users);
        }
    }
}
