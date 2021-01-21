using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Game : IGame
    {
        public List<Personnages> Personnages { get; protected set; }
        public virtual void End()
        {
            throw new NotImplementedException();
        }
        public virtual void Start()
        {
            throw new NotImplementedException();
        }
        protected void CalculateDefense(Personnages attacker, Personnages opponent)
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
            if (!(attacker is Zombie) && !(opponent is Zombie))
            {
                attackerDamage = attacker.CalculateSpecs(attackerDamage);
                attackerDamage = opponent.CalculateSpecs(attackerDamage);
            }
            Utils.WriteLine("*");
            opponent.ReceiveDamage(attackerDamage);
        }
    }
}
