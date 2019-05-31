using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PedidosGO.Entidades
{
    public class Producto
    {
        public int ProductID { get; set; }
        public string Nombre { get; set; }
        public virtual Categorias CategoriaId { get; set; }
        public int ValorUni { get; set; }
        public int Lote { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public virtual Compañia Nit { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}