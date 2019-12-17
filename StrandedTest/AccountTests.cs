using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stranded.Models.ViewModels;
using System.Collections.Generic;
using Stranded.Repositories;
using Stranded.Context.Interfaces;
using Stranded.Context.TestContext;
using Stranded.Models;

namespace StrandedTest
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void TestLogin()
        {
            //Arrange
            LoginViewModel lvm = new LoginViewModel()
            {
                Username = "Bob",
                Password = "Bob2"
            };
            bool loggedin = false;

            IAccountContext _Iac = new TestAccountContext();
            AccountRepo _ar = new AccountRepo(_Iac);

            //Act
            if (lvm.Username != "" && lvm.Password != "")
            {
                if (_ar.CheckAccount(lvm.Username, lvm.Password))
                {
                    loggedin = true;
                }

            }
            //Assert
            Assert.IsTrue(loggedin);
        }
        [TestMethod]
        public void TestRegister()
        {
            //Arrange
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Username = "Bob",
                Password = "Bob2",
                Email = "420@bob.nl"
            };
            bool accountiscreated = false;
            Account acc = new Account(rvm.Username, rvm.Password, rvm.Email);

            IAccountContext _Iac = new TestAccountContext();
            AccountRepo _ar = new AccountRepo(_Iac);
            //Act
            if (rvm.Username != null && rvm.Password != null && rvm.Email != null)
            {
                _ar.Create(acc);
                accountiscreated = true;
            }
            //Assert
            Assert.IsTrue(accountiscreated);
        }
    }
}
