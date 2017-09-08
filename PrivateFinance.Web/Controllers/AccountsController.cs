using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateFinance.ViewModels;
using PrivateFinance.DataAccess.Account;

namespace PrivateFinance.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(ListResponse<AccountResponse>))]
        public async Task<IActionResult> GetAccountsListAsync(AccountFilter filter, ListOptions options,
            [FromServices] IAccountsListQuery query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }
    }
}
