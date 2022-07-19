/*******************************************************************************
 * Arquivo: ColorInfo.cs                                                       *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 17/07/2022                                                            *
 *                                                                             *
 * Classe: ColorInfo                                                           *
 * Descrição: A classe 'ColorInfo' armazena as informações referentes as cores *
 *   que uma determinada peça pode ter, bem como a sua cor atual.              *
 * Atributos:                                                                  *
 *   Primary [Color]: Cor primária da peça.                                    *
 *   Secundary [Color]: Cor secundária da peça.                                *
 *   TypeCurrent [ColorType]: Tipo atual da cor (primário ou secundário).      *
 *******************************************************************************/

using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class ColorInfo
    {
        //----------------------------------------------------------------------
        // Atributos
        //----------------------------------------------------------------------
        public Color Primary { get; private set; }
        public Color Secundary { get; private set; }
        public ColorType TypeCurrent { get; private set; }

        //----------------------------------------------------------------------
        // Construtor da classe 'ColorInfo'
        //----------------------------------------------------------------------
        public ColorInfo(Color primary, Color secundary)
        {
            this.Primary = primary;
            this.Secundary = secundary;
            this.TypeCurrent = ColorType.Primary; // A cor primária será a inicial
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por realizar a troca do tipo de cor atual da peça.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void ChangeColor()
        {
            this.TypeCurrent = (this.TypeCurrent == ColorType.Primary) ? ColorType.Secundary : ColorType.Primary;
        }
    }
}
