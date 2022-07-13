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
        public ColorType Type;

        public ColorInfo(Color primary, Color secundary)
        {
            this.Primary = primary;
            this.Secundary = secundary;
            this.Type = ColorType.Primary;
        }

        public void ChangeColor()
        {
            if(this.Type == ColorType.Primary)
            {
                this.Type = ColorType.Secundary;
            }
            else
            {
                this.Type = ColorType.Primary;
            }
        }

        public ColorType GetColorType()
        {
            return this.Type;
        }
    }
}
