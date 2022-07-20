/*******************************************************************************
 * Arquivo: Circle.cs                                                          *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 15/07/2022                                                            *
 *                                                                             *
 * Classe: Circle                                                              *
 * Descrição: A classe 'Circle' armazena as informações referentes as peças    *
 *   que podem ser movimentadas pelos jogadores. Estas peças tem formato de    *
 *   círculos e podem ter 4 tamanhos diferentes.                               *
 * Atributos:                                                                  *
 *   X [int]: Posição inicial no eixo X do quadrado que círculo será inscrito. *
 *   Y [int]: Posição inicial no eixo Y do quadrado que círculo será inscrito. *
 *   Width [int]: Largura do quadrado que círculo será inscrito.               *
 *   Height [int]: Altura do quadrado que círculo será inscrito.               *
 *   Color [ColorInfo]: Classe com as informações sobre as cores do círculo.   *
 *   Type [CircleType]: Tipo do círculo.                                       *
 *******************************************************************************/

using System;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Circle: IComparable
    {
        //----------------------------------------------------------------------
        // Atributos
        //----------------------------------------------------------------------
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public ColorInfo Color { get; private set; }
        public CircleType Type { get; private set; }

        //----------------------------------------------------------------------
        // Construtor da classe 'Circle'
        //----------------------------------------------------------------------
        public Circle(Color primaryColor, Color secundaryColor, CircleType type)
        {
            this.Color = new ColorInfo(primaryColor, secundaryColor);
            this.Type = type;

            // Define as dimensões do círculo, com base no seu tipo
            switch (this.Type)
            {
                case CircleType.Type4:
                    this.X = this.Y = 3;
                break;

                case CircleType.Type3:
                    this.X = this.Y = 13;
                break;

                case CircleType.Type2:
                    this.X = this.Y = 22;
                break;

                case CircleType.Type1:
                    this.X = this.Y = 30;
                break;

                default:
                    throw new Exception("Tipo de círculo inválido");
            }

            this.Width = this.Height = 80 - (this.X * 2);
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por comparar dois objetos instanciados a partir
        //    da classe 'Circle'.
        // Parâmetros:
        //    obj [object]: Círculo com o qual será realizado a comparação.
        // Retorno:
        //    Valor do tipo inteiro 'n', sendo:
        //      n > 0 : Se o círculo atual for maior que o testado.
        //      n = 0 : Se o círculo atual for igual que o testado.
        //      n < 0 : Se o círculo atual for menor que o testado.
        //----------------------------------------------------------------------
        public int CompareTo(object obj)
        {
            // Se o obj for null a comparação não precisa ser feita, pois o círculo testado é maior
            if(obj == null)
            {
                return 1;
            }

            Circle other = obj as Circle;  // Downcasting
            return this.Type.CompareTo(other.Type);
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função sobrescrita responsável por comprar dois objetos do tipo
        //    'Circle'.
        // Parâmetros:
        //    obj [object]: Objeto do tipo 'Circle' que será comparado.
        // Retorno:
        //    Um valor do tipo 'bool', inicando se os dois objetos comparados
        //    são iguais ou não.
        //----------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (!(obj is Circle) || (obj == null))
            {
                return false;
            }

            Circle other = obj as Circle;  // Downcasting
            return this.Color.Primary == other.Color.Primary;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função sobrescrita responsável por gerar uma hash referente a este
        //    objeto.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Um valor do tipo 'int', que consiste na chave referente ao objeto.
        //----------------------------------------------------------------------
        public override int GetHashCode()
        {
            return this.Color.Primary.GetHashCode();
        }
    }
}
