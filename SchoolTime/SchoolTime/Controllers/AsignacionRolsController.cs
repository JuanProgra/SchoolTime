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
    public class AsignacionRolsController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: AsignacionRols
        public ActionResult Index(int? SelectedRol)
        {
            var rols = db.Rols.OrderBy(q => q.Nombre).ToList();
            ViewBag.SelectedRol = new SelectList(rols, "Id", "Nombre", SelectedRol);
            int RolsID = SelectedRol.GetValueOrDefault();

            IQueryable<AsignacionRol> asignacionRols = db.AsignacionRols
                .Where(c => !SelectedRol.HasValue || c.Rol.Id == RolsID)
                .OrderBy(d => d.Rol.Nombre)
                .Include(a => a.Rol)
                .Include(a => a.Usuario);
            var sql = asignacionRols.ToString();
            //var asignacionRols = db.AsignacionRols.Include(a => a.Rol).Include(a => a.Usuario);
            return View(asignacionRols.ToList());
        }

        // GET: AsignacionRols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionRol asignacionRol = db.AsignacionRols.Find(id);
            if (asignacionRol == null)
            {
                return HttpNotFound();
            }
            return View(asignacionRol);
        }

        // GET: AsignacionRols/Create
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(db.Rols, "Id", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: AsignacionRols/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RolId,UsuarioId")] AsignacionRol asignacionRol)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionRols.Add(asignacionRol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.Rols, "Id", "Nombre", asignacionRol.RolId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", asignacionRol.UsuarioId);
            return View(asignacionRol);
        }

        // GET: AsignacionRols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionRol asignacionRol = db.AsignacionRols.Find(id);
            if (asignacionRol == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Rols, "Id", "Nombre", asignacionRol.RolId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", asignacionRol.UsuarioId);
            return View(asignacionRol);
        }

        // POST: AsignacionRols/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RolId,UsuarioId")] AsignacionRol asignacionRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionRol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Rols, "Id", "Nombre", asignacionRol.RolId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", asignacionRol.UsuarioId);
            return View(asignacionRol);
        }

        // GET: AsignacionRols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionRol asignacionRol = db.AsignacionRols.Find(id);
            if (asignacionRol == null)
            {
                return HttpNotFound();
            }
            return View(asignacionRol);
        }

        // POST: AsignacionRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionRol asignacionRol = db.AsignacionRols.Find(id);
            db.AsignacionRols.Remove(asignacionRol);
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
