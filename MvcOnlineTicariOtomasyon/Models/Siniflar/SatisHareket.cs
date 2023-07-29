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
        public int SatisID { get; set; }
        [Display(Name = "Satış Tarihi")]
        public DateTime SatisTarih { get; set; }
        [Display(Name = "Satış Adedi")]
        public int SatisAdet { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }
        [Display(Name = "Toplam Satış Tutarı")]
        public decimal SatisToplamTutar { get; set; }
   
        public int UrunID { get; set; }

        public int CariID { get; set; }

        public int PersonelID { get; set; }

        [Display(Name = "Ürün")]
        public virtual Urun Urun { get; set; }
        [Display(Name = "Cari")]
        public virtual Cari Cari { get; set; }
        [Display(Name = "Personel")]
        public virtual Personel Personel { get; set; }
    }
}