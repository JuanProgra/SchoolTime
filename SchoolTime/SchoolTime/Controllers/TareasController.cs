using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolTime.Models;

namespace SchoolTime.Controllers
{
    public class TareasController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: Tareas
        public ActionResult Index()
        {
            return View(db.Tareas.ToList());
        }

        // GET: Tareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: Tareas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Detalle,Punteo,FechaEntrega")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Tareas.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Detalle,Punteo,FechaEntrega")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea tarea = db.Tareas.Find(id);
            db.Tareas.Remove(tarea);
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
