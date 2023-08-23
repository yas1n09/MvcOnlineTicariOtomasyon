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

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();

        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();

             return RedirectToAction("Index");

        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = c.Faturas.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.FaturaSaat = f.FaturaSaat;
            fatura.FaturaTarih = f.FaturaTarih;
            fatura.FaturaTeslimAlan = f.FaturaTeslimAlan;
            fatura.FaturaTeslimEden = f.FaturaTeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturas.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs); // View'e cs nesnesini aktarıyoruz
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo,DateTime FaturaTarih,string VergiDairesi,string FaturaSaat,string FaturaTeslimEden,string FaturaTeslimAlan,decimal Toplam,FaturaKalem[]kalemler)
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.FaturaTarih = FaturaTarih;
            f.VergiDairesi = VergiDairesi;
            f.FaturaSaat = FaturaSaat;
            f.FaturaTeslimEden = FaturaTeslimEden;
            f.FaturaTeslimAlan = FaturaTeslimAlan;
            f.Toplam = Toplam;
            c.Faturas.Add(f);
            foreach(var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.FaturaKalemAciklama = x.FaturaKalemAciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.FaturaID = x.FaturaKalemID;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }

    }
}