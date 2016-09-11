using Innova.Common.Core.Entities;
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.GMantenimiento.Domain;
using Innova.GMantenimiento.Infraestructure.Data.CompositeEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Innova.Modulo.Web.Mvc.Controllers
{
    public class AdquisicionController : Controller
    {
        //DataModel database = new DataModel();
        // GET: Adquisicion
        public ActionResult Index(int? CodigoSolicitudAdquision = null, string Solicitante = null, string Area = null,
                                  string Estado = null, string FechaInicio = null, string FechaFin = null)
        {
            Session["ListaArticulosAdquisicion"] = null;
            List<ItemSolAdquisicion> lista = new BL_SolAdquisicion().Lista(CodigoSolicitudAdquision, Solicitante, Area, Estado, FechaInicio, FechaFin);

            return View(lista);
        }

        public ViewResult NuevoAdquisicion()
        {
            /*var oQuery = (from oEmpleado in database.tb_Empleado.ToList()
                          where oEmpleado.CodEmpleado != 1
                          select new
                          {
                              oEmpleado.CodEmpleado,
                              FullNombre = oEmpleado.ApePaterno + " " + oEmpleado.ApeMaterno + ", " + oEmpleado.Nombres
                          }).ToList();

            ViewBag.CodSolicitante = new SelectList(oQuery, "CodEmpleado", "FullNombre");
            ViewBag.CodEstado = new SelectList(database.tb_Estado.ToList(), "CodEstado", "Nombre");*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NuevoAdquisicion([Bind(Include = "FechaEmision,CodSolicitante,NroInforme,Observacion")] ItemSolAdquisicion oSolAdquisicion, HttpPostedFileBase upload)
        {

            //if (ModelState.IsValid)
            /*if (oSolAdquisicion != null)
            {
                if (upload != null)
                {
                    //string adjunto = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(upload.FileName);
                    string adjunto = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + upload.FileName.ToString().Replace(' ', '_');
                    upload.SaveAs(Server.MapPath("~/uploads/" + adjunto));
                    //http://anexsoft.com/p/88/asp-net-mvc-subida-de-archivos-y-relacion-de-uno-a-muchos
                    //http://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files
                    //http://anexsoft.com/p/47/como-subir-varios-archivos-a-la-vez-con-asp-net-mvc
                    //this.alumno.Adjuntar(new Adjunto
                    //{
                    //    Archivo = adjunto,
                    //    Alumno_id = Alumno_id
                    //});
                }

                tb_SolAdquisicion oSolAdq = new tb_SolAdquisicion();
                oSolAdq.FechaEmision = oSolAdquisicion.FechaEmision;
                oSolAdq.CodSolicitante = oSolAdquisicion.CodSolicitante;
                oSolAdq.CodEmpleado = oSolAdquisicion.CodSolicitante;
                oSolAdq.CodEstado = "E";
                oSolAdq.NroInforme = oSolAdquisicion.NroInforme;
                oSolAdq.Observacion = oSolAdquisicion.Observacion;

                DA_SolAdquisicion proceso = new DA_SolAdquisicion();
                proceso.AgregarSolicitudCotizacion(oSolAdq);
                await database.SaveChangesAsync();
                return RedirectToAction("Index", "Adquisicion");
            }

            var oSolicitante = (from oEmpleado in database.tb_Empleado.ToList()
                                where oEmpleado.CodEmpleado != 1
                                select new
                                {
                                    oEmpleado.CodEmpleado,
                                    FullNombre = oEmpleado.ApePaterno + " " + oEmpleado.ApeMaterno + ", " + oEmpleado.Nombres
                                }).ToList();

            ViewBag.CodSolicitante = new SelectList(oSolicitante, "CodEmpleado", "FullNombre", oSolAdquisicion.CodSolicitante);

            var oEstado = database.tb_Estado.ToList().Single(x => x.CodEstado == "E").GetType().GetProperties().ToList();

            ViewBag.CodEstado = new SelectList(oEstado, "CodEstado", "Nombre", oSolAdquisicion.CodEstado);
            return View(oSolAdquisicion);*/
            return View();
        }

        public ActionResult EliminarAdquisicion(int? CodSolAdquisicion = 0)
        {
            /*Models.SolicitudAdquisionModel oSolAdquisicion = null;
            if (!string.IsNullOrEmpty(CodSolAdquisicion.ToString()))
            {
                var oQuery = (from oAdquisicion in database.tb_SolAdquisicion.ToList()

                              where oAdquisicion.CodSolAdquisicion == CodSolAdquisicion

                              select new
                              {
                                  oAdquisicion.CodSolAdquisicion,
                                  oAdquisicion.FechaEmision,
                                  oAdquisicion.CodEstado,
                                  oAdquisicion.CodEmpleado,
                                  oAdquisicion.CodSolicitante,
                                  oAdquisicion.Observacion,
                                  oAdquisicion.NroInforme
                              }).ToList();

                if (oQuery.Count > 0)
                {
                    oSolAdquisicion = new Models.SolicitudAdquisionModel();
                    oSolAdquisicion.CodSolAdquisicion = oQuery[0].CodSolAdquisicion;
                    oSolAdquisicion.FechaEmision = oQuery[0].FechaEmision;
                    oSolAdquisicion.CodEstado = oQuery[0].CodEstado;
                    oSolAdquisicion.CodEmpleado = oQuery[0].CodEmpleado;
                    oSolAdquisicion.CodSolicitante = oQuery[0].CodSolicitante;
                    oSolAdquisicion.Observacion = oQuery[0].Observacion;
                    oSolAdquisicion.NroInforme = oQuery[0].NroInforme;
                }
            }


            if (oSolAdquisicion != null)
            {
                tb_SolAdquisicion oSolAdq = new tb_SolAdquisicion();
                oSolAdq.CodSolAdquisicion = oSolAdquisicion.CodSolAdquisicion;
                oSolAdq.FechaEmision = oSolAdquisicion.FechaEmision;
                oSolAdq.CodSolicitante = oSolAdquisicion.CodSolicitante;
                oSolAdq.CodEmpleado = oSolAdquisicion.CodSolicitante;
                oSolAdq.CodEstado = oSolAdquisicion.CodEstado;
                oSolAdq.NroInforme = oSolAdquisicion.NroInforme;
                oSolAdq.Observacion = oSolAdquisicion.Observacion;

                DA_SolAdquisicion proceso = new DA_SolAdquisicion();
                proceso.EliminarSolicitudCotizacion(oSolAdq);
            }*/
            return RedirectToAction("Index", "Adquisicion");
        }

        public ViewResult ConsultarAdquisicion(int? CodSolAdquisicion = 0)
        {

            /*Models.SolicitudAdquisionModel oSolAdquisicion = new SolicitudAdquisionModel();


            if (!string.IsNullOrEmpty(CodSolAdquisicion.ToString()))
            {
                var oQuery = (from oAdquisicion in database.tb_SolAdquisicion.ToList()
                              join oEmpleado in database.tb_Empleado.ToList() on
                                   oAdquisicion.CodSolicitante equals oEmpleado.CodEmpleado
                              join oEstado in database.tb_Estado.ToList() on
                                    oAdquisicion.CodEstado equals oEstado.CodEstado

                              where oAdquisicion.CodSolAdquisicion == CodSolAdquisicion

                              select new
                              {
                                  oAdquisicion.CodSolAdquisicion,
                                  oAdquisicion.FechaEmision,
                                  oAdquisicion.CodEstado,
                                  oAdquisicion.CodEmpleado,
                                  oAdquisicion.CodSolicitante,
                                  oAdquisicion.Observacion,
                                  oAdquisicion.NroInforme,

                                  Solicitante = oEmpleado.ApePaterno + " " + oEmpleado.ApeMaterno + ", " + oEmpleado.Nombres,
                                  Estado = oEstado.Nombre
                              }).ToList();

                if (oQuery.Count > 0)
                {
                    oSolAdquisicion = new Models.SolicitudAdquisionModel();
                    oSolAdquisicion.CodSolAdquisicion = oQuery[0].CodSolAdquisicion;
                    oSolAdquisicion.FechaEmision = oQuery[0].FechaEmision;
                    oSolAdquisicion.CodEstado = oQuery[0].CodEstado;
                    oSolAdquisicion.CodEmpleado = oQuery[0].CodEmpleado;
                    oSolAdquisicion.CodSolicitante = oQuery[0].CodSolicitante;
                    oSolAdquisicion.Observacion = oQuery[0].Observacion;
                    oSolAdquisicion.NroInforme = oQuery[0].NroInforme;

                    oSolAdquisicion.Solicitante = oQuery[0].Solicitante;
                    oSolAdquisicion.Estado = oQuery[0].Estado;
                }

                ViewBag.CodEstado = new SelectList(database.tb_Estado.ToList(), "CodEstado", "Nombre", oSolAdquisicion.CodEstado);


                var oQueryDet = (from oAdquisicionDet in database.tb_SolAdquisicionDet.ToList()
                                 join oArticulo in database.tb_Articulo.ToList() on
                                    oAdquisicionDet.CodArticulo equals oArticulo.CodArticulo
                                 join oUnidadmedida in database.tb_UnidadMedida.ToList() on
                                    oArticulo.CodUnidMedida equals oUnidadmedida.CodUnidMedida

                                 where oAdquisicionDet.CodSolAdquisicion == CodSolAdquisicion

                                 select new
                                 {
                                     oAdquisicionDet.CodArticulo,
                                     oArticulo.Nombre,
                                     oArticulo.Marca,
                                     oArticulo.Modelo,
                                     UnidadMedida = oUnidadmedida.Nombre,
                                     oAdquisicionDet.Cantidad
                                 }).ToList();

                List<ArticuloModel> listaArticulos = new List<ArticuloModel>();
                ArticuloModel obj = new ArticuloModel();

                if (oQueryDet.Count > 0)
                {
                    foreach (var item in oQueryDet)
                    {
                        obj = new ArticuloModel();
                        obj.CodArticulo = item.CodArticulo;
                        obj.Descripcion = item.Nombre;
                        obj.Modelo = item.Modelo;
                        obj.Marca = item.Marca;
                        obj.UnidadMedida = item.UnidadMedida;
                        obj.Cantidad = int.Parse(item.Cantidad.ToString());
                        listaArticulos.Add(obj);
                    }
                    Session["ListaArticulosAdquisicion"] = listaArticulos;
                }
                else
                {
                    listaArticulos = new List<ArticuloModel>();
                    Session["ListaArticulosAdquisicion"] = null;
                }
                ViewBag.ListaArticulosAgre = listaArticulos;
            }
            return View(oSolAdquisicion);*/
            return View();
        }
   

        public ViewResult EditarAdquisicion(int? CodSolAdquisicion = 0)
        {

            /*Models.SolicitudAdquisionModel oSolAdquisicion = new SolicitudAdquisionModel();


            if (!string.IsNullOrEmpty(CodSolAdquisicion.ToString()))
            {
                var oQuery = (from oAdquisicion in database.tb_SolAdquisicion.ToList()
                              join oEmpleado in database.tb_Empleado.ToList() on
                                   oAdquisicion.CodSolicitante equals oEmpleado.CodEmpleado
                              join oEstado in database.tb_Estado.ToList() on
                                    oAdquisicion.CodEstado equals oEstado.CodEstado

                              where oAdquisicion.CodSolAdquisicion == CodSolAdquisicion

                              select new
                              {
                                  oAdquisicion.CodSolAdquisicion,
                                  oAdquisicion.FechaEmision,
                                  oAdquisicion.CodEstado,
                                  oAdquisicion.CodEmpleado,
                                  oAdquisicion.CodSolicitante,
                                  oAdquisicion.Observacion,
                                  oAdquisicion.NroInforme,

                                  Solicitante = oEmpleado.ApePaterno + " " + oEmpleado.ApeMaterno + ", " + oEmpleado.Nombres,
                                  Estado = oEstado.Nombre
                              }).ToList();

                if (oQuery.Count > 0)
                {
                    oSolAdquisicion = new Models.SolicitudAdquisionModel();
                    oSolAdquisicion.CodSolAdquisicion = oQuery[0].CodSolAdquisicion;
                    oSolAdquisicion.FechaEmision = oQuery[0].FechaEmision;
                    oSolAdquisicion.CodEstado = oQuery[0].CodEstado;
                    oSolAdquisicion.CodEmpleado = oQuery[0].CodEmpleado;
                    oSolAdquisicion.CodSolicitante = oQuery[0].CodSolicitante;
                    oSolAdquisicion.Observacion = oQuery[0].Observacion;
                    oSolAdquisicion.NroInforme = oQuery[0].NroInforme;

                    oSolAdquisicion.Solicitante = oQuery[0].Solicitante;
                    oSolAdquisicion.Estado = oQuery[0].Estado;
                }

                ViewBag.CodEstado = new SelectList(database.tb_Estado.ToList(), "CodEstado", "Nombre", oSolAdquisicion.CodEstado);


                var oQueryDet = (from oAdquisicionDet in database.tb_SolAdquisicionDet.ToList()
                                 join oArticulo in database.tb_Articulo.ToList() on
                                    oAdquisicionDet.CodArticulo equals oArticulo.CodArticulo
                                 join oUnidadmedida in database.tb_UnidadMedida.ToList() on
                                    oArticulo.CodUnidMedida equals oUnidadmedida.CodUnidMedida

                                 where oAdquisicionDet.CodSolAdquisicion == CodSolAdquisicion

                                 select new
                                 {
                                     oAdquisicionDet.CodArticulo,
                                     oArticulo.Nombre,
                                     oArticulo.Marca,
                                     oArticulo.Modelo,
                                     UnidadMedida = oUnidadmedida.Nombre,
                                     oAdquisicionDet.Cantidad
                                 }).ToList();

                List<ArticuloModel> listaArticulos = new List<ArticuloModel>();
                ArticuloModel obj = new ArticuloModel();

                if (oQueryDet.Count > 0)
                {
                    foreach (var item in oQueryDet)
                    {
                        obj = new ArticuloModel();
                        obj.CodArticulo = item.CodArticulo;
                        obj.Descripcion = item.Nombre;
                        obj.Modelo = item.Modelo;
                        obj.Marca = item.Marca;
                        obj.UnidadMedida = item.UnidadMedida;
                        obj.Cantidad = int.Parse(item.Cantidad.ToString());
                        listaArticulos.Add(obj);
                    }
                    Session["ListaArticulosAdquisicion"] = listaArticulos;
                }
                else
                {
                    listaArticulos = new List<ArticuloModel>();
                    Session["ListaArticulosAdquisicion"] = null;
                }
                ViewBag.ListaArticulosAgre = listaArticulos;
            }
            return View(oSolAdquisicion);*/
            return View();
        }

        public List<tb_SolAdquisicionDet> ModelArticulo(int CodSolAdquisicion)
        {
            /*List<tb_SolAdquisicionDet> listaResponse = new List<tb_SolAdquisicionDet>();

            var oQueryDet = (from oAdquisicionDet in database.tb_SolAdquisicionDet.ToList()
                             join oArticulo in database.tb_Articulo.ToList() on
                                oAdquisicionDet.CodArticulo equals oArticulo.CodArticulo
                             join oUnidadmedida in database.tb_UnidadMedida.ToList() on
                                oArticulo.CodUnidMedida equals oUnidadmedida.CodUnidMedida

                             where oAdquisicionDet.CodSolAdquisicion == CodSolAdquisicion

                             select new
                             {
                                 oAdquisicionDet.CodSolAdquisicionDet,
                                 oAdquisicionDet.CodSolAdquisicion,
                                 oAdquisicionDet.CodProveedor,
                                 oAdquisicionDet.CodArticulo,
                                 oAdquisicionDet.Cantidad
                             }).ToList();

            List<tb_SolAdquisicionDet> listaArticulos = new List<tb_SolAdquisicionDet>();
            tb_SolAdquisicionDet obj = new tb_SolAdquisicionDet();

            if (oQueryDet.Count > 0)
            {
                foreach (var item in oQueryDet)
                {
                    obj = new tb_SolAdquisicionDet();
                    obj.CodSolAdquisicionDet = item.CodSolAdquisicionDet;
                    obj.CodSolAdquisicion = item.CodSolAdquisicion;
                    obj.CodProveedor = item.CodProveedor;
                    obj.CodArticulo = item.CodArticulo;
                    obj.Cantidad = int.Parse(item.Cantidad.ToString());
                    listaArticulos.Add(obj);
                }
            }
            else
            {
                listaArticulos = new List<tb_SolAdquisicionDet>();
            }
            listaResponse = listaArticulos;
            return listaResponse;*/
            return null;
        }


        [HttpPost]
        public ActionResult EditarAdquisicion(ItemSolAdquisicion oSolAdquisicion)
        {
            /*if (oSolAdquisicion != null)
            {
                tb_SolAdquisicion oSolAdq = new tb_SolAdquisicion();
                oSolAdq.CodSolAdquisicion = oSolAdquisicion.CodSolAdquisicion;
                oSolAdq.FechaEmision = oSolAdquisicion.FechaEmision;
                oSolAdq.CodSolicitante = oSolAdquisicion.CodSolicitante;
                oSolAdq.CodEmpleado = oSolAdquisicion.CodSolicitante;
                oSolAdq.CodEstado = oSolAdquisicion.CodEstado;
                oSolAdq.NroInforme = oSolAdquisicion.NroInforme;
                oSolAdq.Observacion = oSolAdquisicion.Observacion;

                DA_SolAdquisicion proceso = new DA_SolAdquisicion();
                proceso.EditarSolicitudCotizacion(oSolAdq);

                //ELIMINAR TODOS LOS ARTICULOS
                List<tb_SolAdquisicionDet> listaEliminar = ModelArticulo(oSolAdquisicion.CodSolAdquisicion);
                foreach (tb_SolAdquisicionDet item in listaEliminar)
                {
                    DA_SolAdquisicionDet procesoDetEliminar = new DA_SolAdquisicionDet();
                    procesoDetEliminar.EliminarSolicitudCotizacion(item);
                }


                //GRABAR ARTICULOS
                if (Session["ListaArticulosAdquisicion"] != null)
                {
                    List<ArticuloModel> listaArticulo = new List<ArticuloModel>();
                    listaArticulo = (List<ArticuloModel>)Session["ListaArticulosAdquisicion"];

                    tb_SolAdquisicionDet oDet;
                    foreach (ArticuloModel item in listaArticulo)
                    {
                        oDet = new tb_SolAdquisicionDet();
                        oDet.CodSolAdquisicion = oSolAdquisicion.CodSolAdquisicion;
                        oDet.CodProveedor = 1;
                        oDet.CodArticulo = item.CodArticulo;
                        oDet.Cantidad = item.Cantidad;


                        DA_SolAdquisicionDet procesoDet = new DA_SolAdquisicionDet();
                        procesoDet.AgregarSolicitudAdquisicionDet(oDet);
                    }
                    Session["ListaArticulosAdquisicion"] = null;
                }


            }*/
            return RedirectToAction("Index", "Adquisicion");
        }


        public ActionResult BuscarArticulos(int? CodArticulo = null, string Nombre = null)
        {
            /*var listaArticulo = (from oArticulo in database.tb_Articulo.ToList()
                                 join oUnidadmedida in database.tb_UnidadMedida.ToList() on
                                          oArticulo.CodUnidMedida equals oUnidadmedida.CodUnidMedida
                                 select new
                                 {
                                     oArticulo.CodArticulo,
                                     oArticulo.CodUnidMedida,
                                     oArticulo.Marca,
                                     oArticulo.Modelo,
                                     oArticulo.Nombre,
                                     UnidadMedida = oUnidadmedida.Nombre
                                 }).ToList();

            ArticuloModel obj = new ArticuloModel();
            List<ArticuloModel> lista = new List<ArticuloModel>();
            foreach (var item in listaArticulo)
            {
                obj = new ArticuloModel();
                obj.CodArticulo = item.CodArticulo;
                obj.Descripcion = item.Nombre;
                obj.Marca = item.Marca;
                obj.Modelo = item.Modelo;
                obj.UnidadMedida = item.UnidadMedida;
                lista.Add(obj);
            }

            if (CodArticulo != null && CodArticulo > 0)
            {
                lista = lista.Where(x => x.CodArticulo == CodArticulo).ToList();
            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                lista = lista.Where(x => x.Descripcion == Nombre).ToList();
            }
            ViewBag.ListArticulos = lista;*/
            return View();
        }

        public ActionResult RegistrarArticulos(int? CodArticulo = null, string Cantidad = null)
        {
            /*var Articulo = (from oArticulo in database.tb_Articulo.ToList()
                            where oArticulo.CodArticulo == CodArticulo
                            select new
                            {
                                oArticulo.CodArticulo,
                                oArticulo.CodUnidMedida,
                                oArticulo.Marca,
                                oArticulo.Modelo,
                                oArticulo.Nombre,
                                CantidadArticulo = Cantidad
                            }).ToList();

            ArticuloModel objArticulo = new ArticuloModel();
            List<ArticuloModel> listaArticulo = new List<ArticuloModel>();
            foreach (var item in Articulo)
            {
                objArticulo.CodArticulo = item.CodArticulo;
                objArticulo.Descripcion = item.Nombre;
                objArticulo.Marca = item.Marca;
                objArticulo.Modelo = item.Modelo;
                objArticulo.UnidadMedida = item.CodUnidMedida;
                objArticulo.Cantidad = int.Parse(item.CantidadArticulo);
                listaArticulo.Add(objArticulo);
            }

            if (Session["ListaArticulosAdquisicion"] == null)
            {
                Session["ListaArticulosAdquisicion"] = listaArticulo;
            }
            else
            {
                List<ArticuloModel> listaArticuloProvisional = new List<ArticuloModel>();
                List<ArticuloModel> listaArticuloResponse = new List<ArticuloModel>();

                listaArticuloProvisional = (List<ArticuloModel>)Session["ListaArticulosAdquisicion"];
                listaArticuloResponse = (List<ArticuloModel>)Session["ListaArticulosAdquisicion"];

                listaArticuloProvisional = listaArticuloProvisional.Where(x => x.CodArticulo == CodArticulo).ToList();
                if (listaArticuloProvisional.Count == 0)
                {
                    listaArticuloResponse.Add(objArticulo);
                }
                Session["ListaArticulosAdquisicion"] = listaArticuloResponse;
            }


            ViewBag.ListaArticulosAgregados = (List<ArticuloModel>)Session["ListaArticulosAdquisicion"];*/
            return View();
        }


        public ActionResult EliminarArticulo( int? CodArticulo =  null)
        {
            /*List<ArticuloModel> listaArticulo = null;
            List<ArticuloModel> listaResponse = new List<ArticuloModel>();
            if (Session["ListaArticulosAdquisicion"] == null)
            {
                listaArticulo = new List<ArticuloModel>();
            }
            else
            {
                listaArticulo = (List<ArticuloModel>)Session["ListaArticulosAdquisicion"];
                if(listaArticulo.Count>0)
                {
                    foreach (var item in listaArticulo)
                    {
                        if(item.CodArticulo != CodArticulo)
                        {
                            listaResponse.Add(item); 
                        }
                    }
                }
            }

            Session["ListaArticulosAdquisicion"] = listaResponse;
            ViewBag.ListaArticulosAgregados = (List<ArticuloModel>)Session["ListaArticulosAdquisicion"];*/

            return View();
        }
    }
}