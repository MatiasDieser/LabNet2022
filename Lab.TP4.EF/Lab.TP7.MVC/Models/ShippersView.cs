using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.TP7.MVC.Models
{
    public class ShippersView
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }
    }
}