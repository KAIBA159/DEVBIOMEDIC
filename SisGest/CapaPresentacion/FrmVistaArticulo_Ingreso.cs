using CapaNegocio;
using CapaPresentacion.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVistaArticulo_Ingreso : Form
    {
        private IFormularioReceptorArticulo receptor;

        //public FrmVistaArticulo_Ingreso()
        //{
        //    InitializeComponent();
        //}

        public FrmVistaArticulo_Ingreso(IFormularioReceptorArticulo receptor)
        {
            InitializeComponent();
            this.receptor = receptor;
        }

        private void FrmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (dataListado != null)
            {
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Limitar el ancho máximo
                    if (col.Width > 50)
                    {
                        col.Width = 50;
                    }
                }


                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            }


        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //FrmIngreso form = FrmIngreso.GetInstancia();
            //string par1, par2;
            //par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            //par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            //form.setArticulo(par1,par2);
            //this.Hide();

            if (this.dataListado.CurrentRow != null)
            {
                string id = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
                string nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);

                receptor.setArticulo(id, nombre); // 👈 Se lo pasas al formulario original
                this.Close(); // o this.Hide();
            }

        }
    }
}
