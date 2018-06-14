using System;
using IAEGoogleDrie.Domain.Entities;

namespace IAEGoogleDrie.Settings
{
    public class Setting : Entity<Guid>
    {
//        [Required, ShortString]
        public string Category { get; set; }
//        [Required, ShortString]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}