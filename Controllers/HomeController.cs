using Punto_de_venta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punto_de_venta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // mostrar pedidos
            List<PedidosModel> pedidos;
            PuntoVentaEntities db = new PuntoVentaEntities();
            pedidos = (from p in db.Pedidos
                          join c in db.Clientes
                          on p.IdPedido equals c.IdCliente
                          select new PedidosModel
                          {
                              IdPedido = p.IdPedido,
                              Nombre = c.Nombre,
                              Total = (int)p.Total,
                          }).ToList();


            ViewBag.TotalPedidos = db.Pedidos.SqlQuery("SELECT * FROM Pedidos").Count();
            ViewBag.TotalProductos = db.Productos.SqlQuery("SELECT * FROM Productos").Count();
            ViewBag.TotalClientes = db.Clientes.SqlQuery("SELECT * FROM Clientes").Count();

            return View(pedidos);
        }
    }
}