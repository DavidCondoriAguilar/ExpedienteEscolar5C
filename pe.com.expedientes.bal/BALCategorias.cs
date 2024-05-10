using pe.com.expedientes.dal;
using pe.com.registro.bo;
using System;
using System.Collections.Generic;
using System.Data;

namespace pe.com.expedientes.bal
{
    public class BALCategoria
    {
        DALCategoria dal = new DALCategoria();

        public List<BOCategoria> MostrarCategorias()
        {
            return dal.MostrarCategorias();
        }


        public string CrearCategoria(BOCategoria bc)
        {
            // Supongamos que bc.NombreCategoria es el nombre de la categoría a crear
            return dal.CrearCategoria(bc.NombreCategoria);
        }


        public bool ActualizarCategoria(int categoriaID, string nombre)
        {
            // Supongamos que categoriaID es el ID de la categoría a actualizar
            return dal.ActualizarCategoria(categoriaID, nombre);
        }

        public bool EliminarCategoria(int categoriaID)
        {
            // Supongamos que categoriaID es el ID de la categoría a eliminar
            return dal.EliminarCategoria(categoriaID);
        }
    }
}
