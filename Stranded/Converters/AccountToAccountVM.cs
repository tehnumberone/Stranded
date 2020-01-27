using System.Collections.Generic;
using Library.Models;
using Stranded.ViewModels;

namespace Stranded.Converters
{
    public class AccountToAccountVM
    {
        static public Account ToAccount(AccountViewModel avm)
        {
            var TempList = new List<Character>();
            foreach (var character in avm.Characters)
            {
                TempList.Add(CharacterToCharacterVM.ToCharacter(character));
            }
            var acc = new Account()
            {
                Username = avm.Username,
                Password = avm.Password,
                Email = avm.Email,
                Characters = TempList
            };

            return acc;
        }
        static public AccountViewModel ToAccVM(Account acc)
        {
            var TempList = new List<CharacterViewModel>();
            foreach (var character in acc.Characters)
            {
                TempList.Add(CharacterToCharacterVM.ToCharVM(character));
            }
            var avm = new AccountViewModel()
            {
                Username = acc.Username,
                Password = acc.Password,
                Email = acc.Email,
                Characters = TempList
            };
            return avm;
        }
    }
}
