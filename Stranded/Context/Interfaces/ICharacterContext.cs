﻿using System.Collections.Generic;
using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface ICharacterContext
    {
        bool Create(Character c, Account acc);
        bool Update(Character c);
        void Delete(int id);
        Character GetById(int id);
        List<Character> GetAll(Account acc);
        List<string> GetAllCharModels();

    }
}
