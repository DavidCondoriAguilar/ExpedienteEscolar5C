using System.Data.SqlClient;
using System.Data;
using System;
using pe.com.expedientes.dal;
using pe.com.registro.bo;
using System.Collections.Generic;

public class DALEstudiante
{
    Conexion objconexion = new Conexion();

    private SqlCommand cmd;
    private SqlDataReader dr;


    public List<BOEstudiante> MostrarEstudianteTodo()
    {
        Conexion objconexion = new Conexion();
        List<BOEstudiante> estudiantes = new List<BOEstudiante>();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MostrarEstudianteTodo";
            cmd.Connection = objconexion.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BOEstudiante objEstudiante = new BOEstudiante();

                objEstudiante.EstudianteID = Convert.ToInt32(dr["EstudianteID"]);
                objEstudiante.Nombre = dr["Nombre"].ToString();
                objEstudiante.Apellido = dr["Apellido"].ToString();
                objEstudiante.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                objEstudiante.Direccion = dr["Direccion"].ToString();
                objEstudiante.Email = dr["Email"].ToString();
                objEstudiante.Telefono = dr["Telefono"].ToString();
                objEstudiante.Estado = Convert.ToInt32(dr["Estado"]);

                estudiantes.Add(objEstudiante);
            }

            return estudiantes;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
        finally
        {
            objconexion.CerrarConexion();
        }
    }

    public class BALDocumentos
    {
        private Conexion objconexion; // Dependency

        public BALDocumentos(Conexion conexion) // Inject Conexion in constructor
        {
            this.objconexion = conexion;
        }

        public bool RegistrarEstudiante(string nombre, string apellido, DateTime fechaNacimiento, string direccion, string email, string telefono)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarEstudiante";
                cmd.Connection = objconexion.Conectar();

                // Add parameters to stored procedure
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefono", telefono);

                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0; // Indicates student registration (affected rows > 0)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }



    public bool ActualizarEstudiante(BOEstudiante estudiante)
    {
        Conexion objconexion = new Conexion();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ActualizarEstudiante";
            cmd.Connection = objconexion.Conectar();

            // Agregar parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@estudianteID", estudiante.EstudianteID);
            cmd.Parameters.AddWithValue("@nombre", estudiante.Nombre);
            cmd.Parameters.AddWithValue("@apellido", estudiante.Apellido);
            cmd.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento);
            cmd.Parameters.AddWithValue("@direccion", estudiante.Direccion);
            cmd.Parameters.AddWithValue("@email", estudiante.Email);
            cmd.Parameters.AddWithValue("@telefono", estudiante.Telefono);
            cmd.Parameters.AddWithValue("@estado", estudiante.Estado); 

            int filasAfectadas = cmd.ExecuteNonQuery();

            return filasAfectadas > 0; // Indica si se actualizó un estudiante (filas afectadas > 0)
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        finally
        {
            objconexion.CerrarConexion();
        }
    }


    public bool EliminarEstudiante(int estudianteID)
    {
        try
        {
            cmd = new SqlCommand(); // Reuse the SqlCommand object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_EliminarEstudiante";
            cmd.Connection = objconexion.Conectar();

            // Add parameters to stored procedure
            cmd.Parameters.AddWithValue("@estudianteID", estudianteID);

            int filasAfectadas = cmd.ExecuteNonQuery();

            return filasAfectadas > 0; // Indicates student deletion (affected rows > 0)
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        finally
        {
            objconexion.CerrarConexion();
        }
    }

    public bool RegistrarEstudiante(BOEstudiante bc)
    {
        throw new NotImplementedException();
    }
}
