using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JogoDasTacasRussas.Entities
{
    class Field
    {
        public PictureBox pictureBox;
        private Stack<Circle> _value = new Stack<Circle>();

        public Field(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            this._value.Clear();
        }

        public void Add(Circle circle)
        {
            this._value.Push(circle);
            DrawCircle(circle);
        }

        public void Pop()
        {
            this._value.Pop();
            DrawCircle(GetLast());
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

        private void DrawCircle(Circle circle)
        {
            if (circle == null)
            {
                this.pictureBox.Dispose();
                return;
            }

            Graphics paper = this.pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(circle.color);
            paper.FillEllipse(solidBrush, circle.x, circle.y, circle.width, circle.height);
        }
    }
}
