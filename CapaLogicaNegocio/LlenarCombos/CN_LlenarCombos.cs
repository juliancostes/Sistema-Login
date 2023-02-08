using System.Data;
using CapaAccesoDatos;
using System.Windows.Forms;



namespace CapaLogicaNegocio

{
    public class CN_LlenarCombos
    {
        private CD_LlenarCombos llenar = new CD_LlenarCombos();

        public CN_LlenarCombos(ComboBox CMB, string NombreTabla, string CampoID, string CampoDescrip, string Condicion = "")
        {
            llenar.Tabla = NombreTabla;
            llenar.CampoId = CampoID;
            llenar.CampoDescrip = CampoDescrip;
            llenar.Condicion = Condicion;

            CMB.DataSource = llenar.CargarCMB();

            CMB.DisplayMember = CampoDescrip;
            CMB.ValueMember = CampoID;
            CMB.SelectedIndex = -1;
        }
    }
}
