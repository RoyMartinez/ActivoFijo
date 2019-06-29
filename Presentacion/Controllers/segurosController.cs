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
    public class segurosController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: seguros
        public async Task<ActionResult> Index()
        {
            var seguro = db.seguro.Include(s => s.empresa1);
            return View(await seguro.ToListAsync());
        }

        // GET: seguros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seguro seguro = await db.seguro.FindAsync(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // GET: seguros/Create
        public ActionResult Create()
        {
            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre");
            return View();
        }

        // POST: seguros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,numero,empresa,tiempo")] seguro seguro)
        {
            if (ModelState.IsValid)
            {
                db.seguro.Add(seguro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre", seguro.empresa);
            return View(seguro);
        }

        // GET: seguros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seguro seguro = await db.seguro.FindAsync(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre", seguro.empresa);
            return View(seguro);
        }

        // POST: seguros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,numero,empresa,tiempo")] seguro seguro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguro).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre", seguro.empresa);
            return View(seguro);
        }

        // GET: seguros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seguro seguro = await db.seguro.FindAsync(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // POST: seguros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            seguro seguro = await db.seguro.FindAsync(id);
            db.seguro.Remove(seguro);
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
