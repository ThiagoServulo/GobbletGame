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
        private Field[] _fieldsPlayerX = new Field[12];
        private Field[] _fieldsPlayerY = new Field[12];
        private Field[] _fieldsBoard   = new Field[16];
        private Field[][] _allFields;
        private Player _playerX;
        private Player _playerY;
        private Player _currentPlayer;


        public Board(Form1 form)
        {
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
            if(this.move.Play(field, this._currentPlayer) == PlayStatus.Finish)
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
