using System;
using System.Windows.Forms;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace WinFormsGame.models
{
	public class GameField
	{
        private Cell[,] map = new Cell[4,4]; // field

        public Cell[,] Map   // property
        {
            get { return map; }   // get method
            set { map = value; }  // set method
        }
        public GameField()
		{

		}
	}
}