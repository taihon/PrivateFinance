using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrivateFinance.ViewModels;

namespace PrivateFinance.DataAccess.Account
{
    public interface IAccountQuery
    {
        Task<AccountResponse> RunAsync(int id);
    }
}
