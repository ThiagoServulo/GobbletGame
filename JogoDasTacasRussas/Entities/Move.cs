using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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
        
        public int Play(Field field, int jogador)
        {
            // Checa se o movimento é válido
            if (!IsValidMove(field, jogador)) 
            {
                MessageBox.Show("nao");
                return 0;
            }

            // Se não existir a origem, ela será atribuída
            if (this.Origin == null) 
            {
                this.Origin = field;
                return 1;
            }

            // Se o campo for clicado duas vezes, ele retornará ao estado inicial
            if (this.Origin == field)
            {
                this.Origin.ChangeCircleColor();
                this.Origin = null;
                return 0;
            }

            // Se for selecionado um campo inicial, ele será atribuído
            if ((field.pictureBox.Name.Contains('X') && (jogador == 1)) ||
                (field.pictureBox.Name.Contains('Y') && (jogador == 2))) 
            {
                this.Origin.ChangeCircleColor();
                this.Origin = field;
                return 1;
            }
            else
            {
                // Checa se a peça pode ser colocada no lugar desejado
                if(this.Origin.GetLast().CompareTo(field.GetLast()) > 0)
                {
                    this.Destiny = field;
                    MessageBox.Show("2");
                    return 2;
                }
                return 1;
            }         
        }

        public bool IsValidMove(Field field, int jogador)
        {
            if ((field.pictureBox.Name.Contains('X') && (jogador == 1)) ||
                (field.pictureBox.Name.Contains('Y') && (jogador == 2)))
            {
                return true;
            }

            if(((field.GetLast().colorInfo.Primary == Color.Blue) && (jogador == 1)) ||
                ((field.GetLast().colorInfo.Primary == Color.Red) && (jogador == 2)))
            {
                return true;
            }

            return false;
        }
    }
}
