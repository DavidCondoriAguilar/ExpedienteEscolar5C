using pe.com.expedientes.dal;
using pe.com.registro.bo;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

public class DALEstudiante
{
    Conexion objconexion = new Conexion();

    private SqlCommand cmd;
    private SqlDataReader dr;

    public List<BOEstudiante> MostrarEstudiante()
    {
        List<BOEstudiante> lista = new List<BOEstudiante>();
        try
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MostrarEstudianteTodo"; 
            cmd.Connection = objconexion.Conectar();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BOEstudiante objest = new BOEstudiante();
                objest.EstudianteID = Convert.ToInt32(dr["EstudianteID"].ToString());
                objest.Nombre = dr["Nombre"].ToString();
                objest.Apellido = dr["Apellido"].ToString();
                objest.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                objest.Direccion = dr["Direccion"].ToString();
                objest.Email = dr["Email"].ToString();
                objest.Telefono = dr["Telefono"].ToString();
                objest.Estado = Convert.ToInt16(dr["Estado"].ToString());
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
}