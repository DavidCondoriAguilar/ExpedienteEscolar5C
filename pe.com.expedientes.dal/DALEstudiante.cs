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

            cmd.Parameters.AddWithValue("@estudianteID", estudianteID.Estado);

            res = cmd.ExecuteNonQuery();

            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
