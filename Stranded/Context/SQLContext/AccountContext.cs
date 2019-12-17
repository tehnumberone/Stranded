using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Stranded.Models;
using Stranded.Context.Interfaces;
using Microsoft.Extensions.Configuration;
using Stranded.Models.ViewModels;

namespace Stranded.Context.SQLContext
{
    public class AccountContext : IAccountContext
    {
        private readonly string _connectionString;

        public AccountContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Create(Account acc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO dbo.Accounts (Username,Password,Email) VALUES (@Username,@Password,@Email);";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue(@"Username", acc.Username);
                        cmd.Parameters.AddWithValue(@"Password", acc.Password);
                        cmd.Parameters.AddWithValue(@"Email", acc.Email);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                connection.Close();
                return false;
            }
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetByName(string Username)
        {
            Account acc = new Account();
            string query = "SELECT * FROM dbo.Accounts Where Username = @Username";
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            acc.Id = (int)reader["Id"];
                            acc.Username = reader["Username"].ToString();
                            acc.Password = reader["Password"].ToString();
                            acc.Email = reader["Email"].ToString();
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return acc;
        }
        public bool Exists(string Username)
        {
            Account temp = new Account();
            string query = "SELECT * FROM dbo.Accounts WHERE Username = @Username";
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Username", Username);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Username == reader["Username"].ToString())
                    {
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            connection.Close();
            return false;
        }

    }
}
