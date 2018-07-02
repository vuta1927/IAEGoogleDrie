using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Model
{
    public class Event
    {
        public int Id { get; set; }
        public virtual int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public DateTime Date { get; set; }
        public string Actor { get; set; }
        public virtual Domain Domain { get; set; }
    }
}
