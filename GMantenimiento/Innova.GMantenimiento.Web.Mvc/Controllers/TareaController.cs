using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMSTp2.DataModel;
using GMSTp2.WebSite;

namespace GMSTp2.WebSite.Controllers
{
    public class TareaController : Controller
    {
        private GMSData db = new GMSData();


        //metodo que previene la existencia de una entidad con los mismos atributos
        private bool exists(Tarea tarea) {
            bool existe = false;

            var x = db.Tarea.Where(t => t.NomTarea == tarea.NomTarea || t.AbrevTarea == tarea.AbrevTarea).FirstOrDefault();
            if (x != null)
                existe = true;

            return existe;
        }

        public IEnumerable<SelectListItem> Combo()
        {
            var data_list = db.Tarea
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodTarea.ToString(),
                                    Text = x.NomTarea
                                });

            return new SelectList(data_list, "Value", "Text");
        }


        public Tarea Obtener(int? codigo)
        {
            return db.Tarea.Where(f => f.CodTarea == codigo).FirstOrDefault();
        }

        // GET: Tarea 
        public ActionResult Index(string valor)
        {
            List<Tarea> t = new List<Tarea>();
            if (valor != null)
                t = db.Tarea.Where(fx => fx.NomTarea.Contains(valor)).ToList();
            else
                t = db.Tarea.ToList();

            utils.EventLogger.EscribirLog("Inicia Vista > Tarea");

            return View(t);
        }


        public ActionResult ReporteListadoTarea() {

            utils.PDFExport pdf = new utils.PDFExport();
            utils.DataUtils datautils = new utils.DataUtils();
            System.Data.DataTable dtbdatos = new DataTable();
            System.Data.DataSet dst = new DataSet();
            dtbdatos.TableName = "Tareas";
            dtbdatos = datautils.ToDataTable<Tarea>(db.Tarea.ToList());
            dst.Tables.Add(dtbdatos);
            string filename = pdf.SavePDF(dst,"Listado de Tareas",null);
            return File(filename, "application/pdf", Server.UrlEncode(filename));
        }

        // GET: Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: Tarea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodTarea,NomTarea,AbrevTarea")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                if (exists(tarea)==false)
                {
                    db.Tarea.Add(tarea);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(tarea);
        }

        // GET: Tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodTarea,NomTarea,AbrevTarea")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                if (exists(tarea) == false)
                {
                    db.Entry(tarea).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(tarea);
        }

        // GET: Tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea tarea = db.Tarea.Find(id);
            db.Tarea.Remove(tarea);
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
