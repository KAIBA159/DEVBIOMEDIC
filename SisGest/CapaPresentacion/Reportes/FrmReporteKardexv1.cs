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


    public partial class FrmReporteKardexv1 : Form
    {

        private String _Texto;
        private String _Texto2;
        private int _idproducto;
        private int _idCliente;

        public String Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }
        public String Texto2
        {
            get { return _Texto2; }
            set { _Texto2 = value; }
        }

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

        public FrmReporteKardexv1()
        {
            InitializeComponent();
        }

        private void FrmReporteKardexv1_Load(object sender, EventArgs e)
        {

           

            try
            {
                //exec sp_kardex_producto '01/01/2025','01/08/2026',1008,'REG11008', 1003

                //this.sp_kardex_productoTableAdapter.Fill(this.dsPrincipal.spbuscar_venta_fecha, Texto, Texto2);
                //this.sp_kardex_productoTableAdapter.Fill(this.dsPrincipal.sp_kardex_producto, Convert.ToDateTime( "01/01/2025"), Convert.ToDateTime("01/08/2026") , 1008, 1003);
                this.sp_kardex_productoTableAdapter.Fill(this.dsPrincipal.sp_kardex_producto, Convert.ToDateTime(Texto), Convert.ToDateTime(Texto2), idproducto, idCliente);
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
