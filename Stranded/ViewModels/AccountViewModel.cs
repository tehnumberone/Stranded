using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<CharacterViewModel> Characters { get; set; }
        public List<AccountViewModel> AllAccounts { get; set; }
    }
}
