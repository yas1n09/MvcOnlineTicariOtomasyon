using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Display(Name = "Cari Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter.")]
        public string CariAd { get; set; }

        [Display(Name = "Cari Soyadı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        public string CariSoyad { get; set; }

        [Display(Name = "Cari Şehiri")]
        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string CariSehir { get; set; }

        [Display(Name = "Cari Mail Adresi")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        [Display(Name = "Cari Durumu")]
        public bool Durum { get; set; }


        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}