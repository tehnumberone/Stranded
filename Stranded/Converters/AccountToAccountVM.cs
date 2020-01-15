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
        CharacterToCharacterVM characterConverter = new CharacterToCharacterVM();
        public Account ToAccount(AccountViewModel avm)
        {
            var TempList = new List<Character>();
            foreach (var character in avm.Characters)
            {
                TempList.Add(characterConverter.ToCharacter(character));
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
        public AccountViewModel ToAccVM(Account acc)
        {
            var TempList = new List<CharacterViewModel>();
            foreach (var character in acc.Characters)
            {
                TempList.Add(characterConverter.ToCharVM(character));
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
