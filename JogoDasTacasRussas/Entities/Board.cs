using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Board
    {
        private PictureBox[] _pictureBoxes = new PictureBox[102];
        private Field[] _fieldsPlayer1 = new Field[12];
        public Board(Form1 form)
        {
            _pictureBoxes = new PictureBox[]{ 
                form.pictureBox1,   form.pictureBox2,   form.pictureBox3,   form.pictureBox4,   form.pictureBox6,   
                form.pictureBox7,   form.pictureBox8,   form.pictureBox9,   form.pictureBox11,  form.pictureBox12, 
                form.pictureBox13,  form.pictureBox14,  form.pictureBox16,  form.pictureBox17,  form.pictureBox18,  
                form.pictureBox19,  form.pictureBox21,  form.pictureBox22,  form.pictureBox23,  form.pictureBox24,  
                form.pictureBox26,  form.pictureBox27,  form.pictureBox28,  form.pictureBox29,  form.pictureBox31,  
                form.pictureBox32,  form.pictureBox33,  form.pictureBox34,  form.pictureBox36,  form.pictureBox37,  
                form.pictureBox38,  form.pictureBox39,  form.pictureBox41,  form.pictureBox42,  form.pictureBox43,  
                form.pictureBox44,  form.pictureBox46,  form.pictureBox47,  form.pictureBox48,  form.pictureBox49,  
                form.pictureBox51,  form.pictureBox52,  form.pictureBox53,  form.pictureBox54,  form.pictureBox56,  
                form.pictureBox57,  form.pictureBox58,  form.pictureBox59,  form.pictureBox61,  form.pictureBox62,  
                form.pictureBox63,  form.pictureBox64,  form.pictureBox66,  form.pictureBox67,  form.pictureBox68,  
                form.pictureBox69,  form.pictureBox71,  form.pictureBox72,  form.pictureBox73,  form.pictureBox74,  
                form.pictureBox76,  form.pictureBox77,  form.pictureBox78,  form.pictureBox79,  form.pictureBox81, 
                form.pictureBox82,  form.pictureBox83,  form.pictureBox84,  form.pictureBox86,  form.pictureBox87,  
                form.pictureBox88,  form.pictureBox89,  form.pictureBox91,  form.pictureBox92,  form.pictureBox93,  
                form.pictureBox94,  form.pictureBox96,  form.pictureBox97,  form.pictureBox98,  form.pictureBox99, 
                form.pictureBox101, form.pictureBox102, form.pictureBox103, form.pictureBox104, form.pictureBox106, 
                form.pictureBox107, form.pictureBox108, form.pictureBox109, form.pictureBox111, form.pictureBox112, 
                form.pictureBox113, form.pictureBox114, form.pictureBox116, form.pictureBox117, form.pictureBox118, 
                form.pictureBox119, form.pictureBox137, form.pictureBox138, form.pictureBox139, form.pictureBox140,
                form.pictureBox141, form.pictureBox142};

            foreach (PictureBox pictureBox in _pictureBoxes)
            {
                DrawLine(pictureBox);
            }

            // área de teste (não sei se deve ficar aqui)
            _fieldsPlayer1 = new Field[] { 
                new Field(form.pictureBoxX1),  new Field(form.pictureBoxX2),  new Field(form.pictureBoxX3),
                new Field(form.pictureBoxX4),  new Field(form.pictureBoxX5),  new Field(form.pictureBoxX6),
                new Field(form.pictureBoxX7),  new Field(form.pictureBoxX8),  new Field(form.pictureBoxX9),
                new Field(form.pictureBoxX10), new Field(form.pictureBoxX11), new Field(form.pictureBoxX12)};

            for(int i = 0; i < _fieldsPlayer1.Length; i++)
            {
                if(i < 3)
                {
                    _fieldsPlayer1[i].Add(new Circle(Color.Black, CircleType.Type1));
                }
                else if (i < 6)
                {
                    _fieldsPlayer1[i].Add(new Circle(Color.Black, CircleType.Type2));
                }
                else if (i < 9)
                {
                    _fieldsPlayer1[i].Add(new Circle(Color.Black, CircleType.Type3));
                }
                else
                {
                    _fieldsPlayer1[i].Add(new Circle(Color.Black, CircleType.Type4));
                }
            }

            /*
            // área de teste
            Circle cir = new Circle(Color.Black, CircleType.Type1);
            DrawCircle(form.pictureBoxX1, cir);
            Circle cir2 = new Circle(Color.Black, CircleType.Type2);
            DrawCircle(form.pictureBoxX4, cir2);
            if(cir2.CompareTo(cir) > 0)
            {
                DrawCircle(form.pictureBoxX10, cir2);
            }

            DrawCircle(form.pictureBoxX4, null);
            */
        }

        public void DrawLine(PictureBox pictureBox)
        {
            Graphics paper = pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Size size = pictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }

        private void DrawCircle(PictureBox pictureBox, Circle circle)
        {
            if (circle == null)
            {
                pictureBox.Dispose();
                return;
            }

            Graphics paper = pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(circle.color);
            paper.FillEllipse(solidBrush, circle.x, circle.y, circle.width, circle.height);
        }
    }
}
