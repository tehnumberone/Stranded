﻿using System;
using System.Collections.Generic;
using Stranded.Models;

namespace Stranded.Context.Interfaces
{
    public interface IAccountContext
    {
        bool Create(Account acc);
        bool Update(int id);
        bool Delete(int id);
        Account GetByName(string username);
        bool Exists(string username);
    }
}