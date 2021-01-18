using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class Personnages
    {
        public double Life { get; set; }
        public double Damage { get; set; }
        public string Name { get; set; }
        public double CoefAtk { get; set; }
        public double CoefDef { get; set; }
        public Personnages(double life, double damage, int nameLength, double coefAtk, double coefDef)
        {
            Life = life;
            Damage = damage;
            Name = GenerateName(nameLength);
            CoefAtk = coefAtk;
            CoefDef = coefDef;
        }



        public Personnages(double life, double damage)
        {
            Life = life;
            Damage = damage;
        }

        private string GenerateName(int size)
        {
            var builder = new StringBuilder(size);
            char offset = 'a';
            const int lettersOffset = 26;
            Random random = new Random();
            for (var i = 0; i < size; i++) { 
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return builder.ToString();
        }

        internal void ReceiveDamage(double damage)
        {
            this.Life = this.Life - damage;
        }
    }
}
