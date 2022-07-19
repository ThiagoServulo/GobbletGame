/*******************************************************************************
 * Arquivo: CircleType.cs                                                      *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 16/07/2022                                                            *
 *                                                                             *
 * Enumeração: CircleType.                                                     *
 * Descrição: A enumeração 'CircleType' agrupa os tipos de círculo que irão    *
 *   representar as peças. Cada tipo será responsável por determinar as        *
 *   diferentes dimensões que a peça pode apresentar.                          *
 * Tipo de dado dos itens: inteiro.                                            *
 * Itens da enumeração:                                                        *
 *   Type1: Menor peça do tabuleiro.                                           *
 *   Type2: Segunda menor peça do tabuleiro.                                   *
 *   Type3: Segunda maior peça do tabuleiro.                                   *
 *   Type4: Maior peça do tabuleiro.                                           *
 *******************************************************************************/
namespace JogoDasTacasRussas.Entities.Enums
{
    enum CircleType: int
    {
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4
    }
}
