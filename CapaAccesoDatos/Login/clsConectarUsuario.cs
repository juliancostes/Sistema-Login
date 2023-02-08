using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using CapaComun;

namespace CapaAccesoDatos
{
    public class clsConectarUsuario : clsConexion

    {
        public bool Login(string user, string pass)
        {
            string sSql = "SELECT Usuarios.IdUsuario, Usuarios.Usuario, Usuarios.Password, Usuarios.IdPersona, Usuarios.FechaAlta, Usuarios.FechaBaja, Usuarios.CambiaCada, Usuarios.FechaUltimoCambio, Usuarios.UsuarioDesactivado, Usuarios.FechaDesactivacion, Personal.Apellido, Personal.Nombres, Cargos.Cargo " +
               "FROM(Cargos INNER JOIN Personal ON Cargos.[IdCargo] = Personal.[IdCargo]) " +
               "INNER JOIN Usuarios ON Personal.[IdPersona] = Usuarios.[IdPersona]" +
               " where Usuarios.usuario= '" + user + "' and Usuarios.Password= '" + pass + "'";

            DataTable DT = new DataTable();
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            DT = Ejecutar.Ejecutar(sSql);

            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    UserCache.IdUsuario = Convert.ToInt32(row[0].ToString());
                    UserCache.Usuario = row[1].ToString();
                    UserCache.Password = row[2].ToString();
                    UserCache.IdPersona = Convert.ToInt32(row[3].ToString());
                    if (!string.IsNullOrEmpty(row[4].ToString())) UserCache.FechaAlta = Convert.ToDateTime(row[4].ToString());
                    if (!string.IsNullOrEmpty(row[5].ToString())) UserCache.FechaBaja = Convert.ToDateTime(row[5].ToString());
                    UserCache.CambiaCada = Convert.ToInt32(row[6].ToString());
                    if (!string.IsNullOrEmpty(row[7].ToString())) UserCache.FechaUltimoCambio = Convert.ToDateTime(row[7].ToString());
                    UserCache.UsuarioDesactivado = Convert.ToBoolean(row[8].ToString()); ;
                    UserCache.Apellido = row[10].ToString();
                    UserCache.Nombres = row[11].ToString();
                    UserCache.Cargo = row[12].ToString();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
