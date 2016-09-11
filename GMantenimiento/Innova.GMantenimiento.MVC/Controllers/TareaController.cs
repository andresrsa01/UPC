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

namespace Innova.GMantenimiento.MVC.Controllers
{
    public class TareaController : Controller
    {


        public IEnumerable<SelectListItem> Combo()
        {
            BL_Tarea tarea = new BL_Tarea();
            List<tb_Tarea> lista = new List<tb_Tarea>();
            lista = tarea.Listar();
            var data_list = lista
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodTarea.ToString(),
                                    Text = x.Nombre
                                });

            return new SelectList(data_list, "Value", "Text");
        }


        public tb_Tarea Obtener(int? codigo)
        {
            BL_Tarea tarea = new BL_Tarea();
            return tarea.Obtener(Convert.ToInt32(codigo));
        }

        // GET: Tarea 
        public ActionResult Index(string valor)
        {
            BL_Tarea tarea = new BL_Tarea();
            List<tb_Tarea> t = new List<tb_Tarea>();
            tb_Tarea filtro = new tb_Tarea();

            if (valor == null)
            {
                filtro.Nombre = string.Empty;
                filtro.AbrevTarea = string.Empty;
            }
            else {
                filtro.Nombre = valor;
                filtro.AbrevTarea = valor;
            }

                t = tarea.ListarFiltro(filtro); 

            return View(t);
        }


        public ActionResult ReporteListadoTarea() { 
            BL_Tarea tarea = new BL_Tarea();
            string filename = tarea.ImprimirReporte();
            return File(filename, "application/pdf", Server.UrlEncode(filename));
        }

        // GET: Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Tarea proceso = new BL_Tarea();
            tb_Tarea tarea = proceso.Obtener(Convert.ToInt32(id));
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
        public ActionResult Create([Bind(Include = "CodTarea,Nombre,AbrevTarea")] tb_Tarea tarea)
        {
            BL_Tarea proceso = new BL_Tarea();
            if (ModelState.IsValid)
            {
                if (proceso.exists(tarea)==false)
                {
                    proceso.Registrar(tarea);
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
            BL_Tarea proceso = new BL_Tarea();
            tb_Tarea tarea = proceso.Obtener(Convert.ToInt32(id));
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
        public ActionResult Edit([Bind(Include = "CodTarea,Nombre,AbrevTarea")] tb_Tarea tarea)
        {
            BL_Tarea proceso = new BL_Tarea();
            if (ModelState.IsValid)
            {
                if (proceso.exists(tarea) == false)
                {
                    proceso.Modificar(tarea);
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

            BL_Tarea proceso = new BL_Tarea();
           tb_Tarea tarea = proceso.Obtener(Convert.ToInt32(id));
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
