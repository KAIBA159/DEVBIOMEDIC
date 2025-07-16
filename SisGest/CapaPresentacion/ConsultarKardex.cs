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


    public partial class ConsultarKardex : Form , IFormularioReceptorArticulo ,IFormularioReceptorProveedor
    {
        public ConsultarKardex()
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

    }
}
