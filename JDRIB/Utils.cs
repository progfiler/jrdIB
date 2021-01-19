using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDRIB
{
    class Utils
    {
        public static int randomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static double randomDouble()
        {
            Random random = new Random();
            return Math.Round(random.NextDouble(), 2);
        }

        public static void WriteLine(string type) 
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat(type, 45)));
        }
    }
}
