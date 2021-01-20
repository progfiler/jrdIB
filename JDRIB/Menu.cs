using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Menu
    {
        List<Personnages> personnages = new List<Personnages>();
        PersonnagesBuilder personnagesBuilder = new PersonnagesBuilder();
        public void start()
        {
            Utils.WriteLine("#");
            Console.WriteLine("Bienvenue dans JDR 2.0 WSH T'AS VU");
            Utils.WriteLine("#");
            Console.WriteLine("Une nouvelle expérience de jeu immersive hyper cool ..... :) ");
            Console.WriteLine("Appuyer sur une touche pour commencer ....");
            ConsoleKeyInfo start = Console.ReadKey();
            if (start != null)
            {
                selectMode();
            }
        }
        private void selectMode()
        {
            Utils.WriteLine(".");
            Console.WriteLine("Choisissez votre mode de jeu : ");
            Console.WriteLine("[ N ] - Mode Normal");
            Console.WriteLine("[ Z ] - Mode Zombie");
            string mode = Console.ReadLine();
            if (mode.ToLower() == "n")
            {
                Console.WriteLine("Mode normal activé ....");
                initializeNormalGame();
            } else if (mode.ToLower() == "z")
            {
                Console.WriteLine("Mode zombie activé ....");
                initializeZombieGame();
            } else
            {
                Console.WriteLine("Ce mode n'existe pas :( ");
                selectMode();
            }

        }

        private void initializeZombieGame()
        {
            throw new NotImplementedException();
        }

        private void initializeNormalGame()
        {
            Utils.WriteLine("#");
            Console.WriteLine("Nous allons ajouter des personnages à notre jeu :)");
            bool select = true;
            do
            {
                // Créer un personnage 
                Personnages personnage = personnagesBuilder
                    .setType(selectedPerson())
                    .setName()
                    .setLife()
                    .setDamage()
                    .setAtk()
                    .setDef()
                    .get();
                personnages.Add(personnage);
                Console.WriteLine("Vous venez d'ajouter " + personnage.Name + " à votre jeu.");
                select = addNewPerson();
            } while (select);
            startGame();
        }

        private void startGame()
        {
            if (personnages.Count > 1)
            {
                Monde monde = new Monde(personnages);
                monde.start();
            }
        }

        private int selectedPerson()
        {
            Utils.WriteLine("#");
            Console.WriteLine("Indiquez la race de votre personnage");
            Console.WriteLine("[ 1 ] - Humain");
            Console.WriteLine("[ 2 ] - Nain");
            Console.WriteLine("[ 3 ] - Elf");
            Console.WriteLine("[ 4 ] - Orque");
            Console.WriteLine("Indiquez votre choix : 1,2,3,4 : ");
            string choice = Console.ReadLine();
            return Int32.Parse(choice);
        }

        private bool addNewPerson()
        {
            bool response = true;
            Console.WriteLine("Voulez-vous ajouter un autre personnage ? (Y/n)");
            string addPerson = Console.ReadLine();
            if (addPerson == "n" || addPerson == "N") { 
                response = false; 
            }
            else if (addPerson == "y" || addPerson == "Y") { 
                response = true; 
            }
            else {
                Console.WriteLine("Vous vous êtes trompé de choix : ");
                Console.WriteLine("Y - Ajouter un autre personnage");
                Console.WriteLine("N - Ne pas ajouter un autre personnage");
                return addNewPerson();
            }
            return response; 
        }
    }
}
