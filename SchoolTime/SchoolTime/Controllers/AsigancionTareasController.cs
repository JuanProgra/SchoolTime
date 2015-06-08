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
    public class AsigancionTareasController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: AsigancionTareas
        public ActionResult Index()
        {
            var asigancionTareas = db.AsigancionTareas.Include(a => a.Materia).Include(a => a.Tarea);
            return View(asigancionTareas.ToList());
        }

        // GET: AsigancionTareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigancionTarea asigancionTarea = db.AsigancionTareas.Find(id);
            if (asigancionTarea == null)
            {
                return HttpNotFound();
            }
            return View(asigancionTarea);
        }

        // GET: AsigancionTareas/Create
        public ActionResult Create()
        {
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre");
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre");
            return View();
        }

        // POST: AsigancionTareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MateriaId,TareaId")] AsigancionTarea asigancionTarea)
        {
            if (ModelState.IsValid)
            {
                db.AsigancionTareas.Add(asigancionTarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre", asigancionTarea.MateriaId);
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", asigancionTarea.TareaId);
            return View(asigancionTarea);
        }

        // GET: AsigancionTareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigancionTarea asigancionTarea = db.AsigancionTareas.Find(id);
            if (asigancionTarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre", asigancionTarea.MateriaId);
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", asigancionTarea.TareaId);
            return View(asigancionTarea);
        }

        // POST: AsigancionTareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MateriaId,TareaId")] AsigancionTarea asigancionTarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asigancionTarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre", asigancionTarea.MateriaId);
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", asigancionTarea.TareaId);
            return View(asigancionTarea);
        }

        // GET: AsigancionTareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigancionTarea asigancionTarea = db.AsigancionTareas.Find(id);
            if (asigancionTarea == null)
            {
                return HttpNotFound();
            }
            return View(asigancionTarea);
        }

        // POST: AsigancionTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsigancionTarea asigancionTarea = db.AsigancionTareas.Find(id);
            db.AsigancionTareas.Remove(asigancionTarea);
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
