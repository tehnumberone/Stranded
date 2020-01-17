using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stranded.ViewModels;
using System.Collections.Generic;
using Stranded.Repositories;
using Stranded.Context.Interfaces;
using Stranded.Context.TestContext;
using Stranded.Converters;
using Library.Models;

namespace StrandedTest
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestLoadingGame()
        {
            //Arrange
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
            ICharacterContext _Icc = new TestCharacterContext();
            IItemContext _IIc = new TestItemContext();
            CharacterRepo _cr = new CharacterRepo(_Icc);
            ItemRepo _ir = new ItemRepo(_IIc);
            var mvm = new MapViewModel();
            var tempItemList = new List<ItemViewModel>();
            //Act

            mvm.character = CharacterToCharacterVM.ToCharVM(_cr.GetById(5));
            foreach (Item item in _ir.GetAllItems(0))
            {
                tempItemList.Add(ItemToItemVM.ToItemVM(item));
            }
            mvm.allitems = tempItemList;
            //Assert
            Assert.IsTrue(mvm.character != null && mvm.character.CharacterModel != "");
            Assert.IsTrue(mvm.allitems.Count > 0);
        }
        [TestMethod]
        public void TestDying()
        {
            //Arrange
            var character = new Character()
            {
                Hp = 10,
                Hunger = 10,
                Hydration = 10
            };
            //Act
            for (int i = 0; i < 20; i++)
            {
                if (character.Hydration > 0)
                {
                    character.Hydration--;
                }
                if (character.Hunger > 0)
                {
                    character.Hunger--;
                }
                if (character.Hunger == 0 && character.Hydration == 0 && character.Hp > 0) { character.Hp--; }
            }
            if (character.Hp == 0)
            {
                character.Hp = 10;
            }
            //Assert
            Assert.IsTrue(character.Hp == 10);
        }

    }
}
