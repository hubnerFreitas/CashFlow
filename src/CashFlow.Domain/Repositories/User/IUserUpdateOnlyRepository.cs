﻿using CashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Repositories.User
{
    public  interface IUserUpdateOnlyRepository
    {
        void Update(Users user);
    }
}
