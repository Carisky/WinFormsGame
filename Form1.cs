using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormsGame.models;
using WinFormsGame.utils;
namespace WinFormsGame
{
    public partial class Form1 : Form
    {
        private GameField Field = new GameField();
        private int score = 0;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            InitializeGameField();
            GenerateNewCell();
            GenerateNewCell();
        }
        private void InitializeGameField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Field.Map[i, j] = new Cell(0, null, "");
                }
            }
        }
        private void GenerateNewCell()
        {
            int row, col;

            do
            {
                row = rnd.Next(0, 4);
                col = rnd.Next(0, 4);
            } while (Field.Map[row, col].Value != 0);

            int value = rnd.Next(1, 3) * 2;
            var picture = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(12 + col * 56, 73 + row * 56),
                BackColor = value == 2 ? Color.SeaShell : Color.Pink
            };

            var label = new Label
            {
                Text = value.ToString(),
                Size = new Size(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(new FontFamily("Comic Sans MS"), 12)
            };

            picture.Controls.Add(label);
            this.Controls.Add(picture);
            picture.BringToFront();

            Field.Map[row, col] = new Cell(value, picture, label.Text);
        }
        private void UpdateCellAppearance(Cell cell, int newValue)
        {
            if (cell.Picture != null)
            {
                Label label = (Label)cell.Picture.Controls[0];
                label.Text = newValue.ToString();
                cell.Value = newValue;
                ChangeColor(newValue, cell.Picture);
            }
        }
        private void ChangeColor(int value, PictureBox picture)
        {
            if (value % 1024 == 0)
            {
                picture.BackColor = Color.Pink;
            }
            else
            {
                int exp = (int)Math.Log(value, 2);
                int darkerValue = Math.Max(0, 255 - (exp * 20));
                picture.BackColor = Color.FromArgb(255, darkerValue, darkerValue);
            }
        }
        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            bool moved = false;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    moved = MoveTiles(0, 1);
                    break;
                case Keys.Left:
                    moved = MoveTiles(0, -1);
                    break;
                case Keys.Down:
                    moved = MoveTiles(1, 0);
                    break;
                case Keys.Up:
                    moved = MoveTiles(-1, 0);
                    break;
            }

            if (moved)
            {
                GenerateNewCell();
            }
        }
        private bool MoveTiles(int rowDirection, int colDirection)
        {
            bool moved = false;
            for (int i = (rowDirection > 0 ? 3 : 0); i >= 0 && i < 4; i -= rowDirection > 0 ? 1 : -1)
            {
                for (int j = (colDirection > 0 ? 3 : 0); j >= 0 && j < 4; j -= colDirection > 0 ? 1 : -1)
                {
                    Cell currentCell = Field.Map[i, j];
                    if (currentCell.Value == 0) continue;

                    int nextRow = i + rowDirection;
                    int nextCol = j + colDirection;

                    while (IsValidPosition(nextRow, nextCol) && Field.Map[nextRow, nextCol].Value == 0)
                    {
                        MoveCell(currentCell, Field.Map[nextRow, nextCol]);
                        nextRow += rowDirection;
                        nextCol += colDirection;
                        moved = true;
                    }

                    if (IsValidPosition(nextRow, nextCol) && Field.Map[nextRow, nextCol].Value == currentCell.Value)
                    {
                        MergeCells(currentCell, Field.Map[nextRow, nextCol]);
                        moved = true;
                    }
                }
            }
            UpdateGUI();
            return moved;
        }
        private void MoveCell(Cell from, Cell to)
        {
            if (from.Picture == null)
            {
                // No picture to move
                return;
            }

            // Move the value and picture reference
            to.Value = from.Value;
            to.Picture = from.Picture;
            from.Value = 0;


            // Update the picture's location
            if (to.Picture != null)
            {
                to.Picture.Location = new Point(
                    to.Picture.Location.X + (to.Picture.Location.X - from.Picture.Location.X),
                    to.Picture.Location.Y + (to.Picture.Location.Y - from.Picture.Location.Y)
                );

                from.Picture = null;
            }
        }
        private void MergeCells(Cell from, Cell to)
        {
            int newValue = to.Value + from.Value;
            UpdateCellAppearance(to, newValue);
            score += newValue;
            label1.Text = "Score: " + score;

            from.Value = 0;
            this.Controls.Remove(from.Picture);
            from.Picture = null;
        }
        private bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 4 && col >= 0 && col < 4;
        }
        private void RestartGame(object sender, EventArgs e)
        {
            this.Close();
        }
        private void QuitGame(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void UpdateGUI()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Cell cell = Field.Map[row, col];
                    if (cell.Picture != null)
                    {
                        cell.Picture.Location = new Point(
                            12 + col * 56,  // X координата
                            73 + row * 56   // Y координата
                        );
                    }
                }
            }
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
    }

    
}
