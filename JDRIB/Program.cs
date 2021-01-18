using System;
using System.Collections.Generic;

namespace JDRIB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personnages> personnages = new List<Personnages>() {
                new Orque(200, 25, 5),
                new Humain(80, 16, 3),
                new Nain(100, 35, 8),
                new Elf(70, 28, 7)
            };
            Monde monde = new Monde(personnages);
            monde.start();
        }
    }
}
