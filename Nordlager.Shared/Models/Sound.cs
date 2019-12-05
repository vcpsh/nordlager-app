using System;
using System.ComponentModel.DataAnnotations;

namespace Nordlager.Shared.Models
{
    public class Sound
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Audio content as bytestream
        /// </summary>
        public byte[] Audio { get; set; }

        public string Name { get; set; }

        public string SvgIcon { get; set; }
    }
}
