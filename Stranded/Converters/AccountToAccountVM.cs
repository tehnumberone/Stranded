using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Stranded.ViewModels;

namespace Stranded.Converters
{
    public class AccountToAccountVM
    {
        public Account ToAccount(AccountViewModel avm)
        {
            var acc = new Account()
            {
                Username = avm.Username,
                Password = avm.Password,
                Email = avm.Email
            };
            return acc;
        }
        public AccountViewModel ToAccVM(Account acc)
        {
            var avm = new AccountViewModel()
            {
                Username = acc.Username,
                Password = acc.Password,
                Email = acc.Email
            };
            return avm;
        }
    }
}
