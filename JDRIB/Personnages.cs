using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Personnages
    {
        public double Life { get; set; }
        public double Damage { get; set; }
        public string Name { get; set; }
        public double CoefAtk { get; set; }
        public double CoefDef { get; set; }
        public Specs Specs { get; set; }
        public Personnages() { }

        public Personnages(double life, double damage)
        {
            Life = life;
            Damage = damage;
        }

        internal void ReceiveDamage(double damage)
        {
            this.Life = this.Life - damage;
        }

        internal double CalculateSpecs(double attackerDamage)
        {
            double a = Utils.randomDouble();
            double b = Utils.randomDouble();
            if (a > b)
            {
                Console.WriteLine(this.Name + " a réussi à utiliser sa spec !!!");
                Console.WriteLine("Avant l'utilisation de la spec, les dégats sont de " + attackerDamage);
                attackerDamage = Specs.CalculateDamage(attackerDamage, this);
                Console.WriteLine("Après l'utilisation de la spec, les dégats sont de " + attackerDamage);
            }
            else
            {
                Console.WriteLine(this.Name + " n'a pas réussi à utiliser sa spec !!!");
            }
            return attackerDamage;
        }
    }
}
