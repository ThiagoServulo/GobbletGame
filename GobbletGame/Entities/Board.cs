using System.Drawing;
using System.Windows.Forms;
using GobbletGame.Entities.Enums;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Information about the board.
    * \details The Board class stores information regarding the game board,
    * where the pieces will be placed.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    class Board
    {
        /// \brief Information about the current play.
        public Move PlayerMove { get; private set; }

        /// \brief List containing the initial fields of player X.
        public Field[] InitFieldsPlayerX { get; private set; } = new Field[12];

        /// \brief List containing the initial fields of player Y.
        public Field[] InitFieldsPlayerY { get; private set; } = new Field[12];

        /// \brief List containing the common board fields for the players.
        public Field[] FieldsBoard { get; private set; } = new Field[16];

        /// \brief List containing all the fields of the board.
        public Field[][] AllFields { get; private set; }

        /// \brief Information related to player X.
        public Player PlayerX { get; private set; }

        /// \brief Information related to player Y.
        public Player PlayerY { get; private set; }

        /// \brief Information related to the current player.
        public Player CurrentPlayer { get; private set; }

        /// \brief List containing the \a pictureBoxes of the board.
        public PictureBox[] PictureBoxes { get; private set; }

        /// \brief Number of rounds the game will have.
        public int RoundQuantity { get; private set; }

        /// \brief Number of the current round.
        public int CurrentRound { get; private set; }


        /** ************************************************************************
        * \brief Constructor of the Board class.
        * \param pictureBoxes List containing the \a pictureBoxes of the board.
        * \param labelPlayerX \a label that displays the number of victories of
        * player X.
        * \param labelPlayerY \a label that displays the number of victories of
        * player Y.
        ***************************************************************************/
        public Board(PictureBox[] pictureBoxes, int roundQuantity, Label labelPlayerX, Label labelPlayerY)
        {
            // Initialize the first round
            this.CurrentRound = 1;

            // Save the number of rounds
            this.RoundQuantity = roundQuantity;

            // Store the pictureBoxes of the board
            this.PictureBoxes = pictureBoxes;

            // Board initialization
            this.InitBoard();

            // Players initialization
            this.PlayerX = new Player(PlayerType.PlayerX, labelPlayerX);
            this.PlayerY = new Player(PlayerType.PlayerY, labelPlayerY);
            this.CurrentPlayer = this.PlayerX;
        }


        /** ************************************************************************
        * \brief Initialize the board.
        * \details Function responsible for initializing the game board.
        ***************************************************************************/
        public void InitBoard()
        {
            // Movement initialization
            this.PlayerMove = new Move();
            
            int indexFieldsPlayerX = 0;
            int indexFieldsPlayerY = 0;
            int indexFieldsBoard = 0;

            for (int i = 0; i < this.PictureBoxes.Length; i++)
            {
                if (this.PictureBoxes[i].Name.Contains('X'))
                {
                    // Grouping of initial fields for Player X
                    this.InitFieldsPlayerX[indexFieldsPlayerX] = new Field(PictureBoxes[i]);
                    indexFieldsPlayerX += 1;
                }
                else if (this.PictureBoxes[i].Name.Contains('Y'))
                {
                    // Grouping of initial fields for Player Y
                    this.InitFieldsPlayerY[indexFieldsPlayerY] = new Field(PictureBoxes[i]);
                    ++indexFieldsPlayerY;
                }
                else
                {
                    // Grouping of fields on the board common to both players
                    this.FieldsBoard[indexFieldsBoard] = new Field(PictureBoxes[i]);
                    ++indexFieldsBoard;
                }
            }

            // Initialization of pieces for Player X
            this.InitFields(this.InitFieldsPlayerX, Color.DarkRed, Color.IndianRed);

            // Initialization of pieces for Player Y
            this.InitFields(this.InitFieldsPlayerY, Color.DarkBlue, Color.LightBlue);

            // Board initialization
            this.InitFields(this.FieldsBoard, null, null);

            // Concatenation of all fields on the board
            this.AllFields = new Field[][] { this.FieldsBoard, this.InitFieldsPlayerY, this.InitFieldsPlayerX };
        }


        /** ************************************************************************
        * \brief Initialize the fields.
        * \details Function responsible for initializing the fields on the board,
        * adding pieces or leaving them empty.
        * \param fields List containing the fields to be initialized.
        * \param primaryColor Primary color of the possible added piece.
        * \param secondaryColor Secondary color of the possible added piece.
        ***************************************************************************/
        public void InitFields(Field[] fields, Color? primaryColor, Color? secundaryColor)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                // Enable the field to be selected
                fields[i].FieldPictureBox.Enabled = true;

                if (primaryColor == null || secundaryColor == null) // If the colors are null, the field will be cleared
                {
                    fields[i].DrawCircle(null);
                }
                else if (i < 3) // Add the smallest existing circle
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type1));
                }
                else if (i < 6) // Add the second smallest existing circle
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type2));
                }
                else if (i < 9) // Add the second largest existing circle
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type3));
                }
                else // Add the largest existing circle
                {
                    fields[i].AddCircle(new Circle((Color)primaryColor, (Color)secundaryColor, CircleType.Type4));
                }
            }
        }


        /** ************************************************************************
        * \brief Processes the click event on a \a pictureBox.
        * \details Function responsible for processing the user interruption when
        * clicking on a specific \a pictureBox.
        * \param pictureBox \a pictureBox clicked by the user.
        * \return Boolean value indicating whether the game has ended or not.
        ***************************************************************************/
        public bool Click(PictureBox pictureBox)
        {
            Field field = this.GetField(pictureBox);

            // If the move has been completed, it will switch to the next player
            if (this.PlayerMove.Play(field, this.CurrentPlayer) == PlayStatus.Finish)
            {
                Player playerWinner = this.CheckWinner();
                if (playerWinner != null)
                {
                    playerWinner.AddVictory();
                    string namePlayer = this.UpdateLabelPlayer(playerWinner);
                    this.ShowMessageBoxWinner(namePlayer);
                    this.InitBoard();
                    this.CurrentRound += 1;
                    if (this.CurrentRound > this.RoundQuantity)
                    {
                        if (MessageBox.Show($"Victory of {namePlayer}!\nDo you want to play another match?", 
                            "End of game!", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            // Terminate the application.
                            Application.Exit();
                        }
                        return true;
                    }
                }
                this.ChangeCurrentPlayer();
            }

            return false;
        }


        /** ************************************************************************
        * \brief Update the player's victory \a label.
        * \details Function responsible for updating the player's victory \a label.
        * \param playerWinner Player who won the round.
        * \return Value of type \a string containing the name of the winner.
        ***************************************************************************/
        public string UpdateLabelPlayer(Player playerWinner)
        {
            if(playerWinner == PlayerX)
            {
                this.PlayerX.LabelVictories.Text = $"Victories: {this.PlayerX.Victories}";
                return "Player 1";
            }
            else
            {
                this.PlayerY.LabelVictories.Text = $"Victories: {this.PlayerY.Victories}";
                return "Player 2";
            }
        }


        /** ************************************************************************
        * \brief Displays the winner of the round.
        * \details Function responsible for showing the player who won the current
        * round in a \a MessageBox.
        * \param namePlayer Name of the player who won the round.
        ***************************************************************************/
        public void ShowMessageBoxWinner(string namePlayer)
        {
            MessageBox.Show($"Victory of {namePlayer}");
        }


        /** ************************************************************************
        * \brief Identifies a field.
        * \details Function responsible for converting a \a pictureBox into a known
        * field.
        * \param pictureBox \a pictureBox clicked by the user.
        * \return Value of type Field, which contains the field information
        * related to the provided \a pictureBox.
        ***************************************************************************/
        public Field GetField(PictureBox pictureBox)
        {
            foreach(Field[] listFields in this.AllFields)
            {
                foreach (Field field in listFields)
                {
                    if (field.FieldPictureBox == pictureBox)
                    {
                        return field;
                    }
                }
            }
            return null;
        }


        /** ************************************************************************
        * \brief Switches the current player.
        * \details Function responsible for performing the switch of the current
        * player.
        ***************************************************************************/
        public void ChangeCurrentPlayer()
        {
            this.CurrentPlayer = (this.CurrentPlayer.Type == PlayerType.PlayerX) ? this.PlayerY : this.PlayerX;
        }


        /** ************************************************************************
        * \brief Checks for a winner.
        * \details Function responsible for checking if there is a winner in the
        * match.
        * \return Value of type Player, indicating the winner of the current match.
        * If there is no winner, it returns \a null.
        ***************************************************************************/
        public Player CheckWinner()
        {
            // Check columns
            for(int i = 0; i <= 12; i+=4)
            {
                if (this.FieldsBoard[i].Equals(this.FieldsBoard[i + 1]) && 
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 2]) && 
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 3]))
                {
                    return this.CheckPlayer(this.FieldsBoard[i]);
                }
            }

            // Check rows
            for (int i = 0; i <= 4; i++)
            {
                if (this.FieldsBoard[i].Equals(this.FieldsBoard[i + 4]) &&
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 8]) &&
                    this.FieldsBoard[i].Equals(this.FieldsBoard[i + 12]))
                {
                    return this.CheckPlayer(this.FieldsBoard[i]);
                }
            }

            // Check main diagonal
            if (this.FieldsBoard[0].Equals(this.FieldsBoard[5]) &&
                this.FieldsBoard[0].Equals(this.FieldsBoard[10]) &&
                this.FieldsBoard[0].Equals(this.FieldsBoard[15]))
            {
                return this.CheckPlayer(this.FieldsBoard[0]);
            }

            // Check secondary diagonal
            if (this.FieldsBoard[3].Equals(this.FieldsBoard[6]) &&
                this.FieldsBoard[3].Equals(this.FieldsBoard[9]) &&
                this.FieldsBoard[3].Equals(this.FieldsBoard[12]))
            {
                return this.CheckPlayer(this.FieldsBoard[3]);
            }

            // Returns null if there is no winner
            return null;
        }


        /** ************************************************************************
        * \brief Checks the player who owns the piece.
        * \details Function responsible for checking which player owns the piece
        * located in the provided field.
        * \param field Field to be analyzed.
        * \return Value of type Player, indicating the player who owns the piece in 
        * the field.
        ***************************************************************************/
        public Player CheckPlayer(Field field)
        {
            // Get the color of the circle present in the field
            Color circleColor = field.GetLast().Color.Primary;

            // See the player who owns this piece
            if (circleColor == Color.DarkRed)
            {
                return this.PlayerX;
            }
            else if (circleColor == Color.DarkBlue)
            {
                return this.PlayerY;
            }

            // Return null if the player is not found
            return null;
        }


        /** ************************************************************************
        * \brief Update the board.
        * \details Function responsible for updating the board, placing the pieces 
        * back in their respective positions.
        ***************************************************************************/
        public void UpdateBoard()
        {
            foreach (Field[] listFields in this.AllFields)
            {
                foreach (Field field in listFields)
                {
                    field.DrawCircle(field.GetLast());
                }
            }
        }
    }
}
