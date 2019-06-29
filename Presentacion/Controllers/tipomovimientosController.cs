﻿using System;
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
    public class tipomovimientosController : Controller
    {
        private ActivoFijoEntities db = new ActivoFijoEntities();

        // GET: tipomovimientos
        public async Task<ActionResult> Index()
        {
            return View(await db.tipomovimiento.ToListAsync());
        }

        // GET: tipomovimientos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipomovimiento tipomovimiento = await db.tipomovimiento.FindAsync(id);
            if (tipomovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipomovimiento);
        }

        // GET: tipomovimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipomovimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,descripcion")] tipomovimiento tipomovimiento)
        {
            if (ModelState.IsValid)
            {
                db.tipomovimiento.Add(tipomovimiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipomovimiento);
        }

        // GET: tipomovimientos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipomovimiento tipomovimiento = await db.tipomovimiento.FindAsync(id);
            if (tipomovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipomovimiento);
        }

        // POST: tipomovimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,descripcion")] tipomovimiento tipomovimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipomovimiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipomovimiento);
        }

        // GET: tipomovimientos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipomovimiento tipomovimiento = await db.tipomovimiento.FindAsync(id);
            if (tipomovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipomovimiento);
        }

        // POST: tipomovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipomovimiento tipomovimiento = await db.tipomovimiento.FindAsync(id);
            db.tipomovimiento.Remove(tipomovimiento);
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
