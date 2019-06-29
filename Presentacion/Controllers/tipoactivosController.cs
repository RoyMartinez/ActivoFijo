using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos;

namespace Presentacion.Controllers
{
    public class tipoactivosController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: tipoactivos
        public async Task<ActionResult> Index()
        {
            return View(await db.tipoactivo.ToListAsync());
        }

        // GET: tipoactivos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoactivo tipoactivo = await db.tipoactivo.FindAsync(id);
            if (tipoactivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoactivo);
        }

        // GET: tipoactivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoactivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,descripcion")] tipoactivo tipoactivo)
        {
            if (ModelState.IsValid)
            {
                db.tipoactivo.Add(tipoactivo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoactivo);
        }

        // GET: tipoactivos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoactivo tipoactivo = await db.tipoactivo.FindAsync(id);
            if (tipoactivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoactivo);
        }

        // POST: tipoactivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,descripcion")] tipoactivo tipoactivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoactivo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoactivo);
        }

        // GET: tipoactivos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoactivo tipoactivo = await db.tipoactivo.FindAsync(id);
            if (tipoactivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoactivo);
        }

        // POST: tipoactivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipoactivo tipoactivo = await db.tipoactivo.FindAsync(id);
            db.tipoactivo.Remove(tipoactivo);
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
