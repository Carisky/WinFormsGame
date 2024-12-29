using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGame.models;
using static System.Formats.Asn1.AsnWriter;

namespace WinFormsGame.game_engine
{
    internal static class GUI
    {
        public static void UpdateMapGUI(GameField Field)
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

        public static void UpdateUserInterface(int newValue, Label label, Form form, Cell from)
        {
            GameData.Score += newValue;
            label.Text = "Score: " + GameData.Score;
            form.Controls.Remove(from.Picture);
        }
    }
}
