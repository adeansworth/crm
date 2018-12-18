using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Entities
{
    public class DocumentStatus : IDocumentStatus
    {
        public DateTime? Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? Archived { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
