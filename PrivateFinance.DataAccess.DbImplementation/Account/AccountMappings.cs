using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PrivateFinance.ViewModels;
using PrivateFinance.ViewModels.Account;

namespace PrivateFinance.DataAccess.DbImplementation.Account
{
    public class AccountMappings : Profile, IMappingProfile
    {
        public AccountMappings()
        {
            CreateMap<Entities.Account, AccountResponse>()
                .ForMember(dest => dest.AccountType, src => src.MapFrom(o => (AccountType) (int) o.AccountType)).ReverseMap();
            CreateMap<CreateAccountRequest, Entities.Account>().ReverseMap();
            CreateMap<UpdateAccountRequest, Entities.Account>().ReverseMap();
        }
    }
}
