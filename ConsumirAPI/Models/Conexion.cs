using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirAPI.Models
{
    public class Conexion
    {

        private readonly string connectionString;

        public Conexion(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(connectionString);
        }

        public static void CerrarConexion(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
}
