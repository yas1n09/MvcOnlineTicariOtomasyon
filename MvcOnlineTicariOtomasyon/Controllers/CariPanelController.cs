using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            var degerler = c.Mesajlars.Where(x => x.Alici == Mail).ToList();
            ViewBag.m = Mail;

            var MailID = c.Caris.Where(x => x.CariMail == Mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mid = MailID;
            var ToplamSatis = c.SatisHarekets.Where(x => x.CariID == MailID).Count();
            ViewBag.ToplamSatis = ToplamSatis;
            var ToplamTutar = c.SatisHarekets.Where(x => x.CariID == MailID).Sum(y => y.SatisToplamTutar);
            ViewBag.ToplamTutar = ToplamTutar;
            var ToplamUrunSayisi=c.SatisHarekets.Where(x => x.CariID == MailID).Sum(y => y.SatisAdet);
            ViewBag.ToplamUrunSayisi = ToplamUrunSayisi;
            var AdSoyad = c.Caris.Where(x => x.CariMail == Mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.AdSoyad = AdSoyad;


            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];

            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
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



        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {

            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gelensayisi;

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;

            c.Mesajlars.Add(m);
            c.SaveChanges();

            return View();
        }
        [Authorize]
        public ActionResult KargoTakip(string p)
        {

            var k = from x in c.KargoDetays select x;

                k = k.Where(y => y.TakipKodu == p);

            return View(k.ToList());

            
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {

            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var CariBul = c.Caris.Find(id);
            return PartialView("Partial1", CariBul);

        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(veriler);
        }
    }
}