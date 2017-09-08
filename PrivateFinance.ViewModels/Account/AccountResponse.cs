using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.ViewModels
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
    public enum AccountType
    {
        Savings, Regular
    }
}
