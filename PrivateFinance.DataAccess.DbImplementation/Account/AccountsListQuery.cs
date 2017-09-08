using PrivateFinance.DataAccess.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrivateFinance.ViewModels;
using PrivateFinance.DB;

namespace PrivateFinance.DataAccess.DbImplementation.Account
{
    public class AccountsListQuery: IAccountsListQuery
    {
        private FinanceContext _context;

        public AccountsListQuery(FinanceContext context)
        {
            _context = context;
        }
        public async Task<ListResponse<AccountResponse>> RunAsync(AccountFilter filter, ListOptions options)
        {
            IQueryable<AccountResponse> query = _context.Accounts.Select(t=> new AccountResponse
            {
                Balance = t.Balance,
                Name = t.Name,
                Id = t.Id
            });
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<AccountResponse>
            {
                TotalItemsCount = totalCount,
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id"
            };
        }

        private IQueryable<AccountResponse> ApplyFilter(IQueryable<AccountResponse> query, AccountFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(t => t.Id == filter.Id);
            if (filter.Name != null)
                query = query.Where(t => t.Name.Contains(filter.Name));
            if (filter.Balance != null)
            {
                if (filter.Balance.From != null)
                    query = query.Where(t => t.Balance >= filter.Balance.From);
                if (filter.Balance.To != null)
                    query = query.Where(t => t.Balance <= filter.Balance.To);
            }
            return query;
        }
    }
}
