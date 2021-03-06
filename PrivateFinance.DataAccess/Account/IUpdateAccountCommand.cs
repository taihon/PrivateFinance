﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrivateFinance.ViewModels;
using PrivateFinance.ViewModels.Account;

namespace PrivateFinance.DataAccess.Account
{
    public interface IUpdateAccountCommand
    {
        Task<AccountResponse> ExecuteAsync(int id, UpdateAccountRequest request);
    }
}