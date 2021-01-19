using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB
{
    class PersonnagesBuilder
    {
        Personnages personnage;

        public Personnages get()
        {
            return this.personnage;
        }
        public PersonnagesBuilder setType(int type)
        {
            switch (type)
            {
                case 1:
                    personnage = new Humain();
                    break;
                case 2:
                    personnage = new Nain();
                    break;
                case 3:
                    personnage = new Elf();
                    break;
                case 4:
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
            Utils.WriteLine("-");
            Console.WriteLine("Indiquez le nom de votre personnage");
            this.personnage.Name = Console.ReadLine();
            return this;
        }    
        public PersonnagesBuilder setLife()
        {
            this.personnage.Life = requestData("Indiquez la vie de votre personnage");
            return this;
        }
        public PersonnagesBuilder setDamage()
        {
            this.personnage.Damage = requestData("Indiquez les dégats de votre personnage");
            return this;
        }
        public PersonnagesBuilder setAtk()
        {
            this.personnage.CoefAtk = requestData("Indiquez le coef d'attaque de votre personnage");
            return this;
        }
        public PersonnagesBuilder setDef()
        {
            this.personnage.CoefDef = requestData("Indiquez le coef de defense de votre personnage");
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
