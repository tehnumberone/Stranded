using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stranded.ViewModels;
using System.Collections.Generic;
using Stranded.Repositories;
using Stranded.Context.Interfaces;
using Stranded.Context.TestContext;
using Library.Models;

namespace StrandedTest
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void TestCharacterModelLoading()
        {
            //Arrange
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
            ICharacterContext _Icc = new TestCharacterContext();
            CharacterRepo _cr = new CharacterRepo(_Icc);
            //Act
            ccvm.CharModels = _cr.GetAllCharModels();
            //Assert
            Assert.IsTrue(ccvm.CharModels.Count == 3);
        }
    }
}
