using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormsGame.game_engine;
using WinFormsGame.models;
using WinFormsGame.utils;
using WinFormsGame.db.services;
namespace WinFormsGame
{
    public partial class Form1 : Form
    {
        private Engine engine = new Engine();
        private readonly UserService _userService;
        public Form1(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed!);

            engine.GenerateNewCell(this);
            engine.GenerateNewCell(this);   
        }
        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            bool moved = false;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    moved = engine.MakeMove(0, 1, Controls.Find("label1", false)[0] as Label, this);
                    break;
                case Keys.Left:
                    moved = engine.MakeMove(0, -1, Controls.Find("label1", false)[0] as Label, this);
                    break;
                case Keys.Down:
                    moved = engine.MakeMove(1, 0, Controls.Find("label1", false)[0] as Label, this);
                    break;
                case Keys.Up:
                    moved = engine.MakeMove(-1, 0, Controls.Find("label1", false)[0] as Label, this);
                    break;
            }

            if (moved)
            {
                engine.GenerateNewCell(this);
            }
        }
        private void RestartGame(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void QuitGame(object sender, EventArgs e)
        {
            if (Program.CurrentUser.Highscore<GameData.Score)
            {
                    await _userService.UpdateHighscoreAsync(Program.CurrentUser.Id, GameData.Score);
            }
            Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (GlobalVariables.levels == ("1"))
            {
                менюАдмінаToolStripMenuItem.Visible = true;
            }
        }
        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            UserAdditionalInterface.SetRandomBackColor(this);
        }
        private void ShowGameRules(object sender, EventArgs e)
        {
            UserAdditionalInterface.ShowGameRules(sender, e);
        }
        private void ShowUsersInfo(object sender, EventArgs e)
        {
            UserAdditionalInterface.ChangeUserInfo(sender, e);
        }
        private void ChangeUserInfo(object sender, EventArgs e)
        {
            UserAdditionalInterface.ChangeUserInfo(sender, e);
        }
        private async void ShowLeaderTable(object sender, EventArgs e)
        {   
            var users = await _userService.GetAllUsersAsync();
            users = users.OrderByDescending(u => u.Highscore).ToList();
            UserAdditionalInterface.ShowLeaderTable(sender, e, users);
        }
    }
}
