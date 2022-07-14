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
        private Move move = new Move();
        private PictureBox[] _pictureBoxes = new PictureBox[102];
        private Field[] _fieldsPlayerX = new Field[12];
        private Field[] _fieldsPlayerY = new Field[12];
        private Field[] _fieldsBoard   = new Field[16];
        private Field[][] _allFields;
        private Player _playerX;
        private Player _playerY;
        private Player _currentPlayer;


        public Board(Form1 form)
        {
            // Inicialização do design do tabuleiro
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

            // Inicialização das peças do Jogador X
            _fieldsPlayerX = new Field[] { 
                new Field(form.pictureBoxX1),  new Field(form.pictureBoxX2),  new Field(form.pictureBoxX3),
                new Field(form.pictureBoxX4),  new Field(form.pictureBoxX5),  new Field(form.pictureBoxX6),
                new Field(form.pictureBoxX7),  new Field(form.pictureBoxX8),  new Field(form.pictureBoxX9),
                new Field(form.pictureBoxX10), new Field(form.pictureBoxX11), new Field(form.pictureBoxX12)};
            InitFields(_fieldsPlayerX, Color.DarkRed, Color.IndianRed);

            // Inicialização das peças do Jogador Y
            _fieldsPlayerY = new Field[] {
                new Field(form.pictureBoxY1),  new Field(form.pictureBoxY2),  new Field(form.pictureBoxY3),
                new Field(form.pictureBoxY4),  new Field(form.pictureBoxY5),  new Field(form.pictureBoxY6),
                new Field(form.pictureBoxY7),  new Field(form.pictureBoxY8),  new Field(form.pictureBoxY9),
                new Field(form.pictureBoxY10), new Field(form.pictureBoxY11), new Field(form.pictureBoxY12)};
            InitFields(_fieldsPlayerY, Color.DarkBlue, Color.LightBlue);

            // Inicialização do tabuleiro
            _fieldsBoard = new Field[] {
                new Field(form.pictureBoxA1), new Field(form.pictureBoxA2), new Field(form.pictureBoxA3), new Field(form.pictureBoxA4), 
                new Field(form.pictureBoxB1), new Field(form.pictureBoxB2), new Field(form.pictureBoxB3), new Field(form.pictureBoxB4),  
                new Field(form.pictureBoxC1), new Field(form.pictureBoxC2), new Field(form.pictureBoxC3), new Field(form.pictureBoxC4),
                new Field(form.pictureBoxD1), new Field(form.pictureBoxD2), new Field(form.pictureBoxD3), new Field(form.pictureBoxD4)};
            InitFields(_fieldsBoard, null, null);

            // Concatena todos os campos do tabuleiro
            _allFields = new Field[][] { _fieldsBoard, _fieldsPlayerY, _fieldsPlayerX };

            // Inicialização dos jogadores
            this._playerX = new Player(PlayerType.PlayerX);
            this._playerY = new Player(PlayerType.PlayerY);
            this._currentPlayer = this._playerX;
        }

        public void DrawLine(PictureBox pictureBox)
        {
            Graphics paper = pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Size size = pictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }

        public void InitFields(Field[] fieldsPlayer, Color? primaryColor, Color? secundaryColor)
        {
            for (int i = 0; i < fieldsPlayer.Length; i++)
            {
                if(primaryColor == null || secundaryColor == null)
                {
                    fieldsPlayer[i].Clear();
                }
                else if (i < 3)
                {
                    fieldsPlayer[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type1));
                }
                else if (i < 6)
                {
                    fieldsPlayer[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type2));
                }
                else if (i < 9)
                {
                    fieldsPlayer[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type3));
                }
                else
                {
                    fieldsPlayer[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type4));
                }
            }
        }

        public void Click(PictureBox pictureBox)
        {
            Field field = GetField(pictureBox);
            if(this.move.Play(field, this._currentPlayer) == 2)
            {
                this.ChangeCurrentPlayer();
            }
        }

        public Field GetField(PictureBox pictureBox)
        {
            foreach(Field[] listFields in _allFields)
            {
                foreach (Field field in listFields)
                {
                    if (field.pictureBox == pictureBox)
                    {
                        return field;
                    }
                }
            }
            return null;
        }

        public void ChangeCurrentPlayer()
        {
            this._currentPlayer = (this._currentPlayer.Type == PlayerType.PlayerX) ? this._playerY : this._playerX;
        }
    }
}
