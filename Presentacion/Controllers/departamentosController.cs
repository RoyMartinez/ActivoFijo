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
    public class departamentosController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: departamentos
        public async Task<ActionResult> Index()
        {
            var departamento = db.departamento.Include(d => d.empresa1);
            return View(await departamento.ToListAsync());
        }

        // GET: departamentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamento departamento = await db.departamento.FindAsync(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: departamentos/Create
        public ActionResult Create()
        {
            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre");
            return View();
        }

        // POST: departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,empresa,nombre")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.departamento.Add(departamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre", departamento.empresa);
            return View(departamento);
        }

        // GET: departamentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamento departamento = await db.departamento.FindAsync(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre", departamento.empresa);
            return View(departamento);
        }

        // POST: departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,empresa,nombre")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.empresa = new SelectList(db.empresa, "id", "nombre", departamento.empresa);
            return View(departamento);
        }

        // GET: departamentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamento departamento = await db.departamento.FindAsync(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            departamento departamento = await db.departamento.FindAsync(id);
            db.departamento.Remove(departamento);
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
