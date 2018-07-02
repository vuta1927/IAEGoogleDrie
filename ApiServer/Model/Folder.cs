using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Model
{
    public class Folder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public virtual int FolderTypeId { get; set; }
        public virtual FolderType FolderType { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
