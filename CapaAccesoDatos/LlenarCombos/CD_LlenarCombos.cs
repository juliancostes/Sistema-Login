using System.Data;
using System.Data.OleDb;

/* Esta clase me permite cargar cualquier comboBox desde una tabla
   recibiendo  el Nombre de la tabala, el campo Id de la tabla relacionado al dato que mostrara el ComboBox 
   y el campo que mostrara el ComboBox.
   como opcional podra recibir una condicion .
*/
namespace CapaAccesoDatos
{
    public class CD_LlenarCombos : clsConexion 
    {

        #region ATRIBUTOS
        private string tabla;
        private string campoid;
        private string campodescrip;
        private string condicion;
        #endregion

        #region PROPERTIES
        public string Tabla
        {
            set { tabla = value; }
        }
        public string CampoId
        {
            set { campoid = value; }
        }
        public string CampoDescrip
        {
            set { campodescrip = value; }
        }
        public string Condicion
        {
            set { condicion = value; }
        }
        #endregion


        public DataTable CargarCMB()
        {
            string sSql;
            if (condicion == "")
            {
                sSql = "SELECT " + campoid + ", " + campodescrip + " FROM " + tabla + " ORDER BY " + campodescrip;
            }
            else
            {
                sSql = "SELECT " + campoid + ", " + campodescrip + " FROM " + tabla + " Where  " + condicion + " ORDER BY " + campodescrip;
            }

            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            return Ejecutar.Ejecutar(sSql);
        }
    }
}

