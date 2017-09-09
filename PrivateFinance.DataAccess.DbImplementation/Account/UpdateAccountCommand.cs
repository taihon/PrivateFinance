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
using PrivateFinance.ViewModels.Account;

namespace PrivateFinance.DataAccess.DbImplementation.Account
{
    public class UpdateAccountCommand : IUpdateAccountCommand
    {
        private IMapper _mapper;
        private FinanceContext _context;

        public UpdateAccountCommand(FinanceContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<AccountResponse> ExecuteAsync(int id, UpdateAccountRequest request)
        {
            var foundAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (foundAccount != null)
            {
                var mapped = _mapper.Map<UpdateAccountRequest, Entities.Account>(request);
                mapped.Id = id;
                _context.Entry(foundAccount).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Entities.Account, AccountResponse>(foundAccount);
        }
    }
}
