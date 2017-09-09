using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateFinance.ViewModels;
using PrivateFinance.DataAccess.Account;
using PrivateFinance.ViewModels.Account;

namespace PrivateFinance.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ListResponse<AccountResponse>))]
        public async Task<IActionResult> GetAccountsListAsync(AccountFilter filter, ListOptions options,
            [FromServices] IAccountsListQuery query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AccountResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequest request,
            [FromServices] ICreateAccountCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleAccount", new {accountId = response.Id}, response);
        }

        [HttpGet("{accountId}", Name = "GetSingleAccount")]
        [ProducesResponseType(200, Type = typeof(AccountResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAccountAsync(int accountId, [FromServices] IAccountQuery query)
        {
            var response = await query.RunAsync(accountId);
            return response == null ? (IActionResult) NotFound() : Ok(response);
        }

        [HttpPut("{accountId}")]
        [ProducesResponseType(200, Type = typeof(AccountResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAccountAsync(int accountId, [FromBody] UpdateAccountRequest request,
            [FromServices] IUpdateAccountCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await command.ExecuteAsync(accountId, request);
            return response == null ? (IActionResult) NotFound($"Account with id {accountId} not found") : Ok(response);
        }
    }
}
