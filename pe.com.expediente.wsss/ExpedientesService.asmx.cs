using pe.com.expedientes.bal;
using pe.com.registro.bo;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace pe.com.expediente.wsss
{
    /// <summary>
    /// Descripción breve de ExpedientesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ExpedientesService : System.Web.Services.WebService
    {
        private readonly BALEstudiantes balestu = new BALEstudiantes();
        private readonly BALCategorias balcat = new BALCategorias();

        [WebMethod]
        public List<BOEstudiante> MostrarEstudiante()
        {
            return balestu.MostrarEstudianteTodo();
        }

        [WebMethod]
        public bool RegistrarEstudiante(BOEstudiante bc)
        {
            return balestu.Registrarestudiante(bc);
        }

        [WebMethod]
        public bool ActualizarEstudiante(BOEstudiante bc)
        {
            return balestu.Actualizarestudiante(bc);
        }

        [WebMethod]
        public bool EliminarEstudiante(BOEstudiante codigoEstudiante)
        {
            return balestu.Eliminarestudiante(codigoEstudiante);
        }

        //[WebMethod]
        //public List<BALCategorias> MostrarCategoriaTodo()
        //{
        //    return balcat.MostrarCategoriasTodo();
        //}

        [WebMethod]
        public bool RegistrarCategoria(BOCategoria bc)
        {
            return balcat.CrearCategoria(bc.NombreCategoria);
        }


        [WebMethod]
        public bool ActualizarCategoria(int bc)
        {
            return balcat.ActualizarCategoria(bc);
        }

        [WebMethod]
        public bool EliminarCategoria(int categoriaID)
        {
            return balcat.EliminarCategoria(categoriaID);
        }
    }
}
