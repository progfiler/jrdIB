using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDRIB
{
    class NormalGame : Game
    {
        public NormalGame(List<Personnages> personnages)
        {
            Personnages = personnages;
        }
        public override void Start()
        {
            System.Console.WriteLine("\n");
            foreach (Personnages attacker in Personnages.ToList())
            {
                System.Console.WriteLine("---------------------------------------------");
                Personnages opponent = ReturnOppenent(attacker);
                Figth(attacker, opponent);
            }
            if (Personnages.Count > 1)
            {
                Start();
            }
            else
            {
                End();
            }
        }
        public override void End()
        {
            Utils.WriteLine(".");
            Utils.WriteLine("*");
            Personnages.ForEach(p =>
            {
                System.Console.WriteLine("Le gagnant est : " + p.Name);
            });
            Utils.WriteLine("*");
            Utils.WriteLine(".");
        }
        private void Figth(Personnages attacker, Personnages opponent)
        {
            double randomcoef = Utils.randomDouble();
            Console.WriteLine("un combat se prépare ....");
            Console.WriteLine(attacker.Name + " va affronter " + opponent.Name);

            if (attacker.CoefAtk > randomcoef)
            {
                Console.WriteLine(attacker.Name + " a réussi son attaque. c'est au tour de " + opponent.Name + " de se défendre");
                CalculateDefense(attacker, opponent);
                Console.WriteLine("suite à l'attaque, " + opponent.Name + " lui reste que " + opponent.Life + " de vie");
                if (opponent.Life <= 0)
                {
                    Personnages.Remove(opponent);
                }
            }
            else
            {
                Console.WriteLine("ho ho ho " + attacker.Name + " n'a pas pu attaquer son adversaire.");
            }
        }
        private Personnages ReturnOppenent(Personnages currentPersonnage)
        {
            int randomInt = Utils.randomInt(0, Personnages.Count);
            Personnages opponent = Personnages[randomInt];
            if (currentPersonnage.GetHashCode() == opponent.GetHashCode())
            {
                return ReturnOppenent(currentPersonnage);
            }
            return opponent;
        }
    }
}
