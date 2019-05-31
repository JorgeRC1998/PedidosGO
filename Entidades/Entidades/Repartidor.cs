using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosGO.Entidades
{
    public class Repartidor
    {
        public int ShipmentId { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreRepartidor { get; set; }
        public virtual Orden OrdenId { get; set; }
    }
}
