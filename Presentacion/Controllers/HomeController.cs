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