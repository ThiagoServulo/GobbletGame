using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JogoDasTacasRussas.Entities
{
    class Board
    {
        public Board(Form1 form)
        {
            DrawLine(form.pictureBox1);
            DrawLine(form.pictureBox2);
            DrawLine(form.pictureBox3);
            DrawLine(form.pictureBox4);
            DrawLine(form.pictureBox6);
            DrawLine(form.pictureBox7);
            DrawLine(form.pictureBox8);
            DrawLine(form.pictureBox9);
            DrawLine(form.pictureBox11);
            DrawLine(form.pictureBox12);
            DrawLine(form.pictureBox13);
            DrawLine(form.pictureBox14);
            DrawLine(form.pictureBox16);
            DrawLine(form.pictureBox17);
            DrawLine(form.pictureBox18);
            DrawLine(form.pictureBox19);
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
