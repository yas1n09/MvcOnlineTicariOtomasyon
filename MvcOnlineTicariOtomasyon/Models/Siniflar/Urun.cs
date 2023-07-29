using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Display(Name = "Ürün Markası")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        [Display(Name = "Ürün Stoğu")]
        public short Stok { get; set; }
        [Display(Name = "Ürün Alış Fiyatı")]
        public decimal AlisFiyat { get; set; }
        [Display(Name = "Ürün Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }
        [Display(Name = "Ürün Durumu")]
        public bool Durum { get; set; }

        [Display(Name = "Ürün Görseli")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        
        public int KategoriID { get; set; }
        [Display(Name = "Kategori")]
        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}