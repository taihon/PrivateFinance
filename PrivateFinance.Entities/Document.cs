using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.Entities
{
    public class Document : DomainObject
    {
        public DateTime Date { get; private set; }
        public ICollection<Operation> Operations { get; set; }
        public Place Place { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
