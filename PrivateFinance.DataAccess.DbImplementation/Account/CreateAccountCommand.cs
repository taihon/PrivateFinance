using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrivateFinance.DataAccess.Account;
using PrivateFinance.DB;
using PrivateFinance.ViewModels;
using PrivateFinance.ViewModels.Account;

namespace PrivateFinance.DataAccess.DbImplementation.Account
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private IMapper _mapper;
        private FinanceContext _context;

        public CreateAccountCommand(FinanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            var account = _mapper.Map<CreateAccountRequest, Entities.Account>(request);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Account, AccountResponse>(account);
        }
    }
}
