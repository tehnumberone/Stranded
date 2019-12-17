using Stranded.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.Models.ViewModels;
using Stranded.Models;

namespace Stranded.Context.TestContext
{
    public class TestAccountContext : IAccountContext
    {
        public List<Account> accountList = new List<Account>();
        public TestAccountContext()
        {
            Account testAccount = new Account
            {
                Username = "Bob",
                Password = "Bob2",
                Email = "420@bob.nl"
            };
            accountList.Add(testAccount);
        }
        public bool Exists(string username)
        {
            foreach (Account account in accountList)
            {
                if (username != account.Username)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Create(Account acc)
        {
            List<Account> acclist = new List<Account>();
            try
            {
                acclist.Add(acc);
                return true;
            }
            catch (Exception exc)
            {
                Console.Write(exc);
                return false;
            }


        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetByName(string username)
        {
            Account acc = new Account();
            foreach (Account account in accountList)
            {
                if (username == account.Username)
                {
                    acc.Id = account.Id;
                    acc.Username = account.Username;
                    acc.Password = account.Password;
                    acc.Email = account.Email;
                }
            }
            return acc;
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
