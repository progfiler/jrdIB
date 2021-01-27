using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JDRIB.Entities;
using JDRIB.ORM.REPOSITORIES;
using MySql.Data.MySqlClient;

namespace JDRIB.ORM.Repositories
{
    class GameRepository : AbstractRepository<GameEntity>
    {

        private RequestBuilder requestBuilder;
        public GameRepository(RequestBuilder requestBuilder)
        {
            this.requestBuilder = requestBuilder;
        }

        public override int create(GameEntity obj)
        {
            this.openConnection();
            Dictionary<string, dynamic> gameDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                Console.WriteLine(pr.Name);
                if (pr.Name.ToLower() != "id")
                {
                    gameDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
                .Insert("game")
                .Values(gameDictionnary);
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override int delete(int id)
        {
            throw new NotImplementedException();
        }

        public override GameEntity find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<GameEntity> findAll()
        {
            throw new NotImplementedException();
        }

        public override int update(GameEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
