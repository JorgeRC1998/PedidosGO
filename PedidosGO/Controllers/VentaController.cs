using PedidosGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidosGO.Controllers
{
    public class VentaController : Controller
    {
        private PedidosEntities ce = new PedidosEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View(ce.ORDERS.ToList().OrderBy(x => x.Order_Id));
        }

    }
}