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
        public string Genero { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string TipoDocumento { get; set; }
        public string Grado { get; set; }
        public string NombreTutor { get; set; }
        public string TelefonoTutor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEliminacion { get; set; }
        public int Edad { get; set; }
        public string Notas { get; set; }

        public BOEstudiante()
        {

        }
    }
}
