using System;
using System.Collections.Generic;
using PrivateFinance.Entities;

namespace PrivateFinance.ViewModels
{
    public class DocumentResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Operation> Operations { get; set; }
        public Place Place { get; set; }
        public ICollection<AttachmentResponse> Type { get; set; }
        public int AttachmentCount { get; set; }
    }
}
