using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class PersonnagesBuilder
    {
        Personnages personnage;
        bool random = false; 
        public PersonnagesBuilder(bool random)
        {
            this.random = random;
        }
        public Personnages get()
        {
            return this.personnage;
        }
        public PersonnagesBuilder setType(PersonnagesType type)
        {
            switch (type)
            {
                case PersonnagesType.Humain:
                    personnage = new Humain();
                    break;
                case PersonnagesType.Nain:
                    personnage = new Nain();
                    break;
                case PersonnagesType.Elf:
                    personnage = new Elf();
                    break;
                case PersonnagesType.Orque:
                    personnage = new Orque();
                    break;
                default:
                    personnage = new Humain();
                    break;
            }
            return this;
        }   
        public PersonnagesBuilder setName()
        {
            if (this.random)
            {
                this.personnage.Name = Utils.GenerateName(Utils.randomInt(2, 7));
            } else
            {
                Utils.WriteLine("-");
                Console.WriteLine("Indiquez le nom de votre personnage");
                this.personnage.Name = Console.ReadLine();
            }
            return this;
        }    
        public PersonnagesBuilder setLife()
        {
            if (this.random)
            {
                this.personnage.Life = Convert.ToDouble(Utils.randomInt(30, 200));
            } else
            {
                this.personnage.Life = requestData("Indiquez la vie de votre personnage");
            }
            return this;
        }
        public PersonnagesBuilder setDamage()
        {
            if (this.random)
            {
                this.personnage.Damage = Convert.ToDouble(Utils.randomInt(30, 200));
            }
            else
            {
                this.personnage.Damage = requestData("Indiquez les dégats de votre personnage");
            }
            return this;
        }
        public PersonnagesBuilder setAtk()
        {
            if (this.random)
            {
                this.personnage.CoefAtk = Utils.randomDouble();
            }
            else
            {
                this.personnage.CoefAtk = requestData("Indiquez le coef d'attaque de votre personnage");
            }
            return this;
        }
        public PersonnagesBuilder setDef()
        {
            if (this.random)
            {
                this.personnage.CoefDef = Utils.randomDouble();
            }
            else
            {
                this.personnage.CoefDef = requestData("Indiquez le coef de defense de votre personnage");
            }
            return this;
        }
        private double requestData(string txt)
        {
            Utils.WriteLine("-");
            Console.WriteLine(txt);
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}
