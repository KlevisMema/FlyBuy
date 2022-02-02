using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "You need to give a  description")]
        [StringLength(1000,ErrorMessage ="You cant give a description more than 100 letters")]
        public string Description  { get; set; }

        [Required(ErrorMessage = "You need  to give a rating")]
        [Range(1,5 , ErrorMessage ="You cant give a rating more  than 5 or lower that 0")]
        public int Rate { get; set; }

        [StringLength(30, ErrorMessage = "We cant accept names longer than 30 letters")]
        public string Name { get; set; } = "Anonnymous";

        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; } = DateTime.Now;

    }
}