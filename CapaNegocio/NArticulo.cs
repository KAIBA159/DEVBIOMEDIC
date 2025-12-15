using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string codigo,string nombre, string descripcion,byte[] imagen,int idcategoria, int idpresentacion, string fabricante, string registrosanitario , int idclienteProveedor)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            Obj.Fabricante = fabricante;
            Obj.RegistroSanitario = registrosanitario;

            Obj.IdclienteProveedor = idclienteProveedor;



            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idarticulo,string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string fabricante, string registrosanitario, int idclienteProveedor)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            Obj.Fabricante = fabricante;
            Obj.RegistroSanitario = registrosanitario;

            Obj.IdclienteProveedor = idclienteProveedor;

            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }


        public static bool ExisteCodigo(string codigo, int? idActual = null)
        {
            DArticulo datos = new DArticulo();
            return datos.ExisteCodigo(codigo, idActual);
        }


        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArticulo de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static DataTable BuscarNombre2(string textobuscar , int idclienteProveedor)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            Obj.IdclienteProveedor = idclienteProveedor; 
            return Obj.BuscarNombre2(Obj);
        }

        public static DataTable BuscarCodigo(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCodigo(Obj);
        }

        public static DataTable Stock_Articulos()
        {
            return new DArticulo().Stock_Articulos();
        }
    }
}
