using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaPresentacion.dsPrincipalTableAdapters
{
    public partial class sp_kardex_producto_x_loteTableAdapter
    {
        public void AplicarConexionGlobal()
        {
            this.Connection = Conexion.CrearConexion();
        }
    }
}
