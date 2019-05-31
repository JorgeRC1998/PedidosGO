using PedidosGO.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosGO.Entidades
{
        public class Categorias
        {
            public int CategoriaId { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            List<Producto> Productos { get; set; }
    }
}
