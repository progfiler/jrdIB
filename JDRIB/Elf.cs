using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Elf : Personnages
    {
        public Elf() { }
        public Elf(double life, double damage, int nameLength, double coefAtk = 0.35, double coefDef = 0.55) : base(life, damage, nameLength, coefAtk, coefDef)
        {}
    }
}
