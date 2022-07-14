using System;
using System.Collections.Generic;
using System.Text;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Player
    {
        public int Victories;
        public int Draws;
        public int Defeats;
        public PlayerType Type;

        public Player(PlayerType type)
        {
            this.Type = type;
            this.Defeats = this.Draws = this.Victories = 0;
        }

        public void AddVictory()
        {
            this.Victories += 1;
        }

        public void AddDraw()
        {
            this.Draws += 1;
        }

        public void AddDefeat()
        {
            this.Defeats += 1;
        }
    }
}
