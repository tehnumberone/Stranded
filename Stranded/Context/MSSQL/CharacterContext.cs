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
                            Name = reader["Name"].ToString(),
                            CharacterModel = Convert.ToInt32(reader["CharacterModel"])
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
        public void CreateChar(string Name, int CharacterModel)
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
                    Console.WriteLine("Something went wrong");
                }
            }
            con.Close();
        }
    }
}
