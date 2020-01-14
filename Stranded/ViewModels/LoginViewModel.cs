using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Invalid username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Invalid password")]
        public string Password { get; set; }
    }
}
