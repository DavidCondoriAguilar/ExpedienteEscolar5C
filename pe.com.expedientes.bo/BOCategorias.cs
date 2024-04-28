using System;

namespace pe.com.registro.bo
{
    public class BOCategoria
    {
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }

        public BOCategoria()
        {

        }

        // Constructor con parámetros para simplificar la creación de objetos BOCategoria
        //public BOCategoria(int categoriaID, string nombreCategoria)
        //{
        //    CategoriaID = categoriaID;
        //    NombreCategoria = nombreCategoria;
        //}
    }
}
