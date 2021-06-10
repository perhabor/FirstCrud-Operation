using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(5)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MinLength(6)]
        [Display(Name = "LastName")]
       
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(6)]
        [Display(Name = "Email")]

        public string Email { get; set; }

      
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(6)]
        [Display(Name = "Gender")]

        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(6)]
        [Display(Name = "Address")]

        public string Address { get; set; }
    }
}
