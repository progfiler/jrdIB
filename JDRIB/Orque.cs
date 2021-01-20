using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Orque : Personnages
    {
        public Orque() {
            this.Specs = new Specs("Il se transforme en geant", true, 0.25, Process.Multiplicate);
        }
    }
}
