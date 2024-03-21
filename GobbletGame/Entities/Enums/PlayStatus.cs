namespace GobbletGame.Entities.Enums
{
    /** ************************************************************************
    * \brief Groups the types of play statuses.
    * \details The PlayStatus enumeration groups the possible statuses that a
    * play can have.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    enum PlayStatus : int
    {
        /// \brief Play not yet started, awaiting source field.
        WaitOriginField = 0,

        /// \brief Source field marked, awaiting destination field.
        WaitDestinyField = 1,

        /// \brief Play completed, source and destination fields have been marked.
        Finish = 2
    }
}
