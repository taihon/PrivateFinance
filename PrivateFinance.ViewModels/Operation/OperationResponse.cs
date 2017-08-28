using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.ViewModels
{
    public class OperationResponse
    {
        public int Id { get; set; }
        public AccountResponse From { get; set; }
        public AccountResponse To { get; set; }
        public DateTime Date { get; set; }
        public DocumentResponse Document { get; set; }
        public decimal Sum { get; set; }
        public CategoryResponse Category { get; set; }
        public PlaceResponse Place { get; set; }
        public UserResponse Author { get; set; }
    }
}
