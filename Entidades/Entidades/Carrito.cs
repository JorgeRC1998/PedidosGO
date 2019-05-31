using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PedidosGO.Entidades
{
    public class Carrito
    {
        public int Id { get; set; }
        public virtual Producto Product { get; set; }
        public int Cantidad { get; set; }
        public string CarritoID { get; set; }

    }
}