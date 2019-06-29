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
    public class facturasController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: facturas
        public async Task<ActionResult> Index()
        {
            var factura = db.factura.Include(f => f.proveedor1);
            return View(await factura.ToListAsync());
        }

        // GET: facturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = await db.factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa");
            return View();
        }

        // POST: facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,numerofactura,proveedor,fechaemision,fechaingreso")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.factura.Add(factura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa", factura.proveedor);
            return View(factura);
        }

        // GET: facturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = await db.factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa", factura.proveedor);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,numerofactura,proveedor,fechaemision,fechaingreso")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.proveedor = new SelectList(db.proveedor, "id", "empresa", factura.proveedor);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = await db.factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            factura factura = await db.factura.FindAsync(id);
            db.factura.Remove(factura);
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
