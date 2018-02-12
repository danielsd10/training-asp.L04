using System;
using System.Collections.Generic;
using Northwind.BL.Entities;
using Datos = Northwind.DL.DataAccess;

namespace Northwind.BL.Components
{
    public class Categorias
    {

        public List<Categoria> ListarCategorias()
        {
            Datos.Categorias objDatos = new Datos.Categorias();
            return objDatos.ListarCategorias();
        }

    }
}
