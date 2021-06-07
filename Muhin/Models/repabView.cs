using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muh.Models
{
    public class RepabView
    {
        [Display(Name = "Гос.№")]
        public string Gn { get; set; }
        [Display(Name = "Сумма")]
        public decimal? sm { get; set; }
        [Display(Name = "Авто")]
        public string model { get; set; }
        [Display(Name = "Поездок")]
        public int cnt { get; set; }
        [Display(Name = "Рабочих дней")]
        public int WorkDay { get; set; }
        [Display(Name = "Сумма/Поездок")]
        public decimal? avgAll { get; set; }
        [Display(Name = "Сумма/Рабочих дней")]
        public decimal? avgDay { get; set; }
    }
}