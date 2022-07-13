using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class ColorInfo
    {
        public Color Primary;
        public Color Secundary;
        public ColorType TypeCurrent;

        public ColorInfo(Color primary, Color secundary)
        {
            this.Primary = primary;
            this.Secundary = secundary;
            this.TypeCurrent = ColorType.Primary;
        }

        public void ChangeColor()
        {
            if(this.TypeCurrent == ColorType.Primary)
            {
                this.TypeCurrent = ColorType.Secundary;
            }
            else
            {
                this.TypeCurrent = ColorType.Primary;
            }
        }

        public ColorType GetColorType()
        {
            return this.TypeCurrent;
        }
    }
}
