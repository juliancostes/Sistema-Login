using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaComun;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Loguin;

namespace CapaVistaUsuario.Loguin
{
    public partial class frmCambioPassword : Form
    {
        public frmCambioPassword()
        {
            InitializeComponent();
        }
        private void frmCambioPassword_Load(object sender, EventArgs e)
        {
            txtPassActual.UseSystemPasswordChar = true;
            txtPassNueva.UseSystemPasswordChar = true;
            txtPassNueva1.UseSystemPasswordChar = true;

            lblUsuario.Text = UserCache.Usuario;

        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            CL_clsCambioPass CP = new CL_clsCambioPass();
            try
            {
                CP.CambioPass(UserCache.Usuario, txtPassActual.Text, txtPassNueva.Text, txtPassNueva1.Text);
                MessageBox.Show("Cambio de contraseña exitoso!! \n" +
                    "EL SISTEMA SE CERRARA, VUELVA A INGRESAR CON LA NUEVA CONTRASEÑA. \n \n" +
                    "MAntenga la nueva contraseña en privado \n" +
                    "y no se la entregue a nadie.", "CAMBIO EXITOSO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    "ERROR EN CAMBIO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
