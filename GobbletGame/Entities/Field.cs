using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using GobbletGame.Entities.Enums;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Information about the field.
    * \details The Field class stores information about the fields that the
    * board will contain.
    * \author Thiago Sérvulo Guimarães - thiagoservulog@gmail.com
    * \date 21/03/2024
    * \version v1.0.1
    ***************************************************************************/
    class Field
    {
        /// \brief \a pictureBox related to this field.
        public PictureBox FieldPictureBox { get; private set; }

        /// \brief Stack that receives the circles added to this field.
        public Stack<Circle> StackCircles { get; private set; }


        /** ************************************************************************
        * \brief Constructor of the Field class.
        * \param pictureBox \a pictureBox related to this field.
        ***************************************************************************/
        public Field(PictureBox pictureBox)
        {
            this.FieldPictureBox = pictureBox;
            this.StackCircles = new Stack<Circle>();
            this.StackCircles.Clear();
        }


        /** ************************************************************************
        * \brief Adds a circle to the field.
        * \details Function responsible for adding a circle to the top of the stack
        * related to this field.
        * \param circle Circle that will be added to this field.
        ***************************************************************************/
        public void AddCircle(Circle circle)
        {
            // Adds the circle to the top of the stack
            this.StackCircles.Push(circle);

            // Draws the new circle that is at the top of the stack
            this.DrawCircle(circle);
        }


        /** ************************************************************************
        * \brief Removes a circle from the field.
        * \details Function responsible for removing the circle at the top of the
        * stack of this field and returning it.
        * \return Value of type Circle, corresponding to the circle that was at the
        * top of the stack of this field.
        ***************************************************************************/
        public Circle PopCircle()
        {
            // Removes the circle at the top of the stack
            Circle circle = this.StackCircles.Pop();

            // Draws the new circle that is at the top of the stack
            this.DrawCircle(this.GetLast());
            return circle;
        }


        /** ************************************************************************
        * \brief Changes the circle's color.
        * \details Function responsible for changing the color of the circle that is
        * in this field.
        ***************************************************************************/
        public void ChangeCircleColor()
        {
            // Gets the circle at the top of the stack
            Circle circle = this.GetLast();

            // If the circle is not null, its color will be changed
            if (circle != null)
            {
                this.StackCircles.Pop();
                circle.Color.ChangeColor();
                this.AddCircle(circle);
            }
        }


        /** ************************************************************************
        * \brief Retrieve information about the current circle from a field.
        * \details This function is responsible for retrieving the circle at the top
        * of the stack of this field and returning its information.
        * \return A value of type Circle, corresponding to the circle that was at
        * the top of the stack of this field.
        ***************************************************************************/
        public Circle GetLast()
        {
            if (this.StackCircles.Count == 0)
            {
                return null;
            }
            return this.StackCircles.Peek();
        }


        /** ************************************************************************
        * \brief Clears the stack of circles.
        * \details This function is responsible for clearing the stack of circles
        * in this field.
        ***************************************************************************/
        public void Clear()
        {
            this.StackCircles.Clear();
        }


        /** ************************************************************************
        * \brief Draw a circle.
        * \details This function is responsible for drawing a circle in this field.
        * \param circle Circle to be drawn.
        ***************************************************************************/
        public void DrawCircle(Circle circle)
        {
            SolidBrush solidBrush;

            // Clear the field before drawing the circle
            this.EraseField();

            if (circle == null)
            {
                this.StackCircles.Clear();
                return;
            }

            Graphics paper = this.FieldPictureBox.CreateGraphics();

            // Check what color the circle will have
            solidBrush = (circle.Color.TypeCurrent == ColorType.Primary) ? 
                new SolidBrush(circle.Color.Primary): 
                new SolidBrush(circle.Color.Secundary);

            // Draw the specified circle
            paper.FillEllipse(solidBrush, circle.X, circle.Y, circle.Width, circle.Height);
        }


        /** ************************************************************************
        * \brief Clear the field.
        * \details This function is responsible for clearing the field.
        ***************************************************************************/
        public void EraseField()
        {
            Graphics paper = this.FieldPictureBox.CreateGraphics();
            // Initial color of the field
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(240, 240, 240)); 
            Size size = this.FieldPictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }


        /** ************************************************************************
        * \brief Compare two fields.
        * \details Overridden function responsible for comparing two objects of type 
        * Field.
        * \param obj Field to be compared.
        * \return A boolean value, indicating whether the two compared fields are
        * equal or not.
        ***************************************************************************/
        public override bool Equals(object obj)
        {
            Circle circle = this.GetLast();

            if ((!(obj is Field)) || (circle == null))
            {
                return false;
            }

            // Perform a downcasting
            Field other = obj as Field;  
            return circle.Equals(other.GetLast());
        }


        /** ************************************************************************
        * \brief Generate the hash key for the field.
        * \details Overridden function responsible for generating a hash key for
        * this field.
        * \return An integer value, representing the hash key for the field.
        ***************************************************************************/
        public override int GetHashCode()
        {
            return this.GetLast().GetHashCode();
        }
    }
}
