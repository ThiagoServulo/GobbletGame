namespace JogoDasTacasRussas.Entities.Enums
{
    /** ************************************************************************
    * \brief Agrupa os tipos de status de uma jogada.
    * \details A enumeração PlayStatus agrupa os possíveis status que uma
    * jogada pode apresentar. 
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 13/07/2022
    * \version v1.0
    ***************************************************************************/
    enum PlayStatus : int
    {
        /// \brief Jogada ainda não iniciada, aguardando o campo de origem.
        WaitOriginField = 0,

        /// \brief Campo de origem marcado, aguardando o campo de destino.
        WaitDestinyField = 1,

        /// \brief Jogada finalizada, os campos de origem e destino foram marcados.
        Finish = 2
    }
}
