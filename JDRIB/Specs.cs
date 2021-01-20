using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    enum Process
    {
        Divise,
        Add,
        Substract,
        Multiplicate
    }
    class Specs
    {
        public string Description { get; set; }
        public bool Type { get; set; }
        public double Value { get; set; }
        public Process Process { get; set; }
        public Specs(string description, bool type, double value, Process process)
        {
            Description = description;
            Type = type;
            Value = value;
            Process = process;
        }

        internal double CalculateDamage(double attackerDamage, Personnages personnage)
        {
            double specValue = (attackerDamage * personnage.Specs.Value) / 100;
            switch (personnage.Specs.Process)
            {
                case Process.Add:
                    attackerDamage += specValue;
                    break;
                case Process.Substract:
                    attackerDamage -= specValue;
                    break;
                case Process.Multiplicate:
                    specValue = attackerDamage * personnage.Specs.Value;
                    attackerDamage += specValue;
                    break;
                case Process.Divise:
                    attackerDamage /= personnage.Specs.Value;
                    break;
                default:
                    break;
            }
            return attackerDamage;
        }
    }
}
