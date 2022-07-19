/*******************************************************************************
 * Arquivo: PlayerType.cs                                                      *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 13/07/2022                                                            *
 *                                                                             *
 * Enumeração: PlayerType                                                      *
 * Descrição: A enumeração 'PlayerType' agrupa os tipos de jogadores.          *
 * Tipo de dado dos itens: inteiro                                             *
 * Itens da enumeração:                                                        *
 *   PlayerX: Refere-se ao jogador 1.                                          *
 *   PlayerY: Refere-se ao jogador 2.                                          *
 *******************************************************************************/

namespace JogoDasTacasRussas.Entities.Enums
{
    enum PlayerType: int
    {
        PlayerX = 1,
        PlayerY = 2
    }
}
