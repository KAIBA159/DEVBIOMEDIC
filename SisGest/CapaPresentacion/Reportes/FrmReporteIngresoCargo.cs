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
    public partial class FrmReporteIngresoCargo  : Form
    {
        private String _Texto;
        private String _Texto2;
        private int _idingreso;

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

        public int idingreso
        {
            get { return _idingreso; }
            set { _idingreso = value; }
        }


        public FrmReporteIngresoCargo()
        {
            InitializeComponent();
        }

        private void FrmReporteIngresoCargo_Load(object sender, EventArgs e)
        {

            try
            {
                this.dsPrincipal.EnforceConstraints = false;
                //this.spbuscar_ingreso_fechaTableAdapter.Fill(this.dsPrincipal.spbuscar_ingreso_fecha, Texto,Texto2);
                this.spbuscar_ingresoCargoTableAdapter.Fill(this.dsPrincipal.spbuscar_ingresoCargo, idingreso);

                this.dsPrincipal.EnforceConstraints = true;

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
