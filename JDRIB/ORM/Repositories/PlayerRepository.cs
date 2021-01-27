using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JDRIB.Entities;
using JDRIB.ORM.REPOSITORIES;
using MySql.Data.MySqlClient;

namespace JDRIB.ORM.Repositories
{
    class PlayerRepository : AbstractRepository<PlayerEntity>
    {

        private RequestBuilder requestBuilder;
        public PlayerRepository(RequestBuilder requestBuilder)
        {
            this.requestBuilder = requestBuilder;
        }

        public override int create(PlayerEntity obj)
        {
            this.openConnection();
            Dictionary<string, dynamic> playerDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id")
                {
                    playerDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
                .Insert("personnage")
                .Values(playerDictionnary);
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override int delete(int id)
        {
            this.openConnection();
            string request = requestBuilder.Delete("personnage", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override PlayerEntity find(int id)
        {
            this.openConnection();
            string request = requestBuilder
                .Select()
                .From("personnage")
                .Where("id", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            PlayerEntity player = new PlayerEntity();
            while (rdr.Read())
            {
                player.Id = rdr.GetInt32(0);
                player.Nom = rdr.GetString(1);
                player.Race = getPersonnageType(rdr.GetString(2));
                player.Life = rdr.GetDouble(3);
                player.Damage= rdr.GetDouble(4);
                player.CoefAtk= rdr.GetDouble(5);
                player.CoefDef= rdr.GetDouble(6);
            }
            this.closeConnection(rdr);
            return player;
        }

        public override List<PlayerEntity> findAll()
        {
            this.openConnection();
            string request = requestBuilder
                .Select()
                .From("personnage")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<PlayerEntity> listplayers = new List<PlayerEntity>();

            while (rdr.Read())
            {
                PlayerEntity player = new PlayerEntity();
                player.Id = rdr.GetInt32(0);
                player.Nom = rdr.GetString(1);
                player.Race = getPersonnageType(rdr.GetString(2));
                player.Life = rdr.GetDouble(3);
                player.Damage = rdr.GetDouble(4);
                player.CoefAtk = rdr.GetDouble(5);
                player.CoefDef = rdr.GetDouble(6);
                listplayers.Add(player);
            }
            this.closeConnection(rdr);
            return listplayers;
        }

        public override int update(PlayerEntity obj)
        {
            this.openConnection();
            Dictionary<string, dynamic> playerDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id")
                {
                    playerDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = requestBuilder
              .Update("personnage")
              .Set(playerDictionnary)
              .Where("id", obj.Id).Get();
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        private PersonnagesType getPersonnageType(string v)
        {
            PersonnagesType personnagesType;
            switch (v)
            {
                case "Humain":
                    personnagesType = PersonnagesType.Humain;
                    break;
                case "Elf":
                    personnagesType = PersonnagesType.Elf;
                    break;
                case "Nain":
                    personnagesType = PersonnagesType.Nain;
                    break;
                default:
                    personnagesType = PersonnagesType.Orque;
                    break;
            }
            return personnagesType;
        }
    }
}
