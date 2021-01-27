using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.Entities
{
    class GameEntity
    {
        public Nullable<int> Id { get; set; }
        public int Type { get; set; }
        public int Winner { get; set; }
        public int Tour { get; set; }
        public double Life { get; set;  }

        public GameEntity() { }
        public GameEntity(int type, int winner, int tour, double life, Nullable<int> id = null)
        {
            Id = id;
            Type = type;
            Winner = winner;
            Tour = tour;
            Life = life;
        }
    }
}
