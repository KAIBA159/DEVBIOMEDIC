using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public class Contribuyente
    {
        private string _RUC = string.Empty;
        private string _Direccion = string.Empty;
        private string _Razon = string.Empty;
        private string _Estado = string.Empty;
        private string _Telefono = string.Empty;
        private string _Tipo = string.Empty;
        private string _TieneNegocio = string.Empty;
        private string _Condicion = string.Empty;
        private string _NombreComercial = string.Empty;
        private string _BuenContribuyente = string.Empty;
        private string _Percepcion = string.Empty;
        private string _Retencion = string.Empty;
        private string _Departamento = string.Empty;
        private string _Provincia = string.Empty;
        private string _Distrito = string.Empty;
        private string _Mensaje = string.Empty;
        private string _TipoDoc = string.Empty;
        private string _NumDoc = string.Empty;
        private string _ApePat = string.Empty;
        private string _ApeMat = string.Empty;
        private string _Nombres = string.Empty;

        public int TipoRespuesta { get; set; }
        public string RUC { get => _RUC; set => _RUC = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Razon { get => _Razon; set => _Razon = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public string Condicion { get => _Condicion; set => _Condicion = value; }
        public string NombreComercial { get => _NombreComercial; set => _NombreComercial = value; }
        public string BuenContribuyente { get => _BuenContribuyente; set => _BuenContribuyente = value; }
        public string Percepcion { get => _Percepcion; set => _Percepcion = value; }
        public string Retencion { get => _Retencion; set => _Retencion = value; }
        public string Departamento { get => _Departamento; set => _Departamento = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public string Distrito { get => _Distrito; set => _Distrito = value; }
        public string Mensaje { get => _Mensaje; set => _Mensaje = value; }
        public string TipoDoc { get => _TipoDoc; set => _TipoDoc = value; }
        public string NumDoc { get => _NumDoc; set => _NumDoc = value; }
        public string ApePat { get => _ApePat; set => _ApePat = value; }
        public string ApeMat { get => _ApeMat; set => _ApeMat = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string TieneNegocio { get => _TieneNegocio; set => _TieneNegocio = value; }
    }

}
