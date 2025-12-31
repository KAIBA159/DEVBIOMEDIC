using BCrypt.Net;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CapaPresentacion
{

    
        
    

    public partial class frmLogin : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public const string VersionSW = "v1.0.9";
        public const string NombreApp = "Sistema de Gestion - SAS";

        public frmLogin()
        {
            XmlConfigurator.Configure();

            log.Debug("Mensaje de depuración");

            

            InitializeComponent();

            this.label4.Text = VersionSW;

            LblHora.Text = DateTime.Now.ToString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool EsHashBCrypt(string hash)
        {
            return hash.StartsWith("$2a$") || hash.StartsWith("$2b$") || hash.StartsWith("$2y$");
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            string usuarioIngresado = this.TxtUsuario.Text.Trim();
            string passwordIngresado = this.TxtPassword.Text;

            // Paso 1: Obtener los datos del usuario desde la base de datos
            DataTable Datos = CapaNegocio.NTrabajador.Login(usuarioIngresado);

            // Paso 2: Validar si el usuario existe
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("Usuario no encontrado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Paso 3: Obtener el hash (o texto plano) guardado en la base de datos
            string passwordAlmacenado = Datos.Rows[0]["password"].ToString();
            bool accesoPermitido = false;

            try
            {
                // Paso 4-A: Intentar verificar con BCrypt
                accesoPermitido = BCrypt.Net.BCrypt.Verify(passwordIngresado, passwordAlmacenado);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // Paso 4-B: Si falla el formato del hash, asumimos que es texto plano
                accesoPermitido = passwordIngresado == passwordAlmacenado;

                // Si coincide en texto plano, actualizamos el password en la BD con hash
                if (accesoPermitido)
                {
                    string nuevoHash = BCrypt.Net.BCrypt.HashPassword(passwordIngresado);
                    CapaNegocio.NTrabajador.ActualizarPassword(usuarioIngresado, nuevoHash);
                }
            }

            if (!accesoPermitido)
            {
                MessageBox.Show("Contraseña incorrecta", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Paso 5: Acceso correcto → Abrir el formulario principal
            frmPrincipal frm = new frmPrincipal();
            frm.Idtrabajador = Datos.Rows[0]["idtrabajador"].ToString();
            frm.Apellidos = Datos.Rows[0]["apellidos"].ToString();
            frm.Nombre = Datos.Rows[0]["nombre"].ToString();
            frm.Acceso = Datos.Rows[0]["acceso"].ToString();
            frm.Version = VersionSW;

            frm.Show();
            this.Hide();

            //VersionSW


            //DataTable Datos = CapaNegocio.NTrabajador.Login(this.TxtUsuario.Text,this.TxtPassword.Text);
            ////Evaluar si existe el Usuario
            //if (Datos.Rows.Count==0)
            //{
            //    MessageBox.Show("NO Tiene Acceso al Sistema","Sistema de Ventas",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
            //else
            //{
            //    frmPrincipal frm = new frmPrincipal();
            //    frm.Idtrabajador = Datos.Rows[0][0].ToString();
            //    frm.Apellidos = Datos.Rows[0][1].ToString();
            //    frm.Nombre = Datos.Rows[0][2].ToString();
            //    frm.Acceso = Datos.Rows[0][3].ToString();

            //    frm.Show();
            //    this.Hide();

            //}




        }


        

    }
}
