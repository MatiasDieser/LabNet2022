using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.TP8.WebAPI.Models
{
    public class EmployeesView
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(10)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El campo Firstname sólo permite letras")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El campo LastName sólo permite letras")]
        [Required]
        public string LastName { get; set; }

        [StringLength(35)]
        public string Title { get; set; }
    }
}