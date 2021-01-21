using System;
using System.Collections.Generic;
using System.Linq;

namespace JDRIB
{
    internal class ZombieGame : Game
    {
        private List<Personnages> Zombies;
        public ZombieGame(List<Personnages> personnages, List<Personnages> zombies)
        {
            this.Personnages = personnages;
            this.Zombies = zombies;
        }
        public override void End()
        {
            Utils.WriteLine(".");
            Utils.WriteLine("*");
            if (Personnages.Count > 1)
            {
                System.Console.WriteLine("Les héros on gagné.");
                Personnages.ForEach(p =>
                {
                    System.Console.WriteLine("Les gagnant sont : " + p.Name);
                });
            } else if (Zombies.Count > 1)
            {
                System.Console.WriteLine("Les zombies on gagné.");
                Zombies.ForEach(p =>
                 {
                     System.Console.WriteLine("Les gagnant sont : " + p.Name);
                 });
            }
            Utils.WriteLine("*");
            Utils.WriteLine(".");
        }
        public override void Start()
        {
            System.Console.WriteLine("\n");
            
            foreach (Personnages attacker in Personnages.ToList())
            {
                if (Personnages.Count < 1 || Zombies.Count < 1)
                {
                    break;
                }
                {
                    System.Console.WriteLine("---------------------------------------------");
                    if (Zombies.Count > 1)
                    {
                        Personnages opponent = ReturnOpponent(Zombies);
                        Figth(attacker, opponent);
                    }
                }
            }
            foreach (Personnages attacker in Zombies.ToList())
            {
                if (Personnages.Count < 1 || Zombies.Count < 1)
                {
                    break;
                }else
                {
                    System.Console.WriteLine("---------------------------------------------");
                    if (Personnages.Count > 1)
                    {
                        Personnages opponent = ReturnOpponent(Personnages);
                        Figth(attacker, opponent);
                    }
                }
            }
            if (Personnages.Count > 1 && Zombies.Count > 1)
            {
                Start();
            }
            else
            {
                End();
            }
        }
        private void Figth(Personnages attacker, Personnages opponent)
        {
            double randomcoef = Utils.randomDouble();
            Console.WriteLine("un combat se prépare ....");
            Console.WriteLine(attacker.Name + " [ " + attacker + " ] va affronter " + opponent.Name + " [ " + opponent + " ]");

            if (attacker.CoefAtk > randomcoef)
            {
                Console.WriteLine(attacker.Name + " a réussi son attaque. c'est au tour de " + opponent.Name + " de se défendre");
                CalculateDefense(attacker, opponent);
                Console.WriteLine("suite à l'attaque, " + opponent.Name + " lui reste que " + opponent.Life + " de vie");
                if (!(opponent is Zombie))
                {
                    if (opponent.Life <= 0)
                    {
                        Personnages.Remove(opponent);
                    }
                } else
                {
                    if (opponent.Life <= 0)
                    {
                        Zombies.Remove(opponent);
                    }
                }
            }
            else
            {
                Console.WriteLine("ho ho ho " + attacker.Name + " n'a pas pu attaquer son adversaire.");
            }
        }
        private Personnages ReturnOpponent(List<Personnages> opponent)
        {
            int randomInt = Utils.randomInt(0, opponent.Count);
            return opponent[randomInt];
        }
    }
}