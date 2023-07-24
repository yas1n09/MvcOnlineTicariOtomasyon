using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }
    }
}