using System.Collections.Generic;

namespace PrivateFinance.Entities
{
    public class Place : DomainObject
    {
        public string Name { get; set; }
        public ICollection<CategoryOperation> Operations { get; set; }
    }
}