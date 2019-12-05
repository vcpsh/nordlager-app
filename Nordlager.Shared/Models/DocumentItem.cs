using System;
using System.ComponentModel.DataAnnotations;

namespace Nordlager.Shared.Models
{
    public class DocumentItem
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ButtonUrl { get; set; }

        public string ButtonText { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }
    }
}
