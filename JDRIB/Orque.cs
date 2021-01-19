using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Orque : Personnages
    {
        public Orque() { }
        public Orque(double life, double damage, int nameLength, double coefAtk = 0.48, double coefDef = 0.32) : base(life, damage, nameLength, coefAtk, coefDef)
        {
        }
    }
}
