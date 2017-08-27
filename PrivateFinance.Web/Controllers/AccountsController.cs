using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateFinance.ViewModels;

namespace PrivateFinance.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        public Task<IActionResult> GetAccountsListAsync(AccountFilter filter, ListOptions options,
            [FromServices] IAccountsListQuery)
        {
            
        }
    }
}
