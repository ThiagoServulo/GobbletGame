/*******************************************************************************
 * Arquivo: Move.cs                                                            *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 14/07/2022                                                            *
 *                                                                             *
 * Classe: Move                                                                *
 * Descrição: A classe 'Move' armazena as informações referentes a jogada que  *
 *            está sendo realizada. Logo, ela contém o campo de origem e de    *
 *            destino do movimento que será realizado.                         *
 * Atributos:                                                                  *
 *  Field Origin: Atributo público que contém o campo de origem da jogada.     *
 *  Field Destiny: Atributo público que contém o campo de destino da jogada.   *
 *******************************************************************************/

using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Move
    {
        //-------------------------------------------------------------
        // Atributos
        //-------------------------------------------------------------
        public Field Origin { get; private set; }
        public Field Destiny { get; private set; }

        //-------------------------------------------------------------
        // Construtor da classe 'Move'
        //-------------------------------------------------------------
        public Move()
        {
            this.Origin = null;
            this.Destiny = null;
        }

        //-------------------------------------------------------------
        // Função responsável por processar a jogada realizada
        // Parâmetros:
        //    field: campo selecionado pelo jogador
        //    player: jogador que está realizando a jogada
        // Retorno:
        //todo: Avaliar os retornos da função, talvez é nescessário mudar
        //-------------------------------------------------------------
        public int Play(Field field, Player player)
        {
            if (this.Origin == null) 
            {
                if (!IsValidOrigin(field, player))
                {
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

            // Se for selecionado um outro campo de origem, o antigo campo retorna ao estado inicial e o novo é atribuído
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
