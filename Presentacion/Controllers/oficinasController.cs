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
    public class oficinasController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: oficinas
        public async Task<ActionResult> Index()
        {
            var oficina = db.oficina.Include(o => o.departamento1);
            return View(await oficina.ToListAsync());
        }

        // GET: oficinas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oficina oficina = await db.oficina.FindAsync(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // GET: oficinas/Create
        public ActionResult Create()
        {
            ViewBag.departamento = new SelectList(db.departamento, "id", "nombre");
            return View();
        }

        // POST: oficinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,departamento,nombre")] oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.oficina.Add(oficina);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.departamento = new SelectList(db.departamento, "id", "nombre", oficina.departamento);
            return View(oficina);
        }

        // GET: oficinas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oficina oficina = await db.oficina.FindAsync(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            ViewBag.departamento = new SelectList(db.departamento, "id", "nombre", oficina.departamento);
            return View(oficina);
        }

        // POST: oficinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,departamento,nombre")] oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oficina).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.departamento = new SelectList(db.departamento, "id", "nombre", oficina.departamento);
            return View(oficina);
        }

        // GET: oficinas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oficina oficina = await db.oficina.FindAsync(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // POST: oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            oficina oficina = await db.oficina.FindAsync(id);
            db.oficina.Remove(oficina);
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
