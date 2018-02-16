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

        public Proveedor ListarProveedor(int Id)
        {
            return objProveedoresDL.ObtenerProveedor(Id);
        }

        public bool InsertarProveedor(Proveedor Proveedor)
        {
            return objProveedoresDL.InsertarProveedor(Proveedor);
        }

        public bool ActualizarProveedor(Proveedor Proveedor)
        {
            return objProveedoresDL.ActualizarProveedor(Proveedor);
        }

        public bool EliminarProveedor(int Id)
        {
            return objProveedoresDL.EliminarProveedor(Id);
        }

    }
}
