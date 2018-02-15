using System;
using System.Collections.Generic;
using Northwind.BL.Entities;
using Datos = Northwind.DL.DataAccess;

namespace Northwind.BL.Components
{
    public class Proveedores
    {
        Datos.Proveedores objProveedoresDL = new Datos.Proveedores();

        public List<Proveedor> ListarProveedores()
        {   
            return objProveedoresDL.ListarProveedores();
        }

    }
}
