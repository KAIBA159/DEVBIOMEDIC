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


    public partial class ConsultarKardexLote_x_mes : Form , IFormularioReceptorArticulo ,IFormularioReceptorProveedor
    {


        

        public ConsultarKardexLote_x_mes()
        {
            InitializeComponent();
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            /*Reportes.FrmReporteKardexv4xLoteMes frm = new Reportes.FrmReporteKardexv4xLoteMes();


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




            // 🔹 Mes seleccionado
            DateTime fechaSeleccionada = dateTimePicker1.Value;

            DateTime fechaInicio = new DateTime(
                fechaSeleccionada.Year,
                fechaSeleccionada.Month,
                1);

            DateTime fechaFin = fechaInicio
                .AddMonths(1)
                .AddDays(-1);

            // ✅ PASAR FECHAS COMO DateTime
            frm.FechaInicio = fechaInicio;
            frm.FechaFin = fechaFin;

            frm.idproducto = Convert.ToInt32(txt_idproducto.Text);
            frm.idCliente = Convert.ToInt32(txt_idcliente.Text);
            frm.Lote = tbt_lote.Text;

            frm.ShowDialog();*/


            /*
            //ini

            DateTime fechaSeleccionada = dateTimePicker1.Value;

            int mes = fechaSeleccionada.Month;
            int anio = fechaSeleccionada.Year;

            // Primer día del mes
            DateTime fechaInicio = new DateTime(anio, mes, 1);

            // Último día del mes
            DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);


            frm.Texto = Convert.ToString(fechaInicio);
            frm.Texto2 = Convert.ToString(fechaFin);

            //fin


            frm.idproducto = Convert.ToInt32(txt_idproducto.Text);
            frm.idCliente = Convert.ToInt32(txt_idcliente.Text);

            frm.Lote  = tbt_lote.Text;
            

            frm.ShowDialog();*/


            if (cmbMes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un mes.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int mes = ((KeyValuePair<int, string>)cmbMes.SelectedItem).Key;
            int anio = (int)nudAnio.Value;

            // ✅ Primer día del mes
            DateTime fechaInicio = new DateTime(anio, mes, 1);

            // ✅ Último día del mes (forma segura)
            DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);

            // Pasar al reporte
            Reportes.FrmReporteKardexv4xLoteMes frm = new Reportes.FrmReporteKardexv4xLoteMes();

            frm.FechaInicio = fechaInicio;
            frm.FechaFin = fechaFin;

            frm.idproducto = Convert.ToInt32(txt_idproducto.Text);
            frm.idCliente = Convert.ToInt32(txt_idcliente.Text);
            frm.Lote = tbt_lote.Text;

            frm.ShowDialog();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtbox_producto.Text = string.Empty;
            this.txtbox_cliente.Text = string.Empty;
            this.txt_idproducto.Text = string.Empty;
            this.txt_idcliente.Text = string.Empty;

        }

        private void ConsultarKardexLote_Load(object sender, EventArgs e)
        {

            cmbMes.Items.Clear();

            cmbMes.Items.Add(new KeyValuePair<int, string>(1, "Enero"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(2, "Febrero"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(3, "Marzo"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(4, "Abril"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(5, "Mayo"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(6, "Junio"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(7, "Julio"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(8, "Agosto"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(9, "Septiembre"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(10, "Octubre"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(11, "Noviembre"));
            cmbMes.Items.Add(new KeyValuePair<int, string>(12, "Diciembre"));

            cmbMes.DisplayMember = "Value";
            cmbMes.ValueMember = "Key";

            // Mes actual por defecto
            cmbMes.SelectedValue = DateTime.Now.Month;

            // Año
            nudAnio.Minimum = 2000;
            nudAnio.Maximum = 2100;
            nudAnio.Value = DateTime.Now.Year;


        }
    }
}
