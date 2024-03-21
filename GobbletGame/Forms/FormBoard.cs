using System;
using System.Windows.Forms;
using GobbletGame.Entities;

namespace GobbletGame
{
    /** ************************************************************************
    * \brief Information about the screen where the game board will be presented.
    * \details The FormBoard class stores information about the screen where 
    * the game board will be presented.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    public partial class FormBoard : Form
    {
        /// \brief Game board.
        Board BoardGame;

        /// \brief Fields presented on the game board.
        PictureBox[] PictureBoxes;


        /** ************************************************************************
        * \brief Constructor of the FormBoard class.
        ***************************************************************************/
        public FormBoard()
        {
            // Initialize the components
            this.InitializeComponent();

            // Fill the array of picture boxes
            this.PictureBoxes = new PictureBox[]{
                this.pictureBoxX1,  this.pictureBoxX2,  this.pictureBoxX3,  this.pictureBoxX4,  this.pictureBoxX5,
                this.pictureBoxX6,  this.pictureBoxX7,  this.pictureBoxX8,  this.pictureBoxX9,  this.pictureBoxX10,
                this.pictureBoxX11, this.pictureBoxX12, this.pictureBoxY1,  this.pictureBoxY2,  this.pictureBoxY3,
                this.pictureBoxY4,  this.pictureBoxY5,  this.pictureBoxY6,  this.pictureBoxY7,  this.pictureBoxY8,
                this.pictureBoxY9,  this.pictureBoxY10, this.pictureBoxY11, this.pictureBoxY12, this.pictureBoxA1,
                this.pictureBoxA2,  this.pictureBoxA3,  this.pictureBoxA4,  this.pictureBoxB1,  this.pictureBoxB2,
                this.pictureBoxB3,  this.pictureBoxB4,  this.pictureBoxC1,  this.pictureBoxC2,  this.pictureBoxC3,
                this.pictureBoxC4,  this.pictureBoxD1,  this.pictureBoxD2,  this.pictureBoxD3,  this.pictureBoxD4
            };

            // Initialize the game board
            this.InitFormBoard();
        }


        /** ************************************************************************
        * \brief Initialize the game board screen.
        * \details Function responsible for initializing the screen where the game
        * board will be presented, resetting the \a labels and setting the
        * appropriate initial permissions.
        ***************************************************************************/
        public void InitFormBoard()
        {
            // Start the win counter
            this.labelVictoriesPlayerX.Text = "Victories: 0";
            this.labelVictoriesPlayerY.Text = "Victories: 0";

            // Start the text box
            this.textBoxRoundQuantity.Text = "";
            this.textBoxRoundQuantity.Enabled = true;

            // Enable the start button
            this.buttonStart.Enabled = true;

            // Lock game fields
            foreach (PictureBox pictureBox in this.PictureBoxes)
            {
                pictureBox.Enabled = false;
            }
        }


        /** ************************************************************************
        * \brief Start the game.
        * \details Function responsible for starting the game, enabling the fields
        * and initializing the board.
        * \param roundQuantity Number of rounds that the game will have.
        ***************************************************************************/
        public void StartGame(int roundQuantity)
        {
            // Initialize the game board
            this.BoardGame = new Board(this.PictureBoxes, roundQuantity, 
                this.labelVictoriesPlayerX, this.labelVictoriesPlayerY);

            // Enable the fields on the game board
            foreach (PictureBox pictureBox in this.PictureBoxes)
            {
                pictureBox.Enabled = true;
            }
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the \a start button.
        * \details Function responsible for processing the click interrupt on the 
        * \a start button.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        * \exception FormatException Exception thrown when the number of rounds 
        * provided by the user is not a positive odd integer.
        ***************************************************************************/
        private void ButtonStartClick(object sender, EventArgs e)
        {
            try
            {
                int roundQuantity = int.Parse(this.textBoxRoundQuantity.Text);

                if (((roundQuantity % 2) == 0) || (roundQuantity < 0))
                {
                    throw new FormatException();
                }

                this.textBoxRoundQuantity.Enabled = false;
                this.buttonStart.Enabled = false;
                this.StartGame(roundQuantity);
            }
            catch(FormatException)
            {
                MessageBox.Show("Error: The number of rounds must be a positive odd integer.");
                this.InitFormBoard();
            }
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on a \a pictureBox.
        * \details Function responsible for processing the click interrupt on a \a
        * pictureBox.
        * \param pictureBox Field that was clicked by the user.
        ***************************************************************************/
        public void ClickField(PictureBox pictureBox)
        {
            if(this.BoardGame.Click(pictureBox))
            {
                // If the game has ended, the board is reset
                InitFormBoard();
            }
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X1 field.
        * \details Function responsible for processing the click interrupt on the 
        * X1 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX1);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X2 field.
        * \details Function responsible for processing the click interrupt on the 
        * X2 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX2);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X3 field.
        * \details Function responsible for processing the click interrupt on the 
        * X3 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX3);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X4 field.
        * \details Function responsible for processing the click interrupt on the 
        * X4 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX4);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X5 field.
        * \details Function responsible for processing the click interrupt on the 
        * X5 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX5Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX5);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X6 field.
        * \details Function responsible for processing the click interrupt on the 
        * X6 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX6Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX6);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X7 field.
        * \details Function responsible for processing the click interrupt on the 
        * X7 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX7Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX7);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X8 field.
        * \details Function responsible for processing the click interrupt on the 
        * X8 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX8Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX8);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X9 field.
        * \details Function responsible for processing the click interrupt on the 
        * X9 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX9Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX9);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X10 field.
        * \details Function responsible for processing the click interrupt on the 
        * X10 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX10Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX10);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X11 field.
        * \details Function responsible for processing the click interrupt on the 
        * X11 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX11Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX11);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the X12 field.
        * \details Function responsible for processing the click interrupt on the 
        * X12 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxX12Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX12);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y1 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y1 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY1);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y2 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y2 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY2);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y3 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y3 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY3);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y4 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y4 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY4);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y5 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y5 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY5Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY5);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y6 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y6 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY6Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY6);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y7 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y7 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY7Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY7);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y8 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y8 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY8Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY8);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y9 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y9 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY9Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY9);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y10 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y10 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY10Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY10);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y11 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y11 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY11Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY11);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the Y12 field.
        * \details Function responsible for processing the click interrupt on the 
        * Y12 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxY12Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY12);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the A1 field.
        * \details Function responsible for processing the click interrupt on the 
        * A1 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxA1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA1);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the A2 field.
        * \details Function responsible for processing the click interrupt on the 
        * A2 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxA2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA2);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the A3 field.
        * \details Function responsible for processing the click interrupt on the 
        * A3 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxA3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA3);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the A4 field.
        * \details Function responsible for processing the click interrupt on the 
        * A4 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxA4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA4);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the B1 field.
        * \details Function responsible for processing the click interrupt on the 
        * B1 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxB1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB1);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the B2 field.
        * \details Function responsible for processing the click interrupt on the 
        * B2 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxB2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB2);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the B3 field.
        * \details Function responsible for processing the click interrupt on the 
        * B3 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxB3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB3);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the B4 field.
        * \details Function responsible for processing the click interrupt on the 
        * B4 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxB4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB4);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the C1 field.
        * \details Function responsible for processing the click interrupt on the 
        * C1 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxC1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC1);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the C2 field.
        * \details Function responsible for processing the click interrupt on the 
        * C2 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxC2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC2);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the C3 field.
        * \details Function responsible for processing the click interrupt on the 
        * C3 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxC3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC3);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the C4 field.
        * \details Function responsible for processing the click interrupt on the 
        * C4 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxC4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC4);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the D1 field.
        * \details Function responsible for processing the click interrupt on the 
        * D1 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxD1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD1);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the D2 field.
        * \details Function responsible for processing the click interrupt on the 
        * D2 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxD2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD2);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the D3 field.
        * \details Function responsible for processing the click interrupt on the 
        * D3 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxD3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD3);
        }


        /** ************************************************************************
        * \brief Processes the click interrupt on the D4 field.
        * \details Function responsible for processing the click interrupt on the 
        * D4 field.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void PictureBoxD4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD4);
        }


        /** ************************************************************************
        * \brief Processes the interrupt of the board movement.
        * \details Function responsible for drawing the entire board with the pieces 
        * in their respective positions whenever the board is moved.
        * \param sender Object that holds properties of the element itself that 
        * fired the event.
        * \param e Specific arguments of this event.
        ***************************************************************************/
        private void BoardMove(object sender, EventArgs e)
        {
            // Check if the board exists
            if (this.BoardGame != null)
            {
                this.BoardGame.UpdateBoard();
            }
        }
    }
}
