using System;

namespace pe.com.registro.bo
{
    public class BOExpediente
    {
        public int ExpedienteID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }

        public BOExpediente()
        {

        }
    }
}
