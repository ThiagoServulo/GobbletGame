using System;
using System.Windows.Forms;
using JogoDasTacasRussas.Entities;

namespace JogoDasTacasRussas
{
    public partial class FormBoard : Form
    {
        Board board;

        /// <summary>
        ///  This is the constructor of the class 'FormBoard'.
        /// </summary>
        public FormBoard()
        {
            InitializeComponent();
        }

        public void StartGame()
        {
            this.board = new Board(new PictureBox[]{
                this.pictureBoxX1,  this.pictureBoxX2,  this.pictureBoxX3,  this.pictureBoxX4,  this.pictureBoxX5,
                this.pictureBoxX6,  this.pictureBoxX7,  this.pictureBoxX8,  this.pictureBoxX9,  this.pictureBoxX10,
                this.pictureBoxX11, this.pictureBoxX12, this.pictureBoxY1,  this.pictureBoxY2,  this.pictureBoxY3,
                this.pictureBoxY4,  this.pictureBoxY5,  this.pictureBoxY6,  this.pictureBoxY7,  this.pictureBoxY8,
                this.pictureBoxY9,  this.pictureBoxY10, this.pictureBoxY11, this.pictureBoxY12, this.pictureBoxA1,
                this.pictureBoxA2,  this.pictureBoxA3,  this.pictureBoxA4,  this.pictureBoxB1,  this.pictureBoxB2,
                this.pictureBoxB3,  this.pictureBoxB4,  this.pictureBoxC1,  this.pictureBoxC2,  this.pictureBoxC3,
                this.pictureBoxC4,  this.pictureBoxD1,  this.pictureBoxD2,  this.pictureBoxD3,  this.pictureBoxD4
            });

            this.labelVitoriasJogadorX.Text = "Vitórias: 0";
            this.labelVitoriasJogadorY.Text = "Vitórias: 0";
        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            try
            {
                int roundQuantity = int.Parse(textBoxRoundQuantity.Text);

                if (((roundQuantity % 2) == 0) || (roundQuantity < 0))
                {
                    throw new FormatException();
                }

                textBoxRoundQuantity.Enabled = false;
                StartGame();
            }
            catch(FormatException)
            {
                MessageBox.Show("Erro: A quantidade de rodadas deve ser um número impar maior que zero");
                textBoxRoundQuantity.Text = "";
                textBoxRoundQuantity.Enabled = true;
            }
        }

        private void PictureBoxX1Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX1);
        }

        private void PictureBoxX2Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX2);
        }

        private void PictureBoxX3Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX3);
        }

        private void PictureBoxX4Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX4);
        }

        private void PictureBoxX5Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX5);
        }

        private void PictureBoxX6Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX6);
        }

        private void PictureBoxX7Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX7);
        }

        private void PictureBoxX8Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX8);
        }

        private void PictureBoxX9Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX9);
        }

        private void PictureBoxX10Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX10);
        }

        private void PictureBoxX11Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX11);
        }

        private void PictureBoxX12Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxX12);
        }

        private void PictureBoxY1Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY1);
        }

        private void PictureBoxY2Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY2);
        }

        private void PictureBoxY3Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY3);
        }

        private void PictureBoxY4Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY4);
        }

        private void PictureBoxY5Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY5);
        }

        private void PictureBoxY6Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY6);
        }

        private void PictureBoxY7Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY7);
        }

        private void PictureBoxY8Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY8);
        }

        private void PictureBoxY9Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY9);
        }

        private void PictureBoxY10Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY10);
        }

        private void PictureBoxY11Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY11);
        }

        private void PictureBoxY12Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxY12);
        }

        private void PictureBoxA1Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxA1);
        }

        private void PictureBoxA2Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxA2);
        }

        private void PictureBoxA3Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxA3);
        }

        private void PictureBoxA4Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxA4);
        }

        private void PictureBoxB1Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxB1);
        }

        private void PictureBoxB2Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxB2);
        }

        private void PictureBoxB3Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxB3);
        }

        private void PictureBoxB4Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxB4);
        }

        private void PictureBoxC1Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxC1);
        }

        private void PictureBoxC2Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxC2);
        }

        private void PictureBoxC3Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxC3);
        }

        private void PictureBoxC4Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxC4);
        }

        private void PictureBoxD1Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxD1);
        }

        private void PictureBoxD2Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxD2);
        }

        private void PictureBoxD3Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxD3);
        }

        private void PictureBoxD4Click(object sender, EventArgs e)
        {
            this.board.Click(this.pictureBoxD4);
        }

        private void BoardMove(object sender, EventArgs e)
        {
            if(this.board != null)
            {
                this.board.UpdateBoard();
            }
        }
    }
}
