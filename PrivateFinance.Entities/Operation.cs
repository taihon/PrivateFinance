using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata;

namespace PrivateFinance.Entities
{
    public class Operation:DomainObject
    {
        public Account From { get; set; }
        public Account To { get; set; }
        public DateTime Date { get; set; }
        public Document Document { get; set; }
        public decimal Sum { get; set; }
        public ICollection<CategoryOperation> Categories { get; set; }
        public Place Place { get; set; }
        public User Author { get; set; }
    }
}