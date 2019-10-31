using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Stranded.Context
{
    public class DataConnection
    {
        const string constring = "Server=mssql.fhict.local;Database=dbi415960;User Id=dbi415960;Password=StrandedSQL;";
        public SqlConnection con = new SqlConnection(constring);

        public SqlConnection OpenConn()
        {
            try
            {
                con.Open();
            }
            catch
            {
                Console.WriteLine("Couldnt open connection");
            }
            return con;
        }

        public SqlConnection CloseConn()
        {
            try
            {
                con.Close();
            }
            catch
            {
                Console.WriteLine("Couldnt close connection");
            }
            return con;
        }
    }
}
