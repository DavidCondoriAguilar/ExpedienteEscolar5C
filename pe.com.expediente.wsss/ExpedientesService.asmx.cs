using pe.com.expedientes.bal;
using pe.com.registro.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace pe.com.expediente.wsss
{
    /// <summary>
    /// Descripción breve de ExpedientesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ExpedientesService : System.Web.Services.WebService
    {


        BALEstudiantes balestu = new BALEstudiantes();

        [WebMethod]
        public List<BOEstudiante> MostrarEstudiante()
        {
            List<BOEstudiante> estudiantes = balestu.MostrarEstudianteTodo().ToList();
            return estudiantes;
        }
    }
}
