using pe.com.expedientes.dal;
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
            return dal.MostrarEstudiante();
        }

        public bool Registrarestudiante(BOEstudiante bc)
        {
            // Validación: verificar que el nombre del estudiante no esté vacío
            if (string.IsNullOrEmpty(bc.Nombre))
            {
                throw new ArgumentException("El nombre del estudiante no puede estar vacío.");
            }

            // Ejemplo de cálculo complejo: calcular la edad del estudiante a partir de su fecha de nacimiento
            bc.Edad = CalcularEdad(bc.FechaNacimiento);

            return dal.RegistrarEstudiante(bc);
        }

        public bool Actualizarestudiante(BOEstudiante bc)
        {
            // Validación: verificar que el código del estudiante sea válido
            if (bc.EstudianteID <= 0)
            {
                throw new ArgumentException("El código del estudiante no es válido.");
            }

            // Ejemplo de cálculo complejo: calcular la calificación final del estudiante
            // bc.CalificacionFinal = CalcularCalificacionFinal(bc.Notas);

            return dal.ActualizarEstudiante(bc);
        }

        public bool Eliminarestudiante(BOEstudiante codigoestudiante)
        {
            // Validación: verificar que el código del estudiante a eliminar sea válido
            if (codigoestudiante.EstudianteID <= 0)
            {
                throw new ArgumentException("El código del estudiante a eliminar no es válido.");
            }

            return dal.EliminarEstudiante(codigoestudiante);
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaActual < fechaNacimiento.AddYears(edad))
            {
                edad--;
            }
            return edad;
        }

        private double CalcularCalificacionFinal(List<double> notas)
        {
            // Ejemplo de cálculo de la calificación final a partir de las notas parciales
            if (notas == null || notas.Count == 0)
            {
                throw new ArgumentException("No se proporcionaron notas para calcular la calificación final.");
            }

            double sumaNotas = notas.Sum();
            double promedioNotas = sumaNotas / notas.Count;
            return promedioNotas;
        }
    }
}
