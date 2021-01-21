using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Humain : Personnages
    {
        public Humain() {
            this.Specs = new Specs("Il peut lancer des boules de feux", true, 0.5, Process.Multiplicate);
        }
    }
}
