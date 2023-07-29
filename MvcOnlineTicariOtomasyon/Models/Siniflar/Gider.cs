using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }


        [Display(Name = "Gider Açıklaması")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string GiderAciklama { get; set; }
        [Display(Name = "Gider Tarihi")]
        public DateTime GiderTarih { get; set; }
        [Display(Name = "Gider Tutarı")]
        public decimal GiderTutar { get; set; }
    }
}