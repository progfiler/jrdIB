using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Elf : Personnages
    {
        public Elf() {
            this.Specs = new Specs("Il peut se rendre invisible",false,100, Process.Substract);
        }
    }
}
