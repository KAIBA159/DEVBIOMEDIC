using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public class SunatDLv3
    {

        public string contenidoHTML;

        public async Task<string> ExtraerDatosAsync(string RUC, string tipdoc)
        {

            int tipoRespuesta = 2;
            string mensajeRespuesta = "";

            CuTexto oCuTexto = new CuTexto();

            Stopwatch oCronometro = new Stopwatch();
            oCronometro.Start();

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler controladorMensaje = new HttpClientHandler();
            controladorMensaje.CookieContainer = cookies;
            controladorMensaje.UseCookies = true;
            using (HttpClient cliente = new HttpClient(controladorMensaje))
            {
                cliente.DefaultRequestHeaders.Add("Host", "e-consultaruc.sunat.gob.pe");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua",
                    " \" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                cliente.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                        SecurityProtocolType.Tls12;
                await Task.Delay(100);

                string url =
                        "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias";
                using (HttpResponseMessage resultadoConsulta = await cliente.GetAsync(new Uri(url)))
                {
                    if (resultadoConsulta.IsSuccessStatusCode)
                    {
                        await Task.Delay(100);
                        cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                        cliente.DefaultRequestHeaders.Add("Origin", "https://e-consultaruc.sunat.gob.pe");
                        cliente.DefaultRequestHeaders.Add("Referer", url);
                        cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                        string numeroDNI = "12345678"; // cualquier número DNI que exista en SUNAT. Pueden aprovechar este "bug" para consultar también mediante DNI a la SUNAT

                        if (tipdoc == "4")
                        {
                            numeroDNI = RUC;
                        }

                        var lClaveValor = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("accion", "consPorTipdoc"),
                        new KeyValuePair<string, string>("razSoc", ""),
                        new KeyValuePair<string, string>("nroRuc", ""),
                        new KeyValuePair<string, string>("nrodoc", numeroDNI),
                        new KeyValuePair<string, string>("contexto", "ti-it"),
                        new KeyValuePair<string, string>("modo", "1"),
                        new KeyValuePair<string, string>("search1", ""),
                        new KeyValuePair<string, string>("rbtnTipo", "2"),
                        new KeyValuePair<string, string>("tipdoc",(tipdoc == "6") ? "1": tipdoc),
                        new KeyValuePair<string, string>("search2", numeroDNI),
                        new KeyValuePair<string, string>("search3", ""),
                        new KeyValuePair<string, string>("codigo", ""),
                    };
                        FormUrlEncodedContent contenido = new FormUrlEncodedContent(lClaveValor);

                        url = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias";
                        using (HttpResponseMessage resultadoConsultaRandom = await cliente.PostAsync(url, contenido))
                        {
                            if (resultadoConsultaRandom.IsSuccessStatusCode)
                            {
                                await Task.Delay(100);
                                contenidoHTML = await resultadoConsultaRandom.Content.ReadAsStringAsync();
                                string numeroRandom = oCuTexto.ExtraerContenidoEntreTagString(contenidoHTML, 0, "name=\"numRnd\" value=\"", "\">");

                                if (tipdoc == "4")
                                {
                                    RUC = oCuTexto.ExtraerContenidoEntreTagString(contenidoHTML, 0, "data-ruc=\"", "\">");
                                }

                                lClaveValor = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("accion", "consPorRuc"),
                                new KeyValuePair<string, string>("actReturn", "1"),
                                new KeyValuePair<string, string>("nroRuc", RUC),
                                new KeyValuePair<string, string>("numRnd", numeroRandom),
                                new KeyValuePair<string, string>("modo", "1")
                            };
                                // Por si cae en el primer intento por el código "Unauthorized", en el buble se va a intentar hasta 3 veces "nConsulta"
                                int cConsulta = 0;
                                int nConsulta = 3;
                                HttpStatusCode codigoEstado = HttpStatusCode.Unauthorized;
                                while (cConsulta < nConsulta && codigoEstado == HttpStatusCode.Unauthorized)
                                {
                                    contenido = new FormUrlEncodedContent(lClaveValor);
                                    using (HttpResponseMessage resultadoConsultaDatos =
                                    await cliente.PostAsync(url, contenido))
                                    {
                                        codigoEstado = resultadoConsultaDatos.StatusCode;
                                        if (resultadoConsultaDatos.IsSuccessStatusCode)
                                        {
                                            contenidoHTML = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                            contenidoHTML = WebUtility.HtmlDecode(contenidoHTML);

                                        }
                                        else
                                        {
                                            mensajeRespuesta = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                            mensajeRespuesta =
                                                string.Format(
                                                    "Ocurrió un inconveniente al consultar los datos del RUC {0}.\r\nDetalle:{1}",
                                                    RUC, mensajeRespuesta);
                                        }
                                    }

                                    cConsulta++;
                                }

                            }
                            else
                            {
                                mensajeRespuesta = await resultadoConsultaRandom.Content.ReadAsStringAsync();
                                mensajeRespuesta =
                                    string.Format(
                                        "Ocurrió un inconveniente al consultar el número random del RUC {0}.\r\nDetalle:{1}",
                                        RUC, mensajeRespuesta);
                            }
                        }
                    }
                    else
                    {
                        mensajeRespuesta = await resultadoConsulta.Content.ReadAsStringAsync();
                        mensajeRespuesta =
                            string.Format(
                                "Ocurrió un inconveniente al consultar la página principal {0}.\r\nDetalle:{1}",
                                RUC, mensajeRespuesta);
                    }
                }
            }

            oCronometro.Stop();


            return contenidoHTML;
        }

        //public Contribuyente ObtenerDatos(string Ruc, string tipdoc)
        public async Task<Contribuyente> ObtenerDatosAsync(string Ruc, string tipdoc)
        {
            Contribuyente contrib = new Contribuyente();
            try
            {
                //var myTask = ExtraerDatosAsync(Ruc, tipdoc);
                ////string result = myTask.Result;
                //string result = myTask.GetAwaiter().GetResult();

                string result = await ExtraerDatosAsync(Ruc, tipdoc);

                CuTexto oCuTexto = new CuTexto();

                string nombreInicio = "<HEAD><TITLE>";
                string nombreFin = "</TITLE></HEAD>";
                string contenidoBusqueda = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
                if (contenidoBusqueda == ".:: Pagina de Mensajes ::.")
                {
                    nombreInicio = "<p class=\"error\">";
                    nombreFin = "</p>";
                    contrib.TipoRespuesta = 2;
                    contrib.Mensaje = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
                }
                else if (contenidoBusqueda == ".:: Pagina de Error ::.")
                {
                    nombreInicio = "<p class=\"error\">";
                    nombreFin = "</p>";
                    contrib.TipoRespuesta = 3;
                    contrib.Mensaje = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
                }
                else
                {
                    contrib.TipoRespuesta = 2;
                    nombreInicio = "<div class=\"list-group\">";
                    nombreFin = "<div class=\"panel-footer text-center\">";
                    contenidoBusqueda = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
                    if (contenidoBusqueda == "")
                    {
                        nombreInicio = "<strong>";
                        nombreFin = "</strong>";
                        contrib.Mensaje = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
                        if (contrib.Mensaje == "")
                            contrib.Mensaje = "No se encuentra las cabeceras principales del contenido HTML";
                    }
                    else
                    {
                        result = contenidoBusqueda;
                        contrib.Mensaje = "Mensaje del inconveniente no especificado";
                        nombreInicio = "<h4 class=\"list-group-item-heading\">";
                        nombreFin = "</h4>";
                        int resultadoBusqueda = result.IndexOf(nombreInicio, 0, StringComparison.OrdinalIgnoreCase);
                        if (resultadoBusqueda > -1)
                        {
                            // Modificar cuando el estado del Contribuyente es "BAJA DE OFICIO", porque se agrega un elemento con clase "list-group-item"
                            resultadoBusqueda += nombreInicio.Length;
                            string[] arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, resultadoBusqueda,
                                nombreInicio, nombreFin);

                            string razon = "";
                            if (arrResultado != null)
                            {
                                contrib.RUC = arrResultado[1].Substring(0, 11);
                                string[] razonsoc = arrResultado[1].Split('-');

                                for (int i = 1; i < razonsoc.Length; i++)
                                {
                                    if (i == 1)
                                    {
                                        razon += razonsoc[i];
                                    }
                                    else
                                    {
                                        razon += "-" + razonsoc[i];
                                    }
                                }

                                //contrib.Razon = "’" + razon;
                                contrib.Razon = razon.Replace("\u0092", "’");

                                contrib.TipoDoc = (contrib.RUC.Substring(0, 1).ToString() == "1") ? "DNI" : "";
                                contrib.NumDoc = (contrib.TipoDoc == "DNI") ? contrib.RUC.Substring(2, 8) : "";


                                // Tipo Contribuyente
                                nombreInicio = "<p class=\"list-group-item-text\">";
                                nombreFin = "</p>";
                                arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                    nombreInicio, nombreFin);
                                if (arrResultado != null)
                                {
                                    contrib.Tipo = arrResultado[1];
                                    try
                                    {
                                        contrib.TieneNegocio = (contrib.Tipo.Substring(16, 11).ToString() == "CON NEGOCIO") ? "Y" : "N";
                                    }
                                    catch (Exception)
                                    {

                                        contrib.TieneNegocio = "N";
                                    }

                                    // Nombre Comercial
                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                        nombreInicio, nombreFin);
                                    if (arrResultado != null)
                                    {
                                        if (contrib.TipoDoc != "DNI")
                                        {
                                            contrib.NombreComercial = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();
                                        }

                                        // Fecha de Inscripción
                                        arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                            nombreInicio, nombreFin);
                                        if (arrResultado != null)
                                        {
                                            //oEnSUNAT.f = arrResultado[1];

                                            // Fecha de Inicio de Actividades: 
                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                nombreInicio, nombreFin);
                                            if (arrResultado != null)
                                            {
                                                // oEnSUNAT.FechaInicioActividades = arrResultado[1];

                                                // Estado del Contribuyente                                               

                                                if (Ruc.Substring(0, 2) == "10")
                                                {
                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, 3101,
                                                    nombreInicio, nombreFin);


                                                }
                                                else
                                                {
                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                    nombreInicio, nombreFin);
                                                }

                                                if (arrResultado != null)
                                                {
                                                    contrib.Estado = arrResultado[1].Trim();

                                                    // Condición del Contribuyente


                                                    if (Ruc.Substring(0, 2) == "10")
                                                    {
                                                        arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, 3728,
                                                        nombreInicio, nombreFin);
                                                    }
                                                    else
                                                    {
                                                        arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                        nombreInicio, nombreFin);
                                                    }

                                                    if (arrResultado != null)
                                                    {
                                                        string[] stringSeparators = new string[] { "\r\n\t\t" };
                                                        string[] condicionLines = arrResultado[1].Trim().Split(stringSeparators, StringSplitOptions.None);
                                                        contrib.Condicion = condicionLines[0].Trim();

                                                        // Domicilio Fiscal
                                                        if (Ruc.Substring(0, 2) == "10")
                                                        {
                                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, 4048,
                                                            nombreInicio, nombreFin);
                                                        }
                                                        else
                                                        {
                                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                            nombreInicio, nombreFin);
                                                        }

                                                        if (arrResultado != null)
                                                        {
                                                            contrib.Direccion = arrResultado[1].Trim();
                                                            Ciudad(ref contrib, contrib.Direccion);

                                                            // Actividad(es) Económica(s)
                                                            nombreInicio = "<tbody>";
                                                            nombreFin = "</tbody>";
                                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                                nombreInicio, nombreFin);
                                                            if (arrResultado != null)
                                                            {
                                                                //oEnSUNAT.ActividadesEconomicas = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();

                                                                // Comprobantes de Pago c/aut. de impresión (F. 806 u 816)
                                                                arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                                    nombreInicio, nombreFin);
                                                                if (arrResultado != null)
                                                                {
                                                                    //  oEnSUNAT.ComprobantesPago = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();

                                                                    // Sistema de Emisión Electrónica
                                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                                        nombreInicio, nombreFin);
                                                                    if (arrResultado != null)
                                                                    {
                                                                        // oEnSUNAT.SistemaEmisionComprobante = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();

                                                                        // Afiliado al PLE desde
                                                                        nombreInicio = "<p class=\"list-group-item-text\">";
                                                                        nombreFin = "</p>";
                                                                        arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                                            nombreInicio, nombreFin);
                                                                        if (arrResultado != null)
                                                                        {
                                                                            // oEnSUNAT.AfiliadoPLEDesde = arrResultado[1];

                                                                            // Padrones 
                                                                            nombreInicio = "<tbody>";
                                                                            nombreFin = "</tbody>";
                                                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
                                                                                nombreInicio, nombreFin);
                                                                            if (arrResultado != null)
                                                                            {
                                                                                nombreInicio = "<tr>";
                                                                                nombreFin = "</tr>";
                                                                                string[] values = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Split(new string[] { "<tr>", "</tr>", "<td>", "</td>" }, StringSplitOptions.RemoveEmptyEntries);

                                                                                foreach (var value in values)
                                                                                {
                                                                                    if (value.Contains("Excluido") && value.Contains("Retención"))
                                                                                    {
                                                                                        contrib.Retencion = "NO";
                                                                                    }

                                                                                    if (value.Contains("Incorporado") && value.Contains("Retención"))
                                                                                    {
                                                                                        contrib.Retencion = "SI";
                                                                                    }

                                                                                    if (value.Contains("Excluido") && value.Contains("Percepción"))
                                                                                    {
                                                                                        contrib.Percepcion = "NO";
                                                                                    }

                                                                                    if (value.Contains("Incorporado") && value.Contains("Percepción"))
                                                                                    {
                                                                                        contrib.Percepcion = "SI";
                                                                                    }
                                                                                    if (value.Contains("Incorporado") && value.Contains("Buenos Contribuyentes"))
                                                                                    {
                                                                                        contrib.BuenContribuyente = "SI";
                                                                                    }
                                                                                }
                                                                                if (string.IsNullOrEmpty(contrib.Percepcion))
                                                                                    contrib.Percepcion = "NO";

                                                                                if (string.IsNullOrEmpty(contrib.Retencion))
                                                                                    contrib.Retencion = "NO";

                                                                                if (string.IsNullOrEmpty(contrib.BuenContribuyente))
                                                                                    contrib.BuenContribuyente = "NO";

                                                                                //contrib.BuenContribuyente = (arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Contains("Buenos Contribuyentes")) ? "SI" : "NO";
                                                                                //contrib.Retencion = (arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Contains("Retención")) ? "SI" : "NO";
                                                                                //contrib.Percepcion = (arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Contains("Percepción")) ? "SI" : "NO";
                                                                            }
                                                                            else
                                                                            {
                                                                                contrib.BuenContribuyente = "NO";
                                                                                contrib.Retencion = "NO";
                                                                                contrib.Percepcion = "NO";
                                                                            }
                                                                        }

                                                                        contrib.TipoRespuesta = 1;
                                                                        contrib.Mensaje = "";
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                contrib.Mensaje = ex.Message;
            }

            return contrib;
        }

        public void Ciudad(ref Contribuyente contrib, string Direccion)
        {
            if (Direccion.Length < 2)
            {
                contrib.Direccion = "";
                return;
            }
            String[] array = Direccion.Split('-');
            if (array.Length > 1)
            {
                int a = array.Length;
                string DirTemp = array[a - 3].Trim();
                DirTemp = DirTemp.TrimEnd(' ');
                string[] ArrayDir = DirTemp.Split(' ');
                int i = ArrayDir.Length;
                if (ArrayDir[i - 1].Trim().Contains(")"))
                    contrib.Departamento = ArrayDir[i - 1].Trim().Substring(ArrayDir[i - 1].Trim().LastIndexOf(")") + 1, ArrayDir[i - 1].Trim().Length - ArrayDir[i - 1].Trim().LastIndexOf(")") - 1);
                else
                    contrib.Departamento = ArrayDir[i - 1].Trim();
                if (contrib.Departamento.ToUpper().Contains("LIBERTAD"))
                    contrib.Departamento = "LA LIBERTAD";
                else if (contrib.Departamento.ToUpper().Contains("DIOS"))
                    contrib.Departamento = "MADRE DE DIOS";
                else if (contrib.Departamento.ToUpper().Contains("MARTIN"))
                    contrib.Departamento = "SAN MARTIN";
                if (a > 3)
                {
                    for (int b = 0; b < a - 2; b++)
                    {
                        if (b == 0)
                            DirTemp = array[b];
                        else
                            DirTemp += "-" + array[b];
                    }
                    DirTemp = DirTemp.Trim();
                    DirTemp = DirTemp.Substring(0, DirTemp.Length - contrib.Departamento.Length).Trim();
                }
                else
                    DirTemp = DirTemp.Substring(0, DirTemp.Length - contrib.Departamento.Length).Trim();
                contrib.Direccion = DirTemp;
                contrib.Provincia = array[a - 2].Trim();
                contrib.Distrito = array[a - 1].Trim();
            }
        }
    }
}
