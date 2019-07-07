using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class subtipoactivospController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: subtipoactivosp
        public async Task<ActionResult> Index()
        {
            var subtipoactivo = db.subtipoactivo.Include(s => s.tipoactivo1);
            return View(await subtipoactivo.ToListAsync());
        }

        // GET: subtipoactivosp/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subtipoactivo subtipoactivo = await db.subtipoactivo.FindAsync(id);
            if (subtipoactivo == null)
            {
                return HttpNotFound();
            }
            return View(subtipoactivo);
        }

        // GET: subtipoactivosp/Create
        public ActionResult Create()
        {
            ViewBag.tipoactivo = new SelectList(db.tipoactivo, "id", "descripcion");
            return View();
        }

        // POST: subtipoactivosp/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipoactivo,descripcion")] subtipoactivo subtipoactivo)
        {
            if (ModelState.IsValid)
            {
                db.subtipoactivo.Add(subtipoactivo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tipoactivo = new SelectList(db.tipoactivo, "id", "descripcion", subtipoactivo.tipoactivo);
            return View(subtipoactivo);
        }

        // GET: subtipoactivosp/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subtipoactivo subtipoactivo = await db.subtipoactivo.FindAsync(id);
            if (subtipoactivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoactivo = new SelectList(db.tipoactivo, "id", "descripcion", subtipoactivo.tipoactivo);
            return View(subtipoactivo);
        }

        // POST: subtipoactivosp/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipoactivo,descripcion")] subtipoactivo subtipoactivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subtipoactivo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipoactivo = new SelectList(db.tipoactivo, "id", "descripcion", subtipoactivo.tipoactivo);
            return View(subtipoactivo);
        }

        // GET: subtipoactivosp/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subtipoactivo subtipoactivo = await db.subtipoactivo.FindAsync(id);
            if (subtipoactivo == null)
            {
                return HttpNotFound();
            }
            return View(subtipoactivo);
        }

        // POST: subtipoactivosp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            subtipoactivo subtipoactivo = await db.subtipoactivo.FindAsync(id);
            db.subtipoactivo.Remove(subtipoactivo);
            await db.SaveChangesAsync();
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
