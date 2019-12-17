using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.Context.Interfaces;
using Stranded.Models.ViewModels;
using Stranded.Models;

namespace Stranded.Repositories
{
    public class AccountRepo
    {
        private readonly IAccountContext ctx;

        public AccountRepo(IAccountContext context)
        {
            this.ctx = context;
        }

        public bool Create(Account acc)
        {
            if (!Exists(acc.Username))
            {
                return ctx.Create(acc);
            }
            else return false;
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string username)
        {
            return ctx.Exists(username);
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public bool CheckAccount(string username, string password)
        {
            Account acc = ctx.GetByName(username);
            if (acc.Password == password)
            {
                return true;
            }
            else return false;
        }
        public Account GetByName(string username)
        {
            return ctx.GetByName(username);
        }
    }
}
