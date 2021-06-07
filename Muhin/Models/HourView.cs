using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muh.Models
{
    [Table("bHour")]
    public class HourView
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CategID { get; set; }
        public string  txt { get; set; }
        [DisplayName("Кол-во")]
        [DisplayFormat(DataFormatString = "{0:###,#.#}")]
        public decimal kol { get; set; }
        public DateTime Dat { get; set; }
    }
}