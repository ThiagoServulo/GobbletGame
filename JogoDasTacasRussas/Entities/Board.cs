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
 *   Form [Form1]: Tela onde o tabuleiro será apresentado.                     *
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
        public FormBoard Form { get; private set; }

        //----------------------------------------------------------------------
        // Construtor da classe 'Board'
        //----------------------------------------------------------------------
        public Board(FormBoard form)
        {
            this.Form = form;

            // Inicialização do tabuleiro
            this.InitBoard();

            // Inicialização dos jogadores
            this.PlayerX = new Player(PlayerType.PlayerX);
            this.PlayerY = new Player(PlayerType.PlayerY);
            this.CurrentPlayer = this.PlayerX;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por inicializar o tabuleiro.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void InitBoard()
        {
            // Inicialização da movimentação
            this.PlayerMove = new Move();

            // Inicialização das peças do Jogador X
            this.InitFieldsPlayerX = new Field[] { 
                new Field(this.Form.pictureBoxX1),  new Field(this.Form.pictureBoxX2),  new Field(this.Form.pictureBoxX3),
                new Field(this.Form.pictureBoxX4),  new Field(this.Form.pictureBoxX5),  new Field(this.Form.pictureBoxX6),
                new Field(this.Form.pictureBoxX7),  new Field(this.Form.pictureBoxX8),  new Field(this.Form.pictureBoxX9),
                new Field(this.Form.pictureBoxX10), new Field(this.Form.pictureBoxX11), new Field(this.Form.pictureBoxX12)};
            this.InitFields(this.InitFieldsPlayerX, Color.DarkRed, Color.IndianRed);

            // Inicialização das peças do Jogador Y
            this.InitFieldsPlayerY = new Field[] {
                new Field(this.Form.pictureBoxY1),  new Field(this.Form.pictureBoxY2),  new Field(this.Form.pictureBoxY3),
                new Field(this.Form.pictureBoxY4),  new Field(this.Form.pictureBoxY5),  new Field(this.Form.pictureBoxY6),
                new Field(this.Form.pictureBoxY7),  new Field(this.Form.pictureBoxY8),  new Field(this.Form.pictureBoxY9),
                new Field(this.Form.pictureBoxY10), new Field(this.Form.pictureBoxY11), new Field(this.Form.pictureBoxY12)};
            this.InitFields(this.InitFieldsPlayerY, Color.DarkBlue, Color.LightBlue);

            // Inicialização do tabuleiro
            this.FieldsBoard = new Field[] {
                new Field(this.Form.pictureBoxA1), new Field(this.Form.pictureBoxA2), new Field(this.Form.pictureBoxA3), 
                new Field(this.Form.pictureBoxA4), new Field(this.Form.pictureBoxB1), new Field(this.Form.pictureBoxB2), 
                new Field(this.Form.pictureBoxB3), new Field(this.Form.pictureBoxB4), new Field(this.Form.pictureBoxC1),
                new Field(this.Form.pictureBoxC2), new Field(this.Form.pictureBoxC3), new Field(this.Form.pictureBoxC4),
                new Field(this.Form.pictureBoxD1), new Field(this.Form.pictureBoxD2), new Field(this.Form.pictureBoxD3), 
                new Field(this.Form.pictureBoxD4)};
            this.InitFields(this.FieldsBoard, null, null);

            // Concatenação de todos os campos do tabuleiro
            this.AllFields = new Field[][] { this.FieldsBoard, this.InitFieldsPlayerY, this.InitFieldsPlayerX };
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
                // Habilitar para que o campo possa ser selecionado
                fields[i].FieldPictureBox.Enabled = true;

                if (primaryColor == null || secundaryColor == null) // Se as cores forem nulas, o campo será limpado
                {
                    fields[i].DrawCircle(null);
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
            Field field = this.GetField(pictureBox);

            // Se a jogada estiver sido finalizada, será alternado para o próximo jogador
            if (this.PlayerMove.Play(field, this.CurrentPlayer) == PlayStatus.Finish)
            {
                Player playerWinner = this.CheckWinner();
                if (playerWinner != null)
                {
                    playerWinner.AddVictory();
                    this.InitBoard();
                    MessageBox.Show($"{PlayerX.Victories} - {PlayerY.Victories}");
                }
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
                    if (field.FieldPictureBox == pictureBox)
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

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por verificar se há um ganhador na partida.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Valor do tipo 'Player', indicando o ganhador da partida atual. Se
        //    não ouver ganhador é retornado 'null'.
        //----------------------------------------------------------------------
        public Player CheckWinner()
        {
            // Checar colunas
            for(int i = 0; i <= 12; i+=4)
            {
                if (this.FieldsBoard[i].Equals(this.FieldsBoard[i + 1]) && 
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 2]) && 
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 3]))
                {
                    return this.CheckPlayer(this.FieldsBoard[i]);
                }
            }

            // Checar linhas
            for (int i = 0; i <= 4; i++)
            {
                if (this.FieldsBoard[i].Equals(this.FieldsBoard[i + 4]) &&
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 8]) &&
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 12]))
                {
                    return this.CheckPlayer(this.FieldsBoard[i]);
                }
            }

            // Checar diagonal principal
            if (this.FieldsBoard[0].Equals(this.FieldsBoard[5]) &&
                this.FieldsBoard[0].Equals(this.FieldsBoard[10]) &&
                this.FieldsBoard[0].Equals(this.FieldsBoard[15]))
            {
                return this.CheckPlayer(this.FieldsBoard[0]);
            }

            // Checar diagonal principal
            if (this.FieldsBoard[3].Equals(this.FieldsBoard[6]) &&
                this.FieldsBoard[3].Equals(this.FieldsBoard[9]) &&
                this.FieldsBoard[3].Equals(this.FieldsBoard[12]))
            {
                return this.CheckPlayer(this.FieldsBoard[3]);
            }

            // Retorna null se não houver ganhador
            return null;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por checar de qual jogador é a peça que está
        //    no campo informado.
        // Parâmetros:
        //    field [Field]: Campo que será analizado.
        // Retorno:
        //    Valor do tipo 'Player', indicando o jogador dono da peça presnete
        //    no campo.
        //----------------------------------------------------------------------
        public Player CheckPlayer(Field field)
        {
            // Pega a cor do círculo presnete no campo
            Color circleColor = field.GetLast().Color.Primary;

            // Ver o jogador dono desta peça
            if(circleColor == Color.DarkRed)
            {
                return this.PlayerX;
            }
            else if (circleColor == Color.DarkBlue)
            {
                return this.PlayerY;
            }

            // Retorna null se o jogador não for encontrado
            return null;
        }
    }
}
