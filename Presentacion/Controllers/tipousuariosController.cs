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
    public class tipousuariosController : Controller
    {
        private Login db = new Login();

        // GET: tipousuarios
        public async Task<ActionResult> Index()
        {
            return View(await db.tipousuario.ToListAsync());
        }

        // GET: tipousuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipousuario tipousuario = await db.tipousuario.FindAsync(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // GET: tipousuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipousuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo")] tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.tipousuario.Add(tipousuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipousuario);
        }

        // GET: tipousuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipousuario tipousuario = await db.tipousuario.FindAsync(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // POST: tipousuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo")] tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipousuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipousuario);
        }

        // GET: tipousuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipousuario tipousuario = await db.tipousuario.FindAsync(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // POST: tipousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipousuario tipousuario = await db.tipousuario.FindAsync(id);
            db.tipousuario.Remove(tipousuario);
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
