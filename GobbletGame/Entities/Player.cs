using GobbletGame.Entities.Enums;
using System.Windows.Forms;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Information about a player.
    * \details The Player class stores information about the player making a 
    * piece movement. Therefore, it contains the number of victories the player 
    * has and the type of player (Player X or Y) they are.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    class Player
    {
        /// \brief Number of victories of the player.
        public int Victories { get; private set; }

        /// \brief Type of player (Player X or Y).
        public PlayerType Type { get; private set; }

        /// \brief \a label displaying the player's number of victories.
        public Label LabelVictories { get; private set; }


        /** ************************************************************************
        * \brief Constructor of the Player class.
        * \param type Type of player (Player X or Y).
        ***************************************************************************/
        public Player(PlayerType type, Label label)
        {
            this.Type = type;
            this.Victories = 0;
            this.LabelVictories = label;
        }


        /** ************************************************************************
        * \brief Add a victory for the player.
        * \details Function responsible for adding a victory for the player.
        ***************************************************************************/
        public void AddVictory()
        {
            this.Victories += 1;
        }
    }
}
