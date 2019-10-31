using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Stranded.Context.MSSQL
{
    public class CharacterContext : DataConnection
    {

        public void query()
        {
            using (con)
            {
                OpenConn();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Characters (Id,Name) VALUES (2,'Klaustro');", con))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong");
                }
            }
        }
    }
}
