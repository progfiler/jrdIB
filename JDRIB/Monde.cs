using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDRIB
{
    class Monde
    {
        public IGame Game { get; private set; }

        public Monde(IGame game)
        {
            Game = game;
        }

        public void Start()
        {
            this.Game.Start();
        }
    }
}
