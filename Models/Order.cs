using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class Order
    {
        public int Id { get; set; }

        //[StringLength(30,MinimumLength =3 , ErrorMessage ="Name should not be lower than 3 letters and more than 30 letters")]
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter your name!")]
        public string CustomerName { get; set; }

        [Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your phone number!")]
        public string CustomerPhone { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email!")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Please enter your address!")]
        public string CustomerAddress { get; set; }
        public IList<OrderDetails> Details { get; set; }
    }
}