using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Innova.GMantenimiento.Domain;
using Innova.Common.Core.Entities;
using Innova.GMantenimiento.Infraestructure.Data.CompositeEntities;

namespace Innova.GMantenimiento.MVC.Controllers
{
    public class Planner_mantenimientoController : Controller
    { 

        // GET: Planner_mantenimiento
        public ActionResult Index()
        {
            BL_PlannerMantenimiento proceso = new BL_PlannerMantenimiento();
            if (Session["programacion"] == null)
            {
                List<ItemAtencionPlanner> ListaArticulos = new List<ItemAtencionPlanner>();
                Session.Add("programacion", ListaArticulos);
            }

            return View(proceso.Listar().ToList());
        }

        public IEnumerable<SelectListItem> Combo()
        {
            BL_PlannerMantenimiento proceso = new BL_PlannerMantenimiento();
            var data_list = proceso.Listar() 
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodPlanner.ToString(),
                                    Text = x.codigo
                                });

            return new SelectList(data_list, "Value", "Text");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarItem([Bind(Include = "CodInstalacion,CodTarea,CodArticulo,cantidad,fecha_tentantiva_programacion")] ItemAtencionPlanner programacion)
        {
            List<ItemAtencionPlanner> ListaArticulos = new List<ItemAtencionPlanner>();

            try
            {
                if (Session["programacion"] != null)
                {
                    ListaArticulos = (List<ItemAtencionPlanner>)Session["programacion"];
                }


                TempData["viewbag_hasvalues"] = "SESSION_VALUES";
                TempData["viewbag_codigo"] = Request.Params["viewbag_codigo"].ToString();
                TempData["viewbag_fechainicio"] = Request.Params["viewbag_fechainicio"].ToString();
                TempData["viewbag_fechafin"] = Request.Params["viewbag_fechafin"].ToString();
                TempData["viewbag_codperiodo"] = Request.Params["viewbag_codperiodo"].ToString();
                TempData["viewbag_codplanner"] = Request.Params["viewbag_codplanner"].ToString();

                programacion.secuencial = Guid.NewGuid().ToString().Replace("-", "");
                programacion.CodPlanner = ListaArticulos.Count + 1;
                ListaArticulos.Add(programacion);
            }
            catch (Exception ex) {
               
            }

            return RedirectToAction("Create");
        }



        [HttpGet, ActionName("Reporteplanner")]
        public ActionResult Reporteplanner(string id)
        {

            BL_PlannerMantenimiento planner = new BL_PlannerMantenimiento();
            string filename= planner.ImprimirReporte(Convert.ToInt32(id));    
            return File(filename, "application/pdf", Server.UrlEncode(filename));

            //Buscando los datos del planner 
            
        }

        public tb_Planner_Mantenimiento Obtener(int codigo) {
            BL_PlannerMantenimiento proceso = new BL_PlannerMantenimiento();
            return proceso.Obtener(codigo);
        }

     

        [HttpGet, ActionName("EliminarItem")]
        public ActionResult EliminarItem(string secuencial)
        {
            List<ItemAtencionPlanner> ListaArticulos = new List<ItemAtencionPlanner>();

            try
            {

                if (Session["programacion"] != null)
                {
                    ListaArticulos = (List<ItemAtencionPlanner>)Session["programacion"];
                }

                foreach (var obj in ListaArticulos)
                    if (obj.secuencial.Equals(secuencial))
                    {
                        ListaArticulos.Remove(obj);
                        break;
                    }
            }
            catch (Exception ex) {
                //utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Create");
        }

        [HttpGet, ActionName("Aprobar")]
        public ActionResult Aprobar(int? id)
        {
            try
            {
                BL_PlannerMantenimiento planner = new BL_PlannerMantenimiento();
                planner.CambiarEstado(Convert.ToInt32(id), 3);
            }
            catch (Exception ex) {
               // utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Index");
        }

        // GET: Planner_mantenimiento/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //tb_Planner_mantenimiento planner_mantenimiento = 
            //if (planner_mantenimiento == null)
            //{
            //    return HttpNotFound();
            //}
            return RedirectToAction("Index");
        }

        // GET: Planner_mantenimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planner_mantenimiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPlanner,codigo,FechaInicio,FechaFin,CodPeriodo,CodEstado")] tb_Planner_Mantenimiento planner_mantenimiento)
        {
            try {
                if (ModelState.IsValid)
                {
                    BL_PlannerMantenimiento planner = new BL_PlannerMantenimiento();
                    BL_Programacion prog = new BL_Programacion();

                    //Generando el codigo del planner
                    planner_mantenimiento.codigo = string.Format("{0}{1}-{2}-{3}", DateTime.Today.Year, DateTime.Today.Month.ToString().PadLeft(2, '0'), ((DateTime)planner_mantenimiento.FechaInicio).Day, ((DateTime)planner_mantenimiento.FechaFin).Day);
                    planner_mantenimiento.FechaInicio = DateTime.Today;
                    planner.Registrar(planner_mantenimiento);
                    @TempData["viewbag_codigo_planner"] = planner_mantenimiento.CodPlanner;

                    //Luego Procede a registrar la programación en base al objeto de sesion
                    List<ItemAtencionPlanner> ListaArticulos = new List<ItemAtencionPlanner>();
                    ListaArticulos = (List<ItemAtencionPlanner>)Session["programacion"];
                    foreach (var obj in ListaArticulos)
                    {
                        tb_Programacion programacion = new tb_Programacion();
                        programacion.Cantidad = obj.Cantidad;
                        programacion.CodArticulo = obj.CodArticulo;
                        programacion.CodEstado = planner_mantenimiento.CodEstado;
                        programacion.CodInstalacion = obj.CodInstalacion;
                        programacion.CodPeriodo = Convert.ToInt32(planner_mantenimiento.CodPeriodo);
                        programacion.CodPlanner = planner_mantenimiento.CodPlanner;
                        programacion.CodTarea = obj.CodTarea;
                        programacion.FechaProg = Convert.ToDateTime(obj.fecha_tentantiva_programacion);
                        prog.Registrar(programacion);
                    }

                    //Eliminando la lista actual
                    Session["programacion"] = new List<ItemAtencionPlanner>();
                
            }
            }
            catch (Exception ex)
            {
                //utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Create");
        }

        // GET: Planner_mantenimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            //if (planner_mantenimiento == null)
            //{
            //    return HttpNotFound();
            //}
            return RedirectToAction("Index");
        }

        // POST: Planner_mantenimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPlanner,codigo,FechaInicio,FechaFin,CodPeriodo,CodEstado")] tb_Planner_Mantenimiento planner_mantenimiento)
        {
            //if (ModelState.IsValid)
            //{
            //    BL_PlannerMantenimiento proceso = new BL_PlannerMantenimiento();
            //    proceso.Modificar(planner_mantenimiento);
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }

        // GET: Planner_mantenimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            //if (planner_mantenimiento == null)
            //{
            //    return HttpNotFound();
            //}
            return RedirectToAction("Index");
        }

        // POST: Planner_mantenimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            //db.Planner_mantenimiento.Remove(planner_mantenimiento);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
