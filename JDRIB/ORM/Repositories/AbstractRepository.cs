using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.ORM.REPOSITORIES
{
    abstract class AbstractRepository<T>    
    {
        public MySqlConnection connectionSql = ConnectionSql.getConnection();

        /**
         * Permet de récupérer un objet
         */
        /// <param name="id"> id de référence en bdd</param>
        /// <returns>Renvoi un objet</returns>
        public abstract T find(int id);
        /**
        * Permet de persister un objet
        */
        public abstract T create(T obj);
        /**
        * Permet de modifier un objet
        */
        public abstract T update(T obj);
        /**
        * Permet de supprimer un objet
        */
        public abstract void delete(T obj);

        public void openConnection ()
        {
            Console.WriteLine("Connecting to MySQL...");
            connectionSql.Open();       
        }
    }
}
