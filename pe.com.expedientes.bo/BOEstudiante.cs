using System;

namespace pe.com.registro.bo
{
    public class BOEstudiante
    {
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
        public int Codigorol { get; set; }

        public BOEstudiante()
        {

        }
    }
}
