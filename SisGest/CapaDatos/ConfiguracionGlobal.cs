using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace CapaDatos
{
    public static class ConfiguracionGlobal
    {
        public static string ObtenerCadenaConexion(string nombre = "CapaDatos.Properties.Settings.cn")
        {
            // Ruta al .config del ensamblado actual (CapaDatos.dll.config)
            string dllPath = Assembly.GetExecutingAssembly().Location;
            string configPath = dllPath + ".config";

            // Mapeo de configuración para leer el archivo externo
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            // Buscar la cadena de conexión
            var cadena = config.ConnectionStrings.ConnectionStrings[nombre];
            return cadena?.ConnectionString ?? string.Empty;
        }
    }

}
