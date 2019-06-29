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
    public class proformadetsController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: proformadets
        public async Task<ActionResult> Index()
        {
            var proformadet = db.proformadet.Include(p => p.proformacab);
            return View(await proformadet.ToListAsync());
        }

        // GET: proformadets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proformadet proformadet = await db.proformadet.FindAsync(id);
            if (proformadet == null)
            {
                return HttpNotFound();
            }
            return View(proformadet);
        }

        // GET: proformadets/Create
        public ActionResult Create()
        {
            ViewBag.cabecera = new SelectList(db.proformacab, "id", "numeroserie");
            return View();
        }

        // POST: proformadets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,cabecera,fila,descripcion")] proformadet proformadet)
        {
            if (ModelState.IsValid)
            {
                db.proformadet.Add(proformadet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cabecera = new SelectList(db.proformacab, "id", "numeroserie", proformadet.cabecera);
            return View(proformadet);
        }

        // GET: proformadets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proformadet proformadet = await db.proformadet.FindAsync(id);
            if (proformadet == null)
            {
                return HttpNotFound();
            }
            ViewBag.cabecera = new SelectList(db.proformacab, "id", "numeroserie", proformadet.cabecera);
            return View(proformadet);
        }

        // POST: proformadets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,cabecera,fila,descripcion")] proformadet proformadet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proformadet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cabecera = new SelectList(db.proformacab, "id", "numeroserie", proformadet.cabecera);
            return View(proformadet);
        }

        // GET: proformadets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proformadet proformadet = await db.proformadet.FindAsync(id);
            if (proformadet == null)
            {
                return HttpNotFound();
            }
            return View(proformadet);
        }

        // POST: proformadets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            proformadet proformadet = await db.proformadet.FindAsync(id);
            db.proformadet.Remove(proformadet);
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
