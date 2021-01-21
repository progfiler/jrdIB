using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    interface IGame
    {
        public List<Personnages> Personnages { get; }
        public void Start();
        public string End();
    }
}
