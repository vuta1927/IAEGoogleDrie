﻿using System;
using IAEGoogleDrie.Domain.Entities;

namespace IAEGoogleDrie.IdentityServer4
{
    public class PersistedGrantEntity : Entity<string>
    {
        public virtual string Type { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual DateTime? Expiration { get; set; }

        public virtual string Data { get; set; }
    }
}