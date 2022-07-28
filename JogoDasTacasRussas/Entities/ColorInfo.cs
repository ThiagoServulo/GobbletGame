using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    /** ************************************************************************
    * \brief Informações sobre as cores da peça.
    * \details A classe ColorInfo armazena as informações referentes as cores 
    * que uma determinada peça pode ter, bem como a sua cor atual.
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 17/07/2022
    * \version v1.0
    ***************************************************************************/
    class ColorInfo
    {
        /// \brief Cor primária da peça. 
        public Color Primary { get; private set; }

        /// \brief Cor secundária da peça.
        public Color Secundary { get; private set; }

        /// \brief Tipo atual da cor (primário ou secundário).
        public ColorType TypeCurrent { get; private set; }


        /** ************************************************************************
        * \brief Construtor da classe ColorInfo.
        * \param primary Cor primária da peça. 
        * \param secundary Cor secundária da peça. 
        ***************************************************************************/
        public ColorInfo(Color primary, Color secundary)
        {
            this.Primary = primary;
            this.Secundary = secundary;
            this.TypeCurrent = ColorType.Primary; // A cor primária será a inicial
        }


        /** ************************************************************************
        * \brief Muda cor da peça.
        * \details Função responsável por realizar a troca do tipo de cor atual da 
        * peça.
        ***************************************************************************/
        public void ChangeColor()
        {
            this.TypeCurrent = (this.TypeCurrent == ColorType.Primary) ? ColorType.Secundary : ColorType.Primary;
        }
    }
}
