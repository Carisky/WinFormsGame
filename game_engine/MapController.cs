using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGame.models;
using static System.Formats.Asn1.AsnWriter;

namespace WinFormsGame.game_engine
{
    internal static class MapController
    {
        public static GameField Field = new GameField();
        public static void InitializeGameField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Field.Map[i, j] = new Cell(0, null, "");
                }
            }
        }
        private static void UpdateCellAppearance(Cell cell, int newValue)
        {
            if (cell.Picture != null)
            {
                Label label = (Label)cell.Picture.Controls[0];
                label.Text = newValue.ToString();
                cell.Value = newValue;
                ChangeColor(newValue, cell.Picture);
            }
        }
        private static void ChangeColor(int value, PictureBox picture)
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
        public static bool MoveTiles(int rowDirection, int colDirection, Label label, Form form)
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
                        MergeCells(currentCell, Field.Map[nextRow, nextCol], label, form);
                        moved = true;
                    }
                }
            }
            GUI.UpdateMapGUI(Field);
            return moved;
        }
        private static void MoveCell(Cell from, Cell to)
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
        private static void MergeCells(Cell from, Cell to, Label label, Form form)
        {
            int newValue = to.Value + from.Value;
            UpdateCellAppearance(to, newValue);

            GUI.UpdateUserInterface(newValue, label, form, from);

            from.Value = 0;

            from.Picture = null;
        }
        private static bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 4 && col >= 0 && col < 4;
        }
    }
}
