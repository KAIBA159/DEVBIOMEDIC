using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FrmReporteKardexv4xLoteMes : Form
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        private int _idproducto;
        private int _idCliente;

        private string _Lote;



        public int idproducto
        {
            get { return _idproducto; }
            set { _idproducto = value; }
        }

        public int idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public string Lote
        {
            get { return _Lote; }
            set { _Lote = value; }
        }


        public FrmReporteKardexv4xLoteMes()
        {
            InitializeComponent();
        }

        private void FrmReporteKardexv4xLoteMes_Load(object sender, EventArgs e)
        {

            try
            {
                //exec sp_kardex_producto '01/01/2025','01/08/2026',1008,'REG11008', 1003

                // 🔹 Aplica la conexión global desde CapaDatos
                this.sp_kardex_producto_x_lote_x_mesTableAdapter.Connection = Conexion.CrearConexion();//  sp_kardex_producto_x_loteTableAdapter.Connection = Conexion.CrearConexion();



                //this.sp_kardex_productoTableAdapter.Fill(this.dsPrincipal.spbuscar_venta_fecha, Texto, Texto2);
                //this.sp_kardex_productoTableAdapter.Fill(this.dsPrincipal.sp_kardex_producto, Convert.ToDateTime( "01/01/2025"), Convert.ToDateTime("01/08/2026") , 1008, 1003);
                this.sp_kardex_producto_x_lote_x_mesTableAdapter.Fill(this.dsPrincipal.sp_kardex_producto_x_lote_x_mes, FechaInicio, FechaFin, Lote, idproducto, idCliente);
                //this.sp_kardex_productoTableAdapter.Fill(this.dsPrincipal.sp_kardex_producto, Convert.ToDateTime("01/01/2025"), Convert.ToDateTime("01/08/2026"), idproducto, idCliente);
                this.reportViewer1.RefreshReport();


                //this.spbuscar_venta_fechaTableAdapter.Fill(this.dsPrincipal.spbuscar_venta_fecha, Texto, Texto2);
                //this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }


            
            //this.reportViewer2.RefreshReport();
        }
    }
}
