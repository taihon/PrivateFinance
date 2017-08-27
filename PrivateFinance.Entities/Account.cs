using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateFinance.Entities
{
    public class Account : DomainObject
    {
        [Required]
        public AccountType AccountType { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}