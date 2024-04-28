using System;

namespace pe.com.registro.bo
{
    public class BODocumento
    {
        public int DocumentoID { get; set; }
        public int ExpedienteID { get; set; }
        public string NombreDocumento { get; set; }
        public string RutaDocumento { get; set; }

        public BODocumento()
        {
            // Constructor por defecto
        }

        // Constructor con parámetros para simplificar la creación de objetos BODocumento
        //public BODocumento(int documentoID, int expedienteID, string nombreDocumento, string rutaDocumento)
        //{
        //    DocumentoID = documentoID;
        //    ExpedienteID = expedienteID;
        //    NombreDocumento = nombreDocumento;
        //    RutaDocumento = rutaDocumento;
        //}
    }
}
