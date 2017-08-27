using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateFinance.Entities
{
    public class Category : DomainObject
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        public ICollection<CategoryOperation> Operations { get; set; }
    }
}