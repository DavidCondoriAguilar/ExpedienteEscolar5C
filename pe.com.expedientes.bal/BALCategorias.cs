using System;
using System.Collections.Generic;
using System.Data;
using pe.com.expedientes.dal; // Importa el namespace del DAL
using pe.com.registro.bo; // Importa el namespace de la capa de objetos de negocio

namespace pe.com.expedientes.bal
{
    public class BALCategorias
    {
        private readonly DALCategoria dalCategoria;

        public BALCategorias(string connectionString)
        {
            dalCategoria = new DALCategoria(connectionString);
        }

        public string CrearCategoria(string nombreCategoria)
        {
            return dalCategoria.CrearCategoria(nombreCategoria);
        }

        public List<BOCategoria> ObtenerCategoria(string nombreCategoria)
        {
            var dataTable = dalCategoria.ObtenerCategoria(nombreCategoria);
            List<BOCategoria> listaCategorias = new List<BOCategoria>();

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

        public bool ActualizarCategoria(BOCategoria bc)
        {
            return dalCategoria.ActualizarCategoria(bc);
        }

        public bool EliminarCategoria(int categoriaID)
        {
            return dalCategoria.EliminarCategoria(categoriaID);
        }
    }
}
