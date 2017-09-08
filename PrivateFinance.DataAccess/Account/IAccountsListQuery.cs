using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFinance.ViewModels;

namespace PrivateFinance.DataAccess.Account
{
    public interface IAccountsListQuery
    {
        Task<ListResponse<AccountResponse>> RunAsync(AccountFilter filter, ListOptions options);
    }
}
