using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMSTp2.DataModel;

namespace GMSTp2.WebSite.Controllers
{
    public class Periodo_AcademicoController : Controller
    {
        private GMSData db = new GMSData();

        // GET: Periodo_Academico
        public ActionResult Index()
        {
            return View(db.Periodo_Academico.ToList());
        }

        public Periodo_Academico ObtenerActual()
        {
            return db.Periodo_Academico.Where(f => ((DateTime)f.FechaInicio).Year == DateTime.Today.Year).FirstOrDefault();
        }


        public IEnumerable<SelectListItem> Combo()
        {
            var data_list = db.Periodo_Academico
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodPeriodo.ToString(),
                                    Text = x.NomPeriodo
                                });

            return new SelectList(data_list, "Value", "Text");
        }

        // GET: Periodo_Academico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo_Academico periodo_Academico = db.Periodo_Academico.Find(id);
            if (periodo_Academico == null)
            {
                return HttpNotFound();
            }
            return View(periodo_Academico);
        }

        // GET: Periodo_Academico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodo_Academico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPeriodo,NomPeriodo,NomActividad,FechaInicio,FechaFin")] Periodo_Academico periodo_Academico)
        {
            if (ModelState.IsValid)
            {
                db.Periodo_Academico.Add(periodo_Academico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodo_Academico);
        }

        // GET: Periodo_Academico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo_Academico periodo_Academico = db.Periodo_Academico.Find(id);
            if (periodo_Academico == null)
            {
                return HttpNotFound();
            }
            return View(periodo_Academico);
        }

        // POST: Periodo_Academico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPeriodo,NomPeriodo,NomActividad,FechaInicio,FechaFin")] Periodo_Academico periodo_Academico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo_Academico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodo_Academico);
        }

        // GET: Periodo_Academico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo_Academico periodo_Academico = db.Periodo_Academico.Find(id);
            if (periodo_Academico == null)
            {
                return HttpNotFound();
            }
            return View(periodo_Academico);
        }

        // POST: Periodo_Academico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodo_Academico periodo_Academico = db.Periodo_Academico.Find(id);
            db.Periodo_Academico.Remove(periodo_Academico);
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
