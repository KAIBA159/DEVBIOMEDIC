using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;



namespace CapaNegocio
{
    public class NEncargadoTransportista        
    {
        //Método Insertar que llama al método Insertar de la clase DEncargadoTransportista
        //de la CapaDatos
        public static string Insertar(  string encargadoTransportista, 
                                        string tipo_documento, 
                                        string num_documento,
                                        string placa)
        {
            DEncargadoTransportista Obj = new DEncargadoTransportista();
            Obj.EncargadoTransportista = encargadoTransportista;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Placa = placa;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DEncargadoTransportista
        //de la CapaDatos
        public static string Editar(    int idencargadoTransportista,
                                        string encargadoTransportista,
                                        string tipo_documento,
                                        string num_documento,
                                        string placa
            )
        {
            DEncargadoTransportista Obj = new DEncargadoTransportista();

            Obj.IdEncargadoTransportista = idencargadoTransportista;
            Obj.EncargadoTransportista = encargadoTransportista;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Placa = placa; ;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DEncargadoTransportista
        //de la CapaDatos
        public static string Eliminar(int idencargadoTransportista)
        {
            DEncargadoTransportista Obj = new DEncargadoTransportista();
            Obj.IdEncargadoTransportista = idencargadoTransportista;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DEncargadoTransportista
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DEncargadoTransportista().Mostrar();
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DEncargadoTransportista de la CapaDatos

        public static DataTable BuscarRazon_social(string textobuscar)
        {
            DEncargadoTransportista Obj = new DEncargadoTransportista();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DEncargadoTransportista de la CapaDatos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DEncargadoTransportista Obj = new DEncargadoTransportista();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }

    }
}
