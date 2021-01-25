using JDRIB.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.ORM.DAO
{
    class TestDAO : AbstractDAO<User>
    {
        public override User create(User obj)
        {
            throw new NotImplementedException();
        }

        public override void delete(User obj)
        {
            throw new NotImplementedException();
        }

        public override User find()
        {
            Console.WriteLine("Connecting to MySQL...");
            this.openConnection();

            string sql = "SELECT * FROM user";
            MySqlCommand cmd = new MySqlCommand(sql, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1]);
            }
            rdr.Close();
            return new User("toto", "titi");
        }

        public override User update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
