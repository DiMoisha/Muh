using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muh.Models
{
    public class SalesByCategView
    {
        [Display(Name = "Продукция")]
        public string txt { get; set; }
        [DisplayName("Кол-во")]
        [DisplayFormat(DataFormatString = "{0:###,#.#}")]
        public decimal kol { get; set; }
        public int CategID { get; set; }

    }
}