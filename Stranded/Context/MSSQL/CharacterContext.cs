using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Stranded.Models;
using Stranded.Models.ViewModels;

namespace Stranded.Context.MSSQL
{
    public class CharacterContext : DataConnection
    {
        private List<string> tempList = new List<string>();
        public CharacterViewModel GetAllCharacters()
        {
            CharacterViewModel cvm = new CharacterViewModel();
            List<Character> Characters = new List<Character>();
            string query = "SELECT * FROM dbo.Characters";

            try
            {
                SqlCommand cmd = new SqlCommand(query, OpenConn());
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Character c = new Character()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            CharacterModel = reader["CharacterModel"].ToString()
                        };
                        Characters.Add(c);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Couldn't get all characters");
            }

            cvm.Characters = Characters;

            return cvm;
        }
        public void CreateChar(string Name, string CharacterModel)
        {
            using (con)
            {
                OpenConn();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Characters (Name,CharacterModel) VALUES (@Name,@CharacterModel);", con))
                    {
                        command.Parameters.AddWithValue(@"CharacterModel", CharacterModel);
                        command.Parameters.AddWithValue(@"Name", Name);
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong while adding the character");
                }
            }
            con.Close();
        }
        public void RemoveChar(int CharacterId)
        {
            using (con)
            {
                OpenConn();
                try
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Characters WHERE Id=@CharacterId", con))
                    {
                        command.Parameters.AddWithValue(@"CharacterId", CharacterId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            con.Close();
        }

        public List<string> LoadCharModels()
        {
            using (con)
            {
                OpenConn();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.CharacterModels", con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    string tempString;
                                    tempString = reader["CharacterModel"].ToString();
                                    tempList.Add(tempString);
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            con.Close();
            return tempList;
        }
    }
}
