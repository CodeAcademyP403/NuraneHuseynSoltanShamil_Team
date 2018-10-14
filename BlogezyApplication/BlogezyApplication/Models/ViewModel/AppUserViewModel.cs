using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models.ViewModel
{
    public class AppUserViewModel
    {
        [Required]
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }


        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
