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
    public class catalogosController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: catalogos
        public async Task<ActionResult> Index()
        {
            var catalogo = db.catalogo.Include(c => c.empleado1).Include(c => c.oficina1).Include(c => c.seguro1).Include(c => c.subtipoactivo1);
            return View(await catalogo.ToListAsync());
        }

        // GET: catalogos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catalogo catalogo = await db.catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            return View(catalogo);
        }

        // GET: catalogos/Create
        public ActionResult Create()
        {
            ViewBag.empleado = new SelectList(db.empleado, "id", "nombre");
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre");
            ViewBag.seguro = new SelectList(db.seguro, "id", "numero");
            ViewBag.subtipoactivo = new SelectList(db.subtipoactivo, "id", "descripcion");
            return View();
        }

        // POST: catalogos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,codigo,descripcion,subtipoactivo,empleado,oficina,seguro")] catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                db.catalogo.Add(catalogo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.empleado = new SelectList(db.empleado, "id", "nombre", catalogo.empleado);
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre", catalogo.oficina);
            ViewBag.seguro = new SelectList(db.seguro, "id", "numero", catalogo.seguro);
            ViewBag.subtipoactivo = new SelectList(db.subtipoactivo, "id", "descripcion", catalogo.subtipoactivo);
            return View(catalogo);
        }

        // GET: catalogos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catalogo catalogo = await db.catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.empleado = new SelectList(db.empleado, "id", "nombre", catalogo.empleado);
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre", catalogo.oficina);
            ViewBag.seguro = new SelectList(db.seguro, "id", "numero", catalogo.seguro);
            ViewBag.subtipoactivo = new SelectList(db.subtipoactivo, "id", "descripcion", catalogo.subtipoactivo);
            return View(catalogo);
        }

        // POST: catalogos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,codigo,descripcion,subtipoactivo,empleado,oficina,seguro")] catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.empleado = new SelectList(db.empleado, "id", "nombre", catalogo.empleado);
            ViewBag.oficina = new SelectList(db.oficina, "id", "nombre", catalogo.oficina);
            ViewBag.seguro = new SelectList(db.seguro, "id", "numero", catalogo.seguro);
            ViewBag.subtipoactivo = new SelectList(db.subtipoactivo, "id", "descripcion", catalogo.subtipoactivo);
            return View(catalogo);
        }

        // GET: catalogos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catalogo catalogo = await db.catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            return View(catalogo);
        }

        // POST: catalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            catalogo catalogo = await db.catalogo.FindAsync(id);
            db.catalogo.Remove(catalogo);
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
