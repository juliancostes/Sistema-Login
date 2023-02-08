using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;


namespace CapaAccesoDatos
{
    public abstract class clsConexion
    {
        private readonly string cadena;
        private readonly string cadenaMySql;
        int connex = 2;
        public clsConexion()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Loguin.accdb";
            cadenaMySql= "Server =localhost; Database = login; Uid = root; Pwd = 1234" ;
        }
        protected OleDbConnection GetConexion() // property que devuelve la conexion
        {
            return new OleDbConnection(cadena);
        }

        protected MySqlConnection GetConexionMySql()
        {
            return new MySqlConnection(cadenaMySql);
        }
    }
}
