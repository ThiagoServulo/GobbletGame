using System.Drawing;
using GobbletGame.Entities.Enums;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Information about piece movement.
    * \details The Move class stores information about the move being made.
    * Therefore, it contains the source and destination fields of the move to
    * be made.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    class Move
    {
        /// \brief Source field of the move.
        public Field Origin { get; private set; }

        /// \brief Destination field of the move.
        public Field Destiny { get; private set; }


        /** ************************************************************************
        * \brief Constructor of the Move class.
        ***************************************************************************/
        public Move()
        {
            this.Origin = null;
            this.Destiny = null;
        }


        /** ************************************************************************
        * \brief Process the current move.
        * \details Function responsible for processing the move made, assigning
        * the selected field to either the source or destination position of the move.
        * \param field Field selected by the player.
        * \param player Player making the move.
        * \return A value of type \link GobbletGame.Entities.Enums PlayStatus
        * \endlink, indicating the current status of the move being made.
        ***************************************************************************/
        public PlayStatus Play(Field field, Player player)
        {
            // If the source field is empty, it will be assigned
            if (this.Origin == null)
            {
                // Check if the source field is valid for that player
                if (!this.IsValidOrigin(field, player))
                {
                    return PlayStatus.WaitOriginField;
                }
                else
                {
                    this.Origin = field;
                    this.Origin.ChangeCircleColor();
                    return PlayStatus.WaitDestinyField;
                }
            }

            // If the field is selected twice, it will no longer be considered as the source
            if (this.Origin == field)
            {
                this.Origin.ChangeCircleColor();
                this.Origin = null;
                return PlayStatus.WaitOriginField;
            }

            // If another source field is selected, the old field returns to its initial
            // state and the new one is assigned
            if ((field.FieldPictureBox.Name.Contains('X') && (player.Type == PlayerType.PlayerX)) ||
                (field.FieldPictureBox.Name.Contains('Y') && (player.Type == PlayerType.PlayerY)))
            {
                this.Origin.ChangeCircleColor();
                this.Origin = field;
                this.Origin.ChangeCircleColor();
                return PlayStatus.WaitDestinyField;
            }

            // Check if the destination field is valid for that player
            if (this.IsValidDestiny(field))
            {
                this.Destiny = field;
                this.MovePiece();
                return PlayStatus.Finish;
            }

            // If none of the above conditions are met, the selected field is assigned as the destination
            return PlayStatus.WaitDestinyField;
        }


        /** ************************************************************************
        * \brief Process the piece movement.
        * \details Function responsible for performing the piece movement, i.e., 
        * transferring the piece from the source position to the destination
        * position.
        ***************************************************************************/
        public void MovePiece()
        {
            if (this.Origin.FieldPictureBox.Name.Contains('X') || this.Origin.FieldPictureBox.Name.Contains('Y'))
            {
                this.Origin.FieldPictureBox.Enabled = false;
            }
            Circle circle = this.Origin.PopCircle();
            circle.Color.ChangeColor();
            this.Destiny.AddCircle(circle);
            this.Origin = this.Destiny = null;
        }


        /** ************************************************************************
        * \brief Validate the source field of the move.
        * \details Function that validates if the selected source field is valid 
        * for a certain player.
        * \param field Field selected by the player.
        * \param player Player making the move.
        * \return A boolean value, indicating whether the source field is valid or
        * not.
        ***************************************************************************/
        public bool IsValidOrigin(Field field, Player player)
        {
            // A player can only select initial fields corresponding to their color
            if ((field.FieldPictureBox.Name.Contains('X') && (player.Type == PlayerType.PlayerX)) ||
                (field.FieldPictureBox.Name.Contains('Y') && (player.Type == PlayerType.PlayerY)))
            {
                return true;
            }

            // A player cannot select an initial field that does not contain pieces
            if (field.GetLast() == null)
            {
                return false;
            }

            // A player can only select an initial field that contains a piece of their color
            if (((field.GetLast().Color.Primary == Color.DarkRed) && (player.Type == PlayerType.PlayerX)) ||
                ((field.GetLast().Color.Primary == Color.DarkBlue) && (player.Type == PlayerType.PlayerY)))
            {
                return true;
            }

            // If none of the above conditions are met, the source field is invalid for the move
            return false;
        }


        /** ************************************************************************
        * \brief Validate the destination field of the move.
        * \details Function that validates if the selected destination field is
        * valid.
        * \param field Field selected by the player.
        * \return A boolean value, indicating whether the destination field is valid
        * or not.
        ***************************************************************************/
        public bool IsValidDestiny(Field field)
        {
            // The destination field cannot be an initial field
            if (field.FieldPictureBox.Name.Contains('X') || field.FieldPictureBox.Name.Contains('Y'))
            {
                return false;
            }

            // The destination field can be an empty field
            if (field.GetLast() == null)
            {
                return true;
            }

            // The destination field will only be valid if the piece contained in the
            // source field is larger than the piece present in the destination field
            if (this.Origin.GetLast().CompareTo(field.GetLast()) > 0)
            {
                return true;
            }

            // If none of the above conditions are met, the destination field is
            // invalid for the move
            return false;
        }
    }
}
