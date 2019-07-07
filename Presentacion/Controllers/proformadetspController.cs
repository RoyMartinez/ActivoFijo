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
    public class proformadetspController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: proformadetsp
        public async Task<ActionResult> Index()
        {
            var proformadet = db.proformadet.Include(p => p.proformacab);
            return View(await proformadet.ToListAsync());
        }

        // GET: proformadetsp/Details/5
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

        // GET: proformadetsp/Create
        public ActionResult Create()
        {
            ViewBag.cabecera = new SelectList(db.proformacab, "id", "numeroserie");
            return View();
        }

        // POST: proformadetsp/Create
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

        // GET: proformadetsp/Edit/5
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

        // POST: proformadetsp/Edit/5
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

        // GET: proformadetsp/Delete/5
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

        // POST: proformadetsp/Delete/5
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
