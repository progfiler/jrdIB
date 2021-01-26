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
         * Permet de récupérer une liste d'objet
         */
        /// <returns>Renvoi une liste d'objet</returns>
        public abstract List<T> findAll();
        /**
        * Permet de persister un objet
        */
        public abstract int create(T obj);
        /**
        * Permet de modifier un objet
        */
        public abstract int update(T obj);
        /**
        * Permet de supprimer un objet
        */
        public abstract int delete(int id);

        public void openConnection ()
        {
            Console.WriteLine("Connecting to MySQL...");
            connectionSql.Open();       
        }
        
        public void closeConnection (MySqlDataReader reader)
        {
            Console.WriteLine("Close MySQL...");
            reader.Close();
            connectionSql.Close();       
        }
    }
}
