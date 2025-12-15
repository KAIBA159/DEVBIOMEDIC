using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Interfaces;
using System.Diagnostics.Eventing.Reader;

namespace CapaPresentacion
{
    public partial class FrmVistaProveedor_Ingreso : Form
    {

        private IFormularioReceptorProveedor receptor; 
        //public FrmVistaProveedor_Ingreso()
        //{
        //    InitializeComponent();
        //}

        public FrmVistaProveedor_Ingreso(IFormularioReceptorProveedor receptor)
        {
            InitializeComponent();
            this.receptor = receptor;
        }

        private void FrmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();

            //
            if (dataListado != null)
            {
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Limitar el ancho máximo
                    if (col.Width > 300)
                    {
                        col.Width = 300;
                    }
                }


                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            }
            //

            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCodigo()
        {
            this.dataListado.DataSource = NProveedor.BuscarCodigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {

                if (cbBuscar.Text.Equals("Codigo"))
                {
                    this.BuscarCodigo();
                }
                else 
                {
                    this.BuscarNum_Documento();
                }
    
                    
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //FrmIngreso form = FrmIngreso.GetInstancia();
            //string par1, par2;
            //par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            //par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            //form.setProveedor(par1,par2);
            //this.Hide();


            if (this.dataListado.CurrentRow != null)
            {
                string id = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
                string nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);

                receptor.setProovedor(id, nombre); // 👈 Se lo pasas al formulario original
                this.Close(); // o this.Hide();
            }

        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de "ding" al presionar Enter

                // Ejecutar el método de búsqueda directamente
                //Buscar();

                e.SuppressKeyPress = true; // Evita el sonido "ding" de Windows
                btnBuscar.PerformClick();  // Simula hacer clic en el botón Buscar

                // O simular el click del botón Buscar
                // btnBuscar.PerformClick();
            }

        }
    }
}
