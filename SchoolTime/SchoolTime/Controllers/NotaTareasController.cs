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
    public class NotaTareasController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: NotaTareas
        public ActionResult Index()
        {
            var notaTareas = db.NotaTareas.Include(n => n.Tarea);
            return View(notaTareas.ToList());
        }

        // GET: NotaTareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaTarea notaTarea = db.NotaTareas.Find(id);
            if (notaTarea == null)
            {
                return HttpNotFound();
            }
            return View(notaTarea);
        }

        // GET: NotaTareas/Create
        public ActionResult Create()
        {
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre");
            return View();
        }

        // POST: NotaTareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PunteoFinal,FechaCalificacion,TareaId")] NotaTarea notaTarea)
        {
            if (ModelState.IsValid)
            {
                db.NotaTareas.Add(notaTarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", notaTarea.TareaId);
            return View(notaTarea);
        }

        // GET: NotaTareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaTarea notaTarea = db.NotaTareas.Find(id);
            if (notaTarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", notaTarea.TareaId);
            return View(notaTarea);
        }

        // POST: NotaTareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PunteoFinal,FechaCalificacion,TareaId")] NotaTarea notaTarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notaTarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", notaTarea.TareaId);
            return View(notaTarea);
        }

        // GET: NotaTareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaTarea notaTarea = db.NotaTareas.Find(id);
            if (notaTarea == null)
            {
                return HttpNotFound();
            }
            return View(notaTarea);
        }

        // POST: NotaTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotaTarea notaTarea = db.NotaTareas.Find(id);
            db.NotaTareas.Remove(notaTarea);
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
