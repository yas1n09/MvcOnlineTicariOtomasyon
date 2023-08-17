﻿using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]

        public ActionResult Index()
        {
            var Mail = (string)Session["CariMail"];
            var degerler = c.Caris.FirstOrDefault(x => x.CariMail == Mail);
            ViewBag.m = Mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];

            var mesajlar = c.Mesajlars.Where(x=>x.Alici==mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();



            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gelensayisi;

            return View(degerler);
        }




        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            return View();
        }

    }
}