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
    public class CotizacionController : Controller
    {
        public ActionResult RegistrarCotizacion(int CodSolCotizacion)
        {

            List<tb_BuscarSolCotizacion> lista = new BL_TransaccionCotizacion().BusquedaSolcotizacion(CodSolCotizacion);
            List<Cotizacion> listados = new List<Cotizacion>();
            foreach (var item in lista)
            {
                listados.Add(new Cotizacion()
                {
                    Cantidad = item.Cantidad,
                    CodArticulo = item.CodArticulo,
                    CodEstado = item.CodEstado,
                    CodProveedor = item.CodProveedor,
                    FechaCotizacion = item.FechaCotizacion,
                    NombreEstado = item.NombreEstado,
                    NombreProveedor = item.NombreProveedor,
                    NombreArticulo = item.NombreArticulo,
                    CodSolCotizacion = item.CodSolCotizacion

                });
            }
            return View(listados);
        }

        [HttpPost]
        public ActionResult RegistrarCotizacion(string Buscar, List<Cotizacion> entidad, string FechaCotizacion, string CodProveedor, string CodEstado, string codigocotizacion, string codigosolcotizacion)
        {
            if (Buscar == "Buscar")
            {
                if (codigocotizacion != string.Empty)
                {
                    List<tb_BuscarSolCotizacion> lista = new BL_TransaccionCotizacion().BusquedaSolcotizacion(Convert.ToInt32(codigocotizacion));
                    List<Cotizacion> listados = new List<Cotizacion>();
                    foreach (var item in lista)
                    {
                        listados.Add(new Cotizacion()
                        {
                            Cantidad = item.Cantidad,
                            CodArticulo = item.CodArticulo,
                            CodEstado = item.CodEstado,
                            CodProveedor = item.CodProveedor,
                            FechaCotizacion = item.FechaCotizacion,
                            NombreEstado = item.NombreEstado,
                            NombreProveedor = item.NombreProveedor,
                            NombreArticulo = item.NombreArticulo,
                            CodSolCotizacion = item.CodSolCotizacion

                        });
                    }

                    return View(listados);
                }
                else
                {
                    List<Cotizacion> listados = new List<Cotizacion>();
                    return View(listados);
                }
            }
            else
            {
                List<tb_CotizacionDet> listados = new List<tb_CotizacionDet>();
                tb_Cotizacion cotiza = new tb_Cotizacion();
                cotiza.FechaCotizacion = Convert.ToDateTime(FechaCotizacion);
                cotiza.CodProveedor = Convert.ToInt32(CodProveedor);
                cotiza.CodEstado = CodEstado;
                cotiza.CodSolCotizacion = Convert.ToInt32(codigosolcotizacion);
                foreach (var item in entidad)
                {
                    listados.Add(new tb_CotizacionDet()
                    {
                        CodArticulo = item.CodArticulo,
                        Cantidad = item.Cantidad,
                        Precio = item.Precio
                    });
                }

                new BL_TransaccionCotizacion().TransaccionCotizacion(cotiza, listados);
                return RedirectToAction("ListadoCotizacion", "Cotizacion");
            }
        }

        public ActionResult ListadoCotizacion()
        {
            List<tb_Cotizacion> lista = new BL_TransaccionCotizacion().BuscarCotizacion().Where(x => x.CodEstado != "2").ToList();
            List<Cotizacion> listacotiza = new List<Cotizacion>();
            foreach (var item in lista)
            {
                listacotiza.Add(new Cotizacion()
                {
                    CodCotizacion = item.CodCotizacion,
                    FechaCotizacion = item.FechaCotizacion,
                    CodSolCotizacion = item.CodSolCotizacion,
                    CodProveedor = item.CodProveedor,
                    CodEstado = item.CodEstado
                });
            }

            return View(listacotiza);
        }

        [HttpPost]
        public ActionResult ListadoCotizacion(string codigo)
        {
            if (codigo != string.Empty)
            {
                List<tb_Cotizacion> lista = new BL_TransaccionCotizacion().BuscarCotizacion().Where(x => x.CodCotizacion == Convert.ToInt32(codigo) && x.CodEstado != "2").ToList();
                List<Cotizacion> listacotiza = new List<Cotizacion>();
                foreach (var item in lista)
                {
                    listacotiza.Add(new Cotizacion()
                    {
                        CodCotizacion = item.CodCotizacion,
                        FechaCotizacion = item.FechaCotizacion,
                        CodSolCotizacion = item.CodSolCotizacion,
                        CodProveedor = item.CodProveedor,
                        CodEstado = item.CodEstado
                    });
                }
                return View(listacotiza);
            }
            else
            {
                List<tb_Cotizacion> lista = new BL_TransaccionCotizacion().BuscarCotizacion().Where(x => x.CodEstado != "2").ToList();
                List<Cotizacion> listacotiza = new List<Cotizacion>();
                foreach (var item in lista)
                {
                    listacotiza.Add(new Cotizacion()
                    {
                        CodCotizacion = item.CodCotizacion,
                        FechaCotizacion = item.FechaCotizacion,
                        CodSolCotizacion = item.CodSolCotizacion,
                        CodProveedor = item.CodProveedor,
                        CodEstado = item.CodEstado
                    });
                }
                return View(listacotiza);
            }
        }

        public ActionResult ListadoSolCotizacion()
        {
            List<tb_SolCotizacion> Listado = new BL_TransaccionCotizacion().TraerTodoSolCotizacion();
            List<SolCotizacion> listadosolcotiza = new List<SolCotizacion>();
            foreach (var item in Listado)
            {
                listadosolcotiza.Add(new SolCotizacion()
                {
                    CodSolCotizacion = item.CodSolCotizacion,

                    FechaCotizacion = item.FechaCotizacion,

                    CodSolAdquisicion = item.CodSolAdquisicion,

                    CodProveedor = item.CodProveedor,

                    CodEstado = item.CodEstado
                });
            }

            return View(listadosolcotiza);
        }

        [HttpPost]
        public ActionResult ListadoSolCotizacion(string codigo)
        {
            if (codigo != string.Empty)
            {
                List<tb_SolCotizacion> Listado = new BL_TransaccionCotizacion().TraerTodoSolCotizacion().Where(x => x.CodSolCotizacion == Convert.ToInt32(codigo)).ToList();
                List<SolCotizacion> listadosolcotiza = new List<SolCotizacion>();
                foreach (var item in Listado)
                {
                    listadosolcotiza.Add(new SolCotizacion()
                    {
                        CodSolCotizacion = item.CodSolCotizacion,

                        FechaCotizacion = item.FechaCotizacion,

                        CodSolAdquisicion = item.CodSolAdquisicion,

                        CodProveedor = item.CodProveedor,

                        CodEstado = item.CodEstado
                    });
                }

                return View(listadosolcotiza);
            }
            else
            {
                List<tb_SolCotizacion> Listado = new BL_TransaccionCotizacion().TraerTodoSolCotizacion().ToList();
                List<SolCotizacion> listadosolcotiza = new List<SolCotizacion>();
                foreach (var item in Listado)
                {
                    listadosolcotiza.Add(new SolCotizacion()
                    {
                        CodSolCotizacion = item.CodSolCotizacion,

                        FechaCotizacion = item.FechaCotizacion,

                        CodSolAdquisicion = item.CodSolAdquisicion,

                        CodProveedor = item.CodProveedor,

                        CodEstado = item.CodEstado
                    });
                }

                return View(listadosolcotiza);
            }
        }

        public ActionResult EliminarCotizacion(int codigo)
        {
            new BL_TransaccionCotizacion().EliminarCotizacion(codigo);
            return RedirectToAction("ListadoCotizacion");
        }

        public ActionResult VerCotizacion(int codigo)
        {
            List<tb_BuscarCotizacion> lista = new BL_TransaccionCotizacion().VerCotizacion(codigo);
            List<Cotizacion> listados = new List<Cotizacion>();
            foreach (var item in lista)
            {
                listados.Add(new Cotizacion()
                {
                    Cantidad = item.Cantidad,
                    CodArticulo = item.CodArticulo,
                    CodEstado = item.CodEstado,
                    CodProveedor = item.CodProveedor,
                    FechaCotizacion = item.FechaCotizacion,
                    NombreEstado = item.NombreEstado,
                    NombreProveedor = item.NombreProveedor,
                    NombreArticulo = item.NombreArticulo,
                    Precio = item.Precio

                });
            }
            return View(listados);
        }

        public ActionResult RegistrarCompra(int codigo)
        {
            List<tb_BuscarCotizacion> lista = new BL_TransaccionCotizacion().VerCotizacion(codigo);
            List<OrdenCompra> listados = new List<OrdenCompra>();
            foreach (var item in lista)
            {
                listados.Add(new OrdenCompra()
                {
                    Cantidad = item.Cantidad,
                    CodArticulo = item.CodArticulo,
                    CodEstado = item.CodEstado,
                    CodProveedor = item.CodProveedor,
                    CodCotizacion = item.CodCotizacion,
                    PreUnitario = item.Precio,
                    FechaEmision = DateTime.Now,
                    FechaEntrega = DateTime.Now

                });
            }

            ViewBag.Empleado = new BL_OrdenCompra().empleados().ToList();
            return View(listados);
        }
    }
}
