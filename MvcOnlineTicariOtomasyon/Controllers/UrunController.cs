using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;




namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var degerler = c.Uruns.Where(z => z.Durum == true);

            var urunler = from x in degerler select x;

            if (!string.IsNullOrEmpty(p))
            {
                // urunler = urunler.Where(x => x.Durum == true);
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
                
                    
            }
            
            
            
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            var Urun = c.Uruns.Find(id);
            return View("UrunGetir", Urun);
        }

        public ActionResult UrunGuncelle(Urun k)
        {
            var urn = c.Uruns.Find(k.UrunID);
            urn.UrunAd = k.UrunAd;
            urn.Marka = k.Marka;
            urn.Stok = k.Stok;
            urn.AlisFiyat = k.AlisFiyat;
            urn.SatisFiyat = k.SatisFiyat;
            urn.KategoriID = k.KategoriID;
            urn.UrunGorsel = k.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
         
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;

            return View();
            
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.SatisTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }

    }
}