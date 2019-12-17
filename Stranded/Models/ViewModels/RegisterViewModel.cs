using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
    }
}
