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
    public class ProgramacionsController : Controller
    {
        private GMSData db = new GMSData();

        // GET: Programacions
        public ActionResult Index()
        {
            return View(db.Programacion.ToList());
        }

        // GET: Programacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programacion programacion = db.Programacion.Find(id);
            if (programacion == null)
            {
                return HttpNotFound();
            }
            return View(programacion);
        }

        // GET: Programacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPlanner,CodPeriodo,CodInstalacion,FechaProg,codestado")] Programacion programacion)
        {
            if (ModelState.IsValid)
            {
                db.Programacion.Add(programacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programacion);
        }

        // GET: Programacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programacion programacion = db.Programacion.Find(id);
            if (programacion == null)
            {
                return HttpNotFound();
            }
            return View(programacion);
        }

        // POST: Programacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPlanner,CodPeriodo,CodInstalacion,FechaProg,codestado")] Programacion programacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programacion);
        }

        // GET: Programacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programacion programacion = db.Programacion.Find(id);
            if (programacion == null)
            {
                return HttpNotFound();
            }
            return View(programacion);
        }

        // POST: Programacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programacion programacion = db.Programacion.Find(id);
            db.Programacion.Remove(programacion);
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
