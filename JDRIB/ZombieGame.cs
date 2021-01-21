using System.Collections.Generic;

namespace JDRIB
{
    internal class ZombieGame : IGame
    {
        public List<Personnages> Personnages { get; private set; }
        private List<Personnages> zombies;
        public ZombieGame(List<Personnages> personnages, List<Personnages> zombies)
        {
            this.Personnages = personnages;
            this.zombies = zombies;
        }

        public void End()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}