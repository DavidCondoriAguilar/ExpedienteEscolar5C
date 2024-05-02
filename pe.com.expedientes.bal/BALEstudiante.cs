using pe.com.registro.bo;
using pe.com.expedientes.dal;
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
            return dal.MostrarEstudiante();
        }

        public bool Registrarestudiante(BOEstudiante bc)
        {
            return dal.RegistrarEstudiante(bc);
        }

        public bool Actualizarestudiante(BOEstudiante bc)
        {
            return dal.ActualizarEstudiante(bc);
        }

        public bool Eliminarestudiante(BOEstudiante codigoestudiante)
        {
            return dal.EliminarEstudiante(codigoestudiante);
        }
    }
}
