using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Nain : Personnages
    {
        public Nain() { }
        public Nain(double life, double damage, int nameLength, double coefAtk = 0.55, double coefDef = 0.42) : base(life, damage, nameLength, coefAtk, coefDef)
        {
        }
    }
}
