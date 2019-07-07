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
    public class empleadospController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: empleadosp
        public async Task<ActionResult> Index()
        {
            var empleado = db.empleado.Include(e => e.oficina1);
            return View(await empleado.ToListAsync());
        }

        // GET: empleadosp/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = await db.empleado.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: empleadosp/Create
        public ActionResult Create()
        {
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre");
            return View();
        }

        // POST: empleadosp/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,puesto,codigo,oficina")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre", empleado.oficina);
            return View(empleado);
        }

        // GET: empleadosp/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = await db.empleado.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre", empleado.oficina);
            return View(empleado);
        }

        // POST: empleadosp/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,puesto,codigo,oficina")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre", empleado.oficina);
            return View(empleado);
        }

        // GET: empleadosp/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = await db.empleado.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleadosp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            empleado empleado = await db.empleado.FindAsync(id);
            db.empleado.Remove(empleado);
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
