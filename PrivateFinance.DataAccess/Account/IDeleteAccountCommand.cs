using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrivateFinance.DataAccess.Account
{
    public interface IDeleteAccountCommand
    {
        Task ExecuteAsync(int id);
    }
}
