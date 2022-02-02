using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class AgeCategorie
    {
        public int Id { get; set; } 

        public string Image { get; set; }

        [NotMapped]
        public  HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage =  "This field is required")]
        public string Name { get; set; }
        
    }
}