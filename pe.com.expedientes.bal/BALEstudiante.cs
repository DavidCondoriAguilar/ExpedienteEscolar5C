using pe.com.registro.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.expedientes.bal
{
    public class BALEstudiantes
    {

        DALEstudiante dal = new DALEstudiante();


        public List<BOEstudiante> MostrarEstudianteTodo()
        {
            return dal.MostrarEstudianteTodo();
        }

        public bool RegistrarEstudiante(BOEstudiante bc)
        {
            return dal.RegistrarEstudiante(bc);
        }

        public bool ActualizarEstudiante(BOEstudiante bc)
        {
            return dal.ActualizarEstudiante(bc);
        }

        public bool EliminarEstudiante(int codigoestudiante)
        {
            return dal.EliminarEstudiante(codigoestudiante);
        }
    }
}
