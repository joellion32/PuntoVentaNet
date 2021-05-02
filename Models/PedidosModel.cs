using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punto_de_venta.Models
{
    public class PedidosModel
    {
        public int IdPedido { get; set; }
        public string Nombre { get; set; }
        public int Total { get; set; }
    }
}