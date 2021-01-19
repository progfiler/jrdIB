using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Humain : Personnages
    {
        public Humain() { }
        public Humain(double life, double damage, int nameLength, double coefAtk = 0.44, double coefDef = 0.13) : base(life, damage, nameLength, coefAtk, coefDef)
        {
        }
    }
}
