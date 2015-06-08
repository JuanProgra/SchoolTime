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
    public class CategoriaCursoesController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: CategoriaCursoes
        public ActionResult Index()
        {
            var categoriaCursoes = db.CategoriaCursoes.Include(c => c.Categoria).Include(c => c.Curso);
            return View(categoriaCursoes.ToList());
        }

        // GET: CategoriaCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaCurso categoriaCurso = db.CategoriaCursoes.Find(id);
            if (categoriaCurso == null)
            {
                return HttpNotFound();
            }
            return View(categoriaCurso);
        }

        // GET: CategoriaCursoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre");
            return View();
        }

        // POST: CategoriaCursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoriaId,CursoId")] CategoriaCurso categoriaCurso)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaCursoes.Add(categoriaCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", categoriaCurso.CategoriaId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", categoriaCurso.CursoId);
            return View(categoriaCurso);
        }

        // GET: CategoriaCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaCurso categoriaCurso = db.CategoriaCursoes.Find(id);
            if (categoriaCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", categoriaCurso.CategoriaId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", categoriaCurso.CursoId);
            return View(categoriaCurso);
        }

        // POST: CategoriaCursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoriaId,CursoId")] CategoriaCurso categoriaCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", categoriaCurso.CategoriaId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", categoriaCurso.CursoId);
            return View(categoriaCurso);
        }

        // GET: CategoriaCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaCurso categoriaCurso = db.CategoriaCursoes.Find(id);
            if (categoriaCurso == null)
            {
                return HttpNotFound();
            }
            return View(categoriaCurso);
        }

        // POST: CategoriaCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaCurso categoriaCurso = db.CategoriaCursoes.Find(id);
            db.CategoriaCursoes.Remove(categoriaCurso);
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
