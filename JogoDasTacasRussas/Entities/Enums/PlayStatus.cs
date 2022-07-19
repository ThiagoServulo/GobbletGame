/*******************************************************************************
 * Arquivo: PlayStatus.cs                                                      *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 13/07/2022                                                            *
 *                                                                             *
 * Enumeração: PlayStatus                                                      *
 * Descrição: A enumeração 'PlayStatus' agrupa os possíveis status que uma     *
 *   jogada pode apresentar.                                                   *
 * Tipo de dado dos itens: inteiro                                             *
 * Itens da enumeração:                                                        *
 *   WaitOriginField: Jogada ainda não iniciada, aguardando o campo de origem. *
 *   WaitDestinyField: Campo de origem marcado, aguardando o campo de destino. *
 *   Finish: Jogada finalizada, os campos de origem e destino foram marcados.  *
 *******************************************************************************/

namespace JogoDasTacasRussas.Entities.Enums
{
    enum PlayStatus: int
    {
        WaitOriginField = 0,
        WaitDestinyField= 1,
        Finish = 2
    }
}
