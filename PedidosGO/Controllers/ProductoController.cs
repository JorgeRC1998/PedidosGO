using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedidosGO.Models;

namespace CarritoComprasTuCodigo.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        private PedidosEntities ce = new PedidosEntities();

        [Authorize]
        public ActionResult Index()
        {

            return View(ce.PRODUCTS.ToList().OrderBy(x => x.Nombre));
        }


    }
}
