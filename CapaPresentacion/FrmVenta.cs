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
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using static CapaNegocio.NProveedor;

namespace CapaPresentacion
{
    public partial class FrmVenta : Form, IFormularioReceptorProveedor
    {
        private bool IsNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;

        private decimal totalPagado = 0;

        private static FrmVenta _instancia;

        public static FrmVenta GetInstancia()
        {
            if (_instancia==null)
            {
                _instancia = new FrmVenta();
            }
            return _instancia;
        }

        public void setCliente(string idcliente,string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setProovedor(string id, string nombre)
        {
            this.txtIdcliente.Text = id;          // Asegúrate de tener este TextBox
            this.txtCliente.Text = nombre;  // Asegúrate de tener este TextBox
        }
        

        public void setArticulo (string iddetalle_ingreso,string nombre,
            //decimal precio_compra,
            //decimal precio_venta,
            int stock,
            DateTime fecha_vencimiento,string lotet)
        {
            this.txtIdarticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;

            //this.txtPrecio_Compra.Text = Convert.ToString(precio_compra);
            //this.txtPrecio_Venta.Text = Convert.ToString(precio_venta);

            this.txtStock_Actual.Text = Convert.ToString(stock);
            this.dtFecha_Vencimiento.Value = fecha_vencimiento;
            this.txtLote.Text = lotet;
            this.txtCantidad.Text = string.Empty;

        }

        public FrmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente,"Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese una serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese un número del comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la Cantidad del Artículo a Vender");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Artículo");
            this.txtIdcliente.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFecha_Vencimiento.Enabled = false;
            this.txtPrecio_Compra.ReadOnly = true;
            this.txtStock_Actual.ReadOnly = true;
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

            this.dtFecha.Value = DateTime.Now;
            this.dtFecha_Vencimiento.Value = DateTime.Now;
            

            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.llb_estado.Text = "EMITIDO";

            //this.txtGuia_Cliente.Text = string.Empty;
            //this.txtSubCliente.Text = string.Empty;

            this.lblTotal_Pagado.Text = "0,0";
            this.txtIgv.Text = "18";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock_Actual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;

            this.txtGuia_Cliente.Text = string.Empty;
            this.txtSubCliente.Text = string.Empty;
            this.txtLote.Text = string.Empty;
            


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            

            this.txtIdventa.ReadOnly = !valor;

            this.txtIdventa.ReadOnly = true;

            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = true;
            this.txtPrecio_Venta.ReadOnly = !valor;

            //
            this.txtGuia_Cliente.ReadOnly = !valor;
            this.txtSubCliente.ReadOnly = !valor;

            this.txtStock_Actual.ReadOnly = true;
            
            //this.dtFecha_Vencimiento.Enabled = true;

            this.txtDescuento.ReadOnly = !valor;
            this.dtFecha_Vencimiento.Enabled = false;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
           

            if (dataListado.DataSource != null)
            {


                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count) +" recientes " ;

                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Limitar el ancho máximo
                    if (col.Width > 300)
                    {
                        col.Width = 300;
                    }
                }

            }


        }

        //Método BuscarFechas
        private void BuscarFechas()
        {

            lblTotal.Text = "Total de Registros: 0 encontrados";
            // ⭐⭐ LIMPIEZA TOTAL ⭐⭐
            dataListado.DataSource = null;
            dataListado.Rows.Clear();
            dataListado.Columns.Clear();
            dataListado.Refresh();
            this.BindingContext = new BindingContext();


            //-+-------------------------------------------------------------------

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
                this.dataListado.DataSource = NVenta.BuscarFechas3(
                    this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                    this.dtFecha2.Value.ToString("dd/MM/yyyy"),
                    idProveedor.Value
                );
            }
            else                      // NO TIENE proveedor → buscar todo
            {
                this.dataListado.DataSource = NVenta.BuscarFechas2(
                    this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                    this.dtFecha2.Value.ToString("dd/MM/yyyy")
                );
            }

            //-+-------------------------------------------------------------------

            //this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
            //    this.dtFecha2.Value.ToString("dd/MM/yyyy"));




            if (dataListado.DataSource != null)
            {

                //this.OcultarColumnas();
                //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
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


                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);




            }

            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);



        }

        private void BuscarFechas2()
        {

            lblTotal.Text = "Total de Registros: 0 encontrados";


            // ⭐⭐ LIMPIEZA TOTAL ⭐⭐
            dataListado.DataSource = null;
            dataListado.Rows.Clear();
            dataListado.Columns.Clear();
            dataListado.Refresh();
            this.BindingContext = new BindingContext();


            //-+-------------------------------------------------------------------

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
                this.dataListado.DataSource = NVenta.BuscarFechas3(
                    this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                    this.dtFecha2.Value.ToString("dd/MM/yyyy"),
                    idProveedor.Value
                );
            }
            else                      // NO TIENE proveedor → buscar todo
            {
                this.dataListado.DataSource = NVenta.BuscarFechas2(
                    this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                    this.dtFecha2.Value.ToString("dd/MM/yyyy")
                );
            }

            //-+-------------------------------------------------------------------

            //this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
            //    this.dtFecha2.Value.ToString("dd/MM/yyyy"));




            //if (dataListado.DataSource != null)
            //{

            //    //this.OcultarColumnas();
            //    //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            //    this.OcultarColumnas();
            //    lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);


            //    //this.OcultarColumnas();
            //    //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            //}

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
                /////////////////////////////


                lblTotal.Text = "Total de Registros: " + dataListado.Rows.Count + " encontrados";
            }



        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdventa.Text);

            foreach (DataGridViewColumn col in dataListadoDetalle.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Limitar el ancho máximo
                if (col.Width > 300)
                {
                    col.Width = 300;
                }
            }



        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns["iddetalle_ingreso"].ReadOnly = true;
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns["articulo"].ReadOnly = true;


            this.dtDetalle.Columns.Add("guia_remisioncliente", System.Type.GetType("System.String"));
            this.dtDetalle.Columns["guia_remisioncliente"].ReadOnly = true;
            this.dtDetalle.Columns.Add("subcliente", System.Type.GetType("System.String"));
            this.dtDetalle.Columns["subcliente"].ReadOnly = true;

            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns["cantidad"].ReadOnly = true;

            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["precio_venta"].ReadOnly = true;
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["descuento"].ReadOnly = true;
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["subtotal"].ReadOnly = true;
            this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["Impuesto"].ReadOnly = true;


            this.dtDetalle.Columns.Add("lote", System.Type.GetType("System.String"));
            this.dtDetalle.Columns["lote"].ReadOnly = true;


            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;


            this.dataListadoDetalle.Columns["iddetalle_ingreso"].HeaderText = "iddetalle_ingreso";
            this.dataListadoDetalle.Columns["articulo"].HeaderText = "Nombre de Producto";
            this.dataListadoDetalle.Columns["guia_remisioncliente"].HeaderText = "Guía Cliente";
            this.dataListadoDetalle.Columns["subcliente"].HeaderText = "Subcliente";
            this.dataListadoDetalle.Columns["lote"].HeaderText = "Lote";
            this.dataListadoDetalle.Columns["cantidad"].HeaderText = "Cantidad";


            //ocultar
            this.dataListadoDetalle.Columns["Impuesto"].Visible = false;
            this.dataListadoDetalle.Columns["subtotal"].Visible = false;

            this.dataListadoDetalle.Columns["precio_venta"].Visible = false;
            this.dataListadoDetalle.Columns["descuento"].Visible = false;

            //this.dtDetalle.Columns.Add("guia_remisioncliente", System.Type.GetType("System.String"));


        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();

            CargarCliente_Proveedor();

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


        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //FrmVistaCliente_Venta vista = new FrmVistaCliente_Venta();
            //vista.ShowDialog();

            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso(this);
            vista.ShowDialog();

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {

            if (this.txtIdcliente.Text.Trim() == string.Empty || this.txtCliente.Text == string.Empty)
            {
                MessageBox.Show("Se debe escoger un cliente/proveedor antes de escoger un articulo/producto ", "Sistema de Gestión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                FrmVistaArticulo_Venta vista = new FrmVistaArticulo_Venta(this.txtIdcliente.Text);
                vista.ShowDialog();
            }
                


           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //this.BuscarFechas();

            this.BuscarFechas2();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            try
            {
                // 1. Obtener los IDs seleccionados
                List<int> idsSeleccionados = new List<int>();
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    bool seleccionado = false;
                    if (row.Cells[0].Value != null)
                        seleccionado = Convert.ToBoolean(row.Cells[0].Value);

                    if (seleccionado)
                    {
                        idsSeleccionados.Add(Convert.ToInt32(row.Cells[1].Value)); // idventa
                    }
                }

                if (idsSeleccionados.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos una salida para anular.",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                // 2. Confirmación
                DialogResult confirm = MessageBox.Show(
                    $"Se anularán {idsSeleccionados.Count} salidas seleccionadas.\n¿Desea continuar?",
                    "Confirmación de anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                // 3. Llamar a la capa de negocio
                string rpta = NVenta.AnularEnBloque(idsSeleccionados);

                if (rpta.Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Se anularon correctamente las salidas seleccionadas.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Mostrar(); // Recargar la grilla
                }
                else
                {
                    MessageBox.Show("No se anuló ninguna salida. Detalle: " + rpta,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }




            //try
            //{
            //    DialogResult Opcion;
            //    Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Gestión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //    if (Opcion == DialogResult.OK)
            //    {
            //        string Codigo;
            //        string Rpta = "";

            //        foreach (DataGridViewRow row in dataListado.Rows)
            //        {
            //            if (Convert.ToBoolean(row.Cells[0].Value))
            //            {
            //                Codigo = Convert.ToString(row.Cells[1].Value);
            //                Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

            //                if (Rpta.Equals("OK"))
            //                {
            //                    this.MensajeOk("Se Eliminó Correctamente la salida");
            //                }
            //                else
            //                {
            //                    this.MensajeError(Rpta);
            //                }

            //            }
            //        }
            //        this.Mostrar();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + ex.StackTrace);
            //}
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            // cacnelar evento
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
            //


            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            //this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            //this.txtIgv.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuesto"].Value);

            this.llb_estado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["estado"].Value);

            if (Convert.ToString(this.dataListado.CurrentRow.Cells["estado"].Value) == "ANULADO")
            {
                llb_estado.ForeColor = Color.Red;
            }
            else
            {
                llb_estado.ForeColor = Color.Black; // o el color que quieras cuando no cumple
            }


            this.MostrarDetalle();
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();

            // obtener  id siguiente

            int proximoCodigo = NVenta.ObtenerProximoCodigoSistema();
            txtIdventa.Text = proximoCodigo.ToString();

            //

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();

                string rpta = "";
                if (
                    this.txtIdcliente.Text == string.Empty || 
                    this.txtSerie.Text == string.Empty || 
                    this.txtCorrelativo.Text == string.Empty || 
                    this.txtIgv.Text == string.Empty

                    )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");

                


                }
                else
                {
                    if (dtDetalle != null && dtDetalle.Rows.Count > 0)
                    {
                        errorIcono.Clear();

                        if (this.IsNuevo)
                        {
                            rpta = NVenta.Insertar(
                                Convert.ToInt32(this.txtIdcliente.Text), 
                                Idtrabajador,
                                dtFecha.Value, 
                                cbTipo_Comprobante.Text,
                                txtSerie.Text, 
                                txtCorrelativo.Text,
                                Convert.ToDecimal(txtIgv.Text),

                                llb_estado.Text,


                                dtDetalle);

                        }


                        if (rpta.Equals("OK"))
                        {
                            if (this.IsNuevo)
                            {
                                this.MensajeOk("Se Insertó de forma correcta el registro");
                            }


                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.IsNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.limpiarDetalle();
                        this.Mostrar();


                    }
                    else
                    {
                        errorIcono.SetError(dataListadoDetalle, "Ingrese un valor al Detalle ");
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();

                this.txtDescuento.Text = "0";

                if (this.txtIdarticulo.Text == string.Empty 
                    || this.txtCantidad.Text == string.Empty

                    //|| this.txtDescuento.Text == string.Empty
                    //|| this.txtPrecio_Venta.Text == string.Empty

                    || this.txtGuia_Cliente.Text == string.Empty 
                    || this.txtSubCliente.Text == string.Empty

                    )
                {

                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    //errorIcono.SetError(txtDescuento, "Ingrese un Valor");
                    //errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");

                    errorIcono.SetError(txtGuia_Cliente, "Ingrese una Guia de Cliente");
                    errorIcono.SetError(txtSubCliente, "Ingrese un SubCliente");

                }
                else
                {
                    bool registrar = true;


                    //foreach (DataRow row in dtDetalle.Rows)
                    //{
                    //    if (Convert.ToInt32(row["iddetalle_ingreso"])==Convert.ToInt32(this.txtIdarticulo.Text))
                    //    {
                    //        registrar = false;
                    //        this.MensajeError("Ya se encuentra el artículo en el detalle");
                    //    }
                    //}


                    if (registrar && Convert.ToInt32(txtCantidad.Text)<=Convert.ToInt32(txtStock_Actual.Text))
                    {
                        this.txtPrecio_Venta.Text = "1";
                        this.txtDescuento.Text = "1";

                        decimal subTotal=Convert.ToDecimal(this.txtCantidad.Text)*Convert.ToDecimal(this.txtPrecio_Venta.Text)-Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;

                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");



                        //INI
                        string txtIdarticuloTemp = this.txtIdarticulo.Text;
                        // Leer datos de la interfaz
                        int idDetalleIngreso = Convert.ToInt32(txtIdarticuloTemp.Trim());
                        //string producto = txtProducto.Text.Trim();
                        int cantidadNueva = Convert.ToInt32(txtCantidad.Text.Trim());

                        // Stock disponible desde base de datos o lógica interna
                        int stockDisponible = ObtenerStockDisponible(idDetalleIngreso);

                        // Sumar lo que ya está en el DataGridView para este idDetalleIngreso
                        int cantidadAcumulada = 0;
                        foreach (DataGridViewRow row2 in dataListadoDetalle.Rows)
                        {
                            if (row2.Cells["iddetalle_ingreso"].Value != null &&
                                Convert.ToInt32(row2.Cells["iddetalle_ingreso"].Value) == idDetalleIngreso)
                            {
                                cantidadAcumulada += Convert.ToInt32(row2.Cells["cantidad"].Value);
                            }
                        }

                        // Validar antes de agregar
                        if (cantidadAcumulada + cantidadNueva > stockDisponible)
                        {
                            MessageBox.Show(
                                $"No hay stock suficiente.\n" +
                                $"Stock disponible: {stockDisponible}\n" +
                                $"Ya agregado: {cantidadAcumulada}\n" +
                                $"Intentas agregar: {cantidadNueva}",
                                "Stock insuficiente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }



                        //FIN



                        //Agregar ese detalle al datalistadoDetalle

                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);

                        row["guia_remisioncliente"] = Convert.ToString(this.txtGuia_Cliente.Text);
                        row["subcliente"] = Convert.ToString(this.txtSubCliente.Text);

                        row["lote"] = Convert.ToString(this.txtLote.Text);

                        //errorIcono.SetError(txtGuia_Cliente, "Ingrese una Guia de Cliente");
                        //errorIcono.SetError(txtSubCliente, "Ingrese un SubCliente");


                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay Stock Suficiente");
                    }

                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private int ObtenerStockDisponible(int idDetalleIngreso)
        {
            int stokc_disponible = 0;
            stokc_disponible = NVenta.consultarStockIddetalle_ingreso(idDetalleIngreso);

            return stokc_disponible;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();

            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            
            FrmReporteFactura frm = new FrmReporteFactura();
            frm.Idventa = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ////Reportes.FrmReporteVentas frm = new Reportes.FrmReporteVentas();

            ////frm.Texto = Convert.ToString(dtFecha1.Value);
            ////frm.Texto2 = Convert.ToString(dtFecha2.Value);

            ////frm.ShowDialog();

            Reportes.FrmReporteVentas frm = new Reportes.FrmReporteVentas();

            // Fechas
            frm.Texto = dtFecha1.Value.ToString("dd/MM/yyyy");
            frm.Texto2 = dtFecha2.Value.ToString("dd/MM/yyyy");

            // Proveedor (0 o null → TODOS)
            int? idProveedor = null;

            if (cbContribuyente.SelectedValue != null)
            {
                idProveedor = Convert.ToInt32(cbContribuyente.SelectedValue); // puede ser 0
            }

            frm.IdProveedor = idProveedor;

            frm.ShowDialog();

            //////////////////////////////


        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

            // Cada vez que el contenido de txtCliente varíe, ejecutamos la limpieza
            LimpiarCamposProducto();

        }

        // Método para limpiar los campos específicos del producto
        private void LimpiarCamposProducto()
        {
            txtArticulo.Text = string.Empty;
            txtStock_Actual.Text = string.Empty;
            txtLote.Text = string.Empty;

            // Opcional: Si manejas una variable interna para el ID del producto, 
            // también deberías resetearla aquí.
        }
    }
}
