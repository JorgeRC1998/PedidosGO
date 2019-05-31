using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedidosGO.Models;
using System.Web.Security;

namespace CarritoComprasTuCodigo.Controllers
{
    public class CarritoController : Controller
    {
        //
        // GET: /Carrito/
        private PedidosEntities ce = new PedidosEntities();

        [HttpPost]
        public JsonResult AgregaCarrito(int id, int cantidad)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(ce.PRODUCTS.Find(id), cantidad));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                    compras.Add(new CarritoItem(ce.PRODUCTS.Find(id), cantidad));
                else
                    compras[IndexExistente].Cantidad++;
                Session["carrito"] = compras;
            }
            return Json( new { response = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AgregaCarrito()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            Session["carrito"] = compras;
            return View("AgregaCarrito");
        }

        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.ProductID == id)
                    return i;
            }
            return -1;
        }

        public ActionResult ConfirmarVenta()
        {
            string hola = System.Web.HttpContext.Current.User.Identity.Name;
            if (Session["carrito"] != null)
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                SALES NuevaVenta = new SALES();
                NuevaVenta.DiaVenta = DateTime.Now;
                NuevaVenta.Subtotal = compras.Sum(x => x.Producto.ValorUni * x.Cantidad);
                NuevaVenta.Iva = NuevaVenta.Subtotal * 0.16;
                NuevaVenta.Total = NuevaVenta.Iva + NuevaVenta.Subtotal;

                NuevaVenta.ORDERS = (from item in compras
                                     select new ORDERS
                                     {
                                         CedulaUsuario= int.Parse(hola),
                                         ProductID = item.Producto.ProductID,
                                         Cantidad = item.Cantidad,
                                         TotalCompra = (item.Producto.ValorUni * item.Cantidad),
                                         FechaEntrega = DateTime.Now,
                                         IdVenta = 1
                                         
                                     }).ToList();
                ce.SALES.Add(NuevaVenta);
                ce.SaveChanges();
                compras.Clear();
            }
            return View();
        }
    }
}
