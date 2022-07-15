﻿using System;
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

        public Circle PopCircle()
        {
            Circle circle = this._value.Pop();
            DrawCircle(GetLast());
            return circle;
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

            EraseField();

            if (circle == null)
            {
                this.pictureBox.Image = null;
                return;
            }

            Graphics paper = this.pictureBox.CreateGraphics();

            if (circle.colorInfo.TypeCurrent == ColorType.Primary)
            {
                solidBrush = new SolidBrush(circle.colorInfo.Primary);
            }
            else
            {
                solidBrush = new SolidBrush(circle.colorInfo.Secundary);
            }

            paper.FillEllipse(solidBrush, circle.x, circle.y, circle.width, circle.height);
        }

        public void EraseField()
        {
            Graphics paper = pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            Size size = pictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }
    }
}
