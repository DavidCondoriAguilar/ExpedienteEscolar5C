using pe.com.expedientes.bal;
using pe.com.expedientes.dal;
using pe.com.registro.bo;
using System.Collections.Generic;
using System.Linq;
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
         BALEstudiantes balestu = new BALEstudiantes();
         BALCategoria balcat = new BALCategoria();

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

        [WebMethod]
        public List<BOCategoria> MostrarCategoria()
        {
            return balcat.MostrarCategorias();
        }

        [WebMethod]
        public string RegistrarCategoria(BOCategoria bc)
        {
            return balcat.CrearCategoria(bc);
        }

        [WebMethod]
        public bool ActualizarCategoria(int categoriaID, string nombre)
        {
            return balcat.ActualizarCategoria(categoriaID, nombre);
        }

        [WebMethod]
        public bool EliminarCategoria(int categoriaID)
        {
            return balcat.EliminarCategoria(categoriaID);
        }
    }
}
