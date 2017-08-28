using System;
using System.Collections.Generic;
using System.Text;
using PrivateFinance.Entities;

namespace PrivateFinance.ViewModels
{
    public class CategoryResponse
    {
        public string Name { get; set; }
        public ICollection<CategoryOperation> Operations { get; set; }
        public int Id { get; set; }
    }
}
