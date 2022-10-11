using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.TP8.WebAPI.Models
{
    public class CustomersView
    {
        [StringLength(5)]
        [MinLength(5)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El campo Id sólo permite letras")]
        [Required]
        public string Id  { get; set; }

        [StringLength(30)]
        [Required]
        public string Company { get; set; }

        [StringLength(20)]
        public string ContactName { get; set; }
    }
}