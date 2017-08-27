using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.Entities
{
    public class CategoryOperation:DomainObject
    {
        public Category Category { get; set; }
        public Operation Operation { get; set; }
    }
}
