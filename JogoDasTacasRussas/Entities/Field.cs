using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JogoDasTacasRussas.Entities
{
    class Field
    {
        // Macros
        int PRIMARY_COLOR = 1;
        int SECUNDARY_COLOR = 2;

        public PictureBox pictureBox;
        private Stack<Circle> _value = new Stack<Circle>();

        public Field(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            this._value.Clear();
        }

        public void AddCircle(Circle circle)
        {
            this._value.Push(circle);
            DrawCircle(circle, PRIMARY_COLOR);
        }

        public void PopCircle()
        {
            this._value.Pop();
            DrawCircle(GetLast(), PRIMARY_COLOR);
        }

        public bool ChangeCircleColor(Color color)
        {
            Circle circle = GetLast();
            if (circle.primaryColor == color)
            {
                this._value.Pop();
                DrawCircle(circle, SECUNDARY_COLOR);
                return true;
            }
            return false;
        }

        public Circle GetLast()
        {
            if (this._value.Count == 0)
            {
                return null;
            }
            return this._value.Peek();
        }

        public void Clear()
        {
            this._value.Clear();
        }

        private void DrawCircle(Circle circle, int colorType)
        {
            SolidBrush solidBrush;

            if (circle == null)
            {
                this.pictureBox.Dispose();
                return;
            }

            Graphics paper = this.pictureBox.CreateGraphics();

            if (colorType == 1)
            {
                solidBrush = new SolidBrush(circle.primaryColor);
            }
            else
            {
                solidBrush = new SolidBrush(circle.secundaryColor);
            }

            paper.FillEllipse(solidBrush, circle.x, circle.y, circle.width, circle.height);
        }


    }
}
