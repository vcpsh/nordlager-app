using System;
using System.ComponentModel.DataAnnotations;

namespace Nordlager.Shared.Models
{
    public class NewsItem
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }
    }
}
