using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.ORM.DAO
{
    abstract class AbstractDAO<T>    
    {
        public MySqlConnection connectionSql = ConnectionSql.getConnection();

        /**
         * Permet de récupérer un objet
         */
        public abstract T find();
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
            connectionSql.Open();       
        }
    }
}
