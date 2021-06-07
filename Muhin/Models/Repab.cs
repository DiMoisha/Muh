using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muh.Models
{
    [Table("bRepAb")]
    public class Repab
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = "Гос.№")]
        public string Gn { get; set; }
        [Display(Name = "Авто")]
        public string model { get; set; }
        [Display(Name = "Сумма")]
        public decimal? sm { get; set; }
        public int id_ab { get; set; }
        public DateTime ddat { get; set; }
    }
}