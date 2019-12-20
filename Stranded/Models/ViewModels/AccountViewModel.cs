using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; }
        public List<Account> AllAccounts { get; set; }
    }
}
