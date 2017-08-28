using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.ViewModels
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OperationResponse> Operations { get; set; }
    }
}
