﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(45, ErrorMessage = "The category name can be maximum 45 characters long")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}