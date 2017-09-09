﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PrivateFinance.ViewModels;

namespace PrivateFinance.DataAccess.DbImplementation.Account
{
    public class AccountMappings : Profile, IMappingProfile
    {
        public AccountMappings()
        {
            CreateMap<Entities.Account, AccountResponse>().ReverseMap();
        }
    }
}