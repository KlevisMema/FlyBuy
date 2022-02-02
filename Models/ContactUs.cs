using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [Required(ErrorMessage =  "Your name is required")]
        public string Name { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Your email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "You cant  send a message more that 100  letters")]
        [Required(ErrorMessage = "Your message is required")]
        public string Message { get; set; }
    }
}