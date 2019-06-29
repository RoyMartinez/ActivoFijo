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
    public class movimientosController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: movimientos
        public async Task<ActionResult> Index()
        {
            var movimiento = db.movimiento.Include(m => m.empleado).Include(m => m.empleado1).Include(m => m.tipomovimiento1);
            return View(await movimiento.ToListAsync());
        }

        // GET: movimientos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimiento movimiento = await db.movimiento.FindAsync(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // GET: movimientos/Create
        public ActionResult Create()
        {
            ViewBag.empleadoorigen = new SelectList(db.empleado, "id", "nombre");
            ViewBag.empleadodestino = new SelectList(db.empleado, "id", "nombre");
            ViewBag.tipomovimiento = new SelectList(db.tipomovimiento, "id", "descripcion");
            return View();
        }

        // POST: movimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipomovimiento,empleadoorigen,empleadodestino,fecha,tiempoduracion")] movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.movimiento.Add(movimiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.empleadoorigen = new SelectList(db.empleado, "id", "nombre", movimiento.empleadoorigen);
            ViewBag.empleadodestino = new SelectList(db.empleado, "id", "nombre", movimiento.empleadodestino);
            ViewBag.tipomovimiento = new SelectList(db.tipomovimiento, "id", "descripcion", movimiento.tipomovimiento);
            return View(movimiento);
        }

        // GET: movimientos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimiento movimiento = await db.movimiento.FindAsync(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.empleadoorigen = new SelectList(db.empleado, "id", "nombre", movimiento.empleadoorigen);
            ViewBag.empleadodestino = new SelectList(db.empleado, "id", "nombre", movimiento.empleadodestino);
            ViewBag.tipomovimiento = new SelectList(db.tipomovimiento, "id", "descripcion", movimiento.tipomovimiento);
            return View(movimiento);
        }

        // POST: movimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipomovimiento,empleadoorigen,empleadodestino,fecha,tiempoduracion")] movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.empleadoorigen = new SelectList(db.empleado, "id", "nombre", movimiento.empleadoorigen);
            ViewBag.empleadodestino = new SelectList(db.empleado, "id", "nombre", movimiento.empleadodestino);
            ViewBag.tipomovimiento = new SelectList(db.tipomovimiento, "id", "descripcion", movimiento.tipomovimiento);
            return View(movimiento);
        }

        // GET: movimientos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimiento movimiento = await db.movimiento.FindAsync(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // POST: movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            movimiento movimiento = await db.movimiento.FindAsync(id);
            db.movimiento.Remove(movimiento);
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
