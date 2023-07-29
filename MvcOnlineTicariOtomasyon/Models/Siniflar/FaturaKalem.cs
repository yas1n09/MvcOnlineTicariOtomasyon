using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [Display(Name = "Kalem Açıklaması")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string FaturaKalemAciklama { get; set; }


        [Display(Name = "Mİktar")]
        public int Miktar { get; set; }
        [Display(Name = "Birim Fiyatı")]
        public decimal BirimFiyat { get; set; }
        [Display(Name = "Tutar")]
        public decimal Tutar { get; set; }

        public int FaturaID { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}