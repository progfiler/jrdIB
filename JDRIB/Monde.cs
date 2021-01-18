﻿using System;
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
            //foreach (Personnages attacker in personnages)
            //{
            //    System.Console.WriteLine(attacker.Name + attacker.CoefAtk);
            //}
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
            double coef = Utils.randomDouble();
            if (attacker.CoefAtk > coef)
            {
                System.Console.WriteLine(opponent.Name + " va subir " + attacker.Damage + " dégats");
                opponent.ReceiveDamage(attacker.Damage);
                System.Console.WriteLine("Suite à l'attaque, " + opponent.Name + " lui reste que " + opponent.Life + " de vie");
                if (opponent.Life <= 0)
                {
                    personnages.Remove(opponent);
                }
            } else
            {
                System.Console.WriteLine("Ho Ho Ho " + attacker.Name + " n'a pas pu attaquer son adversaire.");
                System.Console.WriteLine("Le coeficient d'attaque de " + attacker.Name + " qui est de " + attacker.CoefAtk + " est inférieur à " + coef);
            }

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
