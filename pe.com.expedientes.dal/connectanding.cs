using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.expedientes.dal
{
    public class Conexion
    {
        //cadena de conexion
        private string cadena = "Data Source=DESKTOP-NMVGFPU\\BDCONDORI;Initial Catalog=GestorExpedientesEstudiantiles;Integrated Security=True";

        private SqlConnection xcon;

        public SqlConnection Conectar()
        {
            xcon = new SqlConnection(cadena);
            xcon.Open();
            return xcon;
        }

        public void CerrarConexion()
        {
            xcon.Close();
            xcon.Dispose();
        }
    }
}
