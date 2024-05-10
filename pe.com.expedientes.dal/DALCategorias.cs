using pe.com.registro.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.expedientes.dal
{
    public class DALCategoria
    {
        Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private int res = 0;

        public List<BOCategoria> MostrarCategorias()
        {
            List<BOCategoria> listaCategorias = new List<BOCategoria>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarCategorias";
                cmd.Connection = objconexion.Conectar();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    BOCategoria categoria = new BOCategoria
                    {
                        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
                        NombreCategoria = Convert.ToString(row["NombreCategoria"])
                    };
                    listaCategorias.Add(categoria);
                }

                return listaCategorias;
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


        public DataTable ObtenerCategoria(string nombreCategoria)
        {
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ObtenerCategoria";
                cmd.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);
                cmd.Connection = objconexion.Conectar();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

                return dataTable;
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

        public string CrearCategoria(string nombreCategoria)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CrearCategoria";
                cmd.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);
                cmd.Connection = objconexion.Conectar();

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return "Categoría creada exitosamente";
                }
                else
                {
                    return "Error al crear la categoría";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Error al crear la categoría";
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }


        public bool ActualizarCategoria(int categoriaID, string nombre)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarCategoria";
                cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Connection = objconexion.Conectar();

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
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

        public bool EliminarCategoria(int categoriaID)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarCategoria";
                cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                cmd.Connection = objconexion.Conectar();

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
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
}
