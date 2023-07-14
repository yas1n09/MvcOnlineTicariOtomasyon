using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }



        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }
        public DateTime FaturaTarih { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        public DateTime FaturaSaat { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string FaturaTeslimEden { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string FaturaTeslimAlan { get; set; }



        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}