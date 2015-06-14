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
    public class AsigancionSalonsController : Controller
    {
        private SchoolTimeDbContext db = new SchoolTimeDbContext();

        // GET: AsigancionSalons
        public ActionResult Index(int? SelectedSalon)
        {

            var salon = db.Grupos.OrderBy(s => s.Codigo).ToList();
            ViewBag.SelectedSalon = new SelectList(salon, "Id", "Codigo", SelectedSalon);
            int SalonID = SelectedSalon.GetValueOrDefault();


            IQueryable<AsigancionSalon> asignacionSalonss = db.AsigancionSalons
                .Where(c => !SelectedSalon.HasValue || c.Grupo.Id == SalonID)
                .OrderBy(d => d.Salon.Nombre)
                .Include(a => a.Grupo)
                .Include(a => a.Materia)
                .Include(a => a.Salon);
            var sql = asignacionSalonss.ToString();
            return View(asignacionSalonss.ToList());
        }

        // GET: AsigancionSalons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigancionSalon asigancionSalon = db.AsigancionSalons.Find(id);
            if (asigancionSalon == null)
            {
                return HttpNotFound();
            }
            return View(asigancionSalon);
        }

        // GET: AsigancionSalons/Create
        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo");
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre");
            ViewBag.SalonId = new SelectList(db.Salon, "Id", "Nombre");
            return View();
        }

        // POST: AsigancionSalons/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SalonId,GrupoId,MateriaId,Hora,Dia")] AsigancionSalon asigancionSalon)
        {
            if (ModelState.IsValid)
            {
                db.AsigancionSalons.Add(asigancionSalon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo", asigancionSalon.GrupoId);
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre", asigancionSalon.MateriaId);
            ViewBag.SalonId = new SelectList(db.Salon, "Id", "Nombre", asigancionSalon.SalonId);
            return View(asigancionSalon);
        }

        // GET: AsigancionSalons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigancionSalon asigancionSalon = db.AsigancionSalons.Find(id);
            if (asigancionSalon == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo", asigancionSalon.GrupoId);
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre", asigancionSalon.MateriaId);
            ViewBag.SalonId = new SelectList(db.Salon, "Id", "Nombre", asigancionSalon.SalonId);
            return View(asigancionSalon);
        }

        // POST: AsigancionSalons/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SalonId,GrupoId,MateriaId,Hora,Dia")] AsigancionSalon asigancionSalon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asigancionSalon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Codigo", asigancionSalon.GrupoId);
            ViewBag.MateriaId = new SelectList(db.Materia, "Id", "Nombre", asigancionSalon.MateriaId);
            ViewBag.SalonId = new SelectList(db.Salon, "Id", "Nombre", asigancionSalon.SalonId);
            return View(asigancionSalon);
        }

        // GET: AsigancionSalons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigancionSalon asigancionSalon = db.AsigancionSalons.Find(id);
            if (asigancionSalon == null)
            {
                return HttpNotFound();
            }
            return View(asigancionSalon);
        }

        // POST: AsigancionSalons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsigancionSalon asigancionSalon = db.AsigancionSalons.Find(id);
            db.AsigancionSalons.Remove(asigancionSalon);
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
