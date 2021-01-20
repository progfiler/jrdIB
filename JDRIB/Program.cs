using System;
using System.Collections.Generic;

namespace JDRIB
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.start();

            /*
             * 1 Faire une demande sur le terminale sur le nmbre de personnages a ajouter  ainsi que 
             * les caractéristiques à entrer pour chaque personnages
             * 
             * 2 Ajouter des specs sur les races :
             *          - humain : lancer des boules de feux
             *                  - spec d'atk 
             *                  > aléatoirement elle multiplie sa force par 0.5 
             *          - Orque : Il se transforme en geant
             *                  - spec de def =
             *                  > aleatoirement elle lui permet diviser le damage de l'attaquant
             *                    par 2 
             *          - Nain : Il manie la hache avec perfection 
             *                  - spec d'atk 
             *                  > aléatoirement elle multiplie sa force par 0.25 
             *          - Elf : peut se rendre invisible
             *                  - spec de def =
             *                  > aleatoirement elle lui permet de ne subir aucun coup d'atk 
             *                  
             * 3 On va diviser le jeux en deux parties 
             *  - La partie ou tt le monde se tape sur la gueule => battle royal 
             *  - Partie Zombie
             *     - On choisi X héros qui vont affronter X Zombies 
             *          Qui va gagner ? 
             *  
             * 4 - Amélioration du mode zombie : 
             * Mode simple -> celui fait dans le 3
             * Mode par vague : 
             *      Il faur gérer des vagues de zombie 
             *      On choisis X Heros qui vont affronter des vagues de zombies 
             *      Le niveau des zombies augmente toutes les 5 vagues 
             *      Le nombre de zombies augmente à chaque vagues
             *      Les héros peuvent récuprer un % de leurs vie à chaque vagues
             */

            //List<Personnages> personnages = new List<Personnages>() {
            //    new Orque(200, 25, 5),
            //    new Humain(80, 16, 3),
            //    new Nain(100, 35, 8),
            //    new Elf(70, 28, 7)
            //};
            //Monde monde = new Monde(personnages);
            //monde.start();
        }
    }
}
