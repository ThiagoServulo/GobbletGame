using System;
using System.Drawing;
using GobbletGame.Entities.Enums;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Information about player pieces.
    * \details The Circle class stores information about the pieces that can be
    * moved by the players. These pieces are in the shape of circles and can
    * have four different sizes.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    class Circle : IComparable
    {
        /// \brief Initial position on the X-axis of the square in which the circle will be inscribed.
        public int X { get; private set; }

        /// \brief Initial position on the Y-axis of the square in which the circle will be inscribed.
        public int Y { get; private set; }

        /// \brief Width of the square in which the circle will be inscribed.
        public int Width { get; private set; }

        /// \brief Height of the square in which the circle will be inscribed.
        public int Height { get; private set; }

        /// \brief Class with information about the circle's colors.
        public ColorInfo Color { get; private set; }

        /// \brief Circle type.
        public CircleType Type { get; private set; }


        /** ************************************************************************
        * \brief Constructor of the Circle class.
        * \param primaryColor Primary color of the instantiated circle.
        * \param secondaryColor Secondary color of the instantiated circle.
        * \param type Type of the instantiated circle.
        * \exception Exception Exception thrown if the circle type is invalid.
        ***************************************************************************/
        public Circle(Color primaryColor, Color secundaryColor, CircleType type)
        {
            this.Color = new ColorInfo(primaryColor, secundaryColor);
            this.Type = type;

            // Define the dimensions of the circle, based on its type
            this.X = this.Type switch
            {
                CircleType.Type4 => this.Y = 3,
                CircleType.Type3 => this.Y = 13,
                CircleType.Type2 => this.Y = 22,
                CircleType.Type1 => this.Y = 30,
                _ => throw new Exception("Invalid circle type"),
            };
            this.Width = this.Height = 80 - (this.X * 2);
        }


        /** ************************************************************************
        * \brief Compares two circles.
        * \details Function responsible for comparing two circles.
        * \param obj Circle with which the comparison will be performed.
        * \return Integer value n, where:\n
        * n > 0 : If the current circle is greater than the tested one.\n
        * n = 0 : If the current circle is equal to the tested one.\n
        * n < 0 : If the current circle is smaller than the tested one.
        ***************************************************************************/
        public int CompareTo(object obj)
        {
            // If the obj is null, the comparison does not need to be done,
            // as the tested circle is larger
            if (obj == null)
            {
                return 1;
            }

            // Perform downcasting
            Circle other = obj as Circle;  
            return this.Type.CompareTo(other.Type);
        }


        /** ************************************************************************
        * \brief Checks if two circles are equal.
        * \details Overridden function responsible for checking if two circles are 
        * equal.
        * \param obj Circle with which the comparison will be performed.
        * \return A boolean value, indicating whether the two compared objects are 
        * equal or not.
        ***************************************************************************/
        public override bool Equals(object obj)
        {
            if (!(obj is Circle) || (obj == null))
            {
                return false;
            }

            // Perform downcasting
            Circle other = obj as Circle;  
            return this.Color.Primary == other.Color.Primary;
        }


        /** ************************************************************************
        * \brief Returns the hash code for the circle.
        * \details Overridden function responsible for generating a hash code for a
        * circle.
        * \return An integer value, which is the key associated with the object.
        ***************************************************************************/
        public override int GetHashCode()
        {
            return this.Color.Primary.GetHashCode();
        }
    }
}
