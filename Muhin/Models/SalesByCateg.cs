using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Muh
{
    [Table("bSalesByCateg")]
    public class SalesByCateg
    {
        [Key]
        public int ID { get; set; }
        public int saleId { get; set; }
        [Display(Name = "Продукция")]
        public string txt { get; set; }
        [Display(Name = "Продукция")]
        public string categ { get; set; }
        [DisplayName("Кол-во")]
        [DisplayFormat(DataFormatString = "{0:###,#.#}")]
        public decimal kol { get; set; }
        public DateTime Dat { get; set; }
        public int CategID { get; set; }
    }
}