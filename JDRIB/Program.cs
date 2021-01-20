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
             *                  
             * 3 On va diviser le jeux en deux parties 
             *  - Partie Zombie
             *     - On choisi X héros qui vont affronter X Zombies 
             *          Qui va gagner ? 
             *  On revoit le menu du début pour proposer 2 modes de jeux 
             *  mode 1 : 
             *      - La partie ou tt le monde se tape sur la gueule => battle royal 
             *  mode 2 : 
             *      - mode Zombie :
             *          - Demander à l'utilisateur de générer X personnages 
             *              (Nain, Elf, Humain ou Orque)
             *              - Ces personnages auront une Vie, des dégats et des coefs aléatoires
             *          - Demander à l'utilisateur de générer X Zombies 
             *              - Les zombies auront une Vie, des dégats et des coefs aléatoires
             *          - On démarre le jeu 
             *              - Les héros peuvent attaquer les zombies 
             *              - les zombies peuvent attaquer les héros
             *              - le dernier héros survivant gagne SI il n'y a plus de zombies
             *                  sinon c'est les zombies qui gagnent
             *                  
             * 4 - Amélioration du mode zombie : 
             * Mode simple -> celui fait dans le 3
             * Mode par vague : 
             *      Il faur gérer des vagues de zombie 
             *      On choisis X Heros qui vont affronter des vagues de zombies 
             *      Le niveau des zombies augmente toutes les 5 vagues 
             *      Le nombre de zombies augmente à chaque vagues
             *      Les héros peuvent récuprer un % de leurs vie à chaque vagues
             *      
             *     
             * 5 - Persister les parties dans une BDD 
             * 
             */

        }
    }
}
