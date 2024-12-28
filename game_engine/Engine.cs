using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGame.models;

namespace WinFormsGame.game_engine
{
    internal class Engine
    {
        private int score = 0;
        private Random rnd = new Random();
        public Engine() {
            MapController.InitializeGameField();
        }

        public bool MakeMove(int rowDirection, int colDirection, Label label, Form form)
        {
           return MapController.MoveTiles(rowDirection, colDirection, score, label, form);
        }

        public void GenerateNewCell(Form form)
        {
            int row, col;

            do
            {
                row = rnd.Next(0, 4);
                col = rnd.Next(0, 4);
            } while (MapController.Field.Map[row, col].Value != 0);

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
            form.Controls.Add(picture);
            picture.BringToFront();

            MapController.Field.Map[row, col] = new Cell(value, picture, label.Text);
        }
    }
}
