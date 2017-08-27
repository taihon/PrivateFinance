using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.ViewModels.Account
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
