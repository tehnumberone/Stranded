using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.Models;
using Stranded.Context.Interfaces;
using Stranded.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Stranded.Context.SQLContext
{
    public class ItemContext : IItemContext
    {
        private readonly string _connectionString;

        public ItemContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM dbo.Items WHERE Id=@ItemID";
                connection.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", id);
                        cmd.ExecuteNonQuery();
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

        public bool Create(Item item)
        {
            string query;
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                if (item.ImageFile != null) { query = "INSERT INTO dbo.Items (Name,Type,ImageFile) VALUES (@Name,@ItemType,@ImageFile)"; }
                else
                {
                    query = "INSERT INTO dbo.Items (Name,Type) VALUES (@Name,@ItemType)";
                }
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
                if (item.ImageFile != null) { cmd.Parameters.Add("@imageFile", sqlDbType: SqlDbType.VarBinary).Value = item.ImageFile; }
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

        public List<Item> GetAllItems(int sorteertype)
        {
            List<Item> Items = new List<Item>();
            string query = "SELECT * FROM dbo.Items";
            if (sorteertype == 0)
            {
                query = "SELECT * FROM dbo.Items ORDER BY Type DESC";
            }
            else if (sorteertype == 1)
            {
                query = "SELECT * FROM dbo.Items ORDER BY Type ASC";
            }
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Items.Add(new Item((int)reader["Id"], (string)reader["Name"], (Library.Models.ItemType)reader["Type"], (byte[])reader["ImageFile"]));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            connection.Close();
            return Items;

        }

        public Item GetItem(int id)
        {
            Item i = new Item();
            string query = "SELECT * FROM dbo.Items WHERE Id = @Id";
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i = (new Item((int)reader["Id"], (string)reader["Name"], (Library.Models.ItemType)reader["Type"], (byte[])reader["ImageFile"]));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            connection.Close();
            return i;
        }
    }
}
