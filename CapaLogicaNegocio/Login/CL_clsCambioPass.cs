using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaComun;
using CapaAccesoDatos;
using CapaAccesoDatos.Loguin;

namespace CapaLogicaNegocio.Loguin
{
    public class CL_clsCambioPass
    {
        clsConectarUsuario VerificaPass = new clsConectarUsuario();
        

        private bool existe;
        public bool CambioPass(string Usuario, string passVieja, string PassNueva, string PassNueva1)
        {

            existe = VerificaPass.Login(Usuario, clsSeguridad.SHA256(passVieja));
            if (existe)
            {
                if (PassNueva == PassNueva1)
                {
                    CD_ModificaPass MP = new CD_ModificaPass();
                    MP.ModificaPass(IdUser: UserCache.IdUsuario, Pass: clsSeguridad.SHA256(PassNueva));
                }
                else
                {
                    throw new Exception("Las nuevas contraseñas ingresadas no coinciden.");
                }
            }
            else
            {
                throw new Exception("La contraseña ingresada es incorrecta.");
            }
            return true;
        }

    }
}
        
        