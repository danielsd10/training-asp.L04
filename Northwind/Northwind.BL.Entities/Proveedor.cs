using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.BL.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string NombreContacto { get; set; }

        public string TituloContacto { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Region { get; set; }

        public string CodigoPostal { get; set; }

        public string Pais { get; set; }

        public string Telefono { get; set; }

        public string Fax { get; set; }

        public string SitioWeb { get; set; }
    }
}