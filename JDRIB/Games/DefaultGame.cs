using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class DefaultGame : IGame
    {
        public List<Personnages> Personnages => throw new NotImplementedException();

        public void End()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            Console.WriteLine("Cette game n'existe pas");
        }
    }
}
