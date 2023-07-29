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


        [Display(Name = "Fatura Seri No")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Display(Name = "Fatura Sıra No")]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }

        [Display(Name = "Fatura Tarihi")]
        public DateTime FaturaTarih { get; set; }

        [Display(Name = "Vergi Dairesi")]
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Display(Name = "Fatura Saati")]
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }

        [Display(Name = "Fatura Teslim Eden Personel")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string FaturaTeslimEden { get; set; }

        [Display(Name = "Fatura Teslim Alan Cari")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string FaturaTeslimAlan { get; set; }

        [Display(Name = "Fatura Toplam Tutar")]
        public decimal Toplam { get; set; }


        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}