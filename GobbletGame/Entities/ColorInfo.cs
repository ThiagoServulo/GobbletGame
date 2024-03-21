using System.Drawing;
using GobbletGame.Entities.Enums;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Information about piece colors.
    * \details The ColorInfo class stores information about the colors that a 
    * particular piece can have, as well as its current color.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    class ColorInfo
    {
        /// \brief Primary color of the piece.
        public Color Primary { get; private set; }

        /// \brief Secundary color of the piece.
        public Color Secundary { get; private set; }

        /// \brief Current type of color (primary or secondary).
        public ColorType TypeCurrent { get; private set; }


        /** ************************************************************************
        * \brief Constructor of the ColorInfo class.
        * \param primary Primary color of the piece.
        * \param secondary Secondary color of the piece.
        ***************************************************************************/
        public ColorInfo(Color primary, Color secundary)
        {
            this.Primary = primary;
            this.Secundary = secundary;

            // The primary color will be the initial one
            this.TypeCurrent = ColorType.Primary;
        }


        /** ************************************************************************
        * \brief Changes the piece's color.
        * \details Function responsible for changing the current color type of the
        * piece.
        ***************************************************************************/
        public void ChangeColor()
        {
            this.TypeCurrent = (this.TypeCurrent == ColorType.Primary) ? 
                ColorType.Secundary : 
                ColorType.Primary;
        }
    }
}
