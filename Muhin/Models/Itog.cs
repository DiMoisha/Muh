using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muh.Models
{
    public class Itog
    {
        [DisplayName("Категория")]
        public string categ { get; set; }
        [DisplayName("Сутки")]
        [DisplayFormat(DataFormatString = "{0:###,#.#}")]
        public decimal qtyDay { get; set; }
        [DisplayName("Месяц")]
        [DisplayFormat(DataFormatString = "{0:###,#.#}")]
        public decimal qtyMonth { get; set; }
        [DisplayName("Всего")]
        [DisplayFormat(DataFormatString = "{0:###,#.#}")]
        public decimal qty { get; set; }
        public int CategID { get; set; }


    }
}