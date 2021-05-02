using Punto_de_venta.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Punto_de_venta.Controllers
{
    public class ProductController : Controller
    {
        PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: Product
        public ActionResult Index()
        {
            PuntoVentaEntities db = new PuntoVentaEntities();
            var productos = db.Productos.ToList();
            return View(productos);
        }

        public ActionResult Edit(int id)
        {
            var producto = db.Productos.Find(id);
            ViewBag.Id = producto.IdProducto;
            ViewBag.NombreP = producto.NombreProducto;
            ViewBag.Costo = producto.Costo;
            ViewBag.Precio = producto.Precio;
            ViewBag.Fecha = producto.Fecha;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                PuntoVentaEntities db = new PuntoVentaEntities();
                if (ModelState.IsValid)
                {
                    Productos producto = new Productos();
                    producto.NombreProducto = collection["nombre"];
                    producto.Costo = Convert.ToInt32(collection["costo"]);
                    producto.Precio = Convert.ToInt32(collection["precio"]);
                    producto.Fecha =  Convert.ToDateTime(collection["fecha"]);
                    db.Productos.Add(producto);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Update(int id, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                   Productos producto = db.Productos.FirstOrDefault(x => x.IdProducto == id);
                   producto.NombreProducto = collection["nombre"];
                   //producto.Costo = Convert.ToInt32(collection["costo"]);
                   //producto.Precio = Convert.ToInt32(collection["precio"]);
                   //producto.Fecha = Convert.ToDateTime(collection["fecha"]);
                   db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

   
        public ActionResult Delete(int id)
        {
            try
            {
                Productos producto = db.Productos.Find(id);
                db.Productos.Remove(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}

