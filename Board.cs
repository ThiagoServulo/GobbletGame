using System;

public class Board
{
	public Board()
	{
        public void DrawBoard()
        {
            DrawLine(this.pictureBox1);
        }

        public void DrawLine(PictureBox pictureBox)
        {
            Graphics paper = pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Size size = pictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }
    }
}
