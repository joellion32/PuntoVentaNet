using Punto_de_venta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punto_de_venta.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            PuntoVentaEntities db = new PuntoVentaEntities();
            var productos = db.Productos.ToList();
            return View(productos);
        }

        public ActionResult Edit(int id)
        {
            PuntoVentaEntities db = new PuntoVentaEntities();
            var producto = db.Productos.Find(id);

            ViewBag.Id = producto.IdProducto;
            ViewBag.Nombre = producto.NombreProducto;
            ViewBag.Costo = producto.Costo;
            ViewBag.Precio = producto.Precio;
            ViewBag.Fecha = producto.Fecha;
   
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
