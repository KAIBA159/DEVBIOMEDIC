using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;
using static System.Net.Mime.MediaTypeNames;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(
            int idtrabajador,
            int idproveedor, 
            DateTime fecha,
            string tipo_comprobante,
            string serie,
            string correlativo, decimal igv,
            string estado,string cbTipo_Ingreso,
            int idencargadoTransportista,

            DateTime horaInicioDT,
            DateTime horaFinDT,


            string cbTipo_Producto,
            string bultos,
            string dUA,
            string correlativoUnico,

            string conclusion,



            DataTable dtDetalles
            
            )
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.IdencargadoTransportista = idencargadoTransportista;
            

            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;

            Obj.HoraInicioDT = horaInicioDT;
            Obj.HoraFinDT = horaFinDT;

            Obj.CbTipo_Producto = cbTipo_Producto;
            Obj.Bultos = bultos;
            Obj.Dua = dUA;
            Obj.CorrelativoUnico = correlativoUnico;

            Obj.Conclusion = conclusion;

            //DateTime horaInicioDT,
            //DateTime horaFinDT,


            Obj.Tipo_Ingreso = cbTipo_Ingreso;

            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                //detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                //detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());



                //

                //this.dataListadoDetalle.Columns["CantidadManifestada"].HeaderText = "Cantidad Manifestada";
                //this.dataListadoDetalle.Columns["CantidadDiferencia"].HeaderText = "Diferencia";

                detalle.CantidadManifestada = Convert.ToInt32(row["CantidadManifestada"].ToString());
                detalle.CantidadDiferencia = (Convert.ToInt32(row["CantidadManifestada"].ToString()) - Convert.ToInt32(row["stock_inicial"].ToString())) ;// Convert.ToInt32(row["CantidadDiferencia"].ToString());

                //

                //detalle. = Convert.ToString(row["guia_remisioncliente"].ToString());
                //detalle. = Convert.ToString(row["subcliente"].ToString());

                ////
                ///
                bool limpio = Convert.ToBoolean(row["limpio"]);
                detalle.Limpio = limpio ? "Activo" : "Inactivo";
                //detalle.Limpio          = row["limpio"].ToString();

                bool deteriorado = Convert.ToBoolean(row["deteriorado"]);
                detalle.Deteriorado = deteriorado ? "Activo" : "Inactivo";
                //detalle.Deteriorado     = row["deteriorado"].ToString();

                bool envasecerrado = Convert.ToBoolean(row["envasecerrado"]);
                detalle.Envasecerrado = envasecerrado ? "Activo" : "Inactivo";
                //detalle.Envasecerrado   = row["envasecerrado"].ToString();

                bool certanalisis = Convert.ToBoolean(row["certanalisis"]);
                detalle.Certanalisis = certanalisis ? "Activo" : "Inactivo";
                //detalle.Certanalisis    = row["certanalisis"].ToString();

                bool sanitario = Convert.ToBoolean(row["sanitario"]);
                detalle.Sanitario = sanitario ? "Activo" : "Inactivo";
                //detalle.Sanitario       = row["sanitario"].ToString();


                //this.dtDetalle.Columns.Add("limpio", System.Type.GetType("System.String"));
                //this.dtDetalle.Columns.Add("deteriorado", System.Type.GetType("System.String"));
                //this.dtDetalle.Columns.Add("envasecerrado", System.Type.GetType("System.String"));
                //this.dtDetalle.Columns.Add("certanalisis", System.Type.GetType("System.String"));
                //this.dtDetalle.Columns.Add("sanitario", System.Type.GetType("System.String"));

                ////



                detalle.Lote = Convert.ToString(row["lote"].ToString());


                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj,detalles);
        }


        //AnularEnBloque

        public static string AnularEnBloque(List<int> idingresos)
        {

            ////List<int> idsSeleccionados = new List<int>();

            //DIngreso Obj = new DIngreso();
            //Obj.Idingreso = idingreso;
            //return Obj.Anular(Obj);

            return DIngreso.AnularEnBloque(idingresos);

        }




        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar,string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar,textobuscar2);
        }

        public static string ObtenerCorrelativoUnico()
        {
            DIngreso Obj = new DIngreso();

            return Obj.DObtenerCorrelativoUnico();
        }
        

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
