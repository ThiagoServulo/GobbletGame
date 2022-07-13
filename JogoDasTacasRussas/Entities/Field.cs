using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

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

        public void AddCircle(Circle circle)
        {
            this._value.Push(circle);
            DrawCircle(circle);
        }

        public void PopCircle()
        {
            this._value.Pop();
            DrawCircle(GetLast());
        }
        public bool ChangeCircleColor()
        {
            Circle circle = GetLast();
            if (circle != null)
            {
                this._value.Pop();
                circle.colorInfo.ChangeColor();
                AddCircle(circle);
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

        private void DrawCircle(Circle circle)
        {
            SolidBrush solidBrush;

            if (circle == null)
            {
                this.pictureBox.Dispose();
                return;
            }

            Graphics paper = this.pictureBox.CreateGraphics();

            if (circle.colorInfo.Type == ColorType.Primary)
            {
                solidBrush = new SolidBrush(circle.colorInfo.Primary);
            }
            else
            {
                solidBrush = new SolidBrush(circle.colorInfo.Secundary);
            }

            paper.FillEllipse(solidBrush, circle.x, circle.y, circle.width, circle.height);
        }


    }
}
