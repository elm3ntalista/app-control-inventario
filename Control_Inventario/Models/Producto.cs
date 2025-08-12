using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Control_Inventario.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Ubicacion { get; set; }
        public int StockMinimo { get; set; }
    }
}
