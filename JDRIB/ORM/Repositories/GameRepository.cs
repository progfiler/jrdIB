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
                if (pr.Name.ToLower() != "id")
                {
                    gameDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
                .Insert("game")
                .Values(gameDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override int delete(int id)
        {
            this.openConnection();
            string request = requestBuilder.Delete("game", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override GameEntity find(int id)
        {
            this.openConnection();
            string request = requestBuilder
                .Select()
                .From("game")
                .Where("id", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            GameEntity game = new GameEntity();
            while (rdr.Read())
            {
                game.Id = rdr.GetInt32(0);
                game.Type = rdr.GetInt32(1);
                game.Winner = rdr.GetInt32(2);
                game.Tour = rdr.GetInt32(3);
                game.Life = rdr.GetDouble(4);
            }
            this.closeConnection(rdr);
            return game;
        }

        public override List<GameEntity> findAll()
        {
            this.openConnection();
            string request = requestBuilder
                .Select()
                .From("game")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<GameEntity> listGames = new List<GameEntity>();

            while (rdr.Read())
            {
                GameEntity gameEntity = new GameEntity();
                gameEntity.Id = rdr.GetInt32(0);
                gameEntity.Type = rdr.GetInt32(1);
                gameEntity.Winner = rdr.GetInt32(2);
                gameEntity.Tour = rdr.GetInt32(3);
                gameEntity.Life = rdr.GetDouble(4);
                listGames.Add(gameEntity);
            }
            this.closeConnection(rdr);
            return listGames;
        }

        public override int update(GameEntity obj)
        {
            this.openConnection();
            Dictionary<string, dynamic> gameDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id")
                {
                    gameDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
              .Update("game")
              .Set(gameDictionnary)
              .Where("id", obj.Id).Get();
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }
    }
}
