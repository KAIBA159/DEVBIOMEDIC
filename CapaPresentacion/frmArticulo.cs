using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaNegocio.NProveedor;

namespace CapaPresentacion
{
    public partial class frmArticulo : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static frmArticulo _Instancia;

        public static frmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmArticulo();
            }
            return _Instancia;
        }

        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdcategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }
        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Artículo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la Imagen del Artículo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la Categoría del Artículo");
            this.ttMensaje.SetToolTip(this.cbIdpresentacion, "Seleccione la presentación del Artículo");

            this.txtIdcategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();


        }

        private void CargarCliente_Proveedor()
        {
            DataTable dt = NCliente_Proveedor.Listar();

            // Agregar fila vacía manualmente
            DataRow fila = dt.NewRow();
            fila["idproveedor"] = 0;
            fila["razon_social"] = "";   // Texto vacío
            dt.Rows.InsertAt(fila, 0);

            cbContribuyente.DataSource = dt;
            cbContribuyente.DisplayMember = "razon_social";
            cbContribuyente.ValueMember = "idproveedor";
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;

            this.txtFabricante.Text = string.Empty;
            this.txtRegistroSanitario.Text = string.Empty;

            this.comboBox1.SelectedValue = 0;


            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;

            this.txtRegistroSanitario.ReadOnly = !valor;
            this.txtFabricante.ReadOnly = !valor;


            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdpresentacion.Enabled = valor;

            this.comboBox1.Enabled = valor;

            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdarticulo.ReadOnly = true;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;

            dataListado.Columns["idclienteProveedor"].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            


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

        }


      


        //Método BuscarNombre
        private void BuscarNombre()
        {

            lblTotal.Text = "Total de Registros: 0 encontrados";


            // ⭐⭐ LIMPIEZA TOTAL ⭐⭐
            dataListado.DataSource = null;
            dataListado.Rows.Clear();
            dataListado.Columns.Clear();
            dataListado.Refresh();
            this.BindingContext = new BindingContext();

            // ===========================================
            // 1. Obtener proveedor desde ComboBox
            // ===========================================

            int? idProveedor = null;

            if (cbContribuyente.SelectedIndex > 0)   // 0 = vacío
            {
                idProveedor = Convert.ToInt32(cbContribuyente.SelectedValue);
            }



            // ===========================================
            // 2. Ejecutar SP según proveedor
            // ===========================================

            if (idProveedor.HasValue)  // Tiene proveedor seleccionado
            {
                this.dataListado.DataSource = NArticulo.BuscarNombre2(
                    this.txtBuscar.Text,
                    idProveedor.Value
                );
            }
            else                      // NO TIENE proveedor → buscar todo
            {
                this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            }

            // ===========================================
            // 3. Formateo de columnas
            // ===========================================


            if (this.dataListado.DataSource != null)
            {
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (col.Width > 300)
                        col.Width = 300;
                }

                this.OcultarColumnas();

                ///////////////////////////////////////////
                //ini adicional
                if (!dataListado.Columns.Contains("Eliminar"))
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "Eliminar";
                    chk.HeaderText = "Eliminar";
                    chk.ReadOnly = false;
                    chk.Visible = false;

                    dataListado.Columns.Insert(0, chk);
                }
                //fin adicional
                ///////////////////////////////////////////


                lblTotal.Text = "Total de Registros: " + dataListado.Rows.Count + " encontrados";
            }




            //this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);



        }

        private void LlenarComboPresentacion()
        {
            cbIdpresentacion.DataSource = NPresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "idpresentacion";
            cbIdpresentacion.DisplayMember = "nombre";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result==DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

            CargarCliente_Proveedor2();

        }

        private void CargarCliente_Proveedor2()
        {
            //idproveedor, razon_social

            //cbContribuyente.DataSource = NCliente_Proveedor.Listar();
            //cbContribuyente.DisplayMember = "razon_social";
            //cbContribuyente.ValueMember = "idproveedor";
            //cbContribuyente.SelectedIndex = -1;


            DataTable dt = NCliente_Proveedor.Listar();

            // Agregar fila vacía manualmente
            DataRow fila = dt.NewRow();
            fila["idproveedor"] = 0;
            fila["razon_social"] = "";   // Texto vacío
            dt.Rows.InsertAt(fila, 0);

            cbContribuyente.DataSource = dt;
            cbContribuyente.DisplayMember = "razon_social";
            cbContribuyente.ValueMember = "idproveedor";

            DataTable dt2 = NCliente_Proveedor.Listar();

            DataRow fila2 = dt2.NewRow();
            fila2["idproveedor"] = 0;
            fila2["razon_social"] = "";   // Texto vacío
            dt2.Rows.InsertAt(fila2, 0);

            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "razon_social";
            comboBox1.ValueMember = "idproveedor";
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                int idProveedor = 0;

                if (cbContribuyente.SelectedIndex > 0)   // 0 = vacío
                {
                    idProveedor = Convert.ToInt32( comboBox1.SelectedValue.ToString()) ;
                }



                if (this.txtNombre.Text == string.Empty || this.txtIdcategoria.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");
                    errorIcono.SetError(txtCategoria, "Ingrese un Valor");

                    errorIcono.SetError(txtFabricante, "Ingrese un Fabricante");
                    errorIcono.SetError(txtRegistroSanitario, "Ingrese un Registro Sanitario");

                }
                else
                {
                    errorIcono.Clear();

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {

                        if (txtCodigo.Text.Trim() != "NO APLICA")
                        {
                            if (NArticulo.ExisteCodigo(txtCodigo.Text.Trim()))
                            {
                                //MessageBox.Show("El código ingresado ya existe. Use uno diferente.");
                                //MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                MessageBox.Show("El código ingresado ya existe. Use uno diferente.", "Sistema de Ventas SAS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }
                        }



                        rpta = NArticulo.Insertar(this.txtCodigo.Text,
                                                    this.txtNombre.Text.Trim().ToUpper(),
                                                    this.txtDescripcion.Text.Trim(),
                                                    imagen, Convert.ToInt32(this.txtIdcategoria.Text),
                                                    Convert.ToInt32(this.cbIdpresentacion.SelectedValue),

                                                    this.txtFabricante.Text.Trim(),
                                                    this.txtRegistroSanitario.Text.Trim(),

                                                   Convert.ToInt32(this.comboBox1.SelectedValue.ToString().Trim())

                                                    );

                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(
                                                    this.txtIdarticulo.Text),
                                                    this.txtCodigo.Text, 
                                                    this.txtNombre.Text.Trim().ToUpper(),
                                                    this.txtDescripcion.Text.Trim(), 
                                                    imagen,
                                                    Convert.ToInt32(this.txtIdcategoria.Text),
                                                    Convert.ToInt32(this.cbIdpresentacion.SelectedValue),

                                                    this.txtFabricante.Text.Trim(),
                                                    this.txtRegistroSanitario.Text.Trim(),
                                                    Convert.ToInt32(this.comboBox1.SelectedValue.ToString().Trim())

                                                    );
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdarticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //cancelado
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            //cancelado

            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            this.txtRegistroSanitario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Registrosanitario"].Value);
            this.txtFabricante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fabricante"].Value);

            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);

            //this.comboBox1.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);


            object valor = this.dataListado.CurrentRow.Cells["idclienteProveedor"].Value;

            if (valor == null || valor == DBNull.Value || valor.ToString() == "" || valor.ToString() == "0")
            {
                comboBox1.SelectedValue = 0;   // Combo queda vacío naturalmente
            }
            else
            {
                comboBox1.SelectedValue = Convert.ToInt32(valor);
            }







            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria"].Value);
            this.cbIdpresentacion.SelectedValue= Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteArticulos frm = new FrmReporteArticulos();
            frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }

        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
