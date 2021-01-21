﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Menu
    {
        List<Personnages> personnages = new List<Personnages>();
        List<Personnages> zombies;
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
            Utils.WriteLine("#");
            GeneratePersonnages();
            startGame(GameMode.Zombie);
        }

        private void initializeNormalGame()
        {
            Utils.WriteLine("#");
            Console.WriteLine("Nous allons ajouter des personnages à notre jeu :)");
            GeneratePersonnage();
            startGame(GameMode.Normal);
        }
        private void GeneratePersonnages()
        {
            personnages = PersonnagesFactory.InitializeListOfPersonnages();
            zombies = PersonnagesFactory.InitializeListOfZombies();
        }

        private void GeneratePersonnage()
        {
            bool select = true;
            do
            {
                personnages.Add(PersonnagesFactory.InitializeOnePersonnage());
                select = addNewPerson();
            } while (select);
        }

        private void startGame(GameMode mode)
        {
           
            if (personnages.Count > 1)
            {
                IGame game = new Game();
                switch (mode)
                {
                    case GameMode.Normal:
                        game = new NormalGame(this.personnages);
                        break;
                    case GameMode.Zombie:
                        game = new ZombieGame(this.personnages, this.zombies);
                        break;
                    default:
                        Console.WriteLine("Ce mpode n'existe pas");
                        break;
                }
                Monde monde = new Monde(game);
                monde.Start();
            }
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
