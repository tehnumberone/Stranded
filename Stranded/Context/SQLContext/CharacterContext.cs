using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Stranded.Models;
using Stranded.Context.Interfaces;

namespace Stranded.Context.SQLContext
{
    public class CharacterContext : ICharacterContext
    {
        private readonly string _connectionString;

        public CharacterContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Create(Character c, Account acc)
        {
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO dbo.Characters (Name,CharacterModel,AccountID) VALUES (@Name,@CharacterModel,@AccountID)";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@AccountID", acc.Id);
                cmd.Parameters.AddWithValue("@CharacterModel", c.CharacterModel);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            connection.Close();
            return false;
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM dbo.Characters WHERE Id=@CharacterId";
                connection.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue(@"CharacterId", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                connection.Close();
            }
        }

        public Character GetById(int id)
        {
            Character c = new Character();
            string query = "SELECT * FROM dbo.Characters Where Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            c = new Character(id, reader["Name"].ToString(), reader["CharacterModel"].ToString());
                        }
                    }
                }
                connection.Close();
                return c;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return c;
            }
        }

        public List<Character> GetAll(Account acc)
        {
            List<Character> Characters = new List<Character>();
            string query = "SELECT * FROM dbo.Characters INNER JOIN dbo.Accounts ON dbo.Characters.AccountID = dbo.Accounts.Id WHERE dbo.Accounts.Id = @AccountID";
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"AccountID", acc.Id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Character c = new Character(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), reader["CharacterModel"].ToString());
                        Characters.Add(c);
                    }
                }
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return Characters;
        }
        public List<CharacterModel> GetAllCharModels()
        {
            List<CharacterModel> characterModels = new List<CharacterModel>();
            string query = "SELECT * FROM dbo.CharacterModels";
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CharacterModel cm = new CharacterModel()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                characterModel = reader["CharacterModel"].ToString()
                            };
                            characterModels.Add(cm);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return characterModels;
        }
    }
}
