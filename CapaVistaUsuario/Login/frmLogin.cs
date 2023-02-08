using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio;
using CapaComun;
using System.Runtime.InteropServices;
using System.Collections;

namespace CapaVistaUsuario

{
    public partial class frmLoguin : Form
    {
        public frmLoguin()
        {
            InitializeComponent();
        }

        private int intentos =0;
        private string usuario= "";

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLoguin_Load(object sender, EventArgs e)
        {
            btnCancelar.Select();
            CN_LlenarCombos llenarCMB = new CN_LlenarCombos(cmbProv, "Provincias", "IdProvincia", "Provincia");
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.ForeColor = Color.DimGray;
            }
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.ForeColor = Color.Black; ;
            btnIngresar.Font = new Font(btnIngresar.Font, FontStyle.Bold);
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.ForeColor = Color.DarkGray;
            btnIngresar.Font = new Font(btnIngresar.Font, FontStyle.Regular);
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.Black; ;
            btnCancelar.Font = new Font(btnCancelar.Font, FontStyle.Bold);
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.DarkGray;
            btnCancelar.Font = new Font(btnCancelar.Font, FontStyle.Regular);
        }

        private void pctVerPass_Click(object sender, EventArgs e)
        {            
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                pctVerPass.Visible = false;
                pctAsteriscos.Visible = true;
            }
        }

        private void pctAsteriscos_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                txtPassword.UseSystemPasswordChar = true;
                pctVerPass.Visible = true;
                pctAsteriscos.Visible = false;
            }
        }
        private void frmLoguin_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        private void MoverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            clsLogicaLoguin BuscarUsuario = new clsLogicaLoguin();

            if (BuscarUsuario.LoginUser(txtUsuario.Text,  txtPassword.Text)== false)
            {
                MessageBox.Show("Usuario o Password inexistente Fallida");
                // bloquear al usuario si introdujo 3 intentos fallidos
                if (intentos < 3)
                {
                    if (intentos == 0)
                    {
                        usuario = txtUsuario.Text;
                        intentos = 1;
                    }
                    else
                    {
                        if (usuario == txtUsuario.Text)
                        {
                            intentos++;
                        }
                    }
                }
                else
                {
                    //Bloquear usuario
                }
            }
            else
            {
                //El usuario ya esta loguedo, reemplazar el codigo siguiente de mensaje por 
                //el ingreso al sistema
                string perm = "";
                //leo todos los permisos de la HashTable del usuario
                foreach (DictionaryEntry elementos in UserCache.PermisosUsuario)
                {
                    perm += elementos.Key  + " " + elementos.Value  + "\n";
                }

                MessageBox.Show("Ingreso Exitoso!!! \n \n" + UserCache.Apellido + " " + UserCache.Nombres +
                     "\n CARGO: " + UserCache.Cargo + "\n \n PERMISOS: \n" + perm);
                //Grabo en la BITACORA el ingreso del usuario
                CL_clsBitacora Guardar = new CL_clsBitacora("Ingreso al Sistema", "Ingreso Exitoso", "frmLoguin");

                this.DialogResult = DialogResult.OK;
 


            }

        }
    }
}
