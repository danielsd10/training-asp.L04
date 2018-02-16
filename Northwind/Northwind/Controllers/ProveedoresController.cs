using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BL.Components;
using Northwind.BL.Entities;
using Northwind.Models;

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
            ViewBag.Respuesta = (RespuestaModel)TempData["Respuesta"];
            return View(Proveedores);
        }

        // GET: Proveedores/Nuevo
        [HttpGet]
        public ActionResult Nuevo()
        {
            ViewBag.Titulo = "Nuevo Proveedor";
            return View();
        }

        // POST: Proveedores/Nuevo
        [HttpPost]
        public ActionResult Nuevo(Proveedor objDatos)
        {
            if (ProveedoresBL.InsertarProveedor(objDatos))
            {
                TempData["Respuesta"] = new RespuestaModel() {
                    Tipo = "success",
                    Mensaje = "El proveedor se registró correctamente."
                };
            }
            else
            {
                TempData["Respuesta"] = new RespuestaModel()
                {
                    Tipo = "danger",
                    Mensaje = "No se pudo registrar el proveedor."
                };
            }
            return RedirectToAction("Index");
        }

        // GET: Proveedores/Editar/{Id}
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            ViewBag.Titulo = "Editar Proveedor";
            Proveedor Proveedor = ProveedoresBL.ListarProveedor(Id);
            return View("Nuevo", Proveedor);
        }

        // POST: Proveedores/Editar/{Id}
        [HttpPost]
        public ActionResult Editar(int Id, Proveedor objDatos)
        {
            if (ProveedoresBL.ActualizarProveedor(objDatos))
            {
                TempData["Respuesta"] = new RespuestaModel()
                {
                    Tipo = "success",
                    Mensaje = "El proveedor se actualizó correctamente."
                };
            }
            else
            {
                TempData["Respuesta"] = new RespuestaModel()
                {
                    Tipo = "danger",
                    Mensaje = "No se pudo actualizar el proveedor."
                };
            }
            return RedirectToAction("Index");
        }

        // GET: Proveedores/Eliminar/{Id}
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            if (ProveedoresBL.EliminarProveedor(Id))
            {
                TempData["Respuesta"] = new RespuestaModel()
                {
                    Tipo = "warning",
                    Mensaje = "El proveedor se eliminó correctamente."
                };
            }
            else
            {
                TempData["Respuesta"] = new RespuestaModel()
                {
                    Tipo = "danger",
                    Mensaje = "No se pudo eliminar el proveedor."
                };
            }
            return RedirectToAction("Index");
        }
    }
}