using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Interfaces;


namespace CapaPresentacion
{
    //namespace CapaPresentacion.Interfaces
    //{
    //    public interface IFormularioReceptorArticulo
    //    {
    //        void setArticulo(string id, string nombre);
    //    }
    //}


    public partial class ConsultarKardexLote : Form , IFormularioReceptorArticulo ,IFormularioReceptorProveedor
    {
        public ConsultarKardexLote()
        {
            InitializeComponent();
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ck_btnclic_event(object sender, EventArgs e)
        {

            Reportes.FrmReporteKardexv1 frm = new Reportes.FrmReporteKardexv1();
            frm.Texto = Convert.ToString(dtp_desde.Value);
            frm.Texto2 = Convert.ToString(dtp_hasta.Value);
            frm.ShowDialog();

            //Reportes.FrmReporteVentas frm = new Reportes.FrmReporteVentas();
            //frm.Texto = Convert.ToString(dtp_desde.Value);
            //frm.Texto2 = Convert.ToString(dtp_hasta.Value);
            //frm.ShowDialog();



        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ingreso vista = new FrmVistaArticulo_Ingreso(this);
            vista.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso(this);
            vista.ShowDialog();
        }

        public void setArticulo(string id, string nombre)
        {
            txtbox_producto.Text = nombre;
            txt_idproducto.Text  = id;
        }

        public void setProovedor(string id, string nombre)
        {
            this.txt_idcliente .Text = id;          // Asegúrate de tener este TextBox
            this.txtbox_cliente.Text = nombre;  // Asegúrate de tener este TextBox
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteKardexv2xLote frm = new Reportes.FrmReporteKardexv2xLote();


            //frm.Texto = Convert.ToString(dtp_desde.Value);
            //frm.Texto2 = Convert.ToString(dtp_hasta.Value);

            if (txtbox_producto.Text ==string.Empty)
            {
                //MessageBox.Show(      ("Falta ingresar algunos datos, serán remarcados");
                MessageBox.Show("Escoger Producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtbox_cliente.Text == string.Empty)
            {
                //MessageBox.Show(      ("Falta ingresar algunos datos, serán remarcados");
                MessageBox.Show("Escoger Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbt_lote.Text == string.Empty)
            {
                //MessageBox.Show(      ("Falta ingresar algunos datos, serán remarcados");
                MessageBox.Show("Escoger Lote.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frm.idproducto = Convert.ToInt32(txt_idproducto.Text);
            frm.idCliente = Convert.ToInt32(txt_idcliente.Text);

            frm.Lote  = tbt_lote.Text;
            

            frm.ShowDialog();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtbox_producto.Text = string.Empty;
            this.txtbox_cliente.Text = string.Empty;
            this.txt_idproducto.Text = string.Empty;
            this.txt_idcliente.Text = string.Empty;

        }
    }
}
