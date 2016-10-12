using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innova.GMantenimiento.MVC.Models;
using Innova.Common.Core.Entities;
using Innova.GMantenimiento.Domain;

namespace Innova.GMantenimiento.MVC.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: OrdenCompra
        public ActionResult RegistrarCompra(List<OrdenCompra> entidad, string FechaEmision, string FechaEntrega, string CodProveedor, string CodEstado, string Moneda, string TipoCambio, string CodEmpleado, string CodCotizacion)
        {
            List<tb_OrdCompraDet> listadet = new List<tb_OrdCompraDet>();
            decimal total = 0;
            foreach (var item in entidad)
            {
                listadet.Add(new tb_OrdCompraDet()
                {
                    CodArticulo = item.CodArticulo,
                    Cantidad = item.Cantidad,
                    PreUnitario = item.PreUnitario,
                    Descuento = item.Descuento,
                });
                total = Convert.ToDecimal(((item.PreUnitario * item.Descuento) / 100) * item.Cantidad);
            }

            tb_OrdCompra ordencompra = new tb_OrdCompra()
            {
                FechaEmision = Convert.ToDateTime(FechaEmision),
                FechaEntrega = Convert.ToDateTime(FechaEntrega),
                CodEstado = CodEstado,
                Moneda = Moneda,
                TipCambio = Convert.ToDecimal(TipoCambio),
                CodEmpleado = Convert.ToInt32(CodEmpleado),
                CodCotizacion = Convert.ToInt32(CodCotizacion),
                CodProveedor = Convert.ToInt32(CodProveedor),
                Total = total
            };



            new BL_TransaccionOrdenCompra().TransaccionCompra(ordencompra, listadet);
            return RedirectToAction("ListaOrden");
        }

        public ActionResult ListaOrden()
        {
            List<tb_OrdCompra> lista = new BL_OrdenCompra().listarodencompra().Where(x => x.CodEstado != "2").ToList(); ;
            List<OrdenCompra> entidad = new List<OrdenCompra>();
            foreach (var item in lista)
            {
                entidad.Add(new OrdenCompra()
                {
                    CodOrdCompra = item.CodOrdCompra,
                    FechaEmision = item.FechaEmision,
                    FechaEntrega = item.FechaEntrega,
                    CodEstado = item.CodEstado,
                    Moneda = item.Moneda,
                    TipCambio = item.TipCambio,
                    CodEmpleado = item.CodEmpleado,
                    CodCotizacion = item.CodCotizacion,
                    CodProveedor = item.CodProveedor,
                    Total = item.Total
                });
            }
            return View(entidad);
        }
        [HttpPost]
        public ActionResult ListaOrden(string codigo)
        {
            if (codigo != string.Empty)
            {
                List<tb_OrdCompra> lista = new BL_OrdenCompra().listarodencompra().Where(x => x.CodOrdCompra == Convert.ToInt32(codigo) && x.CodEstado != "2").ToList();
                List<OrdenCompra> entidad = new List<OrdenCompra>();
                foreach (var item in lista)
                {
                    entidad.Add(new OrdenCompra()
                    {
                        CodOrdCompra = item.CodOrdCompra,
                        FechaEmision = item.FechaEmision,
                        FechaEntrega = item.FechaEntrega,
                        CodEstado = item.CodEstado,
                        Moneda = item.Moneda,
                        TipCambio = item.TipCambio,
                        CodEmpleado = item.CodEmpleado,
                        CodCotizacion = item.CodCotizacion,
                        CodProveedor = item.CodProveedor,
                        Total = item.Total
                    });
                }
                return View(entidad);
            }
            else
            {
                List<tb_OrdCompra> lista = new BL_OrdenCompra().listarodencompra().Where(x => x.CodEstado != "2").ToList();
                List<OrdenCompra> entidad = new List<OrdenCompra>();
                foreach (var item in lista)
                {
                    entidad.Add(new OrdenCompra()
                    {
                        CodOrdCompra = item.CodOrdCompra,
                        FechaEmision = item.FechaEmision,
                        FechaEntrega = item.FechaEntrega,
                        CodEstado = item.CodEstado,
                        Moneda = item.Moneda,
                        TipCambio = item.TipCambio,
                        CodEmpleado = item.CodEmpleado,
                        CodCotizacion = item.CodCotizacion,
                        CodProveedor = item.CodProveedor,
                        Total = item.Total
                    });
                }
                return View(entidad);
            }
        }

        public ActionResult AnularOrdenCompra(int codigo)
        {
            new BL_OrdenCompra().AnularCompra(codigo);
            return RedirectToAction("ListaOrden");
        }


    }
}