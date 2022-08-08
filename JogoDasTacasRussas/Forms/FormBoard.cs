using System;
using System.Windows.Forms;
using JogoDasTacasRussas.Entities;

namespace JogoDasTacasRussas
{
    /** ************************************************************************
    * \brief Informações a tela onde o tabuleiro será apresentada.
    * \details A classe FormBoard armazena as informações referentes a tela onde
    * o tabuleiro do jogo será apresentado.
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 31/07/2022
    * \version v1.0.0
    ***************************************************************************/
    public partial class FormBoard : Form
    {
        /// \brief Tabuleiro do jogo.
        Board BoardGame;

        /// \brief Campos que o tabuleiro apresenta.
        PictureBox[] PictureBoxes;


        /** ************************************************************************
        * \brief Construtor da classe FormBoard.
        ***************************************************************************/
        public FormBoard()
        {
            // Inicializa os componentes
            this.InitializeComponent();

            // Preenche o array de picture boxes
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

            // Inicializa o tabuleiro
            this.InitFormBoard();
        }


        /** ************************************************************************
        * \brief Inicializa a tela do tabuleiro.
        * \details Função responsável por inicializar a tela onde o tabuleiro será
        * apresentada, resetando os \a labels e colocando as devidas permissões 
        * iniciais.
        ***************************************************************************/
        public void InitFormBoard()
        {
            // Iniciar contador de vitórias
            this.labelVitoriasJogadorX.Text = "Vitórias: 0";
            this.labelVitoriasJogadorY.Text = "Vitórias: 0";

            // Iniciar caixa de texto 
            this.textBoxRoundQuantity.Text = "";
            this.textBoxRoundQuantity.Enabled = true;

            // Habilitar botão de start
            this.buttonStart.Enabled = true;

            // Bloquear campos do jogo
            foreach (PictureBox pictureBox in this.PictureBoxes)
            {
                pictureBox.Enabled = false;
            }
        }


        /** ************************************************************************
        * \brief Inicia o jogo.
        * \details Função responsável por inicializar o jogo, habilitando os campos
        * e inicializando o tabuleiro.
        * \param roundQuantity Quantidade de rodadas que o jogo irá conter.
        ***************************************************************************/
        public void StartGame(int roundQuantity)
        {
            // Inicializa o tabuleiro
            this.BoardGame = new Board(this.PictureBoxes, roundQuantity, 
                this.labelVitoriasJogadorX, this.labelVitoriasJogadorY);

            // Habilita os campos do tabuleiro
            foreach(PictureBox pictureBox in this.PictureBoxes)
            {
                pictureBox.Enabled = true;
            }
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no botão \a start.
        * \details Função responsável por processar a interrupção de \a click no 
        * botão \a start.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        * \exception FormatException Excessão lançada quando a quantidade de rodadas
        * informada pelo usuário não é um número inteiro ímpar maior que zero.
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
                MessageBox.Show("Erro: A quantidade de rodadas deve ser um número impar maior que zero");
                this.InitFormBoard();
            }
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click em um \a pictureBox.
        * \details Função responsável por processar a interrupção de \a click em um 
        * \a pictureBox.
        * \param pictureBox Campo que foi clicado pelo usuário
        ***************************************************************************/
        public void ClickField(PictureBox pictureBox)
        {
            if(this.BoardGame.Click(pictureBox))
            {
                // Caso a partida tenha terminado, o tabuleiro é reinicializado
                InitFormBoard();
            }
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X1.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X1.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX1);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X2.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X2.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX2);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X3.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X3.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX3);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X4.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X4.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX4);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X5.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X5.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX5Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX5);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X6.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X6.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX6Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX6);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X7.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X7.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX7Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX7);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X8.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X8.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX8Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX8);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X9.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X9.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX9Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX9);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X10.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X10.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX10Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX10);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X11.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X11.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX11Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX11);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo X12.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo X12.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxX12Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxX12);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y1.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y1.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY1);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y2.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y2.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY2);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y3.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y3.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY3);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y4.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y4.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY4);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y5.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y5.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY5Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY5);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y6.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y6.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY6Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY6);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y7.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y7.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY7Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY7);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y8.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y8.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY8Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY8);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y9.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y9.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY9Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY9);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y10.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y10.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY10Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY10);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y11.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y11.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY11Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY11);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo Y12.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo Y12.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxY12Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxY12);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo A1.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo A1.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxA1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA1);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo A2.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo A2.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxA2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA2);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo A3.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo A3.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxA3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA3);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo A4.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo A4.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxA4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxA4);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo B1.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo B1.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxB1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB1);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo B2.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo B2.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxB2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB2);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo B3.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo B3.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxB3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB3);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo B4.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo B4.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxB4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxB4);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo C1.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo C1.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxC1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC1);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo C2.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo C2.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxC2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC2);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo C3.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo C3.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxC3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC3);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo C4.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo C4.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxC4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxC4);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo D1.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo D1.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxD1Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD1);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo D2.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo D2.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxD2Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD2);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo D3.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo D3.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxD3Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD3);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de \a click no campo D4.
        * \details Função responsável por processar a interrupção de \a click no 
        * no campo D4.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void PictureBoxD4Click(object sender, EventArgs e)
        {
            this.ClickField(this.pictureBoxD4);
        }


        /** ************************************************************************
        * \brief Processa a interrupção de movimentação do tabuleiro.
        * \details Função responsável por desenhar todo o tabuleiro com as peças em 
        * suas respectivas posições sempre que o tabuleiro é movido.
        * \param sender Objeto que possui as propiedades do próprio elemento que 
        * disparou o evento.
        * \param e Argumentos específicos deste evento.
        ***************************************************************************/
        private void BoardMove(object sender, EventArgs e)
        {
            // Checa se o tabuleiro existe
            if(this.BoardGame != null)
            {
                this.BoardGame.UpdateBoard();
            }
        }
    }
}
