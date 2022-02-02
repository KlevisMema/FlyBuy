using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(45, ErrorMessage = "The maximum length must be upto 45 characters only")]
        [Display(Name = " Product ")]
        public string Name { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Has to be decimal with two decimal points")]
        [Range(0, 2000, ErrorMessage = "The maximum possible value should be upto 5 digits")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price Field is required")]
        [Display(Name = " Price ")]
        public Decimal Price { get; set; }

        [MaxLength(80, ErrorMessage = "The maximum length must be upto 80 characters only")]
        [Display(Name = " Description ")]
        public string Description { get; set; }

        [Display(Name = "Updated At")]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "This  field is required")]
        public string AgeCategory { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Display(Name = " Rating ")]
        public decimal Rating { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}