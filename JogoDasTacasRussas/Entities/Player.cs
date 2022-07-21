/*******************************************************************************
 * Arquivo: Player.cs                                                          *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 13/07/2022                                                            *
 *                                                                             *
 * Classe: Player                                                              *
 * Descrição: A classe 'Player' armazena as informações referentes ao jogador  *
 *   que está realizando uma movimentação de uma peça. Logo, ela contém as     *
 *   informações referentes ao jogador (quantidade de vitórias, derrotas e     *
 *   empates), além do tipo de jogador (Jogador X ou Y).                       *
 * Atributos:                                                                  *
 *   Victories [int]: Quantidade de vitórias do jogador.                       *
 *   Defeats [int]: Quantidade de derrotas do jogador.                         *
 *   Type [PlayerType]: Tipo do jogador (Jogador X ou Y) .                     *
 *******************************************************************************/

using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Player
    {
        //----------------------------------------------------------------------
        // Atributos
        //----------------------------------------------------------------------
        public int Victories { get; private set; }
        public int Defeats { get; private set; }
        public PlayerType Type { get; private set; }

        //----------------------------------------------------------------------
        // Construtor da classe 'Player'
        //----------------------------------------------------------------------
        public Player(PlayerType type)
        {
            this.Type = type;
            this.Defeats = this.Victories = 0;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por adicionar uma vitória para o jogador.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void AddVictory()
        {
            this.Victories += 1;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por adicionar uma derrota para o jogador.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void AddDefeat()
        {
            this.Defeats += 1;
        }
    }
}
