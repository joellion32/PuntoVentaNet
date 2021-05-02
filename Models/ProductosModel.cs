using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punto_de_venta.Models
{
    public class ProductosModel
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public int Precio { get; set; }
        public DateTime Fecha { get; set; }

    }
}