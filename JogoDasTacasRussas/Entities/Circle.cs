using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Circle: IComparable
    {
        public ColorInfo colorInfo;
        public int x;
        public int y;
        public int width;
        public int height;
        public CircleType type;

        public Circle(Color primaryColor, Color secundaryColor, CircleType type)
        {
            this.colorInfo = new ColorInfo(primaryColor, secundaryColor);
            this.type = type;

            switch (this.type)
            {
                case CircleType.Type4:
                    x = y = 5;
                    width = height = 70;
                break;

                case CircleType.Type3:
                    x = y = 10;
                    width = height = 60;
                break;

                case CircleType.Type2:
                    x = y = 15;
                    width = height = 50;
                break;

                case CircleType.Type1:
                    x = y = 20;
                    width = height = 40;
                break;
            }
        }

        public int CompareTo(object obj)
        {
            if(obj == null)
            {
                return 1;
            }
            Circle other = obj as Circle;  // Downcasting
            return type.CompareTo(other.type);
        }
    }
}
