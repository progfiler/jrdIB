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

        public static string GenerateName(int size)
        {
            var builder = new StringBuilder(size);
            char offset = 'a';
            const int lettersOffset = 26;
            Random random = new Random();
            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return builder.ToString();
        }
    }
}
