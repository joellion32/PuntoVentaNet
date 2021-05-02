using Punto_de_venta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punto_de_venta.Controllers
{
    public class ClientController : Controller
    {
        PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: Client
        public ActionResult Index()
        {
            var clientes = db.Clientes.ToList();
            return View(clientes);
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
                if (ModelState.IsValid)
                {
                    Clientes clientes = new Clientes();
                    clientes.Nombre = collection["nombre"];
                    clientes.Email = collection["email"];
                    clientes.Telefono = collection["telefono"];
                    clientes.Direccion = collection["direccion"];
                    db.Clientes.Add(clientes);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var clientes = db.Clientes.Find(id);

            ViewBag.IdCliente = clientes.IdCliente;
            ViewBag.Nombre = clientes.Nombre;
            ViewBag.Email = clientes.Email;
            ViewBag.Telefono = clientes.Telefono;
            ViewBag.Direccion = clientes.Direccion;

            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Clientes clientes = db.Clientes.FirstOrDefault(x => x.IdCliente == id);
                    clientes.Nombre = collection["nombre"];
                    clientes.Email = collection["email"];
                    clientes.Telefono = collection["telefono"];
                    clientes.Direccion = collection["direccion"];
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
                Clientes clientes = db.Clientes.Find(id);
                db.Clientes.Remove(clientes);
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
