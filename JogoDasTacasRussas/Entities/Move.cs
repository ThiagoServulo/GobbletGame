using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Move
    {
        public Field Origin = null;
        public Field Destiny = null;

        public Move()
        {
            this.Origin = null;
            this.Destiny = null;
        }
        
        public int Play(Field field, Player player)
        {
            if (this.Origin == null) 
            {
                if (!IsValidOrigin(field, player))
                {
                    MessageBox.Show($"saposo{player.Type}");
                    return 0;
                }
                this.Origin = field;
                this.Origin.ChangeCircleColor();
                return 1;
            }

            // Se o campo for clicado duas vezes, ele retornará ao estado inicial
            if (this.Origin == field)
            {
                this.Origin.ChangeCircleColor();
                this.Origin = null;
                return 0;
            }

            // Se for selecionado um outro campo de origm, o antigo campo retorna ao estado inicial, e o novo será atribuído
            if ((field.pictureBox.Name.Contains('X') && (player.Type == PlayerType.PlayerX)) ||
                (field.pictureBox.Name.Contains('Y') && (player.Type == PlayerType.PlayerY))) 
            {
                this.Origin.ChangeCircleColor();
                this.Origin = field;
                this.Origin.ChangeCircleColor();
                return 1;
            }
            else
            {
                // Checa se a peça pode ser colocada no lugar desejado
                if(IsValidDestiny(field, player))
                {
                    //field.ChangeCircleColor();
                    this.Destiny = field;
                    MovePiece();
                    return 2;
                }
                return 1;
            }         
        }

        private void MovePiece()
        {
            if (this.Origin.pictureBox.Name.Contains('X') || this.Origin.pictureBox.Name.Contains('Y'))
            {
                this.Origin.pictureBox.Enabled = false;
            }
            Circle circle = this.Origin.PopCircle();
            circle.colorInfo.ChangeColor();
            this.Destiny.AddCircle(circle);
            this.Origin = this.Destiny = null;
        }

        public bool IsValidOrigin(Field field, Player player)
        {
            if ((field.pictureBox.Name.Contains('X') && (player.Type == PlayerType.PlayerX)) ||
                (field.pictureBox.Name.Contains('Y') && (player.Type == PlayerType.PlayerY)))
            {
                return true;
            }

            if(field.GetLast() == null)
            {
                return false;
            }

            if(((field.GetLast().colorInfo.Primary == Color.DarkRed) && (player.Type == PlayerType.PlayerX)) ||
                ((field.GetLast().colorInfo.Primary == Color.DarkBlue) && (player.Type == PlayerType.PlayerY)))
            {
                return true;
            }

            return false;
        }

        public bool IsValidDestiny(Field field, Player player)
        {
            if (field.pictureBox.Name.Contains('X') || field.pictureBox.Name.Contains('Y'))
            {
                return false;
            }

            if (field.GetLast() == null)
            {
                return true;
            }

            if (this.Origin.GetLast().CompareTo(field.GetLast()) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
