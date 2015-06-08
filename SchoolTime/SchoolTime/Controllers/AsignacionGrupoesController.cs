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
    public class AsignacionGrupoesController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: AsignacionGrupoes
        public ActionResult Index()
        {
            var asignacionGrupoes = db.AsignacionGrupoes.Include(a => a.Grupo).Include(a => a.Usuario);
            return View(asignacionGrupoes.ToList());
        }

        // GET: AsignacionGrupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionGrupo asignacionGrupo = db.AsignacionGrupoes.Find(id);
            if (asignacionGrupo == null)
            {
                return HttpNotFound();
            }
            return View(asignacionGrupo);
        }

        // GET: AsignacionGrupoes/Create
        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: AsignacionGrupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,GrupoId")] AsignacionGrupo asignacionGrupo)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionGrupoes.Add(asignacionGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo", asignacionGrupo.GrupoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", asignacionGrupo.UsuarioId);
            return View(asignacionGrupo);
        }

        // GET: AsignacionGrupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionGrupo asignacionGrupo = db.AsignacionGrupoes.Find(id);
            if (asignacionGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo", asignacionGrupo.GrupoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", asignacionGrupo.UsuarioId);
            return View(asignacionGrupo);
        }

        // POST: AsignacionGrupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,GrupoId")] AsignacionGrupo asignacionGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionGrupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo", asignacionGrupo.GrupoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", asignacionGrupo.UsuarioId);
            return View(asignacionGrupo);
        }

        // GET: AsignacionGrupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionGrupo asignacionGrupo = db.AsignacionGrupoes.Find(id);
            if (asignacionGrupo == null)
            {
                return HttpNotFound();
            }
            return View(asignacionGrupo);
        }

        // POST: AsignacionGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionGrupo asignacionGrupo = db.AsignacionGrupoes.Find(id);
            db.AsignacionGrupoes.Remove(asignacionGrupo);
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
