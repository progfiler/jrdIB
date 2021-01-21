using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDRIB
{
    class NormalGame : IGame
    {
        public List<Personnages> Personnages { get; private set; }
        public NormalGame(List<Personnages> personnages)
        {
            Personnages = personnages;
        }
        public void Start()
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
        public void End()
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
                CaculateDefense(attacker, opponent);
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
        private void CaculateDefense(Personnages attacker, Personnages opponent)
        {
            double randomDouble = Utils.randomDouble();
            double attackerDamage = attacker.Damage;
            System.Console.WriteLine(opponent.Name + " se prépare à défendre ....");
            if (opponent.CoefDef > randomDouble)
            {
                System.Console.WriteLine(opponent.Name + " c'est défendu !!!");
                double reduceDamage = attackerDamage * opponent.CoefDef;
                attackerDamage = attackerDamage - Math.Round(reduceDamage);
                System.Console.WriteLine("L'attaque a été réduite à " + attackerDamage);
            }
            else
            {
                System.Console.WriteLine(opponent.Name + " n'a pas réussi à ce défendre !!");
            }
            Utils.WriteLine("*");
            Console.WriteLine("Attention, nos personnages on des specs, voyont s'ils arrivent à les utiliser");
            attackerDamage = attacker.CalculateSpecs(attackerDamage);
            attackerDamage = opponent.CalculateSpecs(attackerDamage);
            Utils.WriteLine("*");
            opponent.ReceiveDamage(attackerDamage);
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
