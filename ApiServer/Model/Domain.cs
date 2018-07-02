﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAEGoogleDrie.Security;

namespace ApiServer.Model
{
    public class Domain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<ServiceAccount> ServiceAccounts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
