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
        public Specs Specs { get; set; }
        public Personnages() { }
        public Personnages(double life, double damage, int nameLength, double coefAtk, double coefDef, Specs specs)
        {
            this.Life = life;
            this.Damage = damage;
            this.Name = GenerateName(nameLength);
            this.CoefAtk = coefAtk;
            this.CoefDef = coefDef;
            this.specs = specs;
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
