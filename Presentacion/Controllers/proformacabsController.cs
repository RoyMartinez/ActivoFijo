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
    public class proformacabsController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: proformacabs
        public async Task<ActionResult> Index()
        {
            var proformacab = db.proformacab.Include(p => p.proveedor1);
            return View(await proformacab.ToListAsync());
        }

        // GET: proformacabs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proformacab proformacab = await db.proformacab.FindAsync(id);
            if (proformacab == null)
            {
                return HttpNotFound();
            }
            return View(proformacab);
        }

        // GET: proformacabs/Create
        public ActionResult Create()
        {
            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa");
            return View();
        }

        // POST: proformacabs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,proveedor,numeroserie")] proformacab proformacab)
        {
            if (ModelState.IsValid)
            {
                db.proformacab.Add(proformacab);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa", proformacab.proveedor);
            return View(proformacab);
        }

        // GET: proformacabs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proformacab proformacab = await db.proformacab.FindAsync(id);
            if (proformacab == null)
            {
                return HttpNotFound();
            }
            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa", proformacab.proveedor);
            return View(proformacab);
        }

        // POST: proformacabs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,proveedor,numeroserie")] proformacab proformacab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proformacab).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa", proformacab.proveedor);
            return View(proformacab);
        }

        // GET: proformacabs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proformacab proformacab = await db.proformacab.FindAsync(id);
            if (proformacab == null)
            {
                return HttpNotFound();
            }
            return View(proformacab);
        }

        // POST: proformacabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            proformacab proformacab = await db.proformacab.FindAsync(id);
            db.proformacab.Remove(proformacab);
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
