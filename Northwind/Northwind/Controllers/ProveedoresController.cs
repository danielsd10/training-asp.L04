using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BL.Components;
using Northwind.BL.Entities;

namespace Northwind.Controllers
{
    public class ProveedoresController : Controller
    {
        Proveedores ProveedoresBL = new Proveedores();

        // GET: Proveedores
        [HttpGet]
        public ActionResult Index()
        {
            List<Proveedor> Proveedores = ProveedoresBL.ListarProveedores();
            ViewBag.Titulo = "Proveedores";
            return View(Proveedores);
        }

        // GET: Proveedores/Nuevo
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Proveedores/Nuevo
        [HttpPost]
        public ActionResult Nuevo(Proveedor objDatos)
        {
            return View();
        }

        // GET: Proveedores/Editar/{id}
        [HttpGet]
        public string Editar(int Id)
        {
            return "Editar ID = " + Id.ToString();
        }

        // POST: Proveedores/Editar/{id}
        [HttpPost]
        public ActionResult Editar(Proveedor objDatos)
        {
            return View();
        }

        // GET: Proveedores/Eliminar/{id}
        [HttpGet]
        public string Eliminar(int Id)
        {
            return "Eliminar ID = " + Id.ToString();
        }
    }
}