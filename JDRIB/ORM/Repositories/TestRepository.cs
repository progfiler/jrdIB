using JDRIB.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.ORM.REPOSITORIES
{
    class TestRepository : AbstractRepository<User>
    {
        private RequestBuilder requestBuilder;
        public TestRepository (RequestBuilder requestBuilder)
        {
            this.requestBuilder = requestBuilder;
        }
        public override User create(User obj)
        {
            throw new NotImplementedException();
        }

        public override void delete(User obj)
        {
            throw new NotImplementedException();
        }

        public override User find(int id)
        {
            this.openConnection();
            string request = requestBuilder
                .Select()
                .From("user")
                .Where("id", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1] + " " + rdr[2]);
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
