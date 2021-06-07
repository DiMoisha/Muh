using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muh.Models
{
    public class Total
    {
        [Display(Name = "Сумма")]
        public decimal? sm { get; set; }
        [Display(Name = "Поездок")]
        public int cnt { get; set; }
        [Display(Name = "Рабочих дней")]
        public int WorkDay { get; set; }
    }
}