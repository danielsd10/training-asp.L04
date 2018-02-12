using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.BL.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Nullable<int> IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}