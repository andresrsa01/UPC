using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMSTp2.DataModel;
using GMSTp2.DataModel.Auxiliares.Planner;

namespace GMSTp2.WebSite.Controllers
{
    public class Planner_mantenimientoController : Controller
    {
        private GMSData db = new GMSData();

        // GET: Planner_mantenimiento
        public ActionResult Index()
        {
            
            if (Session["programacion"] == null)
            {
                List<ItemAtencionPlanner> ListaArticulos = new List<ItemAtencionPlanner>();
                Session.Add("programacion", ListaArticulos);
            }

            return View(db.Planner_mantenimiento.ToList());
        }

        public IEnumerable<SelectListItem> Combo()
        {
            var data_list = db.Planner_mantenimiento 
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
                utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Create");
        }



        [HttpGet, ActionName("Reporteplanner")]
        public ActionResult Reporteplanner(string id)
        {

            System.Data.DataSet dst = new DataSet();

            System.Data.DataTable dtbCabecera = new DataTable();
            System.Data.DataTable dtbDetalle = new DataTable();

            utils.PDFExport pdf = new utils.PDFExport();
            utils.DataUtils datautils = new utils.DataUtils();

            try
            {
                List<Planner_mantenimiento> lp = new List<Planner_mantenimiento>();
                lp.Add(Obtener(Convert.ToInt32(id)));

                List<ItemAtencionProgramacionPlanner> li = new List<ItemAtencionProgramacionPlanner>();
                li = ListadoDetallePlanner(Convert.ToInt32(id));

                dtbCabecera = datautils.ToDataTable<Planner_mantenimiento>(lp);

                dtbDetalle = datautils.ToDataTable<ItemAtencionProgramacionPlanner>(li);
                
            }
            catch (Exception ex) {
                utils.EventLogger.EscribirLog(ex.ToString());
            }

            dtbCabecera.TableName = "cabecera";
            dtbDetalle.TableName = "detalle";
            dst.Tables.Add(dtbCabecera);
            dst.Tables.Add(dtbDetalle);

            string filename = pdf.SavePDF(dst, "Listado de Tareas", null);
            return File(filename, "application/pdf", Server.UrlEncode(filename));

            //Buscando los datos del planner 
            
        }

        public Planner_mantenimiento Obtener(int codigo) {
            return db.Planner_mantenimiento.Where(f => f.CodPlanner == codigo).FirstOrDefault();
        }

        public List<ItemAtencionProgramacionPlanner > ListadoDetallePlanner(int codigo) {
            List<ItemAtencionProgramacionPlanner> lista = new List<ItemAtencionProgramacionPlanner>();

            List<Programacion> prg = db.Programacion.Where(f => f.CodPlanner == codigo).ToList<Programacion>();

            foreach (Programacion p in prg) {
                ItemAtencionProgramacionPlanner i = new ItemAtencionProgramacionPlanner();
                i.cantidad = Convert.ToInt32 ( p.cantidad);
                i.articulo = db.Articulo.Where(f => f.CodArticulo == p.CodArticulo).FirstOrDefault().NomArticulo;
                i.instalacion = db.Instalacion.Where(f => f.CodInstalacion == p.CodInstalacion).FirstOrDefault().NomInstalacion;
                i.tarea = db.Tarea.Where(f => f.CodTarea == p.CodTarea).FirstOrDefault().NomTarea;
                lista.Add(i);
            }

            return lista;
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
                utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Create");
        }

        [HttpGet, ActionName("Aprobar")]
        public ActionResult Aprobar(int? id)
        {
            try
            {
                Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Where(f => f.CodPlanner == id).FirstOrDefault();
                planner_mantenimiento.CodEstado = 3;
                db.Entry(planner_mantenimiento).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex) {
                utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Index");
        }

        // GET: Planner_mantenimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            if (planner_mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(planner_mantenimiento);
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
        public ActionResult Create([Bind(Include = "CodPlanner,codigo,FechaInicio,FechaFin,CodPeriodo,CodEstado")] Planner_mantenimiento planner_mantenimiento)
        {
            try {
                if (ModelState.IsValid)
                {
                    //Generando el codigo del planner
                    planner_mantenimiento.codigo = string.Format("{0}{1}-{2}-{3}", DateTime.Today.Year, DateTime.Today.Month.ToString().PadLeft(2, '0'), ((DateTime)planner_mantenimiento.FechaInicio).Day, ((DateTime)planner_mantenimiento.FechaFin).Day);
                    planner_mantenimiento.FechaRegistro = DateTime.Today;
                    db.Planner_mantenimiento.Add(planner_mantenimiento);
                    db.SaveChanges();
                    @TempData["viewbag_codigo_planner"] = planner_mantenimiento.CodPlanner;

                    //Luego Procede a registrar la programación en base al objeto de sesion
                    List<ItemAtencionPlanner> ListaArticulos = new List<ItemAtencionPlanner>();
                    ListaArticulos = (List<ItemAtencionPlanner>)Session["programacion"];
                    foreach (var obj in ListaArticulos)
                    {
                        Programacion programacion = new Programacion();
                        programacion.cantidad = obj.cantidad;
                        programacion.CodArticulo = obj.CodArticulo;
                        programacion.codestado = planner_mantenimiento.CodEstado;
                        programacion.CodInstalacion = obj.CodInstalacion;
                        programacion.CodPeriodo = Convert.ToInt32(planner_mantenimiento.CodPeriodo);
                        programacion.CodPlanner = planner_mantenimiento.CodPlanner;
                        programacion.CodTarea = obj.CodTarea;
                        programacion.FechaProg = Convert.ToDateTime(obj.fecha_tentantiva_programacion);
                        db.Programacion.Add(programacion);
                        db.SaveChanges();
                    }

                    //Eliminando la lista actual
                    Session["programacion"] = new List<ItemAtencionPlanner>();
                
            }
            }
            catch (Exception ex)
            {
                utils.EventLogger.EscribirLog(ex.ToString());
            }

            return RedirectToAction("Create");
        }

        // GET: Planner_mantenimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            if (planner_mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(planner_mantenimiento);
        }

        // POST: Planner_mantenimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPlanner,codigo,FechaInicio,FechaFin,CodPeriodo,CodEstado")] Planner_mantenimiento planner_mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planner_mantenimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planner_mantenimiento);
        }

        // GET: Planner_mantenimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            if (planner_mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(planner_mantenimiento);
        }

        // POST: Planner_mantenimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planner_mantenimiento planner_mantenimiento = db.Planner_mantenimiento.Find(id);
            db.Planner_mantenimiento.Remove(planner_mantenimiento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
