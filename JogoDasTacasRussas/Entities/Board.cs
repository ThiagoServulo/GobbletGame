/*******************************************************************************
 * Arquivo: Board.cs                                                           *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 19/07/2022                                                            *
 *                                                                             *
 * Classe: Board                                                               *
 * Descrição: A classe 'Board' armazena as informações referentes ao tabuleiro *
 *   do jogo, ou seja, onde as peças serão colocadas.                          *
 * Atributos:                                                                  *
 *   PlayerMove [Move]: Informações da jogada atual.                           *
 *   InitFieldsPlayerX [Field[]]: Campos iniciais do jogador X.                *
 *   InitFieldsPlayerY [Field[]]: Campos iniciais do jogador Y.                *
 *   FieldsBoard [Field[]]: Campos do tabuleiro do jogo.                       * 
 *   AllFields [Field[][]]: Todos os campos do jogo.                           *
 *   PlayerX [Player]: Informações relativas ao jogador X.                     *
 *   PlayerY [Player]: Informações relativas ao jogador Y.                     *
 *   CurrentPlayer [Player]: Informações relativas ao jogador atual.           *
 *******************************************************************************/

using System.Drawing;
using System.Windows.Forms;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Board
    {
        //----------------------------------------------------------------------
        // Atributos
        //----------------------------------------------------------------------
        public Move PlayerMove { get; private set; }
        public Field[] InitFieldsPlayerX { get; private set; }
        public Field[] InitFieldsPlayerY { get; private set; }
        public Field[] FieldsBoard { get; private set; }
        public Field[][] AllFields { get; private set; }
        public Player PlayerX { get; private set; }
        public Player PlayerY { get; private set; }
        public Player CurrentPlayer { get; private set; }


        //----------------------------------------------------------------------
        // Construtor da classe 'Board'
        //----------------------------------------------------------------------
        public Board(Form1 form)
        {
            // Inicialização da movimentação
            this.PlayerMove = new Move();

            // Inicialização das peças do Jogador X
            this.InitFieldsPlayerX = new Field[] { 
                new Field(form.pictureBoxX1),  new Field(form.pictureBoxX2),  new Field(form.pictureBoxX3),
                new Field(form.pictureBoxX4),  new Field(form.pictureBoxX5),  new Field(form.pictureBoxX6),
                new Field(form.pictureBoxX7),  new Field(form.pictureBoxX8),  new Field(form.pictureBoxX9),
                new Field(form.pictureBoxX10), new Field(form.pictureBoxX11), new Field(form.pictureBoxX12)};
            InitFields(this.InitFieldsPlayerX, Color.DarkRed, Color.IndianRed);

            // Inicialização das peças do Jogador Y
            this.InitFieldsPlayerY = new Field[] {
                new Field(form.pictureBoxY1),  new Field(form.pictureBoxY2),  new Field(form.pictureBoxY3),
                new Field(form.pictureBoxY4),  new Field(form.pictureBoxY5),  new Field(form.pictureBoxY6),
                new Field(form.pictureBoxY7),  new Field(form.pictureBoxY8),  new Field(form.pictureBoxY9),
                new Field(form.pictureBoxY10), new Field(form.pictureBoxY11), new Field(form.pictureBoxY12)};
            InitFields(this.InitFieldsPlayerY, Color.DarkBlue, Color.LightBlue);

            // Inicialização do tabuleiro
            this.FieldsBoard = new Field[] {
                new Field(form.pictureBoxA1), new Field(form.pictureBoxA2), new Field(form.pictureBoxA3), new Field(form.pictureBoxA4), 
                new Field(form.pictureBoxB1), new Field(form.pictureBoxB2), new Field(form.pictureBoxB3), new Field(form.pictureBoxB4),  
                new Field(form.pictureBoxC1), new Field(form.pictureBoxC2), new Field(form.pictureBoxC3), new Field(form.pictureBoxC4),
                new Field(form.pictureBoxD1), new Field(form.pictureBoxD2), new Field(form.pictureBoxD3), new Field(form.pictureBoxD4)};
            InitFields(this.FieldsBoard, null, null);

            // Concatenação de todos os campos do tabuleiro
            this.AllFields = new Field[][] { this.FieldsBoard, this.InitFieldsPlayerY, this.InitFieldsPlayerX };

            // Inicialização dos jogadores
            this.PlayerX = new Player(PlayerType.PlayerX);
            this.PlayerY = new Player(PlayerType.PlayerY);
            this.CurrentPlayer = this.PlayerX;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por inicializar os campos do tabuleiro,
        //    adicionando as peças ou deixando-os vazios.
        // Parâmetros:
        //    fields [Field[]]: Campos que serão inicializados.
        //    primaryColor [Color?]: Cor primária da possível peça adicionada.
        //    secundaryColor [Color?]: Cor secundária da possível peça adicionada.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void InitFields(Field[] fields, Color? primaryColor, Color? secundaryColor)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if(primaryColor == null || secundaryColor == null) // Se as cores forem nulas, o campo será limpado
                {
                    fields[i].Clear();
                }
                else if (i < 3) // Adiciona o menor círculo existente
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type1));
                }
                else if (i < 6) // Adiciona o segundo menor círculo existente
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type2));
                }
                else if (i < 9) // Adiciona o segundo maior círculo existente
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type3));
                }
                else // Adiciona o maior círculo existente
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type4));
                }
            }
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por processar a interrupção do usuário ao clicar
        //    em um determinado 'pictureBox'.
        // Parâmetros:
        //    pictureBox [PictureBox]: 'pictureBox' clicado pelo usuário.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void Click(PictureBox pictureBox)
        {
            Field field = GetField(pictureBox);

            // Se a jogada estiver sido finalizada, será alternado para o próximo jogador
            if(this.PlayerMove.Play(field, this.CurrentPlayer) == PlayStatus.Finish)
            {
                this.ChangeCurrentPlayer();
            }
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por converter um 'pictureBox' para um campo
        //    conhecido.
        // Parâmetros:
        //    pictureBox [PictureBox]: 'pictureBox' que será convertido.
        // Retorno:
        //     Valor do tipo 'Field', que apresenta as informações do campo
        //    referentes ao 'pictureBox' informado.
        //----------------------------------------------------------------------
        public Field GetField(PictureBox pictureBox)
        {
            foreach(Field[] listFields in this.AllFields)
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

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por realizar a troca do jogador atual.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void ChangeCurrentPlayer()
        {
            this.CurrentPlayer = (this.CurrentPlayer.Type == PlayerType.PlayerX) ? this.PlayerY : this.PlayerX;
        }
    }
}
