/*******************************************************************************
 * Arquivo: ColorType.cs                                                       *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 16/07/2022                                                            *
 *                                                                             *
 * Enumeração: ColorType.                                                      *
 * Descrição: A enumeração 'ColorType' agrupa os tipos de cores que a peça     *
 *   pode apresentar.                                                          *
 * Tipo de dado dos itens: inteiro.                                            *
 * Itens da enumeração:                                                        *
 *   Primary: Cor primária da peça .                                           *
 *   Secundary: Cor secundária da peça.                                        *
 *******************************************************************************/

namespace JogoDasTacasRussas.Entities.Enums
{
    enum ColorType: int
    {
        Primary = 1,
        Secundary = 2
    }
}
