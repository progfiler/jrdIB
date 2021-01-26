using JDRIB.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        public override int create(User obj)
        {
            this.openConnection();
            Dictionary<string, dynamic> userDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id")
                {
                    userDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
                .Insert("user")
                .Values(userDictionnary);
                
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override int delete(int id)
        {
            this.openConnection();
            string request = requestBuilder.Delete("user", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
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
            User user = new User();
            while (rdr.Read())
            {
                user.Id = rdr.GetInt32(0);
                user.Name = rdr.GetString(1);
                user.Lastname = rdr.GetString(2);
            }
            this.closeConnection(rdr);
            return user;
        }

        public override List<User> findAll()
        {
            this.openConnection();
            string request = requestBuilder
                .Select()
                .From("user")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<User> listUsers = new List<User>();
            
            while (rdr.Read())
            {
                User user = new User();
                user.Id = rdr.GetInt32(0);
                user.Name = rdr.GetString(1);
                user.Lastname = rdr.GetString(2);
                listUsers.Add(user);
            }
            this.closeConnection(rdr);
            return listUsers;
        }

        public override int update(User obj)
        {
            this.openConnection();
            Dictionary<string, dynamic> userDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id")
                {
                    userDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
              .Update("user")
              .Set(userDictionnary)
              .Where("id",  obj.Id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }
    }
}
