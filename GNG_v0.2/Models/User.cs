using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public class User
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage ="You must enter a valid username.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a valid email address.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a valid password.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Your password should be in the range of 8 to 20 characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
