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
    public partial class FrmReporteKardexv3xFabricante : Form
    {

        private DateTime _Inicio;
        private DateTime _Fin;
        private int _idproducto;
        private int _idCliente;


        private String _Texto;
        private String _Texto2;

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


        public int idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public FrmReporteKardexv3xFabricante()
        {
            InitializeComponent();
        }

        private void FrmReporteKardexv3xFabricante_Load(object sender, EventArgs e)
        {
            

            try
            {
                this.sp_kardex_resumen_por_fabricanteTableAdapter.Connection = Conexion.CrearConexion();

                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_kardex_resumen_por_fabricante' Puede moverla o quitarla según sea necesario.
                this.sp_kardex_resumen_por_fabricanteTableAdapter.Fill(this.dsPrincipal.sp_kardex_resumen_por_fabricante, Convert.ToDateTime(Texto), Convert.ToDateTime(Texto2), idCliente);
                //this.sp_kardex_producto_x_loteTableAdapter.Fill(this.dsPrincipal.sp_kardex_producto_x_lote, Lote, idproducto, idCliente);

                this.reportViewer1.RefreshReport();

            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
                //throw;
            }
        }
    }
}
