/*******************************************************************************
 * Arquivo: Player.cs                                                          *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 13/07/2022                                                            *
 *                                                                             *
 * Classe: Player                                                              *
 * Descrição: A classe 'Player' armazena as informações referentes ao jogador  *
 *   que está realizando uma movimentação de uma peça. Logo, ela contém as     *
 *   a quantidade de vitórias que o jogador possui e o tipo de jogador         *
 *   (Jogador X ou Y) que ele é.                                               *
 * Atributos:                                                                  *
 *   Victories [int]: Quantidade de vitórias do jogador.                       *
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
        public PlayerType Type { get; private set; }

        //----------------------------------------------------------------------
        // Construtor da classe 'Player'
        //----------------------------------------------------------------------
        public Player(PlayerType type)
        {
            this.Type = type;
            this.Victories = 0;
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
    }
}
