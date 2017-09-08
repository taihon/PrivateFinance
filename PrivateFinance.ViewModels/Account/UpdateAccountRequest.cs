using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrivateFinance.ViewModels.Account
{
    public class UpdateAccountRequest
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
    }
}
