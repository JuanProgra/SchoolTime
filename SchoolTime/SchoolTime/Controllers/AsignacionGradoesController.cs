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
    public class AsignacionGradoesController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: AsignacionGradoes
        public ActionResult Index()
        {
            var asignacionGradoes = db.AsignacionGradoes.Include(a => a.Curso).Include(a => a.Grado);
            return View(asignacionGradoes.ToList());
        }

        // GET: AsignacionGradoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionGrado asignacionGrado = db.AsignacionGradoes.Find(id);
            if (asignacionGrado == null)
            {
                return HttpNotFound();
            }
            return View(asignacionGrado);
        }

        // GET: AsignacionGradoes/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre");
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre");
            return View();
        }

        // POST: AsignacionGradoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CursoId,GradoId")] AsignacionGrado asignacionGrado)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionGradoes.Add(asignacionGrado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", asignacionGrado.CursoId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", asignacionGrado.GradoId);
            return View(asignacionGrado);
        }

        // GET: AsignacionGradoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionGrado asignacionGrado = db.AsignacionGradoes.Find(id);
            if (asignacionGrado == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", asignacionGrado.CursoId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", asignacionGrado.GradoId);
            return View(asignacionGrado);
        }

        // POST: AsignacionGradoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CursoId,GradoId")] AsignacionGrado asignacionGrado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionGrado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", asignacionGrado.CursoId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", asignacionGrado.GradoId);
            return View(asignacionGrado);
        }

        // GET: AsignacionGradoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionGrado asignacionGrado = db.AsignacionGradoes.Find(id);
            if (asignacionGrado == null)
            {
                return HttpNotFound();
            }
            return View(asignacionGrado);
        }

        // POST: AsignacionGradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionGrado asignacionGrado = db.AsignacionGradoes.Find(id);
            db.AsignacionGradoes.Remove(asignacionGrado);
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
