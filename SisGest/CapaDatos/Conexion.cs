using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class Conexion
    {

        public static string Cn = Properties.Settings.Default.cn;
        public static string CadenaConexion => ConfiguracionGlobal.ObtenerCadenaConexion();

        // 🔹 Método principal para crear la conexión SQL
        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(CadenaConexion);
        }




    }
}
