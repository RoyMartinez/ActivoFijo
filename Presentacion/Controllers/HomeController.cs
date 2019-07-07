using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {

        Datos.ActivoFijoEntities db = new Datos.ActivoFijoEntities();

        public ActionResult Index()
        {

            //EmpresaPre empresa = new EmpresaPre();

            //var e = db.empresa.ToList();


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: movimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string usuario, string contraseña)
        { 

            Login db = new Login();
            var user = db.usuario.Where(p => (p.usuario1 == usuario) && (p.contrasena == contraseña)).ToList();
            if (user == null)
            {
                return View();
            }
            else
            {
                Presentacion.Globals.Globals.Usuario = usuario;
                return RedirectToAction("Index", "home");
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}