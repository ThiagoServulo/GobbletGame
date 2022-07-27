using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    /** ************************************************************************
    * \brief Informações sobre a movimentação das peças.
    * \details A classe Move armazena as informações referentes a jogada que 
    * está sendo realizada. Logo, ela contém o campo de origem e de destino 
    * do movimento que será realizado.
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 14/07/2022
    * \version v1.0
    ***************************************************************************/
    class Move
    {
        /***************************************************************************
        * Atributos da classe
        ***************************************************************************/
        /// \brief Campo de origem da jogada.
        public Field Origin { get; private set; }

        /// \brief Campo de destino da jogada.
        public Field Destiny { get; private set; }


        /** ************************************************************************
        * \brief Construtor da classe Move.
        ***************************************************************************/
        public Move()
        {
            this.Origin = null;
            this.Destiny = null;
        }

        /** ************************************************************************
        * \brief Processa a jogada atual.
        * \details Função responsável por processar a jogada realizada, atribuindo
        * o campo selecionado a posição de origem ou destino da jogada.
        * \param field Campo selecionado pelo jogador.
        * \param player Jogador que está realizando a jogada.
        * \return Valor do tipo \link JogoDasTacasRussas.Entities.Enums PlayStatus
        * \endlink, indicando o status atual da jogada que está sendo realizada.
        ***************************************************************************/
        public PlayStatus Play(Field field, Player player)
        {
            // Se o campo de origem estiver vazio ele será atribuído
            if (this.Origin == null)
            {
                // Checa se o campo de origem é válido para aquele jogador
                if (!this.IsValidOrigin(field, player))
                {
                    return PlayStatus.WaitOriginField;
                }
                else
                {
                    this.Origin = field;
                    this.Origin.ChangeCircleColor();
                    return PlayStatus.WaitDestinyField;
                }
            }

            // Se o campo for selecionado duas vezes, ele não será mais considerado a origem 
            if (this.Origin == field)
            {
                this.Origin.ChangeCircleColor();
                this.Origin = null;
                return PlayStatus.WaitOriginField;
            }

            // Se for selecionado um outro campo de origem, o antigo campo retorna ao estado inicial
            // e o novo é atribuído
            if ((field.FieldPictureBox.Name.Contains('X') && (player.Type == PlayerType.PlayerX)) ||
                (field.FieldPictureBox.Name.Contains('Y') && (player.Type == PlayerType.PlayerY)))
            {
                this.Origin.ChangeCircleColor();
                this.Origin = field;
                this.Origin.ChangeCircleColor();
                return PlayStatus.WaitDestinyField;
            }

            // Checa se o campo de destino é válido para aquele jogador
            if (this.IsValidDestiny(field))
            {
                this.Destiny = field;
                this.MovePiece();
                return PlayStatus.Finish;
            }

            // Caso nenhuma condição acima satisfaça, o campo selecionado é atribuído como o de destino
            return PlayStatus.WaitDestinyField;

        }

        /** ************************************************************************
        * \brief Processa a movimentação da peça.
        * \details Função responsável por realizar a movimentação da peça, ou 
        * seja, transferir a peça da posição de origem para a posição de destino.
        ***************************************************************************/
        public void MovePiece()
        {
            if (this.Origin.FieldPictureBox.Name.Contains('X') || this.Origin.FieldPictureBox.Name.Contains('Y'))
            {
                this.Origin.FieldPictureBox.Enabled = false;
            }
            Circle circle = this.Origin.PopCircle();
            circle.Color.ChangeColor();
            this.Destiny.AddCircle(circle);
            this.Origin = this.Destiny = null;
        }

        /** ************************************************************************
        * \brief Valida o campo de origem da jogada.
        * \details Função que valida se o campo de origem selecionado é válido 
        * para um determinado jogador.
        * \param field Campo selecionado pelo jogador.
        * \param player Jogador que está realizando a jogada.
        * \return Valor do tipo booleano, inicando se o campo de origem é válida 
        * ou não
        ***************************************************************************/
        public bool IsValidOrigin(Field field, Player player)
        {
            // Um jogador só poderá selecionar os campos iniciais referentes a sua cor
            if ((field.FieldPictureBox.Name.Contains('X') && (player.Type == PlayerType.PlayerX)) ||
                (field.FieldPictureBox.Name.Contains('Y') && (player.Type == PlayerType.PlayerY)))
            {
                return true;
            }

            // Um jogador não poderá selecionar um campo incial que não contenha peças
            if (field.GetLast() == null)
            {
                return false;
            }

            // Um jogador só poderá selecionar um campo incial que contenha alguma peça de sua cor
            if (((field.GetLast().Color.Primary == Color.DarkRed) && (player.Type == PlayerType.PlayerX)) ||
                ((field.GetLast().Color.Primary == Color.DarkBlue) && (player.Type == PlayerType.PlayerY)))
            {
                return true;
            }

            // Se nenhuma condição acima for satisfeita, o campo de origem é inválido para a jogada
            return false;
        }

        /** ************************************************************************
        * \brief Valida o campo de destino da jogada.
        * \details Função que valida se o campo de destino selecionado é válido.
        * \param field Campo selecionado pelo jogador.
        * \return Valor do tipo booleano, inicando se o campo de destino é válida
        * ou não
        ***************************************************************************/
        public bool IsValidDestiny(Field field)
        {
            // O campo de destino não pode ser um campo inicial
            if (field.FieldPictureBox.Name.Contains('X') || field.FieldPictureBox.Name.Contains('Y'))
            {
                return false;
            }

            // O campo de destino pode ser um campo vazio
            if (field.GetLast() == null)
            {
                return true;
            }

            // O campo de destino só será válido caso a peça contida no campo de origem seja
            // maior que a peça presnete no campo de destino
            if (this.Origin.GetLast().CompareTo(field.GetLast()) > 0)
            {
                return true;
            }

            // Se nenhuma condição acima for satisfeita, o campo de destino é inválido para a jogada
            return false;
        }
    }
}
