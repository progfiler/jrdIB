using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDRIB
{
    class Monde
    {
        public List<Personnages> personnages = new List<Personnages>();
        public Monde(List<Personnages> personnages)
        {
            this.personnages = personnages;              
        }
        public void start ()
        {
            System.Console.WriteLine("\n");
            foreach (Personnages attacker in personnages.ToList())
            {
                System.Console.WriteLine("---------------------------------------------");
                Personnages opponent = returnOppenent(attacker);
                fight(attacker, opponent);
            }   
            if (personnages.Count > 1)
            {
                start();
            } else
            {
                personnages.ForEach(p =>
                {
                    System.Console.WriteLine("Le gagnant est : " + p.Name);
                });
            }
        }
        private void fight(Personnages attacker, Personnages opponent)
        {
            double randomCoef = Utils.randomDouble();
            Console.WriteLine("Un combat se prépare ....");
            Console.WriteLine(attacker.Name + " va affronter " + opponent.Name);

            if (attacker.CoefAtk > randomCoef)
            {
                System.Console.WriteLine(attacker.Name + " a réussi son attaque. C'est au tour de " + opponent.Name + " de se défendre");
                CaculateDefense(attacker, opponent);
                System.Console.WriteLine("Suite à l'attaque, " + opponent.Name + " lui reste que " + opponent.Life + " de vie");
                if (opponent.Life <= 0)
                {
                    personnages.Remove(opponent);
                }
            } else
            {
                System.Console.WriteLine("Ho Ho Ho " + attacker.Name + " n'a pas pu attaquer son adversaire.");
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
            } else
            {
                System.Console.WriteLine(opponent.Name +  " n'a pas réussi à ce défendre !!");
            }
            Utils.WriteLine("*");
            Console.WriteLine("Attention, nos personnages on des specs, voyont s'ils arrivent à les utiliser");
            // On applique les specs
            // personnage.calculateSpecs(attackerDamage, isAttacker = Boolean)
            attackerDamage = attacker.CalculateSpecs(attackerDamage);
            attackerDamage = opponent.CalculateSpecs(attackerDamage); 
            Utils.WriteLine("*");
            opponent.ReceiveDamage(attackerDamage);
        }
        private Personnages returnOppenent(Personnages currentPersonnage)
        {
            int randomInt = Utils.randomInt(0, personnages.Count);
            Personnages opponent = personnages[randomInt];
            if (currentPersonnage.GetHashCode() == opponent.GetHashCode())
            {
                 return returnOppenent(currentPersonnage);
            }
            return opponent; 
        } 
    }
}
