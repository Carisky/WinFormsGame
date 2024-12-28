using System;
using System.Windows.Forms;
namespace WinFormsGame.models
{
	public class Cell
	{
		private string _label = "";
		private int _value = 0;
		private PictureBox _picture;

        public string Label   // property
        {
            get { return _label; }   // get method
            set { _label = value; }  // set method
        }


        public int Value   // property
        {
            get { return _value; }   // get method
            set { _value = value; }  // set method
        }

        public PictureBox Picture   // property
        {
            get { return _picture; }   // get method
            set { _picture = value; }  // set method
        }

        public Cell(int value, PictureBox picture, string label)
		{
			_value = value;
			_picture = picture;
			_label = label;
		}
	}
}