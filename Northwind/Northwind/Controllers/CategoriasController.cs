using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BL.Components;
using Northwind.BL.Entities;

namespace Northwind.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            Categorias CategoriasBL = new Categorias();
            List<Categoria> Categorias = CategoriasBL.ListarCategorias();
            ViewBag.Titulo = "Categorías";
            return View(Categorias);
        }

        // GET: Categorias/Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }
    }
}