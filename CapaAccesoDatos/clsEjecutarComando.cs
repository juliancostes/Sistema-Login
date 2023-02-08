using System.Data;
using System.Data.OleDb;

namespace CapaAccesoDatos
{
    class clsEjecutarComando : clsConexion
    {
        OleDbDataReader DR;
        private DataTable DT = new DataTable();

        public DataTable Ejecutar(string sSql)
        {
            //La importancia de usar USING:
            //La declaración using garantiza que se llame a Dispose una vez termine de ejecutarse los códigos
            //dentro del bloque using, incluso si ocurre una excepción.
            //Para entender mejor, una vez que termine de ejecutarse el método Login,
            //se desechará los objetos OleDbConnection y OleDbCommand,
            
            using (OleDbConnection CNN = GetConexion())
            {
                CNN.Open();
                using (OleDbCommand comando = new OleDbCommand(sSql, CNN))
                {
                    DR = comando.ExecuteReader();
                    DT.Load(DR);
                    return DT;
                }
            }
        }
        public void EjecucionDirecta(string sSql)
        {
            using (OleDbConnection CNN = GetConexion())
            {
                CNN.Open();
                using (OleDbCommand comando = new OleDbCommand(sSql, CNN))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
