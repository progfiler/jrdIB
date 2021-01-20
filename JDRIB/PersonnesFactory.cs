using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDRIB
{
    class PersonnesFactory
    {
        public static List<Personnages> InitializeListOfPersonnages()
        {
            List<Personnages> humains = GetPersonnages(PersonnagesType.Humain, RequestNumberOfPersonnage("d'humains"));
            List<Personnages> elfs = GetPersonnages(PersonnagesType.Elf, RequestNumberOfPersonnage("d'elfs"));
            List<Personnages> orques = GetPersonnages(PersonnagesType.Orque, RequestNumberOfPersonnage("d'orques"));
            List<Personnages> nains = GetPersonnages(PersonnagesType.Nain, RequestNumberOfPersonnage("de nain"));
            List<Personnages> personnages = humains.Concat(elfs).Concat(orques).Concat(nains).ToList();
            return personnages;
        }
        internal static Personnages InitializeOnePersonnage()
        {
            return GetPersonnage(defineType(), false);
        }
        private static List<Personnages> GetPersonnages(PersonnagesType type, int nbr)
        {
            List<Personnages> personnages = new List<Personnages>();
            if (nbr > 0)
            {
                for (int i = 0; i < nbr; i++)
                {
                    personnages.Add(GetPersonnage(type, true));
                }
            }
            return personnages;
        }
        private static Personnages GetPersonnage(PersonnagesType type, bool random)
        {
            PersonnagesBuilder personnagesBuilder = new PersonnagesBuilder(random);
            return personnagesBuilder
                .setType(type)
                .setName()
                .setLife()
                .setDamage()
                .setAtk()
                .setDef()
                .get();
            }
        private static PersonnagesType defineType()
        {
            Utils.WriteLine("#");
            Console.WriteLine("Indiquez la race de votre personnage");
            Console.WriteLine("[ 1 ] - Humain");
            Console.WriteLine("[ 2 ] - Nain");
            Console.WriteLine("[ 3 ] - Elf");
            Console.WriteLine("[ 4 ] - Orque");
            Console.WriteLine("Indiquez votre choix : 1,2,3,4 : ");
            int choice = Int32.Parse(Console.ReadLine());
            PersonnagesType personnagesType;
            switch (choice) {
                case 1:
                    personnagesType = PersonnagesType.Humain;
                    break;
                case 2:
                    personnagesType = PersonnagesType.Nain;
                    break;
                case 3:
                    personnagesType = PersonnagesType.Elf;
                    break;
                case 4:
                    personnagesType = PersonnagesType.Orque;
                    break;
                default:
                    personnagesType = PersonnagesType.Humain;
                    break;
            }
            return personnagesType;
        }
        private static int RequestNumberOfPersonnage(string v)
        {
            Utils.WriteLine("~");
            Console.WriteLine("Combien " + v + " voulez-vous ?");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
