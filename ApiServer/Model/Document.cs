using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Model
{
    public class Document
    {
        public Guid Id { get; set; }
        public string DocId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual Guid FolderId { get; set; }
        public virtual Folder Folder { get; set; }
    }
}
