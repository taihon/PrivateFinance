using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PrivateFinance.DataAccess.Account;
using PrivateFinance.DB;
using PrivateFinance.ViewModels;

namespace PrivateFinance.DataAccess.DbImplementation.Account
{
    public class AccountQuery : IAccountQuery
    {
        private FinanceContext _context;
        private IMapper _mapper;

        public AccountQuery(FinanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountResponse> RunAsync(int id)
        {
            var response = await _context.Accounts.ProjectTo<AccountResponse>().FirstOrDefaultAsync(a => a.Id == id);
            return response;
        }
    }
}
