using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }
        //ürün
        //cari
        //personel

        public DateTime SatisHareketTarih { get; set; }
        public int SatisHareketAdet { get; set; }
        public decimal SatisHareketFiyat { get; set; }
        public decimal SatisHareketToplamTutar { get; set; }



        public ICollection<Urun> Uruns { get; set; }
        public ICollection<Cari> Caris { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}