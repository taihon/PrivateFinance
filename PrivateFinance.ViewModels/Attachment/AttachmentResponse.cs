using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateFinance.ViewModels
{
    public class AttachmentResponse
    {
        public int Id { get; set; }
        public AttachmentType Type { get; set; }
        public DocumentResponse Document { get; set; }
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
