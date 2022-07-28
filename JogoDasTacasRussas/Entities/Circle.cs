using System;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    /** ************************************************************************
    * \brief Informações sobre as peças dos jogadores.
    * \details A classe Circle armazena as informações referentes as peças que 
    * podem ser movimentadas pelos jogadores. Estas peças tem formato de círculos 
    * e podem ter quatro tamanhos diferentes.
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 15/07/2022
    * \version v1.0
    ***************************************************************************/
    class Circle : IComparable
    {
        /// \brief Posição inicial no eixo X do quadrado que círculo será inscrito.
        public int X { get; private set; }

        /// \brief Posição inicial no eixo Y do quadrado que círculo será inscrito.
        public int Y { get; private set; }

        /// \brief Largura do quadrado que círculo será inscrito.
        public int Width { get; private set; }

        /// \brief Altura do quadrado que círculo será inscrito.
        public int Height { get; private set; }

        /// \brief Classe com as informações sobre as cores do círculo.
        public ColorInfo Color { get; private set; }

        /// \brief Tipo do círculo.
        public CircleType Type { get; private set; }


        /** ************************************************************************
        * \brief Construtor da classe Circle.
        * \param primaryColor Cor primária do círculo instanciado.
        * \param secundaryColor Cor secundária do círculo instanciado.
        * \param type Tipo do círculo instanciado.
        * \exception Exception Exceção caso o tipo de círculo seja inválido.
        ***************************************************************************/
        public Circle(Color primaryColor, Color secundaryColor, CircleType type)
        {
            this.Color = new ColorInfo(primaryColor, secundaryColor);
            this.Type = type;

            // Define as dimensões do círculo, com base no seu tipo
            this.X = this.Type switch
            {
                CircleType.Type4 => this.Y = 3,
                CircleType.Type3 => this.Y = 13,
                CircleType.Type2 => this.Y = 22,
                CircleType.Type1 => this.Y = 30,
                _ => throw new Exception("Tipo de círculo inválido"),
            };
            this.Width = this.Height = 80 - (this.X * 2);
        }


        /** ************************************************************************
        * \brief Compara dos círculos.
        * \details Função responsável por comparar dois círculos.
        * \param obj Círculo com o qual será realizado a comparação.
        * \return  Valor do tipo inteiro n, sendo:\n
        * n > 0 : Se o círculo atual for maior que o testado.\n
        * n = 0 : Se o círculo atual for igual que o testado.\n
        * n < 0 : Se o círculo atual for menor que o testado.
        ***************************************************************************/
        public int CompareTo(object obj)
        {
            // Se o obj for null a comparação não precisa ser feita, pois o círculo testado é maior
            if(obj == null)
            {
                return 1;
            }

            // Realizar downcasting
            Circle other = obj as Circle;  
            return this.Type.CompareTo(other.Type);
        }


        /** ************************************************************************
        * \brief Verifica se dois círculos são iguais.
        * \details Função sobrescrita responsável por verificar se dois círculos são 
        * iguais.
        * \param obj Círculo com o qual será realizado a comparação.
        * \return Um valor do tipo booleano, inicando se os dois objetos comparados
        * são iguais ou não.
        ***************************************************************************/
        public override bool Equals(object obj)
        {
            if (!(obj is Circle) || (obj == null))
            {
                return false;
            }

            // Realizar o downcasting
            Circle other = obj as Circle;  
            return this.Color.Primary == other.Color.Primary;
        }


        /** ************************************************************************
        * \brief Retorna a hash referente ao círculo.
        * \details Função sobrescrita responsável por gerar uma hash referente a um
        * círculo.
        * \return Um valor do tipo inteiro, que consiste na chave referente ao 
        * objeto.
        ***************************************************************************/
        public override int GetHashCode()
        {
            return this.Color.Primary.GetHashCode();
        }
    }
}
