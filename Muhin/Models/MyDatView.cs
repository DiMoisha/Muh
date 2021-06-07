using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muh.Models
{
    public class MyDatView
    {
        //[System.ComponentModel.DataAnnotations.Display(Name = "Дата выполнения")]
        //[DataType(DataType.Date)]
        //[UIHint("Date")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime BDat { get; set; }

        [Display(Name = "Дата начала")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public string CBDat { get; set; }

        [Display(Name = "Дата окончания")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public string CEDat { get; set; }

    }
}