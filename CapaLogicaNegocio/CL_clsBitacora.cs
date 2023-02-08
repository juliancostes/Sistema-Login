using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class CL_clsBitacora
    {
        private string evento;
        private string detalle;
        private string origen;

        public  CL_clsBitacora(string evento, string detalle, string origen)
        {
            this.evento = evento;
            this.detalle = detalle;
            this.origen = origen;

            CD_clsBitacora Guardar = new CD_clsBitacora(evento, detalle, origen);
        }
    }
}
