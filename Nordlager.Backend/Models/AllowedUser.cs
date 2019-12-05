using System;
using System.ComponentModel.DataAnnotations;

namespace Nordlager.Backend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
