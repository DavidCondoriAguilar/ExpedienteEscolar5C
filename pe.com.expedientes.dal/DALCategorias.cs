using System;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.expedientes.dal
{
    public class DALCategoria
    {
        private readonly string connectionString;

        public DALCategoria(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DALCategoria(Conexion conexion)
        {
        }

        public string CrearCategoria(string nombreCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CrearCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string mensaje = Convert.ToString(reader["Mensaje"]);
                        return mensaje;
                    }
                    return "Error al crear la categoría.";
                }
            }
        }

        public DataTable ObtenerCategoria(string nombreCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public bool ActualizarCategoria(int categoriaID, string nombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@categoriaID", categoriaID);
                    command.Parameters.AddWithValue("@nombre", nombre);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool EliminarCategoria(int categoriaID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@categoriaID", categoriaID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
