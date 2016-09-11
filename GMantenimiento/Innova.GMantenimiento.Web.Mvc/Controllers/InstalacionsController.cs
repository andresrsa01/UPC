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
    public class InstalacionsController : Controller
    {
        private GMSData db = new GMSData();

        // GET: Instalacions
        public ActionResult Index()
        {
            return View(db.Instalacion.ToList());
        }

        public IEnumerable<SelectListItem> Combo()
        {
            var data_list = db.Instalacion
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodInstalacion.ToString(),
                                    Text = x.NomInstalacion
                                });

            return new SelectList(data_list, "Value", "Text");
        }

        public Instalacion Obtener(int? codigo)
        {
            return db.Instalacion.Where(f => f.CodInstalacion == codigo).FirstOrDefault();
        }

        // GET: Instalacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalacion instalacion = db.Instalacion.Find(id);
            if (instalacion == null)
            {
                return HttpNotFound();
            }
            return View(instalacion);
        }

        // GET: Instalacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instalacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodInstalacion,NomInstalacion,AbrevInstalacion,Aforo")] Instalacion instalacion)
        {
            if (ModelState.IsValid)
            {
                db.Instalacion.Add(instalacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instalacion);
        }

        // GET: Instalacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalacion instalacion = db.Instalacion.Find(id);
            if (instalacion == null)
            {
                return HttpNotFound();
            }
            return View(instalacion);
        }

        // POST: Instalacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodInstalacion,NomInstalacion,AbrevInstalacion,Aforo")] Instalacion instalacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instalacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instalacion);
        }

        // GET: Instalacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalacion instalacion = db.Instalacion.Find(id);
            if (instalacion == null)
            {
                return HttpNotFound();
            }
            return View(instalacion);
        }

        // POST: Instalacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instalacion instalacion = db.Instalacion.Find(id);
            db.Instalacion.Remove(instalacion);
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
