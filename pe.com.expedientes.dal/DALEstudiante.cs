using pe.com.expedientes.dal;
using pe.com.registro.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class DALEstudiante
{
    Conexion objconexion = new Conexion();
    private SqlCommand cmd;
    private int res = 0;

    public List<BOEstudiante> MostrarEstudiante()
    {
        List<BOEstudiante> lista = new List<BOEstudiante>();
        try
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MostrarEstudianteTodo";
            cmd.Connection = objconexion.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BOEstudiante objest = new BOEstudiante();
                objest.EstudianteID = Convert.ToInt32(dr["EstudianteID"]);
                objest.Nombre = dr["Nombre"].ToString();
                objest.Apellido = dr["Apellido"].ToString();
                objest.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                objest.Direccion = dr["Direccion"].ToString();
                objest.Email = dr["Email"].ToString();
                objest.Telefono = dr["Telefono"].ToString();
                objest.Estado = Convert.ToInt32(dr["Estado"]);

                // Nuevos campos a mostrar
                objest.Genero = dr["Genero"].ToString();
                objest.NumeroIdentificacion = dr["NumeroIdentificacion"].ToString();
                objest.TipoDocumento = dr["TipoDocumento"].ToString();
                objest.Grado = dr["Grado"].ToString();
                objest.NombreTutor = dr["NombreTutor"].ToString();
                objest.TelefonoTutor = dr["TelefonoTutor"].ToString();
                objest.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                //objest.Ultima = Convert.ToDateTime(dr["UltimaActualizacion"]);
                objest.FechaEliminacion = Convert.ToDateTime(dr["FechaEliminacion"]);
                objest.Notas = dr["Notas"].ToString();
                objest.Edad = Convert.ToInt32(dr["Edad"]);

                lista.Add(objest);
            }
            return lista;
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


    public bool RegistrarEstudiante(BOEstudiante be)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_RegistrarEstudiante";
            cmd.Connection = objconexion.Conectar();

            cmd.Parameters.AddWithValue("@nombre", be.Nombre);
            cmd.Parameters.AddWithValue("@apellido", be.Apellido);
            cmd.Parameters.AddWithValue("@fechaNacimiento", be.FechaNacimiento);
            cmd.Parameters.AddWithValue("@direccion", be.Direccion);
            cmd.Parameters.AddWithValue("@email", be.Email);
            cmd.Parameters.AddWithValue("@telefono", be.Telefono);
            cmd.Parameters.AddWithValue("@estado", be.Estado);
            cmd.Parameters.AddWithValue("@notas", be.Notas); 

            res = cmd.ExecuteNonQuery();

            return res == 1;
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

    public bool ActualizarEstudiante(BOEstudiante be)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ActualizarEstudiante";
            cmd.Connection = objconexion.Conectar();

            cmd.Parameters.AddWithValue("@estudianteID", be.EstudianteID);
            cmd.Parameters.AddWithValue("@nombre", be.Nombre);
            cmd.Parameters.AddWithValue("@apellido", be.Apellido);
            cmd.Parameters.AddWithValue("@fechaNacimiento", be.FechaNacimiento);
            cmd.Parameters.AddWithValue("@direccion", be.Direccion);
            cmd.Parameters.AddWithValue("@email", be.Email);
            cmd.Parameters.AddWithValue("@telefono", be.Telefono);
            cmd.Parameters.AddWithValue("@estado", be.Estado);

            // Nuevos campos a actualizar
            cmd.Parameters.AddWithValue("@genero", be.Genero);
            cmd.Parameters.AddWithValue("@numeroIdentificacion", be.NumeroIdentificacion);
            cmd.Parameters.AddWithValue("@tipoDocumento", be.TipoDocumento);
            cmd.Parameters.AddWithValue("@grado", be.Grado);
            cmd.Parameters.AddWithValue("@nombreTutor", be.NombreTutor);
            cmd.Parameters.AddWithValue("@telefonoTutor", be.TelefonoTutor);
            cmd.Parameters.AddWithValue("@fechaIngreso", be.FechaIngreso);
            //cmd.Parameters.AddWithValue("@ultimaActualizacion", be.UltimaActualizacion);
            cmd.Parameters.AddWithValue("@fechaEliminacion", be.FechaEliminacion);
            cmd.Parameters.AddWithValue("@notas", be.Notas);
            cmd.Parameters.AddWithValue("@edad", be.Edad);

            res = cmd.ExecuteNonQuery();

            return res == 1;
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

    public bool EliminarEstudiante(BOEstudiante estudianteID)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_EliminarEstudiante";
            cmd.Connection = objconexion.Conectar();

            cmd.Parameters.AddWithValue("@estudianteID", estudianteID.EstudianteID); 

            res = cmd.ExecuteNonQuery();

            return res == 1;
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


    public bool ActualizarEstudianteEstado(BOEstudiante be, int? nuevoEstado)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ActualizarEstudianteEstado";
            cmd.Connection = objconexion.Conectar();

            cmd.Parameters.AddWithValue("@estudianteID", be.EstudianteID);
            cmd.Parameters.AddWithValue("@nombre", be.Nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@apellido", be.Apellido ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fechaNacimiento", be.FechaNacimiento != null ? (object)be.FechaNacimiento : DBNull.Value);
            cmd.Parameters.AddWithValue("@direccion", be.Direccion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@email", be.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@telefono", be.Telefono ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@nuevoEstado", nuevoEstado ?? (object)DBNull.Value);

            res = cmd.ExecuteNonQuery();

            return res == 1;
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
