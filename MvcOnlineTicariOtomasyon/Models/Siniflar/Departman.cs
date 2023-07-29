using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }

        [Display(Name = "Departman Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }

        [Display(Name = "Departman Durumu")]
        public bool Durum { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}