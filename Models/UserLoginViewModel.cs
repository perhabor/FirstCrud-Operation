using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Models
{
    public class UserLoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(6)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
