using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using CapaComun;
using CapaAccesoDatos;

namespace CapaDatos
{
    public class clsPermisos : clsConexion
    {
        public bool Permisos(int IdUser)
        {
            string sSql = "SELECT PermisosUsuarios.IdPermiso, Permisos.Funcionalidad"+
                          " FROM Permisos INNER JOIN PermisosUsuarios ON Permisos.[IdPermiso] = PermisosUsuarios.[IdPermiso]" +
                          " where IdUsuario = " + IdUser + 
                          " and ISNULL(PermisosUsuarios.FechaBaja) " +
                          " and iif(NOT ISNULL(PermisosUsuarios.AltaProvisoria), PermisosUsuarios.AltaProvisoria >= date(), ISNULL(PermisosUsuarios.AltaProvisoria))  ";

            DataTable DT = new DataTable();
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            DT= Ejecutar.Ejecutar(sSql);

            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    UserCache.PermisosUsuario.Add(Convert.ToInt32(row[0].ToString()), row[1].ToString());
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
