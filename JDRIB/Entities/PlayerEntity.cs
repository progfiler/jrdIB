using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.Entities
{
    class PlayerEntity
    {
        public Nullable<int> Id { get; set; }
        public string Nom { get; set; }
        public PersonnagesType Race { get; set; }
        public double Life { get; set; }
        public double Damage { get; set; }
        public double CoefAtk { get; set;  }
        public double CoefDef { get; set;  }

        public PlayerEntity() { }
        public PlayerEntity(string nom, PersonnagesType race, double life, double damage, double coefAtk, double coefDef, int? id = null)
        {
            Id = id;
            Nom = nom;
            Race = race;
            Life = life;
            Damage = damage;
            CoefAtk = coefAtk;
            CoefDef = coefDef;
        }
    }
}
