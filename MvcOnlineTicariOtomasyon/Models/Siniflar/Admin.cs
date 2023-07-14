using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(16)]
        public string AdminKullaniciAd { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(16)]
        public string AdminKullaniciSifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string AdminYetki { get; set; }
    }
}