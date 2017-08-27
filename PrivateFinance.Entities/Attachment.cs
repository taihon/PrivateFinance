using System.ComponentModel.DataAnnotations;

namespace PrivateFinance.Entities
{
    public class Attachment : DomainObject
    {
        public AttachmentType Type { get; set; }
        [Required]
        public Document Document { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }
    }

    public enum AttachmentType
    {
        Picture, Sound
    }
}