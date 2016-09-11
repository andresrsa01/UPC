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
    public class Calidad_MantenimientoController : Controller
    {
        private GMSData db = new GMSData();

        // GET: Calidad_Mantenimiento
        public ActionResult Index()
        {
            return View(db.Calidad_Mantenimiento.ToList());
        }

        // GET: Calidad_Mantenimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calidad_Mantenimiento calidad_Mantenimiento = db.Calidad_Mantenimiento.Find(id);
            if (calidad_Mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(calidad_Mantenimiento);
        }

        // GET: Calidad_Mantenimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calidad_Mantenimiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodConsolidado,FechaRegistro,CodPlanner,CodPeriodo,CodEstado")] Calidad_Mantenimiento calidad_Mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Calidad_Mantenimiento.Add(calidad_Mantenimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calidad_Mantenimiento);
        }

        // GET: Calidad_Mantenimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calidad_Mantenimiento calidad_Mantenimiento = db.Calidad_Mantenimiento.Find(id);
            if (calidad_Mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(calidad_Mantenimiento);
        }

        // POST: Calidad_Mantenimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodConsolidado,FechaRegistro,CodPlanner,CodPeriodo,CodEstado")] Calidad_Mantenimiento calidad_Mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calidad_Mantenimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calidad_Mantenimiento);
        }

        // GET: Calidad_Mantenimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calidad_Mantenimiento calidad_Mantenimiento = db.Calidad_Mantenimiento.Find(id);
            if (calidad_Mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(calidad_Mantenimiento);
        }

        // POST: Calidad_Mantenimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calidad_Mantenimiento calidad_Mantenimiento = db.Calidad_Mantenimiento.Find(id);
            db.Calidad_Mantenimiento.Remove(calidad_Mantenimiento);
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
