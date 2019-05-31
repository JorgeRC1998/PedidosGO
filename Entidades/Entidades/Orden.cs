using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosGO.Entidades
{
    public class Orden
    {
        public int OrderId { get; set; }
        public virtual Usuario UserID { get; set; }
        public virtual Producto ProductId { get; set; }
        public virtual Repartidor ReparteId { get; set; }
        public double Descuento { get; set; }
        public double IVA { get; set; }
        public int TotalCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
