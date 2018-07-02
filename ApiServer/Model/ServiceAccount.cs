using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Model
{
    public class ServiceAccount
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string KeyValue { get; set; }
        public virtual Guid DomainId { get; set; }
        public virtual Domain Domain { get; set; }
    }
}
