using System;
using System.Collections.Generic;
using System.Text;

namespace Control_Inventario.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Proveedor { get; set; }
    }
}
