namespace GobbletGame.Entities.Enums
{
    /** ************************************************************************
    * \brief Groups the types of circles.
    * \details The CircleType enumeration groups the types of circles that will
    * represent the pieces. Each type will be responsible for determining the
    * different dimensions that the piece can have.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    enum CircleType : int
    {
        /// \brief The smallest piece on the board.
        Type1 = 1,

        /// \brief The second smallest piece on the board.
        Type2 = 2,

        /// \brief The second largest piece on the board.
        Type3 = 3,

        /// \brief The largest piece on the board.
        Type4 = 4
    }
}
