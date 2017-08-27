using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PrivateFinance.Entities
{
    public class User : DomainObject
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
